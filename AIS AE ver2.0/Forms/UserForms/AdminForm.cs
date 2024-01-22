using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AIS_AE_ver2._0
{
    public partial class AdminForm : Form
    {
        string connectionString;
        int selectedStudentId;
        int SubjectComboBoxSelectedId;
        int lastGradeID;
        int lastJournalID;
        Bitmap bitmap;
        int teacherId = 1;
        int selectedTeacherId;
        private int selectedGroupId;
        public AdminForm(string str)
        {
            InitializeComponent();
            connectionString = str;
            // комбобокс з вчителями
            FillTeachersComboBox();
            FillStudentsComboBox();
            FillClassesComboBox();
            FillAddTeachersComboBox();
            FillAddStudentsComboBox();
            LoadUsersData();
        }
        private bool CheckIfGradesExist(int studentId, int teacherId)
        {
            string query = "SELECT COUNT(*) FROM Grades " +
                           "JOIN ElectronicJournal ON Grades.GradeID = ElectronicJournal.GradeID " +
                           "WHERE Grades.StudentID = @StudentID AND ElectronicJournal.TeacherID = @TeacherID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@TeacherID", teacherId);
                    connection.Open();

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        public void GetLastGradeAndJournalID()
        {
            lastGradeID = GetLastGradeID();
            lastJournalID = GetLastJournalID();
        }
        private int GetLastGradeID()
        {
            string query = "SELECT TOP 1 GradeID FROM Grades ORDER BY GradeID DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            return -1; // Return -1 if no GradeID is found
        }
        private int GetLastJournalID()
        {
            string query = "SELECT TOP 1 JournalID FROM ElectronicJournal ORDER BY JournalID DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            return -1; // Return -1 if no JournalID is found
        }
        private void AddGradeToDatabase(int studentId, int teacherId)
        {
            // Отримати значення з елементів інтерфейсу
            int selectedSubjectId = ((SubjectItem)TeacherSubjectComboBox.SelectedItem).SubjectId;
            string userInputGrade = TeacherUserInputTextBox.Text;

            // Перевірити, чи коректно введено бал
            if (!int.TryParse(userInputGrade, out int grade) || grade < 0 || grade > 100)
            {
                MessageBox.Show("Бал повинен бути числовим значенням в межах від 0 до 100.");
                return;
            }

            // Отримати сьогоднішню дату
            DateTime dateRecorded = DateTime.Today;

            // Викликати метод для запису в базу даних
            InsertGradeIntoDatabase(studentId, teacherId, selectedSubjectId, grade, dateRecorded);

            // Оновити таблицю
            GridFill(studentId, teacherId);
        }
        private void InsertGradeIntoDatabase(int studentId, int teacherId, int subjectId, int grade, DateTime dateRecorded)
        {
            GetLastGradeAndJournalID();
            string insertGradeQuery = "INSERT INTO Grades (GradeID, StudentID, SubjectID, Grade) VALUES (@GradeID, @StudentID, @SubjectID, @Grade); ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand insertGradeCommand = new SqlCommand(insertGradeQuery, connection, transaction))
                        {
                            insertGradeCommand.Parameters.AddWithValue("@GradeID", lastGradeID + 1);
                            insertGradeCommand.Parameters.AddWithValue("@StudentID", studentId);
                            insertGradeCommand.Parameters.AddWithValue("@SubjectID", subjectId);
                            insertGradeCommand.Parameters.AddWithValue("@Grade", grade);

                            insertGradeCommand.ExecuteNonQuery();
                        }

                        string insertJournalQuery = "INSERT INTO ElectronicJournal (JournalID, TeacherID, GradeID, DateRecorded) VALUES (@JournalID, @TeacherID, @GradeID, @DateRecorded);";
                        using (SqlCommand insertJournalCommand = new SqlCommand(insertJournalQuery, connection, transaction))
                        {
                            insertJournalCommand.Parameters.AddWithValue("@JournalID", lastJournalID + 1);
                            insertJournalCommand.Parameters.AddWithValue("@TeacherID", teacherId);
                            insertJournalCommand.Parameters.AddWithValue("@GradeID", lastGradeID + 1);
                            insertJournalCommand.Parameters.AddWithValue("@DateRecorded", dateRecorded);

                            insertJournalCommand.ExecuteNonQuery();
                        }

                        // Завершення транзакції
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Помилка транзакції, виведення інформації та відкат транзакції
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }
        private void DeleteLastRecord()
        {
            GetLastGradeAndJournalID();
            if (lastGradeID == -1 || lastJournalID == -1 || lastGradeID == 0 || lastJournalID == 0)
            {
                MessageBox.Show("Не вдалося знайти останній запис для видалення.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Створюємо транзакцію
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Видалення останнього запису з ElectronicJournal
                    string deleteJournalQuery = "DELETE FROM ElectronicJournal WHERE JournalID = @JournalID";
                    using (SqlCommand command = new SqlCommand(deleteJournalQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@JournalID", lastJournalID);
                        command.ExecuteNonQuery();
                    }

                    // Видалення останнього запису з Grades
                    string deleteGradeQuery = "DELETE FROM Grades WHERE GradeID = @GradeID";
                    using (SqlCommand command = new SqlCommand(deleteGradeQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@GradeID", lastGradeID);
                        command.ExecuteNonQuery();
                    }

                    // Завершуємо транзакцію
                    transaction.Commit();

                    MessageBox.Show("Останній запис видалено успішно.");
                }
                catch (Exception ex)
                {
                    // У разі помилки відкот транзакції
                    transaction.Rollback();
                    MessageBox.Show("Виникла помилка під час видалення: " + ex.Message);
                }
            }
        }
        private void GridFill(int studentId, int teacherId)
        {
            TeacherJournalGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                            "Subjects.SubjectName,\r\n    " +
                            "COALESCE(Teachers.FirstName + ' ' + Teachers.LastName, 'Немає вчителя') AS TeacherName,\r\n    " +
                            "COALESCE(Grades.Grade, 'Немає оцінки') AS Grade,\r\n    " +
                            "COALESCE(CAST(ElectronicJournal.DateRecorded AS NVARCHAR), 'Немає дати') AS DateRecorded\r\n" +
                            "FROM ElectronicJournal\r\nJOIN Grades ON ElectronicJournal.GradeID = Grades.GradeID\r\n" +
                            "JOIN Students ON Grades.StudentID = Students.StudentID\r\n" +
                            "JOIN Subjects ON Grades.SubjectID = Subjects.SubjectID\r\n" +
                            "JOIN Teachers ON ElectronicJournal.TeacherID = Teachers.TeacherID\r\n" +
                            "WHERE Students.StudentID = @StudentID AND Teachers.TeacherID = @TeacherID\r\n" +
                            "ORDER BY ElectronicJournal.DateRecorded;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@TeacherID", teacherId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string grade = reader["Grade"].ToString();
                            string dateRecorded = reader["DateRecorded"].ToString();

                            TeacherJournalGridView.Rows.Add(subjectName, grade, dateRecorded);
                        }
                    }
                }
            }
        }
        private void FillSubjectsComboBox(int teacherId)
        {
            TeacherSubjectComboBox.Items.Clear(); // Очистіть попередні елементи

            string query = "SELECT SubjectID, SubjectName FROM Subjects WHERE TeacherID = @TeacherID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherID", teacherId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int subjectId = reader.GetInt32(reader.GetOrdinal("SubjectID"));
                            string subjectName = reader["SubjectName"].ToString();

                            TeacherSubjectComboBox.Items.Add(new SubjectItem(subjectId, subjectName));
                        }
                    }
                }
            }

            TeacherSubjectComboBox.DisplayMember = "SubjectName"; // Вказує, що відображати
            TeacherSubjectComboBox.ValueMember = "SubjectId"; // Вказує, яке значення використовувати
        }
        private void FillStudentsComboBox()
        {
            string query = "SELECT StudentID, FirstName, LastName FROM Students;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();

                            TeacherStudentComboBox.Items.Add(new StudentItem(studentId, firstName + " " + lastName));
                        }
                    }
                }
            }

            TeacherStudentComboBox.DisplayMember = "StudentName"; // Вказує, що відображати
            TeacherStudentComboBox.ValueMember = "StudentId"; // Вказує, яке значення використовувати
        }
        private void TeacherSchedule(int teacherId)
        {
            TeacherMondaySchedule(teacherId);
            TeacherTuesdaySchedule(teacherId);
            TeacherWednesdaySchedule(teacherId);
            TeacherThursdaySchedule(teacherId);
            TeacherFridaySchedule(teacherId);
        }
        private void TeacherMondaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            AdminMondayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Classes.ClassName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Classes ON Schedule.ClassID = Classes.ClassID\r\n" +
                           "WHERE Schedule.TeacherID = @TeacherId AND Schedule.DayOfWeek = N'Понеділок'\r\n" +
                           "ORDER BY Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string className = reader["ClassName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            AdminMondayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherTuesdaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            AdminTuesdayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Classes.ClassName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Classes ON Schedule.ClassID = Classes.ClassID\r\n" +
                           "WHERE Schedule.TeacherID = @TeacherId AND Schedule.DayOfWeek = N'Вівторок'\r\n" +
                           "ORDER BY Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string className = reader["ClassName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            AdminTuesdayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherWednesdaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            AdminWednesdayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Classes.ClassName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Classes ON Schedule.ClassID = Classes.ClassID\r\n" +
                           "WHERE Schedule.TeacherID = @TeacherId AND Schedule.DayOfWeek = N'Середа'\r\n" +
                           "ORDER BY Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string className = reader["ClassName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            AdminWednesdayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherThursdaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            AdminThursdayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Classes.ClassName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Classes ON Schedule.ClassID = Classes.ClassID\r\n" +
                           "WHERE Schedule.TeacherID = @TeacherId AND Schedule.DayOfWeek = N'Четвер'\r\n" +
                           "ORDER BY Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string className = reader["ClassName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            AdminThursdayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherFridaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            AdminFridayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Classes.ClassName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Classes ON Schedule.ClassID = Classes.ClassID\r\n" +
                           "WHERE Schedule.TeacherID = @TeacherId AND Schedule.DayOfWeek = N'П’ятниця'\r\n" +
                           "ORDER BY Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string className = reader["ClassName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            AdminFridayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherBackButton_Click(object sender, EventArgs e)
        {
            AutherisationForm autherisationform = new AutherisationForm();
            autherisationform.Show();
            this.Close();
        }
        private void TeacherExitButton_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Ви точно хочете вийти?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void FillTeachersComboBox()
        {
            string query = "SELECT TeacherID, FirstName, LastName FROM Teachers;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int teacherId = reader.GetInt32(reader.GetOrdinal("TeacherID"));
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();

                            AdminChoseTeacherComboBox.Items.Add(new TeacherItem(teacherId, $"{firstName} {lastName}"));
                        }
                    }
                }
            }

            AdminChoseTeacherComboBox.DisplayMember = "TeacherName";
            AdminChoseTeacherComboBox.ValueMember = "TeacherId";
        }
        private void TeacherStudentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeacherStudentComboBox.SelectedItem != null)
            {
                StudentItem selectedStudent = (StudentItem)TeacherStudentComboBox.SelectedItem;
                // Тут можна працювати з вибраним ID студента
                selectedStudentId = selectedStudent.StudentId;
                //вивід оцінок
                GridFill(selectedStudentId, teacherId);
            }
        }
        private void AdminChoseTeacherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AdminChoseTeacherComboBox.SelectedItem != null)
            {
                TeacherItem selectedTeacher = (TeacherItem)AdminChoseTeacherComboBox.SelectedItem;
                selectedTeacherId = selectedTeacher.TeacherId;
                //MessageBox.Show(selectedTeacherId.ToString());
                TeacherSchedule(selectedTeacherId);
                FillSubjectsComboBox(selectedTeacherId);
                GridFill(selectedStudentId, selectedTeacherId);
            }
        }
        private void TeacherSubjectComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (TeacherSubjectComboBox.SelectedItem != null)
            {
                SubjectItem selectedSubject = (SubjectItem)TeacherSubjectComboBox.SelectedItem;
                SubjectComboBoxSelectedId = selectedSubject.SubjectId;
            }
        }
        private void TeacherAddButton_Click_1(object sender, EventArgs e)
        {
            // Отримати значення із ComboBox
            if (TeacherSubjectComboBox.SelectedItem == null)
            {
                MessageBox.Show("Виберіть предмет.");
                return;
            }

            // Додати бал в базу даних та оновити таблицю
            AddGradeToDatabase(selectedStudentId, teacherId);
        }
        private void TeacherDeleteButton_Click_1(object sender, EventArgs e)
        {
            if (!CheckIfGradesExist(selectedStudentId, teacherId))
            {
                MessageBox.Show("У студента нема оцінок на предметах, які ведете ви.");
                return;
            }

            DeleteLastRecord();
            GridFill(selectedStudentId, teacherId);
        }
        private void TeacherPrintButton_Click_1(object sender, EventArgs e)
        {
            int height = TeacherJournalGridView.Height;
            TeacherJournalGridView.Height = TeacherJournalGridView.RowCount * TeacherJournalGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(TeacherJournalGridView.Width, TeacherJournalGridView.Height);
            TeacherJournalGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, TeacherJournalGridView.Width, TeacherJournalGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            TeacherJournalGridView.Height = height;
        }
        private void TeacherSaveButton_Click_1(object sender, EventArgs e)
        {
            // Создание приложения Excel
            Excel.Application app = new Excel.Application();
            Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Excel._Worksheet worksheet = null;

            app.Visible = true;

            // Установка активного листа
            worksheet = workbook.Sheets["Аркуш1"];
            if (worksheet == null)
            {
                worksheet = workbook.Sheets.Add();
                worksheet.Name = "Аркуш1";
            }
            worksheet = workbook.ActiveSheet;

            // Название рабочего листа
            worksheet.Name = "Exported from gridview";

            // Заполнение шапки
            for (int i = 1; i < TeacherJournalGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = TeacherJournalGridView.Columns[i - 1].HeaderText;
            }

            // Заполнение ячеек данными
            for (int i = 0; i < TeacherJournalGridView.Rows.Count; i++)
            {
                for (int j = 0; j < TeacherJournalGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = TeacherJournalGridView.Rows[i].Cells[j].Value.ToString();
                }
            }

            // Авторазмер колонок
            worksheet.Columns.AutoFit();
        }
        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        private void FillClassesComboBox()
        {
            string query = "SELECT ClassID, ClassName FROM Classes;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int classId = reader.GetInt32(reader.GetOrdinal("ClassID"));
                            string className = reader["ClassName"].ToString();

                            GroupComboBox.Items.Add(new ClassItem(classId, className));
                        }
                    }
                }
            }

            GroupComboBox.DisplayMember = "ClassName"; // Вказує, що відображати
            GroupComboBox.ValueMember = "ClassId"; // Вказує, яке значення використовувати
        }
        private void MondayGrid(int id)
        {
            // Очистити таблицю перед додаванням нових значень
            MondayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Teachers.FirstName + ' ' + Teachers.LastName AS TeacherName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Teachers ON Schedule.TeacherID = Teachers.TeacherID\r\n" +
                           "WHERE Schedule.ClassID = @id AND Schedule.DayOfWeek = N'Понеділок' \r\n" +
                           "ORDER BY \r\n    " +
                           "Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string teacherName = reader["TeacherName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            MondayDataGridView.Rows.Add(subjectName, teacherName, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TuesdayGrid(int id)
        {
            // Очистити таблицю перед додаванням нових значень
            TuesdayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Teachers.FirstName + ' ' + Teachers.LastName AS TeacherName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Teachers ON Schedule.TeacherID = Teachers.TeacherID\r\n" +
                           "WHERE Schedule.ClassID = @id AND Schedule.DayOfWeek = N'Вівторок' \r\n" +
                           "ORDER BY \r\n    " +
                           "Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string teacherName = reader["TeacherName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            TuesdayDataGridView.Rows.Add(subjectName, teacherName, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void WednesdayGrid(int id)
        {
            // Очистити таблицю перед додаванням нових значень
            WednesdayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Teachers.FirstName + ' ' + Teachers.LastName AS TeacherName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Teachers ON Schedule.TeacherID = Teachers.TeacherID\r\n" +
                           "WHERE Schedule.ClassID = @id AND Schedule.DayOfWeek = N'Середа' \r\n" +
                           "ORDER BY \r\n    " +
                           "Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string teacherName = reader["TeacherName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            WednesdayDataGridView.Rows.Add(subjectName, teacherName, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void ThursdayGrid(int id)
        {
            // Очистити таблицю перед додаванням нових значень
            ThursdayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Teachers.FirstName + ' ' + Teachers.LastName AS TeacherName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Teachers ON Schedule.TeacherID = Teachers.TeacherID\r\n" +
                           "WHERE Schedule.ClassID = @id AND Schedule.DayOfWeek = N'Четвер' \r\n" +
                           "ORDER BY \r\n    " +
                           "Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string teacherName = reader["TeacherName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            ThursdayDataGridView.Rows.Add(subjectName, teacherName, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void FridayGrid(int id)
        {
            // Очистити таблицю перед додаванням нових значень
            FridayDataGridView.Rows.Clear();
            string query = "SELECT \r\n    " +
                           "Subjects.SubjectName,\r\n    " +
                           "Teachers.FirstName + ' ' + Teachers.LastName AS TeacherName,\r\n    " +
                           "Schedule.StartTime,\r\n    " +
                           "Schedule.EndTime\r\n" +
                           "FROM Schedule\r\n" +
                           "JOIN Subjects ON Schedule.SubjectID = Subjects.SubjectID\r\n" +
                           "JOIN Teachers ON Schedule.TeacherID = Teachers.TeacherID\r\n" +
                           "WHERE Schedule.ClassID = @id AND Schedule.DayOfWeek = N'П’ятниця' \r\n" +
                           "ORDER BY \r\n    " +
                           "Schedule.StartTime; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string teacherName = reader["TeacherName"].ToString();
                            string startTime = reader["StartTime"].ToString();
                            string endTime = reader["EndTime"].ToString();

                            FridayDataGridView.Rows.Add(subjectName, teacherName, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GroupComboBox.SelectedItem != null)
            {
                ClassItem selectedClass = (ClassItem)GroupComboBox.SelectedItem;
                selectedGroupId = selectedClass.ClassId;
                MondayGrid(selectedGroupId);
                TuesdayGrid(selectedGroupId);
                WednesdayGrid(selectedGroupId);
                ThursdayGrid(selectedGroupId);
                FridayGrid(selectedGroupId);
            }
        }
        private int GetLastUserId()
        {
            string query = "SELECT TOP 1 UserID FROM Users ORDER BY UserID DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            return -1; // Повернути -1, якщо UserID не знайдено
        }
        private void FillAddTeachersComboBox()
        {
            string query = "SELECT TeacherID, FirstName, LastName FROM Teachers;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int teacherId = reader.GetInt32(reader.GetOrdinal("TeacherID"));
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();

                            AdminAddTeacherComboBox.Items.Add(new TeacherItem(teacherId, $"{firstName} {lastName}"));
                        }
                    }
                }
            }

            AdminAddTeacherComboBox.DisplayMember = "TeacherName";
            AdminAddTeacherComboBox.ValueMember = "TeacherId";
        }
        private void AdminAddAdminButton_Click(object sender, EventArgs e)
        {
            string login = AdminAddAdminLogin.Text;
            string password = AdminAddAdminPassword.Text;
            int newId = GetLastUserId() + 1;

            // Запит для додавання нового адміністратора
            string query = "INSERT INTO Users (UserID, Username, Pasword, Role, StudentID, TeacherID) VALUES (@UserID, @Login, @Password, @Role, NULL, NULL)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Параметризований запит для безпеки
                    command.Parameters.AddWithValue("@UserID", newId);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", "admin");

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Адміністратор доданий успішно.");
            LoadUsersData();
        }
        private void AdminAddTeacherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AdminAddTeacherComboBox.SelectedItem != null)
            {
                TeacherItem selectedTeacher = (TeacherItem)AdminAddTeacherComboBox.SelectedItem;
                selectedTeacherId = selectedTeacher.TeacherId;
                //MessageBox.Show(selectedTeacherId.ToString());
            }
        }
        private void AdminAddTeacherButton_Click(object sender, EventArgs e)
        {
            string login = AdminAddTeacherLoginTextBox.Text;
            string password = AdminAddTeacherPasswordTextBox.Text;
            int newId = GetLastUserId() + 1;

            // Запит для додавання нового викладача
            string query = "INSERT INTO Users  (UserID, Username, Pasword, Role, StudentID, TeacherID) VALUES (@UserID, @Login, @Password, @Role, NULL, @TeacherID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Параметризований запит для безпеки
                    command.Parameters.AddWithValue("@UserID", newId);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", "teacher");
                    command.Parameters.AddWithValue("@TeacherID", selectedTeacherId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Викладач доданий успішно.");
            LoadUsersData();
        }
        private void AdminAddStudentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AdminAddStudentComboBox.SelectedItem != null)
            {
                StudentItem selectedTeacher = (StudentItem)AdminAddStudentComboBox.SelectedItem;
                selectedTeacherId = selectedTeacher.StudentId;
                //MessageBox.Show(selectedTeacherId.ToString());
            }
        }
        private void FillAddStudentsComboBox()
        {
            string query = "SELECT StudentID, FirstName, LastName FROM Students;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int studentId = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();

                            AdminAddStudentComboBox.Items.Add(new StudentItem(studentId, firstName + " " + lastName));
                        }
                    }
                }
            }

            AdminAddStudentComboBox.DisplayMember = "StudentName"; // Вказує, що відображати
            AdminAddStudentComboBox.ValueMember = "StudentId"; // Вказує, яке значення використовувати
        }
        private void AdminAddStudentButton_Click(object sender, EventArgs e)
        {
            string login = AdminAddStudentLoginTextBox.Text;
            string password = AdminAddStudentPasswordTextBox.Text;
            int newId = GetLastUserId() + 1;

            // Запит для додавання нового викладача
            string query = "INSERT INTO Users  (UserID, Username, Pasword, Role, StudentID, TeacherID) VALUES (@UserID, @Login, @Password, @Role, @StudentID, NULL)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Параметризований запит для безпеки
                    command.Parameters.AddWithValue("@UserID", newId);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", "student");
                    command.Parameters.AddWithValue("@StudentID", selectedTeacherId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Студент доданий успішно.");
            LoadUsersData();
        }
        private void AdminStatisticsUpdateButton_Click(object sender, EventArgs e)
        {
            // Загальна кількість студентів
            int studentCount = GetRowCount("SELECT COUNT(*) FROM Students");
            string studentQuontity = studentCount.ToString();

            // Загальна кількість зареєстрованих студентів
            int registeredStudentCount = GetRowCount("SELECT COUNT(*) FROM Users WHERE Role = 'student'");
            string registeredStudentQuontity = registeredStudentCount.ToString();

            // Загальна кількість викладачів
            int teacherCount = GetRowCount("SELECT COUNT(*) FROM Teachers");
            string teacherQuontity = teacherCount.ToString();

            // Загальна кількість зареєстрованих викладачів
            int registeredTeacherCount = GetRowCount("SELECT COUNT(*) FROM Users WHERE Role = 'teacher'");
            string registeredTeacherQuontity = registeredTeacherCount.ToString();

            // Загальна кількість адмінів
            int adminCount = GetRowCount("SELECT COUNT(*) FROM Users WHERE Role = 'admin'");
            string adminQuontity = adminCount.ToString();

            // Відображення кількостей на формі
            AdminStudentQtLabel.Text = studentQuontity;
            AdminRegStudentQtLabel.Text = registeredStudentQuontity;
            AdminTeacherQtLabel.Text = teacherQuontity;
            AdminRegTeacherQtLabel.Text = registeredTeacherQuontity;
            AdminAdminQtLabel.Text = adminQuontity;
            AdminStatStatusLabel.Text = "Штатна робота, помилок не виявлено";
        }
        private int GetRowCount(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        private void LoadUsersData()
        {
            // Очистити таблицю перед додаванням нових значень
            AdminUsersDataGridView.Rows.Clear();
            string query = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userID = reader["UserID"].ToString();
                            string username = reader["Username"].ToString();
                            string pasword = reader["Pasword"].ToString();
                            string role = reader["Role"].ToString();
                            string studentID = reader["StudentID"].ToString();
                            string teacherID = reader["TeacherID"].ToString();

                            AdminUsersDataGridView.Rows.Add(userID, username, pasword, role, studentID, teacherID);
                        }
                    }
                }
            }
        }
        private void AdminStatsGridDeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.AdminUsersDataGridView.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    int userId = Convert.ToInt32(row.Cells["UserIdColumn"].Value);
                    DeleteUserById(userId);
                }
            }

            LoadUsersData(); // Перезавантаження даних після видалення
        }
        private void DeleteUserById(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Users WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка видалення користувача: " + ex.Message);
                }
            }
        }
        private void AdminStatsGridPrintButton_Click(object sender, EventArgs e)
        {
            int height = AdminUsersDataGridView.Height;
            AdminUsersDataGridView.Height = AdminUsersDataGridView.RowCount * AdminUsersDataGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(AdminUsersDataGridView.Width, AdminUsersDataGridView.Height);
            AdminUsersDataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, AdminUsersDataGridView.Width, AdminUsersDataGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            AdminUsersDataGridView.Height = height;
        }
        private void AdminStatsGridSaveButton_Click(object sender, EventArgs e)
        {
            // Создание приложения Excel
            Excel.Application app = new Excel.Application();
            Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Excel._Worksheet worksheet = null;

            app.Visible = true;

            // Установка активного листа
            worksheet = workbook.Sheets["Аркуш1"];
            if (worksheet == null)
            {
                worksheet = workbook.Sheets.Add();
                worksheet.Name = "Аркуш1";
            }
            worksheet = workbook.ActiveSheet;

            // Название рабочего листа
            worksheet.Name = "Exported from gridview";

            // Заполнение шапки
            for (int i = 1; i < AdminUsersDataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = AdminUsersDataGridView.Columns[i - 1].HeaderText;
            }

            // Заполнение ячеек данными
            for (int i = 0; i < AdminUsersDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < AdminUsersDataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = AdminUsersDataGridView.Rows[i].Cells[j].Value.ToString();
                }
            }

            // Авторазмер колонок
            worksheet.Columns.AutoFit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Вибір файлу Excel для імпорту
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                // Ініціалізація Excel
                Excel.Application app = new Excel.Application();
                Excel.Workbook workbook = app.Workbooks.Open(path);
                Excel._Worksheet worksheet = workbook.Sheets[1];
                Excel.Range range = worksheet.UsedRange;

                int rows = range.Rows.Count;
                int cols = range.Columns.Count;

                // Читання даних з Excel
                for (int i = 2; i <= rows; i++) // Починаємо з другого рядка, оскільки перший - заголовки
                {
                    string userID = range.Cells[i, 1].Value2.ToString();
                    string username = range.Cells[i, 2].Value2.ToString();
                    string password = range.Cells[i, 3].Value2.ToString();
                    string role = range.Cells[i, 4].Value2.ToString();
                    string studentID = range.Cells[i, 5].Value2 != null ? range.Cells[i, 5].Value2.ToString() : null;
                    string teacherID = range.Cells[i, 6].Value2 != null ? range.Cells[i, 6].Value2.ToString() : null;

                    // Тут додаємо перевірку та збереження даних у базу
                    UpdateDatabase(userID, username, password, role, studentID, teacherID);
                }

                // Закриття Excel
                workbook.Close(false);
                app.Quit();
            }
            LoadUsersData();
        }
        private void UpdateDatabase(string userID, string username, string password, string role, string studentID, string teacherID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Перевірка чи користувач існує вже за ідентифікатором userID
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID";
                    using (SqlCommand checkUserCommand = new SqlCommand(checkUserQuery, connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("@UserID", userID);
                        int userCount = (int)checkUserCommand.ExecuteScalar();

                        if (userCount > 0)
                        {
                            // Якщо користувач існує, виконуємо оновлення
                            string updateQuery = "UPDATE Users SET Username = @Username, Pasword = @Pasword, Role = @Role, StudentID = @StudentID, TeacherID = @TeacherID WHERE UserID = @UserID";
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@UserID", userID);
                                updateCommand.Parameters.AddWithValue("@Username", username);
                                updateCommand.Parameters.AddWithValue("@Pasword", password);
                                updateCommand.Parameters.AddWithValue("@Role", role);
                                updateCommand.Parameters.AddWithValue("@StudentID", (object)studentID ?? DBNull.Value);
                                updateCommand.Parameters.AddWithValue("@TeacherID", (object)teacherID ?? DBNull.Value);

                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Якщо користувача немає, виконуємо додавання
                            string insertQuery = "INSERT INTO Users (UserID, Username, Pasword, Role, StudentID, TeacherID) VALUES (@UserID, @Username, @Pasword, @Role, @StudentID, @TeacherID)";
                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@UserID", userID);
                                insertCommand.Parameters.AddWithValue("@Username", username);
                                insertCommand.Parameters.AddWithValue("@Pasword", password);
                                insertCommand.Parameters.AddWithValue("@Role", role);
                                insertCommand.Parameters.AddWithValue("@StudentID", (object)studentID ?? DBNull.Value);
                                insertCommand.Parameters.AddWithValue("@TeacherID", (object)teacherID ?? DBNull.Value);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка оновлення бази даних: " + ex.Message);
                }
            }
        }
    }
    public class TeacherItem
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public TeacherItem(int teacherId, string teacherName)
        {
            TeacherId = teacherId;
            TeacherName = teacherName;
        }

        public override string ToString()
        {
            return TeacherName;
        }
    }
}
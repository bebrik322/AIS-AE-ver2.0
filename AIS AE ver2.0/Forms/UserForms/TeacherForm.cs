using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AIS_AE_ver2._0
{
    public partial class TeacherForm : Form
    {
        string connectionString;
        private string teacherName;
        private int teacherId;
        int selectedStudentId;
        int SubjectComboBoxSelectedId;
        int lastGradeID;
        int lastJournalID;
        Bitmap bitmap;
        public TeacherForm(string str, string teacherName, int teacherId)
        {
            InitializeComponent();
            //константи
            connectionString = str;
            this.teacherName = teacherName;
            this.teacherId = teacherId;
            //Вивід імені викладача
            TeacherInfoOutput.Text = teacherName;
            //Вивід розкладу Вчителя
            TeacherSchedule(teacherId);
            //Заповнення комбобоксу учнями, запис обраного учня у selectedStudentId
            FillStudentsComboBox();
            //Заповнення комбобоксу предметами, які веде викладач, запис обраного предмета у SubjectComboBoxSelectedId
            FillSubjectsComboBox(teacherId);

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
            TeacherMondayDataGridView.Rows.Clear();
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

                            TeacherMondayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherTuesdaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            TeacherTuesdayDataGridView.Rows.Clear();
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

                            TeacherTuesdayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherWednesdaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            TeacherWednesdayDataGridView.Rows.Clear();
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

                            TeacherWednesdayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherThursdaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            TeacherThursdayDataGridView.Rows.Clear();
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

                            TeacherThursdayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
        }
        private void TeacherFridaySchedule(int teacherId)
        {
            // Очистити таблицю перед додаванням нових значень
            TeacherFridayDataGridView.Rows.Clear();
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

                            TeacherFridayDataGridView.Rows.Add(subjectName, className, startTime, endTime);
                        }
                    }
                }
            }
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
        private void AdminBackButton_Click(object sender, EventArgs e)
        {
            AutherisationForm autherisationform = new AutherisationForm();
            autherisationform.Show();
            this.Close();
        }
        private void AdminExitButton_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Ви точно хочете вийти?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                this.Close();
            }
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
        private void TeacherSubjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeacherSubjectComboBox.SelectedItem != null)
            {
                SubjectItem selectedSubject = (SubjectItem)TeacherSubjectComboBox.SelectedItem;
                SubjectComboBoxSelectedId = selectedSubject.SubjectId;
            }
        }
        private void TeacherAddButton_Click(object sender, EventArgs e)
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
        private void TeacherDeleteButton_Click(object sender, EventArgs e)
        {
            if (!CheckIfGradesExist(selectedStudentId, teacherId))
            {
                MessageBox.Show("У студента нема оцінок на предметах, які ведете ви.");
                return;
            }

            DeleteLastRecord();
            GridFill(selectedStudentId, teacherId);
        }
        private void TeacherPrintButton_Click(object sender, EventArgs e)
        {
            int height = TeacherJournalGridView.Height;
            TeacherJournalGridView.Height = TeacherJournalGridView.RowCount * TeacherJournalGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(TeacherJournalGridView.Width, TeacherJournalGridView.Height);
            TeacherJournalGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, TeacherJournalGridView.Width, TeacherJournalGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            TeacherJournalGridView.Height = height;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        private void TeacherSaveButton_Click(object sender, EventArgs e)
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
            for (int i = 0; i < TeacherJournalGridView.Rows.Count ; i++)
            {
                for (int j = 0; j < TeacherJournalGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = TeacherJournalGridView.Rows[i].Cells[j].Value.ToString();
                }
            }

            // Авторазмер колонок
            worksheet.Columns.AutoFit();
        }
    }
    public class StudentItem
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public StudentItem(int studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
        }

        public override string ToString()
        {
            return StudentName;
        }
    }
    public class SubjectItem
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public SubjectItem(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public override string ToString()
        {
            return SubjectName;
        }
    }
}
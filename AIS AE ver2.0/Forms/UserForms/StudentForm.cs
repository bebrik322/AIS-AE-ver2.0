using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Excel = Microsoft.Office.Interop.Excel;

namespace AIS_AE_ver2._0
{
    public partial class StudentForm : Form
    {
        private string connectionString;
        private string studentName;
        private int studentId;
        private int selectedGroupId;
        Bitmap bitmap;
        public StudentForm(string str, string studentName, int studentId)
        {
            //Форма
            InitializeComponent();
            //просвоєння констант
            connectionString = str;
            this.studentName = studentName;
            this.studentId = studentId;
            //Вивід Імені студента
            StudentNameOutput.Text = studentName;
            //Вивід невиставленних предметів
            GradesInfoOutputLabel.Text = GetStudentSubjects(studentId);
            //Заповнення журналу
            GridFill(studentId);
            //заповнення комбобоксу для групп группами
            FillClassesComboBox();
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
        private string GetStudentSubjects(int id)
        {
            string query = "SELECT COALESCE(Subjects.SubjectName, 'Немає предметів') AS SubjectName " +
                           "FROM Subjects " +
                           "LEFT JOIN Grades ON Subjects.SubjectID = Grades.SubjectID AND Grades.StudentID = @UserId " +
                           "WHERE Grades.GradeID IS NULL;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", id);
                    connection.Open();

                    List<string> subjects = new List<string>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(reader["SubjectName"].ToString());
                        }
                    }

                    return string.Join(", ", subjects);
                }
            }
        }
        private void GridFill(int id)
        {
            string query = "SELECT \r\n    " +
                            "Subjects.SubjectName,\r\n    " +
                            "COALESCE(Teachers.FirstName + ' ' + Teachers.LastName, 'Немає вчителя') AS TeacherName,\r\n    " +
                            "COALESCE(Grades.Grade, 'Немає оцінки') AS Grade,\r\n    " +
                            "COALESCE(CAST(ElectronicJournal.DateRecorded AS NVARCHAR), 'Немає дати') AS DateRecorded\r\n" +
                            "FROM ElectronicJournal\r\nJOIN Grades ON ElectronicJournal.GradeID = Grades.GradeID\r\n" +
                            "JOIN Students ON Grades.StudentID = Students.StudentID\r\n" +
                            "JOIN Subjects ON Grades.SubjectID = Subjects.SubjectID\r\n" +
                            "JOIN Teachers ON ElectronicJournal.TeacherID = Teachers.TeacherID\r\n" +
                            "WHERE Students.StudentID = @ID\r\n" +
                            "ORDER BY ElectronicJournal.DateRecorded;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["SubjectName"].ToString();
                            string teacherName = reader["TeacherName"].ToString();
                            string grade = reader["Grade"].ToString();
                            string dateRecorded = reader["DateRecorded"].ToString();

                            JournalGridView.Rows.Add(subjectName, teacherName, grade, dateRecorded);
                        }
                    }
                }
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            AutherisationForm autherisationform = new AutherisationForm();
            autherisationform.Show();
            this.Close();
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Ви точно хочете вийти?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void StudentSaveButton_Click(object sender, EventArgs e)
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
            for (int i = 1; i < JournalGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = JournalGridView.Columns[i - 1].HeaderText;
            }

            // Заполнение ячеек данными
            for (int i = 0; i < JournalGridView.Rows.Count; i++)
            {
                for (int j = 0; j < JournalGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = JournalGridView.Rows[i].Cells[j].Value.ToString();
                }
            }

            // Авторазмер колонок
            worksheet.Columns.AutoFit();
        }
        private void StudentPrintButton_Click(object sender, EventArgs e)
        {
            int height = JournalGridView.Height;
            JournalGridView.Height = JournalGridView.RowCount * JournalGridView.RowTemplate.Height * 2;
            bitmap = new Bitmap(JournalGridView.Width, JournalGridView.Height);
            JournalGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, JournalGridView.Width, JournalGridView.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            JournalGridView.Height = height;
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
    public class ClassItem
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public ClassItem(int classId, string className)
        {
            ClassId = classId;
            ClassName = className;
        }

        public override string ToString()
        {
            return ClassName;
        }
    }
}
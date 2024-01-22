using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AIS_AE_ver2._0
{
    public partial class AutherisationForm : Form
    {
        string connectionString; 
        public AutherisationForm()
        {
            InitializeComponent();
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder["Data Source"] = "Gleck";
            connectionStringBuilder["Initial Catalog"] = "LearningAutomationDB";
            connectionStringBuilder["Integrated Security"] = true;
            connectionString = connectionStringBuilder.ConnectionString;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTestBox.Text;
           
            if (!UserCheck(login, password))
            {
                MessageBox.Show("Невірний пароль або логін!!");
                return;
            }
            string query = "SELECT Role " +
                           "FROM Users WHERE Username = @UserLogin " +
                           "AND Pasword = @UserPassword";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@UserLogin", login);
                        command.Parameters.AddWithValue("@UserPassword", password);
                        connection.Open();
                        object result = command.ExecuteScalar();

                        switch (result)
                        {
                            case "admin":
                                AdminForm adminform = new AdminForm(connectionString);
                                adminform.Show();
                                this.Hide();
                                break;
                            case "student":
                                StudentForm studentform = new StudentForm(connectionString, GetStudentName(login, password), GetStudentId(login, password));
                                studentform.Show();
                                this.Hide();
                                break;
                            case "teacher":
                                TeacherForm teacherform = new TeacherForm(connectionString, GetTeacherName(login, password), GetTeacherId(login, password));
                                teacherform.Show();
                                this.Hide();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private int GetStudentId(string login, string password)
        {
            string query = "SELECT Students.StudentID " +
                           "FROM Users " +
                           "JOIN Students ON Users.StudentID = Students.StudentID " +
                           "WHERE Users.Username = @UserLogin AND Users.Pasword = @UserPassword;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserLogin", login);
                    command.Parameters.AddWithValue("@UserPassword", password);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int res = reader.GetInt32(reader.GetOrdinal("StudentID"));
                            return res;
                        }
                        else
                        {
                            return 0; // коли студент не знайдений
                        }
                    }
                }
            }
        }
        private string GetStudentName(string login, string password)
        {
            string query = "SELECT Students.FirstName, Students.LastName " +
                           "FROM Users " +
                           "JOIN Students ON Users.StudentID = Students.StudentID " +
                           "WHERE Users.Username = @UserLogin AND Users.Pasword = @UserPassword;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserLogin", login);
                    command.Parameters.AddWithValue("@UserPassword", password);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            return firstName + " " + lastName;
                        }
                        else
                        {
                            return "Помилка при зчитуванні імені"; // коли студент не знайдений
                        }
                    }
                }
            }
        }
        private string GetTeacherName(string login, string password)
        {
            string query = "SELECT Teachers.FirstName, Teachers.LastName " +
                           "FROM Users " +
                           "JOIN Teachers ON Users.TeacherID = Teachers.TeacherID " +
                           "WHERE Users.Username = @UserLogin AND Users.Pasword = @UserPassword;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserLogin", login);
                    command.Parameters.AddWithValue("@UserPassword", password);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            return firstName + " " + lastName;
                        }
                        else
                        {
                            return "Помилка при зчитуванні імені вчителя"; // коли вчитель не знайдений
                        }
                    }
                }
            }
        }
        private int GetTeacherId(string login, string password)
        {
            string query = "SELECT Teachers.TeacherID " +
                           "FROM Users " +
                           "JOIN Teachers ON Users.TeacherID = Teachers.TeacherID " +
                           "WHERE Users.Username = @UserLogin AND Users.Pasword = @UserPassword;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserLogin", login);
                    command.Parameters.AddWithValue("@UserPassword", password);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int res = reader.GetInt32(reader.GetOrdinal("TeacherID"));
                            return res;
                        }
                        else
                        {
                            return 0; // коли вчитель не знайдений
                        }
                    }
                }
            }
        }
        private bool UserCheck(string login, string password)
        {
            string query = "SELECT COUNT(*) " +
                           "FROM Users WHERE Username = @UserLogin " +
                           "AND Pasword = @UserPassword";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserLogin", login);
                    command.Parameters.AddWithValue("@UserPassword", password);
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}

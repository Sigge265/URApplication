using System;
using System.Windows;

namespace Project
{
    public partial class LoginWindow : Window
    {
        private string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sigge\Documents\URtest2.mdf;Integrated Security=True;Connect Timeout=30";
        private LoginManager _loginManager;

        public LoginWindow()
        {
            InitializeComponent();
            _loginManager = new LoginManager(_connectionString);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the entered username and password
                string enteredUsername = txtUsername.Text;
                string enteredPassword = txtPassword.Text;

                // Create UserCredentials object
                UserCredentials credentials = new UserCredentials
                {
                    Username = enteredUsername,
                    Password = enteredPassword
                };

                // Validate login using LoginManager
                bool isValidLogin = _loginManager.ValidateLogin(credentials);

                // Display login result
                if (isValidLogin)
                {
                    MessageBox.Show("Login successful!");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login failed. Please check your username and password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

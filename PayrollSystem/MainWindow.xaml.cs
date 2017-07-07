using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PayrollSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtUserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LoginContext())
            {
                string user = txtUserName.Text;
                string password = txtPassword.Password;

                if (user != "" && password != "")
                {
                    var User = (from u in db.LoginInfo
                                where u.UserName == user && u.Password == password
                                select new { u.EMP_ID , u.CompanyName , u.EmployeeName });

                    if (User.Any())
                    {
                        var emp = User.First();

                        MainUI mainUI = new MainUI(emp.EMP_ID,emp.EmployeeName,emp.CompanyName);
                        mainUI.Show();
                        Hide();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("LOGIN UNSUCESSFUL \nPlease make sure your Username & Password are correct");
                    }
                }
            }
        }
         private void txtPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;               
            }
            base.OnPreviewKeyDown(e);
        }

        private void lblCreateUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CreateUser Create = new CreateUser();
            Create.ShowDialog();
            this.Hide();
            this.Close();
        }
    }
}

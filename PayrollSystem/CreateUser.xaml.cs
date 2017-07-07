using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Linq;


namespace PayrollSystem
{
    public partial class CreateUser : Window
    {

        public CreateUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Login = new MainWindow();
            Login.Show();
            this.Hide();
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LoginContext())
            {
                string companyName = txtCompanyName.Text;
                string employeeName = txtEmployeeName.Text;
                string irdNumber = txtIRD.Text;
                string bankNumber = txtAcountNum.Text;
                string userName = txtUserName.Text;
                string password = txtPassword.Password;
                string passwordAuth = txtPasswordAuth.Password;

                if (companyName != "" && employeeName != "" && irdNumber != "" && bankNumber != "" && userName != "" && password != "" && passwordAuth != "")
                {
                    if (password == passwordAuth && password !="" && passwordAuth !="") 
                    {

                        var User = (from u in db.LoginInfo
                                    where u.UserName == userName
                                    select u);

                        if(User.Any())
                        {
                            MessageBox.Show("The Username that you've selected is already taken");
                        }
                        else
                        {
                            var newUser = new LoginID
                            {
                                CompanyName = companyName,
                                EmployeeName = employeeName,
                                IRDNumber = irdNumber,
                                AccountNumber = bankNumber,
                                UserName = userName,
                                Password = password
                            };

                            db.LoginInfo.Add(newUser);
                            db.SaveChanges();
                            MessageBox.Show("User Succesfully Created");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make sure passwords are the same");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the information");
                }
            }
        }
    }
}

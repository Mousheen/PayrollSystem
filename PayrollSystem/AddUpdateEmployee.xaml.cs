using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PayrollSystem
{
    public partial class AddUpdateEmployee : Window
    {
        string EmployeeName;
        string CompanyName;
        int ManagerID;

        public AddUpdateEmployee(int id, string empname, string companyname)
        {
            EmployeeName = empname;
            CompanyName = companyname;
            ManagerID = id;

            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LoginContext())
            {
                var User = (from u in db.LoginInfo
                            select new { u.EMP_ID, u.CompanyName, u.EmployeeName });

                var emp = User.First();

                MainUI mainUI = new MainUI(emp.EMP_ID, emp.EmployeeName, emp.CompanyName);
                mainUI.Show();
                Hide();
                Close();
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

            if (txtFirst.Text != "" && txtLast.Text != "" && txtIRDNum.Text != "" && txtBankNum.Text != "" && txtPayRate.Text != "")
            {
                using (var db = new LoginContext())
                {
                    Employee EmployeeObj = new Employee();
                    DateTime dt = dpStartDate.SelectedDate.Value;

                    EmployeeObj.First_Name = txtFirst.Text;
                    EmployeeObj.Last_Name = txtLast.Text;
                    EmployeeObj.IRD_Number = txtIRDNum.Text;
                    EmployeeObj.Taxcode = cbTaxCode.SelectionBoxItem.ToString();
                    EmployeeObj.Kiwisaver = Convert.ToDouble(cbKiwiSaver.SelectionBoxItem.ToString());
                    EmployeeObj.StudentLoan = cbStudentLoan.SelectionBoxItem.ToString();
                    EmployeeObj.Start_Date = dt;
                    EmployeeObj.Pay_Rate = Convert.ToDouble(txtPayRate.Text);
                    EmployeeObj.Bank_ACC_Num = txtBankNum.Text;
                    EmployeeObj.Annual_Leave = 5;
                    EmployeeObj.Sick_Days = 5;

                    var User = (from u in db.LoginInfo
                                where u.EMP_ID == ManagerID
                                select u).First();

                    User.Employees.Add(EmployeeObj);

                    db.SaveChanges();
                    DGSearchEmployee.ItemsSource = db.EmployeeInfo.ToList();
                    MessageBox.Show("Employee Added Successfully");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbTaxCode.Items.Add("M");
            cbTaxCode.Items.Add("M SL");
            cbTaxCode.Items.Add("ME");
            cbTaxCode.Items.Add("ME SL");
            cbTaxCode.Items.Add("SB");
            cbTaxCode.Items.Add("SB SL");
            cbTaxCode.Items.Add("S");
            cbTaxCode.Items.Add("S SL");
            cbTaxCode.Items.Add("SH");
            cbTaxCode.Items.Add("SH SL");
            cbTaxCode.Items.Add("ST SL");

            using (var db = new LoginContext())
            {
                DGSearchEmployee.ItemsSource = db.EmployeeInfo.ToList();
            }
        }

        private void btnUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtFirst.Text != "" && txtLast.Text != "" && txtIRDNum.Text != "" && txtBankNum.Text != "" && txtPayRate.Text != "")
                {
                    using (var db = new LoginContext())
                    {
                        Employee EmployeeObj = new Employee();
                        DateTime dt = dpStartDate.SelectedDate.Value;

                        var row = DGSearchEmployee.SelectedItems[0];
                        Type type = row.GetType();

                        var ID = (int)type.GetProperty("EMPLOYEE_ID").GetValue(row, null);


                        var User = (from u in db.EmployeeInfo
                                    where u.EMPLOYEE_ID == ID
                                    select u).First();

                        User.First_Name = txtFirst.Text;
                        User.Last_Name = txtLast.Text;
                        User.IRD_Number = txtIRDNum.Text;
                        User.Taxcode = cbTaxCode.SelectionBoxItem.ToString();
                        User.Kiwisaver = Convert.ToDouble(cbKiwiSaver.SelectionBoxItem.ToString());
                        User.StudentLoan = cbStudentLoan.SelectionBoxItem.ToString();
                        User.Pay_Rate = Convert.ToDouble(txtPayRate.Text);
                        User.Bank_ACC_Num = txtBankNum.Text;

                        db.SaveChanges();
                        DGSearchEmployee.ItemsSource = db.EmployeeInfo.ToList();
                        MessageBox.Show("Employee Updated Successfully");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select An Employee");
            }

        }

        private void DGSearchEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var db = new LoginContext())
                {
                    var row = DGSearchEmployee.SelectedItems[0];

                    Type type = row.GetType();

                    txtFirst.Text = (string)type.GetProperty("First_Name").GetValue(row, null);
                    txtLast.Text = (string)type.GetProperty("Last_Name").GetValue(row, null);
                    txtIRDNum.Text = (string)type.GetProperty("IRD_Number").GetValue(row, null);
                    cbTaxCode.SelectedValue = (string)type.GetProperty("Taxcode").GetValue(row, null);
                    cbKiwiSaver.Text = (double)type.GetProperty("Kiwisaver").GetValue(row, null) + "";
                    cbStudentLoan.Text = (string)type.GetProperty("StudentLoan").GetValue(row, null);
                    dpStartDate.SelectedDate = (DateTime)type.GetProperty("Start_Date").GetValue(row, null);
                    txtPayRate.Text = (double)type.GetProperty("Pay_Rate").GetValue(row, null) + "";
                    txtBankNum.Text = (string)type.GetProperty("Bank_ACC_Num").GetValue(row, null);
                }
            }
            catch (Exception)
            {

            }
        }

        private void txtPayRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new LoginContext())
            {
                var sQuery = from x in db.EmployeeInfo
                             select x;

                if (!string.IsNullOrEmpty(txtSearch.Text))
                    sQuery = sQuery.Where(x => x.First_Name.Contains(txtSearch.Text) || x.Last_Name.Contains(txtSearch.Text));

                DGSearchEmployee.ItemsSource = sQuery.ToList();
            }
        }
    }
}

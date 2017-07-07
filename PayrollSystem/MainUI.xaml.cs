using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class MainUI : Window
    {
        string EmployeeName;
        string CompanyName;
        int EmployeeID;
        SalaryCalculator objSalary = new SalaryCalculator();

        public MainUI(int id,string empname,string companyname)
        {
            EmployeeName = empname;
            CompanyName = companyname;
            EmployeeID = id;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblWelcome.Content += " " + EmployeeName + "\nCompany Name: " + CompanyName;

            using (var db = new LoginContext())
            {
                DGEmployees.ItemsSource = db.EmployeeInfo.ToList();
            }
        }

        private void addUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LoginContext())
            {
                var User = (from u in db.LoginInfo
                            select new { u.EMP_ID, u.CompanyName, u.EmployeeName });

                var emp = User.First();

                AddUpdateEmployee AUEmployee = new AddUpdateEmployee(emp.EMP_ID, emp.EmployeeName, emp.CompanyName);
                AUEmployee.Show();
                Hide();
                Close();
            }
        }

        private void deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Delete Employee", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (var db = new LoginContext())
                {
                    Employee emp = (Employee)DGEmployees.SelectedItems[0];
                    int ID = emp.EMPLOYEE_ID;

                    var User = (from c in db.EmployeeInfo
                                where c.EMPLOYEE_ID == ID
                                select c).First();

                    db.EmployeeInfo.Remove(User);

                    db.SaveChanges();
                    MessageBox.Show("Employee Successfully Deleted");
                    DGEmployees.ItemsSource = db.EmployeeInfo.ToList();
                }

            }
        }

        private void DGEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using (var db = new LoginContext())
                {
                    cbSickLeave.Items.Clear();
                    cbAnnualLeave.Items.Clear();

                    var row = DGEmployees.SelectedItems[0];

                    Type type = row.GetType();

                    double sickLeave = (double)type.GetProperty("Sick_Days").GetValue(row, null);
                    double annualLeave = (double)type.GetProperty("Annual_Leave").GetValue(row, null);

                    for (int i = 1; i <= sickLeave; i++)
                    {
                        cbSickLeave.Items.Add(i);
                    }

                    for (int i = 1; i <= annualLeave; i++)
                    {
                        cbAnnualLeave.Items.Add(i);
                    }

                    tbEmpInfo.Text = " EMPLOYEE INFORMATION \n";
                    tbEmpInfo.Text += "\n First Name: " + (string)type.GetProperty("First_Name").GetValue(row, null);
                    tbEmpInfo.Text += "\n Last Name: " + (string)type.GetProperty("Last_Name").GetValue(row, null);
                    tbEmpInfo.Text += "\n IRD Number: " + (string)type.GetProperty("IRD_Number").GetValue(row, null);
                    tbEmpInfo.Text += "\n Tax Code: " + (string)type.GetProperty("Taxcode").GetValue(row, null);
                    tbEmpInfo.Text += "\n Kiwisaver: " + (double)type.GetProperty("Kiwisaver").GetValue(row, null) + "%";
                    tbEmpInfo.Text += "\n Student Loan: " + (string)type.GetProperty("StudentLoan").GetValue(row, null);
                    tbEmpInfo.Text += "\n Start Date: " + (DateTime)type.GetProperty("Start_Date").GetValue(row, null);
                    tbEmpInfo.Text += "\n Bank Account Number: " + (string)type.GetProperty("Bank_ACC_Num").GetValue(row, null);
                    tbEmpInfo.Text += "\n Annual Leave Days: " + (double)type.GetProperty("Annual_Leave").GetValue(row, null);
                    tbEmpInfo.Text += "\n Sick Days Remaining: " + (double)type.GetProperty("Sick_Days").GetValue(row, null);
                    tbEmpInfo.Text += "\n Pay Rate: $" + (double)type.GetProperty("Pay_Rate").GetValue(row, null);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if(txtHoursWorked.Text != "" && DGEmployees.SelectedItem != null)
            {
                using (var db = new LoginContext())
                {
                    Payment objPayment = new Payment();
                    Employee objEmployee = new Employee();

                    var row = DGEmployees.SelectedItems[0];

                    Type type = row.GetType();

                    DateTime startDate = (DateTime)type.GetProperty("Start_Date").GetValue(row, null);
                    DateTime sickLeaveRenew = startDate.AddDays(365);
                    if (DateTime.Now == sickLeaveRenew)
                    {
                        objEmployee.Start_Date = DateTime.Today;
                        objEmployee.Sick_Days = objEmployee.Sick_Days + 5;
                        objEmployee.Annual_Leave = objEmployee.Annual_Leave + 20;
                    }

                    objSalary.hoursWorked = Convert.ToDouble(txtHoursWorked.Text);
                    objSalary.studentLoan = (string)type.GetProperty("StudentLoan").GetValue(row, null);
                    objSalary.payRate = (double)type.GetProperty("Pay_Rate").GetValue(row, null);
                    objSalary.KiwisaverPercent = (double)type.GetProperty("Kiwisaver").GetValue(row, null);

                    objSalary.sickLeave = Convert.ToDouble(cbSickLeave.SelectedValue);
                    objSalary.annualLeave = Convert.ToDouble(cbAnnualLeave.SelectedValue);

                    objSalary.grossPayment();
                    objSalary.payment();

                    objPayment.Gross_Income = Convert.ToDouble(objSalary.annualPay);
                    objPayment.Payment_Date = DateTime.Today;
                    objPayment.Sick_Days_Used = Convert.ToDouble(cbSickLeave.SelectedValue);
                    objPayment.Annual_Leave = Convert.ToDouble(cbAnnualLeave.SelectedValue);
                    objPayment.Tax_Deduction = Convert.ToDouble(objSalary.taxDeductionWeekly);
                    objPayment.Kiwi_Saver_Deduction = Convert.ToDouble(objSalary.KiwiSaverDeduction);
                    objPayment.StudentLoan_Deduction = Convert.ToDouble(objSalary.studentLoanDeduction);
                    objPayment.Yearly_Income = Convert.ToDouble(objSalary.takeHomePayYearly);
                    objPayment.Sick_Days_Remaining = (double)type.GetProperty("Sick_Days").GetValue(row, null);
                    objPayment.Annual_Leave_Remaining = (double)type.GetProperty("Annual_Leave").GetValue(row, null);
                    var id = (int)type.GetProperty("EMPLOYEE_ID").GetValue(row, null);

                    var User = (from u in db.EmployeeInfo
                                where u.EMPLOYEE_ID == id
                                select u).First();

                    User.Sick_Days = User.Sick_Days - Convert.ToDouble(cbSickLeave.SelectedValue);
                    User.Annual_Leave = User.Annual_Leave - Convert.ToDouble(cbAnnualLeave.SelectedValue);
                    objPayment.Sick_Days_Remaining = objPayment.Sick_Days_Remaining - Convert.ToDouble(cbSickLeave.SelectedValue);
                    objPayment.Annual_Leave_Remaining = objPayment.Annual_Leave_Remaining - Convert.ToDouble(cbAnnualLeave.SelectedValue);

                    User.Payments.Add(objPayment);
                    db.SaveChanges();

                    tbResult.Text = "PAYSLIP FOR " + (string)type.GetProperty("First_Name").GetValue(row, null) + " " + (string)type.GetProperty("Last_Name").GetValue(row, null);
                    tbResult.Text += "\n\nHOURS WORKED: " + objSalary.hoursWorked.ToString();
                    tbResult.Text += " @ " + objSalary.payRate.ToString("$" + "#.##");
                    tbResult.Text += "\nSICK LEAVE USED: " + objSalary.sickLeave / 8;
                    tbResult.Text += "\nANNUAL LEAVE USED: " + objSalary.annualLeave / 8;
                    tbResult.Text += "\nGROSS PAY: $" + objSalary.grossPay.ToString("#.##");
                    tbResult.Text += "\nTAX DEDUCTIONS: $" + objSalary.taxDeductionWeekly.ToString("#.##");
                    tbResult.Text += "\nTAX CODE: " + (string)type.GetProperty("Taxcode").GetValue(row, null);
                    tbResult.Text += "\nSTUDENT LOANS DEDUCTION: " + objSalary.studentLoanDeduction.ToString("$" + "#.##");
                    tbResult.Text += "\nKIWISAVER DEDUCTION: " + objSalary.KiwiSaverDeduction.ToString("$" + "#.##");
                    tbResult.Text += "\n\nTAKE HOME PAY: $" + objSalary.takeHomePayWeekly.ToString("#.##");
                    tbResult.Text += "\n\nSICK DAYS REMAINING: " + objPayment.Sick_Days_Remaining;
                    tbResult.Text += "\nANNUAL LEAVE REMAINING: " + objPayment.Annual_Leave_Remaining;

                    DGEmployees.ItemsSource = db.EmployeeInfo.ToList();
                    MessageBox.Show("Payment Processed");
                }
            }
            else
            {
                MessageBox.Show("Select an employee or allocate hours worked");
            }
        }

        private void txtHoursWorked_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void btnPayslip_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, tbResult.Text);
        }
    }
}

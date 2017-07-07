using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    class SalaryCalculator
    {
        public double tax1 = 0.105;
        public double tax2 = 0.175;
        public double tax3 = 0.30;
        public double tax4 = 0.33;

        public string studentLoan { get; set; }
        public double studentLoanPercent = 0.12;
        public double studentLoanDeduction { get; set; }

        public double KiwisaverPercent { get; set; }
        public double KiwiSaverDeduction { get; set; }

        public double grossPay { get; set; }
        public double payRate { get; set; }
        public string pay { get; set; }
        public double hoursWorked { get; set; } 
        public double annualPay { get; set; }
        public double taxDeductionYearly { get; set; }
        public double taxDeductionWeekly { get; set; }
        public double takeHomePayYearly { get; set; }
        public double takeHomePayWeekly { get; set; }
        public double leftoverPay { get; set; }
        public double annualLeave { get; set; }
        public double sickLeave { get; set; }

        public double grossPayment()
        {
            annualLeave = annualLeave * 8;
            sickLeave = sickLeave * 8;
            hoursWorked = annualLeave + hoursWorked + sickLeave;
            grossPay = hoursWorked * payRate;
            return grossPay;
        }

        public double payment()
        {
            using (var db = new LoginContext())
            {
                Employee EmployeeDB = new Employee();
                annualPay = grossPay * 52;

                if(annualPay <= 14000)
                {
                    taxDeductionYearly = annualPay * tax1;
                    taxDeductionWeekly = taxDeductionYearly / 52;
                    takeHomePayYearly = annualPay - taxDeductionYearly;
                    takeHomePayWeekly = takeHomePayYearly / 52;
                }
                else if (annualPay >= 14000 && annualPay <= 48000)
                {
                    leftoverPay = annualPay - 14000;
                    taxDeductionYearly = leftoverPay * tax2;
                    taxDeductionYearly = taxDeductionYearly + 1470;
                    taxDeductionWeekly = taxDeductionYearly / 52;
                    takeHomePayYearly = annualPay - taxDeductionYearly;
                    takeHomePayWeekly = takeHomePayYearly / 52;
                }
                else if (annualPay >= 48000 && annualPay <= 70000)
                {
                    leftoverPay = annualPay - 48000;
                    taxDeductionYearly = leftoverPay * tax3;
                    taxDeductionYearly = taxDeductionYearly + 1470 + 5950;
                    taxDeductionWeekly = taxDeductionYearly / 52;
                    takeHomePayYearly = annualPay - taxDeductionYearly;
                    takeHomePayWeekly = takeHomePayYearly / 52;
                }
                else if (annualPay >= 70000)
                {
                    leftoverPay = annualPay - 70000;
                    taxDeductionYearly = leftoverPay * tax4;
                    taxDeductionYearly = taxDeductionYearly + 1470 + 5950 + 6600;
                    taxDeductionWeekly = taxDeductionYearly / 52;
                    takeHomePayYearly = annualPay - taxDeductionYearly;
                    takeHomePayWeekly = takeHomePayYearly / 52;
                }

                if(KiwisaverPercent != 0)
                {
                    KiwisaverPercent = KiwisaverPercent / 100;
                    KiwiSaverDeduction = takeHomePayWeekly * KiwisaverPercent;
                    takeHomePayWeekly = takeHomePayWeekly - KiwiSaverDeduction;
                }

                if (studentLoan == "Yes")
                {
                    studentLoanDeduction = takeHomePayWeekly * studentLoanPercent;
                    takeHomePayWeekly = takeHomePayWeekly - studentLoanDeduction;
                }

            }
                return takeHomePayWeekly;
        }

        public void SickDayRenew()
        {

        }
    }
}

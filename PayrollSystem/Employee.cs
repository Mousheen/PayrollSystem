using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PayrollSystem
{
    public class Employee
    {
        [Key]
        public int EMPLOYEE_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string IRD_Number { get; set; }
        public string Taxcode { get; set; }
        public double Kiwisaver { get; set; }
        public string StudentLoan { get; set; }
        public DateTime Start_Date { get; set; }
        public string Bank_ACC_Num { get; set; }
        public double Pay_Rate { get; set; }
        public double Sick_Days { get; set; }
        public double Annual_Leave { get; set; }
        public virtual List<LoginID> Logins { get; set; }
        public virtual List<Payment> Payments { get; set; }

    }

}

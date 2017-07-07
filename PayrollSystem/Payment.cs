using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class Payment
    {
        [Key]
        public int PAYMENT_ID { get; set; }
        public double Gross_Income { get; set; }
        public DateTime Payment_Date { get; set; }
        public double Sick_Days_Used { get; set; }
        public double Annual_Leave { get; set; }
        public double Tax_Deduction { get; set; }
        public double Kiwi_Saver_Deduction { get; set; }
        public double StudentLoan_Deduction { get; set; }
        public double Yearly_Income { get; set; }
        public double Sick_Days_Remaining { get; set; }
        public double Annual_Leave_Remaining { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }


}

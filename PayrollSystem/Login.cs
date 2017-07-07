using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
        public class LoginID
        {
            [Key]
            public int EMP_ID { get; set; } 
            public string CompanyName { get; set; }
            public string EmployeeName { get; set; }
            public string IRDNumber { get; set; }
            public string AccountNumber { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public virtual List<Employee> Employees { get; set; }
        }

    public class LoginContext : DbContext
        {
            public DbSet<LoginID> LoginInfo { get; set; }
            public DbSet<Employee> EmployeeInfo { get; set; }
            public DbSet<Payment> PaymentInfo { get; set; }
        }


}

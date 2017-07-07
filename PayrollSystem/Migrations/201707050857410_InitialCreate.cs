namespace PayrollSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EMPLOYEE_ID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        IRD_Number = c.String(),
                        Taxcode = c.String(),
                        Kiwisaver = c.Double(nullable: false),
                        StudentLoan = c.String(),
                        Start_Date = c.DateTime(nullable: false),
                        Bank_ACC_Num = c.String(),
                        Pay_Rate = c.Double(nullable: false),
                        Sick_Days = c.Double(nullable: false),
                        Annual_Leave = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EMPLOYEE_ID);
            
            CreateTable(
                "dbo.LoginIDs",
                c => new
                    {
                        EMP_ID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        EmployeeName = c.String(),
                        IRDNumber = c.String(),
                        AccountNumber = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EMP_ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PAYMENT_ID = c.Int(nullable: false, identity: true),
                        Gross_Income = c.Double(nullable: false),
                        Payment_Date = c.DateTime(nullable: false),
                        Sick_Days_Used = c.Double(nullable: false),
                        Annual_Leave = c.Double(nullable: false),
                        Tax_Deduction = c.Double(nullable: false),
                        Kiwi_Saver_Deduction = c.Double(nullable: false),
                        StudentLoan_Deduction = c.Double(nullable: false),
                        Yearly_Income = c.Double(nullable: false),
                        Sick_Days_Remaining = c.Double(nullable: false),
                        Annual_Leave_Remaining = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PAYMENT_ID);
            
            CreateTable(
                "dbo.LoginIDEmployees",
                c => new
                    {
                        LoginID_EMP_ID = c.Int(nullable: false),
                        Employee_EMPLOYEE_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginID_EMP_ID, t.Employee_EMPLOYEE_ID })
                .ForeignKey("dbo.LoginIDs", t => t.LoginID_EMP_ID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EMPLOYEE_ID, cascadeDelete: true)
                .Index(t => t.LoginID_EMP_ID)
                .Index(t => t.Employee_EMPLOYEE_ID);
            
            CreateTable(
                "dbo.PaymentEmployees",
                c => new
                    {
                        Payment_PAYMENT_ID = c.Int(nullable: false),
                        Employee_EMPLOYEE_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Payment_PAYMENT_ID, t.Employee_EMPLOYEE_ID })
                .ForeignKey("dbo.Payments", t => t.Payment_PAYMENT_ID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EMPLOYEE_ID, cascadeDelete: true)
                .Index(t => t.Payment_PAYMENT_ID)
                .Index(t => t.Employee_EMPLOYEE_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentEmployees", "Employee_EMPLOYEE_ID", "dbo.Employees");
            DropForeignKey("dbo.PaymentEmployees", "Payment_PAYMENT_ID", "dbo.Payments");
            DropForeignKey("dbo.LoginIDEmployees", "Employee_EMPLOYEE_ID", "dbo.Employees");
            DropForeignKey("dbo.LoginIDEmployees", "LoginID_EMP_ID", "dbo.LoginIDs");
            DropIndex("dbo.PaymentEmployees", new[] { "Employee_EMPLOYEE_ID" });
            DropIndex("dbo.PaymentEmployees", new[] { "Payment_PAYMENT_ID" });
            DropIndex("dbo.LoginIDEmployees", new[] { "Employee_EMPLOYEE_ID" });
            DropIndex("dbo.LoginIDEmployees", new[] { "LoginID_EMP_ID" });
            DropTable("dbo.PaymentEmployees");
            DropTable("dbo.LoginIDEmployees");
            DropTable("dbo.Payments");
            DropTable("dbo.LoginIDs");
            DropTable("dbo.Employees");
        }
    }
}

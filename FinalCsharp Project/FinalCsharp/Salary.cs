using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCsharp
{
    class Salary
    {
        protected int num;
        protected double amount;

        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }


        }
        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }


        }

        public virtual double Calculate()
        {

            return num;

        }

    }


    class Income : Salary
    {

        public override double Calculate()
        {
            return num * 15 + amount;
        }
    }

    class Deduction : Salary
    {

        public override double Calculate()
        {
            return num * 5.5 + amount;
        }
    }

    class employee
    {
       public string name;
       public int id;
       public Salary income;
       public Salary deduction;
        
        public employee(int id , string name)
        {
            this.id = id;
            this.name = name;
            income = new Income();
            deduction = new Deduction();
        }



    }

    class Admin
    {
        List<employee> employees;

        public Admin()
        {
            employees = new List<employee>();
        }

        public void AddEmployee(employee e)
        {

            employees.Add(e);


        }

      public  void AddPayroll(int id , int workDays , double bouns , int absent , double loan)
        {
            foreach (employee obj in employees) 
            {
                if(obj.id == id)
                {
                    obj.income.Num = workDays;
                    obj.income.Amount = bouns;
                    obj.deduction.Num = absent;
                    obj.deduction.Amount = loan;
                }
            }


        }

        public string EmployeeInfo()
        {
            string info = "Name\tID\tWorkdays\tBonus\tAbsent Days\tLoan\n";
            foreach (employee obj in employees) {
                info += $"{obj.name}\t{obj.id}\t{obj.income.Num}\t{obj.income.Amount}\t{obj.deduction.Num}\t{obj.deduction.Amount}\n";
            }
            return info;
        }

        public string EmployeeSlip(int id) {
            string info = "";
            foreach (employee obj in employees) {
                if (obj.id == id) {
                    info = $"Employee Slip:\nName:{obj.name}\tID:{obj.id}\nIncome= {obj.income.Calculate()}\nDeduction= {obj.deduction.Calculate()}\n";
                    info += $"{obj.income.Calculate() - obj.deduction.Calculate()}\n";
                
                }
            }

            return info;
        
        }
    }

}

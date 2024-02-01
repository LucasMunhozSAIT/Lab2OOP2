using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Final
{
    public class Salaried : Employee
    {
        public double Salary { get; set; }
        public static double salariedCounter;

        public Salaried()
        {

        }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Salary = salary;
            salariedCounter++;
        }

        public double GetPay()
        {
            return this.Salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"Salary: ${this.Salary:F2}";
        }
    }
}

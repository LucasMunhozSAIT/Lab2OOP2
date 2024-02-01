using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Final
{
    public class Wages : Employee
    {
        public double Rate;
        public double Hours;
        public static double wagesCounter;

        public Wages()
        {

        }

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Rate = rate;
            this.Hours = hours;
            wagesCounter++;
        }

        public double GetPay()
        {
            double totalWeekPayment = 0;
            double regularPayment = 0;
            double overtimePayment = 0;

            if (Hours > 40)
            {
                double overtime = Hours - 40;
                regularPayment = Rate * 40;
                overtimePayment = overtime * (Rate * 1.5);
                totalWeekPayment = regularPayment + overtimePayment;
            }
            else
            {
                totalWeekPayment = Rate * Hours;
            }

            return totalWeekPayment;
        }

        public override string ToString()
        {
            return base.ToString() + $"Rate: {this.Rate}, Hours: {this.Hours}, Payment: ${GetPay():F2}";
        }
    }
}

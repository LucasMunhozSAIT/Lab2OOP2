using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Final
{
    public class PartTime : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }
        public static double partTimeCounter;

        public PartTime()
        {

        }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Rate = rate;
            this.Hours = hours;
            partTimeCounter++;
        }

        public double GetPay()
        {
            return Rate * Hours;
        }

        public override string ToString()
        {
            return base.ToString() + $"Rate: {Rate}, Hours: {Hours}, Payment: ${GetPay():F2}";
        }
    }
}

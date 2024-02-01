using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Final
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Sin { get; set; }
        public string Dob { get; set; }
        public string Dept { get; set; }
        public static double employeeCounter;

        public Employee()
        {

        }

        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Sin = sin;
            this.Dob = dob;
            this.Dept = dept;
            employeeCounter++;
        }

        public override string ToString()
        {
            return $"ID: {this.Id}, Name: {this.Name}, Address: {this.Address}, Phone: {this.Phone}, Sin: {this.Sin}, Date of birthday: {this.Dob}, Department: {this.Dept}";
        }
    }
}

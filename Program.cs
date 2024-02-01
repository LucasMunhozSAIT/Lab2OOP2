using System.Security.Cryptography.X509Certificates;

namespace Lab2Final
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] employeesDoc = File.ReadAllLines("C:\\Users\\Lucas\\OneDrive\\Área de Trabalho\\Lab2Final\\res\\employees.txt");
            
            //4.	Create an application with the following methods:
            //a.	Fill a list with objects based on the supplied data file.
            List<string> salariedList = new List<string>();
            List<string> wageList = new List<string>();
            List<string> partTimeList = new List<string>();

            foreach (string line in employeesDoc)
            {
                if (line[0] == '0' || line[0] == '1' || line[0] == '2' || line[0] == '3' || line[0] == '4')
                {
                    salariedList.Add(line);
                }
                else if (line[0] == '5' || line[0] == '6' || line[0] == '7')
                {
                    wageList.Add(line);
                }
                else
                {
                    partTimeList.Add(line);
                }
            }
            List<Salaried> salariedObject = new List<Salaried>();
            List<Wages> wagesObject = new List<Wages>();
            List<PartTime> partTimeObject = new List<PartTime>();

            foreach (string line in salariedList)
            {

                string[] salariedSplit = line.Split(':');
                string id = salariedSplit[0];
                string name = salariedSplit[1];
                string address = salariedSplit[2];
                string phone = salariedSplit[3];
                long sin = long.Parse(salariedSplit[4]);
                string dob = salariedSplit[5];
                string dept = salariedSplit[6];
                double salary = double.Parse(salariedSplit[7]);

                Salaried salaried = new Salaried(id, name, address, phone, sin, dob, dept, salary);

                salariedObject.Add(salaried);
            }

            foreach (string line in wageList)
            {
                string[] wageSplit = line.Split(":");
                string id = wageSplit[0];
                string name = wageSplit[1];
                string address = wageSplit[2];
                string phone = wageSplit[3];
                long sin = long.Parse(wageSplit[4]);
                string dob = wageSplit[5];
                string dept = wageSplit[6];
                double rate = double.Parse(wageSplit[7]);
                double hours = double.Parse(wageSplit[8]);

                Wages wages = new Wages(id, name, address, phone, sin, dob, dept, rate, hours);

                wagesObject.Add(wages);
            }

            foreach (string line in partTimeList)
            {
                string[] partTimeSplit = line.Split(":");
                string id = partTimeSplit[0];
                string name = partTimeSplit[1];
                string address = partTimeSplit[2];
                string phone = partTimeSplit[3];
                long sin = long.Parse(partTimeSplit[4]);
                string dob = partTimeSplit[5];
                string dept = partTimeSplit[6];
                double rate = double.Parse(partTimeSplit[7]);
                double hours = double.Parse(partTimeSplit[8]);

                PartTime partTime = new PartTime(id, name, address, phone, sin, dob, dept, rate, hours);

                partTimeObject.Add(partTime);
            }

            Console.WriteLine("\nList of Salaried group employees:");
            foreach (var objectSalaried in salariedObject)
            {
               Console.WriteLine($"Employee {objectSalaried.Name} receives a payment of: ${objectSalaried.GetPay():F2}");
            }

            Console.WriteLine("\nList of Wages group employees:");
            foreach (var objectWages in wagesObject)
            {
                Console.WriteLine($"Employee {objectWages.Name} receives a payment of: ${objectWages.GetPay():F2}");
            }

            Console.WriteLine("\nList of PartTime group employees:");
            foreach (var objectPartTime in partTimeObject)
            {
                Console.WriteLine($"Employee {objectPartTime.Name} receives a paymento of: ${objectPartTime.GetPay():F2}");
            }

            //b.	Calculate and return the average weekly pay for all employees.
            double totalWeeklyPay = 0;
            
            foreach (var objectSalaried in salariedObject)
            {
                totalWeeklyPay += objectSalaried.GetPay();
            }

            foreach (var objectWages in wagesObject)
            {
                totalWeeklyPay += objectWages.GetPay();
            }

            foreach (var objectPartTime in partTimeObject)
            {
                totalWeeklyPay += objectPartTime.GetPay();
            }

            double averageWeeklyPay = totalWeeklyPay / Employee.employeeCounter;

            Console.WriteLine($"\n\nAverage weekly pay for all employees: ${averageWeeklyPay:F2}");

            //c.	Calculate and return the highest weekly pay for the wage employees, including the name of the employee.
            Console.WriteLine("\n\nThe highest weekly pay for the Wage employees:");
            List<Wages> highestWeekPayment = wagesObject.OrderByDescending(objectWages => objectWages.GetPay()).ToList();
            Console.WriteLine($"Name: {highestWeekPayment[0].Name} and weekly pay: ${highestWeekPayment[0].GetPay():F2}");

            //d.	Calculate and return the lowest salary for the salaried employees, including the name of the employee.
            Console.WriteLine("\n\nThe lowest salary for the Salaried employees:");
            List<Salaried> lowestWeekPayment = salariedObject.OrderBy(objectSalaried => objectSalaried.GetPay()).ToList();
            Console.WriteLine($"Name: {lowestWeekPayment[0].Name} and salary: ${lowestWeekPayment[0].GetPay():F2}");

            //e.	What percentage of the company’s employees fall into each employee category? 
            Console.WriteLine("\n\nPercentage of each category of employees:");
            double percentageSalaried = (Salaried.salariedCounter / Employee.employeeCounter) * 100;
            Console.WriteLine($"The percentage of employees that fall into the Salaried category is: {percentageSalaried:F2}%");

            double percentageWages = (Wages.wagesCounter / Employee.employeeCounter) * 100;
            Console.WriteLine($"The percentage of employees that fall into the Wages category is: {percentageWages:F2}%");

            double percentagePartTime = (PartTime.partTimeCounter / Employee.employeeCounter) * 100;
            Console.WriteLine($"The percentage of employees that fall into the PartTime category is: {percentagePartTime:F2}%");

            //General list of employees and their data.
            Console.WriteLine("\n\nConfidential information: List of Employees separated by categories with their complete data.");

            Console.WriteLine("\nSalaried category:");
            foreach (var objectSalaried in salariedObject)
            {
                Console.WriteLine(objectSalaried.ToString());
            }

            Console.WriteLine("\nWages category:");
            foreach (var objectWages in wagesObject)
            {
                Console.WriteLine(objectWages.ToString());
            }

            Console.WriteLine("\nPartTime category:");
            foreach (var objectPartTime in partTimeObject)
            {
                Console.WriteLine(objectPartTime.ToString());
            }
        }
    }
}

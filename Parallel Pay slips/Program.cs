using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Pay_slips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paralel Payslips");
            var employees = new Employees();
            var startTimerNonParallel = Stopwatch.StartNew();
            Parallel.For(0, employees.Count, (int i) =>
            {
                Operations.GenerateSlip(employees[i]);
                //calling generateslip() method
                Console.WriteLine($"Pay slip For {employees[i].EmpNo} Generated");
                //i++;
            });
            Console.WriteLine($"Parallel Process completed at {DateTime.Now}" +
              $"Total Time {startTimerNonParallel.Elapsed.TotalSeconds}");
        }
    }
    internal class Operations
    {
        public static void GenerateSlip(Employee emp)
        {
            string path = @$"C:\Users\Coditas\Desktop\ParallelPayslips\Salary-for-March-2022-{emp.EmpNo}.txt";
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                Method(emp.Salary, emp.Designation, out int HRA, out int TS, out int DA, out int Tax, out int NetSalary);

                string slip = $"|--payslip for month March- EmpNo: {emp.EmpNo} EmpName: {emp.EmpName} DeptName: {emp.DeptName} ---------\n" +
                             $"|-----------------------------------------------------------------------------|\n" +
                             $"|    Designation :{emp.Designation}                                           \n" +
                              "|--------------------------------------|---------------------------------------|\n" +
                             $"|    Income : {NetSalary}                                                     \n" +
                              "|--------------------------------------|---------------------------------------|\n" +
                             $"|    Basic Salary : {emp.Salary}                                              \n" +
                              "|--------------------------------------|---------------------------------------|\n" +
                             $"|    HRA : {HRA}                                                              \n" +
                              "|--------------------------------------|---------------------------------------|\n" +
                             $"|    Ts : {TS}                                                                \n" +
                              "|--------------------------------------|---------------------------------------|\n" +
                             $"|    DA ={DA}                            Tax ={Tax}                           \n" +
                              "|--------------------------------------|---------------------------------------|\n" +
                             $"| Amoount Deposited :{NetSalary} \\-                                               \n" +
                              "---------------------------------------|---------------------------------------|\n" +
                             $"|      {Convert(NetSalary)}  Rupees only                                     \n" +
                              "|------------------------------------------------------------------------------|";
                sw.Write(slip);
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }

        }
       public static void Method(int salary, String Desig, out int Hra, out int Ts, out int Da, out int Tax, out int NetSalary)
        {

            switch (Desig)
            {
                case "Manager":

                    Hra = (int)(0.1 * salary);
                    Ts = (int)(0.15 * salary);
                    Da = (int)(0.2 * salary);
                    break;

                case "Director":
                    Hra = (int)(0.2 * salary);
                    Ts = (int)(0.3 * salary);
                    Da = (int)(0.4 * salary);
                    break;
                case "Staff":
                    Hra = (int)(0.1 * salary);
                    Ts = (int)(0.1 * salary);
                    Da = (int)(0.1 * salary);
                    break;
                case "Engineer":
                    Hra = (int)(0.1 * salary);
                    Ts = (int)(0.15 * salary);
                    Da = (int)(0.2 * salary);
                    break;
                default:
                    Hra = 0;
                    Ts = 0;
                    Da = 0;
                    break;
            }


            int Gross = salary + Hra + Ts + Da;
            if (Gross * 12 < 1000000 && Gross * 12 > 500000)
            {
                Tax = (int)(0.2 * Gross);
            }
            else if (Gross * 12 > 1000000 && Gross * 12 < 2000000)
            {
                Tax = (int)(0.25 * Gross);
            }
            else if (Gross * 12 < 2000000)
            {
                Tax = (int)(0.3 * Gross);
            }
            else
            {
                Tax = (int)(0.4 * Gross);
            }
            NetSalary = Gross - Tax;

        }
       public static String Convert(int i)
        {
            String[] units = { "Zero", "One", "Two", "Three",
                   "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                   "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                       "Seventeen", "Eighteen", "Nineteen" };
            String[] tens = { "", "", "Twenty", "Thirty", "Forty",
                    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + Convert(i % 10) : "");
            }
            if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + Convert(i % 100) : "");
            }
            if (i < 100000)
            {
                return Convert(i / 1000) + " Thousand "
                + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");
            }
            if (i < 10000000)
            {
                return Convert(i / 100000) + " Lakh "
                        + ((i % 100000 > 0) ? " " + Convert(i % 100000) : "");
            }
            if (i < 1000000000)
            {
                return Convert(i / 10000000) + " Crore "
                        + ((i % 10000000 > 0) ? " " + Convert(i % 10000000) : "");
            }
            return Convert(i / 1000000000) + " Arab "
                    + ((i % 1000000000 > 0) ? " " + Convert(i % 1000000000) : "");
        }
    }
    internal class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "Admin", Designation = "Manager", Salary = 113000 });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Designation = "Director", Salary = 122000 });
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Designation = "Staff", Salary = 123000 });
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = " Account", Designation = "Director", Salary = 143000 });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Designation = "Staff", Salary = 10000 });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Designation = "Engineer", Salary = 93000 });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Designation = "Engineer", Salary = 80300 });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = " Account", Designation = "Engineer", Salary = 73000 });
            Add(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Designation = "Director", Salary = 64000 });
            Add(new Employee() { EmpNo = 110, EmpName = "Suprotim", DeptName = "IT", Designation = "Manager", Salary = 54000 });
            Add(new Employee() { EmpNo = 111, EmpName = "Ravi", DeptName = "IT", Designation = "Manager", Salary = 110040 });
            Add(new Employee() { EmpNo = 112, EmpName = "Suresh", DeptName = "Admin", Designation = "Engineer", Salary = 124000 });
            Add(new Employee() { EmpNo = 113, EmpName = "Harish", DeptName = "SL", Designation = "Staff", Salary = 123000 });
            Add(new Employee() { EmpNo = 114, EmpName = "Surya", DeptName = "IT", Designation = "Engineer", Salary = 142000 });
            Add(new Employee() { EmpNo = 115, EmpName = "Akansha", DeptName = " Account", Designation = "Engineer", Salary = 120000 });
            Add(new Employee() { EmpNo = 116, EmpName = "Abhi", DeptName = "SL", Designation = "Manager", Salary = 92000 });
            Add(new Employee() { EmpNo = 117, EmpName = "Harsha", DeptName = "IT", Designation = "Staff", Salary = 84000 });
            Add(new Employee() { EmpNo = 118, EmpName = "Suchand", DeptName = "HR", Designation = "Director", Salary = 74000 });
            Add(new Employee() { EmpNo = 119, EmpName = "Sai", DeptName = " Account", Designation = "Director", Salary = 60300 });
            Add(new Employee() { EmpNo = 120, EmpName = "Brahma", DeptName = "Admin", Designation = "Director", Salary = 52000 });
            Add(new Employee() { EmpNo = 121, EmpName = "Amar", DeptName = "IT", Designation = "Manager", Salary = 110200 });
            Add(new Employee() { EmpNo = 122, EmpName = "Tarun", DeptName = "HR", Designation = "Director", Salary = 122000 });
            Add(new Employee() { EmpNo = 123, EmpName = "BalaKrishna", DeptName = "SL", Designation = "Staff", Salary = 130200 });
            Add(new Employee() { EmpNo = 124, EmpName = "Hema", DeptName = "IT", Designation = "Staff", Salary = 140200 });
            Add(new Employee() { EmpNo = 125, EmpName = "Asha", DeptName = "HR", Designation = "Engineer", Salary = 100200 });
            Add(new Employee() { EmpNo = 126, EmpName = "Akshay", DeptName = "SL", Designation = "Staff", Salary = 92000 });
            Add(new Employee() { EmpNo = 127, EmpName = "sharukh", DeptName = "IT", Designation = "Director", Salary = 83000 });
            Add(new Employee() { EmpNo = 128, EmpName = "Salman", DeptName = "HR", Designation = "Manager", Salary = 70300 });
            Add(new Employee() { EmpNo = 129, EmpName = "Vivek obeari", DeptName = "SL", Designation = "Director", Salary = 36000 });
            Add(new Employee() { EmpNo = 130, EmpName = "Sushant", DeptName = "IT", Designation = "Director", Salary = 25000 });
            Add(new Employee() { EmpNo = 131, EmpName = "vishnu", DeptName = "Admin", Designation = "Staff", Salary = 121000 });
            Add(new Employee() { EmpNo = 132, EmpName = "Bhaskar", DeptName = "HR", Designation = "Manager", Salary = 122000 });
            Add(new Employee() { EmpNo = 133, EmpName = "Raju", DeptName = "SL", Designation = "Staff", Salary = 132000 });
            Add(new Employee() { EmpNo = 134, EmpName = "Brunda", DeptName = "IT", Designation = "Engineer", Salary = 143000 });
            Add(new Employee() { EmpNo = 135, EmpName = "Anurdha", DeptName = "HR", Designation = "Staff", Salary = 100300 });
            Add(new Employee() { EmpNo = 136, EmpName = "Soundarya", DeptName = "SL", Designation = "Manager", Salary = 39000 });
            Add(new Employee() { EmpNo = 137, EmpName = "Mounisha", DeptName = "Admin", Designation = "Staff", Salary = 28000 });
            Add(new Employee() { EmpNo = 138, EmpName = "Mounika", DeptName = "HR", Designation = "Director", Salary = 73000 });
            Add(new Employee() { EmpNo = 139, EmpName = "Dhanvi", DeptName = "SL", Designation = "Staff", Salary = 63000 });
            Add(new Employee() { EmpNo = 140, EmpName = "Keerthi", DeptName = " Account", Designation = "Staff", Salary = 53000 });
            Add(new Employee() { EmpNo = 141, EmpName = "Dharani", DeptName = "Admin", Designation = "Manager", Salary = 11000 });
            Add(new Employee() { EmpNo = 142, EmpName = "Sirisha", DeptName = "HR", Designation = "Staff", Salary = 12000 });
            Add(new Employee() { EmpNo = 143, EmpName = "Janu", DeptName = " Account", Designation = "Engineer", Salary = 132000 });
            Add(new Employee() { EmpNo = 144, EmpName = "Deepika", DeptName = "IT", Designation = "Director", Salary = 140400 });
            Add(new Employee() { EmpNo = 145, EmpName = "Kajal", DeptName = " Account", Designation = "Engineer", Salary = 130000 });
            Add(new Employee() { EmpNo = 146, EmpName = "Eesha", DeptName = "Admin", Designation = "Engineer", Salary = 39000 });
            Add(new Employee() { EmpNo = 147, EmpName = "Ananya", DeptName = "IT", Designation = "Manager", Salary = 83000 });
            Add(new Employee() { EmpNo = 148, EmpName = "Manasi", DeptName = " Account", Designation = "Director", Salary = 77000 });
            Add(new Employee() { EmpNo = 149, EmpName = "MAyur", DeptName = " Account", Designation = "Engineer", Salary = 60000 });
            Add(new Employee() { EmpNo = 150, EmpName = "Venkat Raman", DeptName = "Admin", Designation = "Manager", Salary = 50000 });
        }
    }
}

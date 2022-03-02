using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Cs.PaySlip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pay Slips");
            Employees emps = new Employees();
            BinaryFormatter bf = new BinaryFormatter();
            Console.WriteLine("Enter Month");
            string Month = Console.ReadLine();
            foreach (Employee emp in emps)
            {
                string path = @$"C:\Users\Coditas\Desktop\payslips\Salary-for-{Month}-2022-{emp.EmpNo}.txt";
                //Used by filestram
                string path2 = @$"C:\Users\Coditas\Desktop\Serialized paySlips\Salary-for-{Month}-2022-{emp.EmpNo}.txt";
                //used by serialization
                //FileStream fs = new FileStream(path, FileMode.Create,FileAccess.Write);
                if (File.Exists(path))
                {
                    Console.WriteLine("File Is Already Present");
                }
                else
                {
                    FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                    // filrstram to payslips folder
                    FileStream fs2 = new FileStream(path2, FileMode.CreateNew);
                    //filrstream for Payslips for serilaztion
                    StreamWriter sw = new StreamWriter(fs);
                    //calling method that calculates required values Like DA HRA when we pass salary and Designation
                    Method(emp.Salary, emp.Designation, out int HRA, out int TS, out int DA, out int Tax, out int NetSalary);

                    string slip = $"|--payslip for month {Month}- EmpNo: {emp.EmpNo} EmpName: {emp.EmpName} DeptName: {emp.DeptName} ---------\n" +
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
                                  "---------------------------------------|---------------------------------------|\n"+
                                 $"|      {Convert(NetSalary)}  Rupees only                                     \n"+
                                    // Convert() is method that Converts salary into a words format
                                  "|------------------------------------------------------------------------------|";
                    //Serializing the slip into folder
                    bf.Serialize(fs2, slip);
                    // writing slip data into folder
                    sw.Write(slip);
                    sw.Close();
                    fs.Close();
                    fs2.Close();
                    Console.WriteLine($"PaySlip is Generated for {emp.EmpName}");
                }


            }
            void Method(int salary, String Desig, out int Hra, out int Ts, out int Da, out int Tax, out int NetSalary)
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
                if (Gross*12 < 1000000 && Gross * 12 > 500000)
                {
                    Tax = (int)(0.2 * Gross);
                }
                else if(Gross * 12 > 1000000 && Gross * 12 < 2000000)
                {
                    Tax = (int)(0.25 * Gross);
                }
                else if (Gross * 12 < 2000000 )
                {
                    Tax = (int)(0.3 * Gross);
                }
                else
                {
                    Tax = (int)(0.4 * Gross); 
                }
                NetSalary = Gross - Tax;
                                               
            }
             String Convert(int i)
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
    }
}

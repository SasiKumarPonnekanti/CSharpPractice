using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Cs_Payslips_Using_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var duration = Stopwatch.StartNew();

            Task task = Task.Factory.StartNew(() => GenerateSlip(null))
                .ContinueWith(delegate { TransferSlips(); });

                

            Console.WriteLine($"Time to COmplete {duration.Elapsed.TotalMilliseconds}");
        }
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
        public static void TransferSlips()
        {
            try
            {
                File.Copy(,)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Employee_App.models
{
    internal class Client
    {
        public  EmployeeOperations opt = new EmployeeOperations();
        public bool validateEmpNo(int data)
        {         
            return !opt.SearchEmployee(data, out int? index) && data>0;
        }
        public bool validateEmpname(string name)
        {         
            Regex p = new Regex("^[A-Z][a-z0-9_-]{3,19}$");
            Match m = p.Match(name);
            if (m.Success)
                return true;
            else
                return false;         
        }
        public void Delete()
        {
            Console.WriteLine("Enter The Employee Number");
            int id = Convert.ToInt32(Console.ReadLine());           
            opt. DeleteEmployee(id);             
        }
        public void Search()
        {
            Console.WriteLine("Enter The Employee Number to search");
            int id = Convert.ToInt32(Console.ReadLine());
            if (opt.SearchEmployee(id, out int? index))
            {
                Console.WriteLine($"Name = {EmployeeOperations.Employees[(int)index].EmpName}");
                Console.WriteLine($"Department = {EmployeeOperations.Employees[(int)index].DeptName}");
                Console.WriteLine($"Designation = {EmployeeOperations.Employees[(int)index].Designation}");
                Console.WriteLine($"Salary = {EmployeeOperations.Employees[(int)index].Salary}");
            }
            else
            {
                Console.WriteLine("Employee Not Found");
            }
        }      
        public void Add()
        {
            try
            {
                Console.WriteLine("Enter Employee Number which is Non Negative");
                int Id = Convert.ToInt32(Console.ReadLine());


                while(!validateEmpNo(Id))
                {                   
                        Console.WriteLine("Employee No is not valid or may be repeated Enter Again");
                        Id = Convert.ToInt32(Console.ReadLine());
                }


                Console.WriteLine("Enter Employee Name");
                string name = Console.ReadLine();
                while(!validateEmpname(name))
                {
                    Console.WriteLine("Employee Name is not in correct format Enter agiain");
                    name = Console.ReadLine();
                }
                string DeprtName = Dropdown("Department");
                while(DeprtName == "")
                {
                    Console.WriteLine("Enter Correct Choice Of Department");
                    DeprtName = Dropdown("Department");
                }
                string desgntn = Dropdown("Designation");
                while (desgntn == "")
                {
                    Console.WriteLine("Enter Correct Choice Of Department");
                    desgntn = Dropdown("Designation");
                }
                Console.WriteLine("Enter Employee Salary");
                int salary= Convert.ToInt32(Console.ReadLine());
                while(salary<0)
                {
                    Console.WriteLine("salary cannot be negative Enter Again");
                    salary = Convert.ToInt32(Console.ReadLine());
                }
                Employee emp = new Employee() {EmpNo=Id,EmpName=name, DeptName = DeprtName,Designation=desgntn,Salary=salary };
                 opt.AddEmployee(emp);               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Display()
        {
            Console.WriteLine("1.Total data 2.Department wise 3.Designation wise");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    foreach (Employee emp in opt.GetEmployees())
                    {
                        Console.WriteLine("Empno\tEmpName\tDepartment Designation\tSalary");
                        Console.WriteLine($"{emp.EmpNo}\t{emp.EmpName}\t{emp.DeptName}\t   {emp.Designation}\t{emp.Salary}");
                        Console.WriteLine("----------------------------------");
                    }
                   
                    break;
                case 2:
                    string Department = Dropdown("Department");
                    foreach(Employee emp in opt.GetEmployees())
                    {
                        if (emp.DeptName == Department)
                        {
                            Console.WriteLine(emp.EmpName);
                        }
                    }
                   
                    break;
                case 3:
                    
                    break;
                default:
                    Console.WriteLine("Wrong Choice");
                    break;

            }           
        }
        public string Dropdown(string type)
        {
            string output="";
            if (type=="Department")
            {
                Console.WriteLine("Enter Choic of Department 1)IT, 2)HRD, 3)Sales, 4)Admin, 5)Account");
                int CoiceOfDepart = Convert.ToInt32(Console.ReadLine());
                switch (CoiceOfDepart)
                {
                    case 1:
                        output = "IT";
                        break;
                    case 2:
                        output = "HRD";
                        break;
                    case 3:
                        output = "Sales";
                        break;
                    case 4:
                        output = "Admin";
                        break;
                    case 5:
                        output = "Account";
                        break;
                    default:
                        break;

                }
            }
            if(type == "Designation")
            {
                Console.WriteLine("Enter Choic of Designation 1) Manager, 2)Engineer, 3)Clerk, 4)Staff");
                int CoiceOfDesign = Convert.ToInt32(Console.ReadLine());
                switch (CoiceOfDesign)
                {
                    case 1:
                        output = "Manager";
                        break;
                    case 2:
                        output = "Engineer";
                        break;
                    case 3:
                        output = "Clerk";
                        break;
                    case 4:
                        output = "Staff";
                        break;
                    default:
                        break;

                }
            }
            return output;
        } 
        public void Update()
        {
            try
            {
                Console.WriteLine("Enter employee Number you need to update");
                int Id = Convert.ToInt32(Console.ReadLine());
                if (opt.SearchEmployee(Id, out int? Index))
                {
                    int index = (int)Index;
                    Console.WriteLine("Enter New name");
                    string name = Console.ReadLine();
                    while (!validateEmpname(name))
                    {
                        Console.WriteLine("Enter Name in corect Format");
                        name = Console.ReadLine();
                    }
                    EmployeeOperations.Employees[index].EmpName = name;
                    EmployeeOperations.Employees[index].DeptName = Dropdown("Department");
                    EmployeeOperations.Employees[index].Designation = Dropdown("Designation");
                    Console.WriteLine("Enter the Salary");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    while (salary < 0)
                    {
                        Console.WriteLine("The salary you enterd is Negative Enter Again");
                        salary = Convert.ToInt32(Console.ReadLine());
                    }
                    EmployeeOperations.Employees[index].Salary = salary;
                }
                else
                {
                    throw new Exception("The employee not found");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using Cs_EfCore_DBfirst.Models;
using Cs_EfCore_DBfirst.DataAccess;
using System.Text.Json;
using Cs_EfCore_DBfirst;

// See https://aka.ms/new-console-template for more information
do
{
    Console.WriteLine("Welcome To Coditas!\n");
    Console.WriteLine("Enter Choice");
    Console.WriteLine("1.Employee\n2.Department\n3.Exit\n4.Clear");
    string Choice = Console.ReadLine();
    if (Choice == "3")
        break;
    switch (Choice)
    {
        case "1":
            IdataAccess<Employee, int> EmpAccess = new EmpDataAccess();
            Console.WriteLine("1.GetAllEmployees\n2.GetById\n3.CreateEmployee\n4.UpdateEmployee\n5.DeleteEmployee\n");
            Console.WriteLine("Enter Choice");
            string Choice1 = Console.ReadLine();
            switch (Choice1)
            {
                case "1":
                    var Employees = await EmpAccess.GetAllAsync();
                    Console.WriteLine("List Of Employees:\n");
                    foreach (Employee e in Employees)
                    {
                        Console.WriteLine($"EmpNo: {e.EmpNo} EmpName: {e.EmpName} DeptNo: {e.DeptNo}" +
                            $" Designation:{e.Designation} Salary: {e.Salary}");
                    }
                    break;
                case "2":
                    Console.WriteLine("Enter EmpNo");
                    bool IsNum = int.TryParse(Console.ReadLine(), out int num);
                    while (!IsNum)
                    {
                        Console.WriteLine("Enter Valid Number");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                    }
                    var emp = await EmpAccess.GetByIdAsync(num);
                    if (emp != null)
                    {
                        Console.WriteLine($"EmpNo: {emp.EmpNo} EmpName: {emp.EmpName} DeptNo: {emp.DeptNo}" +
                           $" Designation:{emp.Designation} Salary: {emp.Salary}");
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Found");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter EmpNo");
                    IsNum = int.TryParse(Console.ReadLine(), out num);

                    while (!IsNum)
                    {
                        Console.WriteLine("Enter Valid Number");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                    }
                    var empToCreate = await EmpAccess.GetByIdAsync(num);
                    if (empToCreate == null)
                    {
                        empToCreate = new Employee();
                        empToCreate.EmpNo = num;
                        Console.WriteLine("Enter Name");
                        empToCreate.EmpName = Console.ReadLine();
                        Console.WriteLine("Enter Designation");
                        empToCreate.Designation = Console.ReadLine();
                        showDepartments();
                        Console.WriteLine("Enter DeptNo");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                        while (!IsNum)
                        {
                            Console.WriteLine("Enter Valid Number");
                            IsNum = int.TryParse(Console.ReadLine(), out num);
                        }
                        empToCreate.DeptNo = num;
                        Console.WriteLine("Enter Salary");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                        while (!IsNum)
                        {
                            Console.WriteLine("Enter Valid Number");
                            IsNum = int.TryParse(Console.ReadLine(), out num);
                        }
                        empToCreate.Salary = num;
                        empToCreate = await EmpAccess.CreateAsync(empToCreate);
                        if (empToCreate != null)
                        {
                            Console.WriteLine("Employee creation Success");
                            Console.WriteLine($"EmpNo: {empToCreate.EmpNo} EmpName: {empToCreate.EmpName} DeptNo: {empToCreate.DeptNo}" +
                               $" Designation:{empToCreate.Designation} Salary: {empToCreate.Salary}");
                        }
                        else
                        {
                            Console.WriteLine("Employee creation Failed");
                        }


                    }
                    else
                    {
                        Console.WriteLine("Employee already present");
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter EmpNo");
                    IsNum = int.TryParse(Console.ReadLine(), out num);
                    while (!IsNum)
                    {
                        Console.WriteLine("Enter Valid Number");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                    }
                    var empToUpdate = await EmpAccess.GetByIdAsync(num);
                    if (empToUpdate != null)
                    {

                        empToUpdate.EmpNo = num;
                        Console.WriteLine("Enter Name");
                        empToUpdate.EmpName = Console.ReadLine();
                        Console.WriteLine("Enter Designation");
                        empToUpdate.Designation = Console.ReadLine();
                        Console.WriteLine("Enter DeptNo");
                        showDepartments();
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                        while (!IsNum)
                        {
                            Console.WriteLine("Enter Valid Number");
                            IsNum = int.TryParse(Console.ReadLine(), out num);
                        }
                        empToUpdate.DeptNo = num;
                        Console.WriteLine("Enter Salary");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                        while (!IsNum)
                        {
                            Console.WriteLine("Enter Valid Number");
                            IsNum = int.TryParse(Console.ReadLine(), out num);
                        }
                        empToUpdate.Salary = num;
                        empToUpdate = await EmpAccess.UpdateAsync(empToUpdate.EmpNo, empToUpdate);
                        if (empToUpdate != null)
                        {
                            Console.WriteLine("Employee Update Success");
                            Console.WriteLine($"EmpNo: {empToUpdate.EmpNo} EmpName: {empToUpdate.EmpName} DeptNo: {empToUpdate.DeptNo}" +
                               $" Designation:{empToUpdate.Designation} Salary: {empToUpdate.Salary}");
                        }
                        else
                        {
                            Console.WriteLine("Employee Update Failed");
                        }


                    }
                    else
                    {
                        Console.WriteLine("Employee Not present");
                    }

                    break;
                case "5":
                    Console.WriteLine("Enter EmpNo");
                    IsNum = int.TryParse(Console.ReadLine(), out num);
                    while (!IsNum)
                    {
                        Console.WriteLine("Enter Valid Number");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                    }
                    var empToDelete = await EmpAccess.GetByIdAsync(num);
                    if (empToDelete != null)
                    {
                        empToDelete = await EmpAccess.DeleteAsync(empToDelete.EmpNo);
                        Console.WriteLine("Delete Success");
                        Console.WriteLine($"EmpNo: {empToDelete.EmpNo} EmpName: {empToDelete.EmpName} DeptNo: {empToDelete.DeptNo}" +
                           $" Designation:{empToDelete.Designation} Salary: {empToDelete.Salary}");
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Found to delete");
                    }
                    break;
                default:
                    Console.WriteLine("Wrong Choice");
                    break;
            }
            break;
        case "2":
            IdataAccess<Department, int> DeptAccess = new DeptDataAccess();
            Console.WriteLine("1.GetAllDepartments\n2.GetDeptByDeptNo\n3.CreateDept\n4.UpdateDept\n5.DeleteDept\n");
            Console.WriteLine("Enter Choice");
            string Choice2 = Console.ReadLine();
            switch (Choice2)
            {
                case "1":
                    var departments = await DeptAccess.GetAllAsync();
                    Console.WriteLine("List Of Departments:\n");
                    foreach (var de in departments)
                    {
                        Console.WriteLine($"DeptNo: {de.DeptNo} DeptName: {de.DeptName} Location : {de.Location} Capacity : {de.Capacity}");
                    }
                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine("Enter DeptNo");
                    bool IsNum = int.TryParse(Console.ReadLine(), out int num);
                    while (!IsNum)
                    {
                        Console.WriteLine("Enter Valid Number");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                    }
                    var dept = await DeptAccess.GetByIdAsync(num);
                    if (dept != null)
                    {
                        Console.WriteLine($"DeptNo: {dept.DeptNo} DeptName: {dept.DeptName} Location : {dept.Location} Capacity : {dept.Capacity}");
                    }
                    else
                    {
                        Console.WriteLine("Department Not Found");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter DeptNo");
                    IsNum = int.TryParse(Console.ReadLine(), out num);
                    while (!IsNum)
                    {
                        Console.WriteLine("Enter Valid Number");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                    }
                    var deptCreate = await DeptAccess.GetByIdAsync(num);
                    if (deptCreate == null)
                    {
                        deptCreate = new Department();
                        deptCreate.DeptNo = num;
                        Console.WriteLine("Enter DeptName");
                        deptCreate.DeptName = Console.ReadLine();
                        Console.WriteLine("Enter New Location");
                        deptCreate.Location = Console.ReadLine();
                        Console.WriteLine("Enter capacity");
                        IsNum = int.TryParse(Console.ReadLine(), out int Capacity);
                        while (!IsNum)
                        {
                            Console.WriteLine("Enter Valid Number");
                            IsNum = int.TryParse(Console.ReadLine(), out Capacity);
                        }
                        deptCreate.Capacity = Capacity;
                        deptCreate = await DeptAccess.CreateAsync(deptCreate);
                        Console.WriteLine(" Created Department Info Is:\n");
                        Console.WriteLine($"DeptNo: {deptCreate.DeptNo} DeptName: {deptCreate.DeptName}" +
                            $" Location : {deptCreate.Location} Capacity : {deptCreate.Capacity}");
                    }
                    else
                    {
                        Console.WriteLine("Department Already Present");
                    }
                    break;
                case "4":
                    Console.WriteLine("Enter DeptNo");
                    IsNum = int.TryParse(Console.ReadLine(), out num);
                    while (!IsNum)
                    {
                        Console.WriteLine("Enter Valid Number");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                    }
                    var deptUpdate = await DeptAccess.GetByIdAsync(num);
                    if (deptUpdate != null)
                    {
                        Console.WriteLine("Department Old Info Is:\n");
                        Console.WriteLine($"DeptNo: {deptUpdate.DeptNo} DeptName: {deptUpdate.DeptName}" +
                            $" Location : {deptUpdate.Location} Capacity : {deptUpdate.Capacity}");
                        Console.WriteLine("Enter New DeptName");
                        deptUpdate.DeptName = Console.ReadLine();
                        Console.WriteLine("Enter New Location");
                        deptUpdate.Location = Console.ReadLine();
                        Console.WriteLine("Enter capacity");
                        IsNum = int.TryParse(Console.ReadLine(), out int Capacity);
                        while (!IsNum)
                        {
                            Console.WriteLine("Enter Valid Number");
                            IsNum = int.TryParse(Console.ReadLine(), out Capacity);
                        }
                        deptUpdate.Capacity = Capacity;
                        deptUpdate = await DeptAccess.UpdateAsync(num, deptUpdate);
                        Console.WriteLine("Department New Info Is:\n");
                        Console.WriteLine($"DeptNo: {deptUpdate.DeptNo} DeptName: {deptUpdate.DeptName}" +
                            $" Location : {deptUpdate.Location} Capacity : {deptUpdate.Capacity}");
                    }
                    else
                    {
                        Console.WriteLine("Department Not Found");
                    }
                    break;
                case "5":
                    Console.WriteLine("Enter DeptNo");
                    IsNum = int.TryParse(Console.ReadLine(), out num);
                    while (!IsNum)
                    {
                        Console.WriteLine("Enter Valid Number");
                        IsNum = int.TryParse(Console.ReadLine(), out num);
                    }
                    var deptDeleted = await DeptAccess.GetByIdAsync(num);
                    if (deptDeleted != null)
                    {
                        deptDeleted = await DeptAccess.DeleteAsync(deptDeleted.DeptNo);
                        Console.WriteLine("Delete Success");
                        Console.WriteLine("Department Deleted Is:\n");

                        Console.WriteLine($"DeptNo: {deptDeleted.DeptNo} DeptName: {deptDeleted.DeptName} Location : {deptDeleted.Location} Capacity : {deptDeleted.Capacity}");
                    }
                    else
                    {
                        Console.WriteLine("Department Not Found");
                    }
                    break;
                default:
                    Console.WriteLine("Wrong Choice");
                    break;

            }
            break;
        case "4":
            Console.Clear();
            break;
        default:
            Console.WriteLine("Wrong Choice");
            break;
    }
    Console.WriteLine("=======================================");


}
while (true);

async void showDepartments()
{
    IdataAccess<Department, int> DeptAccess = new DeptDataAccess();

    var departments = await DeptAccess.GetAllAsync();
    Console.WriteLine("List Of Departments:\n");
    foreach (var de in departments)
    {
        Console.WriteLine($"DeptNo: {de.DeptNo} DeptName: {de.DeptName} ");
    }
    Console.WriteLine("Select From Above");

}

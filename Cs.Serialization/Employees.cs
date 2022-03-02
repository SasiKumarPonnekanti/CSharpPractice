using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs.Serialization
{
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "Admin", Designation = "Manager", Salary = 113000 });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Designation = "Director", Salary = 122000 });
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Designation = "Staff", Salary = 123000 });
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = " Account", Designation = "Director", Salary = 143000 });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Designation = "Staff", Salary = 10000 });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Designation = " Engineer", Salary = 93000 });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Designation = " Engineer", Salary = 80300 });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = " Account", Designation = " Engineer", Salary = 73000 });
            Add(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Designation = "Director", Salary = 64000 });
            Add(new Employee() { EmpNo = 110, EmpName = "Suprotim", DeptName = "IT", Designation = "Manager", Salary = 54000 });
            Add(new Employee() { EmpNo = 111, EmpName = "Ravi", DeptName = "IT", Designation = "Manager", Salary = 110040 });
            Add(new Employee() { EmpNo = 112, EmpName = "Suresh", DeptName = "Admin", Designation = " Engineer", Salary = 124000 });
            Add(new Employee() { EmpNo = 113, EmpName = "Harish", DeptName = "SL", Designation = "Staff", Salary = 123000 });
            Add(new Employee() { EmpNo = 114, EmpName = "Surya", DeptName = "IT", Designation = " Engineer", Salary = 142000 });
            Add(new Employee() { EmpNo = 115, EmpName = "Akansha", DeptName = " Account", Designation = " Engineer", Salary = 120000 });
            Add(new Employee() { EmpNo = 116, EmpName = "Abhi", DeptName = "SL", Designation = "Manager", Salary = 92000 });
            Add(new Employee() { EmpNo = 117, EmpName = "Harsha", DeptName = "IT", Designation = "Staff", Salary = 84000 });
            Add(new Employee() { EmpNo = 118, EmpName = "Suchand", DeptName = "HR", Designation = "Director", Salary = 74000 });
            Add(new Employee() { EmpNo = 119, EmpName = "Sai", DeptName = " Account", Designation = "Director", Salary = 60300 });
            Add(new Employee() { EmpNo = 120, EmpName = "Brahma", DeptName = "Admin", Designation = "Director", Salary = 52000 });
            Add(new Employee() { EmpNo = 121, EmpName = "Amar", DeptName = "IT", Designation = "Manager", Salary = 110200 });
            Add(new Employee() { EmpNo = 122, EmpName = "Tarun", DeptName = "HR", Designation = "Director", Salary = 122000 });
            Add(new Employee() { EmpNo = 123, EmpName = "BalaKrishna", DeptName = "SL", Designation = "Staff", Salary = 130200 });
            Add(new Employee() { EmpNo = 124, EmpName = "Hema", DeptName = "IT", Designation = "Staff", Salary = 140200 });
            Add(new Employee() { EmpNo = 125, EmpName = "Asha", DeptName = "HR", Designation = " Engineer", Salary = 100200 });
            Add(new Employee() { EmpNo = 126, EmpName = "Akshay", DeptName = "SL", Designation = "Staff", Salary = 92000 });
            Add(new Employee() { EmpNo = 127, EmpName = "sharukh", DeptName = "IT", Designation = "Director", Salary = 83000 });
            Add(new Employee() { EmpNo = 128, EmpName = "Salman", DeptName = "HR", Designation = "Manager", Salary = 70300 });
            Add(new Employee() { EmpNo = 129, EmpName = "Vivek obeari", DeptName = "SL", Designation = "Director", Salary = 36000 });
            Add(new Employee() { EmpNo = 130, EmpName = "Sushant", DeptName = "IT", Designation = "Director", Salary = 25000 });
            Add(new Employee() { EmpNo = 131, EmpName = "vishnu", DeptName = "Admin", Designation = "Staff", Salary = 121000 });
            Add(new Employee() { EmpNo = 132, EmpName = "Bhaskar", DeptName = "HR", Designation = "Manager", Salary = 122000 });
            Add(new Employee() { EmpNo = 133, EmpName = "Raju", DeptName = "SL", Designation = "Staff", Salary = 132000 });
            Add(new Employee() { EmpNo = 134, EmpName = "Brunda", DeptName = "IT", Designation = " Engineer", Salary = 143000 });
            Add(new Employee() { EmpNo = 135, EmpName = "Anurdha", DeptName = "HR", Designation = "Staff", Salary = 100300 });
            Add(new Employee() { EmpNo = 136, EmpName = "Soundarya", DeptName = "SL", Designation = "Manager", Salary = 39000 });
            Add(new Employee() { EmpNo = 137, EmpName = "Mounisha", DeptName = "Admin", Designation = "Staff", Salary = 28000 });
            Add(new Employee() { EmpNo = 138, EmpName = "Mounika", DeptName = "HR", Designation = "Director", Salary = 73000 });
            Add(new Employee() { EmpNo = 139, EmpName = "Dhanvi", DeptName = "SL", Designation = "Staff", Salary = 63000 });
            Add(new Employee() { EmpNo = 140, EmpName = "Keerthi", DeptName = " Account", Designation = "Staff", Salary = 53000 });
            Add(new Employee() { EmpNo = 141, EmpName = "Dharani", DeptName = "Admin", Designation = "Manager", Salary = 11000 });
            Add(new Employee() { EmpNo = 142, EmpName = "Sirisha", DeptName = "HR", Designation = "Staff", Salary = 12000 });
            Add(new Employee() { EmpNo = 143, EmpName = "Janu", DeptName = " Account", Designation = " Engineer", Salary = 132000 });
            Add(new Employee() { EmpNo = 144, EmpName = "Deepika", DeptName = "IT", Designation = "Director", Salary = 140400 });
            Add(new Employee() { EmpNo = 145, EmpName = "Kajal", DeptName = " Account", Designation = " Engineer", Salary = 130000 });
            Add(new Employee() { EmpNo = 146, EmpName = "Eesha", DeptName = "Admin", Designation = " Engineer", Salary = 39000 });
            Add(new Employee() { EmpNo = 147, EmpName = "Ananya", DeptName = "IT", Designation = "Manager", Salary = 83000 });
            Add(new Employee() { EmpNo = 148, EmpName = "Manasi", DeptName = " Account", Designation = "Director", Salary = 77000 });
            Add(new Employee() { EmpNo = 149, EmpName = "MAyur", DeptName = " Account", Designation = " Engineer", Salary = 60000 });
            Add(new Employee() { EmpNo = 150, EmpName = "Venkat Raman", DeptName = "Admin", Designation = "Manager", Salary = 50000 });
        }
    }
}

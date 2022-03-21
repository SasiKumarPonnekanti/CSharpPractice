using System.Collections.Generic;
namespace Cs_CoreWebApp.Models
{
    public class Department
    {


        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DeptNo { get; set; }
        public string DeptName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Capacity { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

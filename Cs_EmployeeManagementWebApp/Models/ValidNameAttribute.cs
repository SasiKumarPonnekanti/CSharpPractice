using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Cs_EmployeeManagementWebApp.Models
{
    public class ValidNameAttribute :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex r = new Regex("[A-Z][A-Za-z ]+[A-Za-z]$");
            Match m = r.Match(value.ToString());
            if (m.Success)
            {
                return true;

            }
            return false;
        }
    }
}

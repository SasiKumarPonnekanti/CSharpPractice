using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Cs_JobPortalWebApp.CustomValidators
{
    public class FullNameAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex IsName = new Regex("([A-Z][a-z]{3,} )([A-Z][a-z]{3,} )?([A-Z][a-z]{3,})");
            Match m = IsName.Match(value.ToString());
            if (m.Success)
            {
                return true;
            }
            return false;
            
        }
    }
}

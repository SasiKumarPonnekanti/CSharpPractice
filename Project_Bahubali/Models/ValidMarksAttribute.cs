namespace Project_Bahubali.Models
{
   
    public class ValidMarksAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int marks = Convert.ToInt32(value);
            if (marks>=0&&marks<=100)
            {
                return true;

            }
            return false;
        }
    }
}

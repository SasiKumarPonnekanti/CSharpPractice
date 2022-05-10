namespace Cs_ProCatApi.CustomValidators
{
    public class NonNegativeAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (Convert.ToInt32(value) < 0)
            {
                return false;
            }
            return true;
        }
    }
}

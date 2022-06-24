using System.ComponentModel.DataAnnotations;

namespace API1.Attributes
{
    public class CustomAdmissionDate : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value == null)
                return false;

            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now.AddHours(1);
        }
    }
}

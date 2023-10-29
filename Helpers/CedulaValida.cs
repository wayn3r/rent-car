
using System.ComponentModel.DataAnnotations;

namespace RentCar.Helpers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class CedulaValida : ValidationAttribute
    {
        public CedulaValida()
            : base()
        {
        }


        public override bool IsValid(object? value)
        {
            if (value == null) return true;
            if (value is not string) return false;

            return Validator.ValidateCedula((string)value);
        }
    }
}



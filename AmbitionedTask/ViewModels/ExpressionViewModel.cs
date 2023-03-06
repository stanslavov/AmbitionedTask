using AmbitionedTask.Models;
using System.ComponentModel.DataAnnotations;

namespace AmbitionedTask.ViewModels
{
    public class ExpressionViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = Constants.ErrorMessageMinLength)]
        [MaxLength(20)]
        [CustomValidation(ErrorMessage = Constants.ErrorMessage)]
        public string Expression { get; set; }

        public Number Result { get; set; }
    }

    public class CustomValidationAttribute : ValidationAttribute
    {
        private readonly char[] notAllowedCharacters;

        public CustomValidationAttribute()
        {
            this.notAllowedCharacters = Constants.NotAllowedCharacters.ToCharArray();
        }

        public override bool IsValid(object value)
        {
            string strValue = value as string;

            foreach (var item in this.notAllowedCharacters)
            {
                if (strValue.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

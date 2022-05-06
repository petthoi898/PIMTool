using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PIMTool.Client.ValidationRule
{
    public class BaseValidationRule : System.Windows.Controls.ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, string.Empty);
            }
            return ValidationResult.ValidResult;
        }
    }
}

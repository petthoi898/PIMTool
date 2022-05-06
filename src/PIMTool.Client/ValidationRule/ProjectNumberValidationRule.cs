using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PIMTool.Client.ValidationRule
{
    public class ProjectNumberValidationRule : System.Windows.Controls.ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, string.Empty);
            }
            else if (!int.TryParse(value.ToString(), out int _))
            {
                return new ValidationResult(false, string.Empty);
            }

            return ValidationResult.ValidResult;

        }
        
    }

}
using Bakery.Wpf.Common;
using Covid19Screening.Wpf.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Covid19Screening.Wpf.ViewModels
{
    public class AddTestResultViewModel : BaseViewModel
    {
        public AddTestResultViewModel(IWindowController controller) : base(controller)
        {
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}

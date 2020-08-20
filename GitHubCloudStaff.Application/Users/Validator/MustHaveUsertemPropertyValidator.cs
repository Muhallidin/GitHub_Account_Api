using FluentValidation.Validators;
using GitHubCloudStaff.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitHubCloudStaff.Application.Users.Validator
{
    public class MustHaveInvoiceItemPropertyValidator : PropertyValidator
    {
        public MustHaveInvoiceItemPropertyValidator()
            : base("Property (PropertyName) should not be empty list!")
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var list = context.PropertyValue as IList<UserProfileVm>;
            return list != null && list.Any();
        }
    }
}

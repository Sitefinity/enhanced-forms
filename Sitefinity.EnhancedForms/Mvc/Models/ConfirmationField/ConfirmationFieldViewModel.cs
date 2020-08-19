using System.ComponentModel;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.TextField;
using Telerik.Sitefinity.Localization;

namespace Sitefinity.EnhancedForms.Mvc.Models.ConfirmationField
{
    /// <inheritDocs />
    public class ConfirmationFieldViewModel : TextFieldViewModel
    {
        /// <summary>
        /// Gets or sets the second value field.
        /// </summary>
        /// <value>
        /// The second value field.
        /// </value>
        public string SecondValue { get; set; }

        /// <summary>
        /// Gets or sets the confirmation field title.
        /// </summary>
        /// <value>
        /// The confirmation field title.
        /// </value>
        public string ConfirmationTitle { get; set; }

        /// <summary>
        /// Gets or sets the confirmation placeholder.
        /// </summary>
        /// <value>
        /// The confirmation placeholder.
        /// </value>
        public string ConfirmationPlaceholder { get; set; }

        private ConfirmationValidatorDefinition validatorDefinition;

        /// <summary>
        /// Gets or sets a validation mechanism for the field.
        /// </summary>
        /// <value>The validation.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ConfirmationValidatorDefinition ConfirmValidatorDefinition
        {
            get
            {
                if (this.validatorDefinition == null)
                {
                    this.validatorDefinition = new ConfirmationValidatorDefinition
                    {
                        FieldsDoNotMatchMessage = Res.Get<EnhancedFormsResources>().FieldsDoNotMatchMessage
                    };
                }

                return this.validatorDefinition;
            }
            set
            {
                this.validatorDefinition = value;
            }
        }

        /// <summary>
        /// Gets the validation attributes.
        /// </summary>
        /// <value>
        /// The validation attributes.
        /// </value>
        public new string ValidationAttributes { get; internal set; }

        /// <summary>
        /// Gets or sets the main field required error message.
        /// </summary>
        /// <value>
        /// The main field required error message.
        /// </value>
        public string MainFieldRequiredViolationMessage { get; set; }

        /// <summary>
        /// Gets or sets the confirmation field required error message.
        /// </summary>
        /// <value>
        /// The confirmation field required error message.
        /// </value>
        public string ConfirmationFieldRequiredViolationMessage { get; set; }

        /// <summary>
        /// Gets or sets the default message shown when max length validation has failed.
        /// </summary>
        /// <value>The max length violation message.</value>
        public string MaxLengthViolationMessage { get; set; }
    }
}

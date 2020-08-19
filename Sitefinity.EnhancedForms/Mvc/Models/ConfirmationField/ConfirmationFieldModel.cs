using System.ComponentModel;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.TextField;
using Telerik.Sitefinity.Frontend.Forms.Mvc.StringResources;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Services;

namespace Sitefinity.EnhancedForms.Mvc.Models.ConfirmationField
{
    /// <summary>
    /// This class represents the model used for confirmation field widget.
    /// </summary>
    public class ConfirmationFieldModel : TextFieldModel
    {
        /// <summary>
        /// Gets or sets the first value field.
        /// </summary>
        /// <value>
        /// The first value field.
        /// </value>
        public string FirstValue { get; set; }

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
        public string ConfirmationTitle
        {
            get
            {
                if (this.confirmationTitle == null)
                {
                    this.confirmationTitle = string.Format("{0} {1}", Res.Get<EnhancedFormsResources>().Confirm, this.MetaField.Title);
                }

                return this.confirmationTitle;
            }
            set
            {
                this.confirmationTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets the confirmation placeholder.
        /// </summary>
        /// <value>
        /// The confirmation placeholder.
        /// </value>
        public string ConfirmationPlaceholder { get; set; }

        /// <summary>
        /// Gets or sets the confirmation default value.
        /// </summary>
        /// <value>
        /// The confirmation default value.
        /// </value>
        public string ConfirmationDefaultValue { get; set; }

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
                        FieldsDoNotMatchMessage = Res.Get<EnhancedFormsResources>().FieldsDoNotMatchMessage,
                        RequiredViolationMessage = Res.Get<FormResources>().RequiredInputErrorMessage
                    };
                }

                return this.validatorDefinition;
            }
            set
            {
                this.validatorDefinition = value;
            }
        }

        /// <inheritDocs />
        public override object GetViewModel(object value, IMetaField metaField)
        {
            this.Value = value;
            var valueAsString = value as string;

            var viewModel = new ConfirmationFieldViewModel()
            {
                Value = valueAsString ?? this.MetaField.DefaultValue ?? string.Empty,
                SecondValue = valueAsString ?? this.ConfirmationDefaultValue ?? string.Empty,
                MetaField = metaField,
                ValidationAttributes = this.BuildValidationAttributes(),
                CssClass = this.CssClass,
                ValidatorDefinition = this.ValidatorDefinition,
                MainFieldRequiredViolationMessage = BuildErrorMessage(this.ValidatorDefinition.RequiredViolationMessage, metaField.Title),
                ConfirmationFieldRequiredViolationMessage = BuildErrorMessage(this.ValidatorDefinition.RequiredViolationMessage, this.ConfirmationTitle),
                MaxLengthViolationMessage = BuildErrorMessage(this.ValidatorDefinition.MaxLengthViolationMessage, metaField.Title),
                PlaceholderText = this.PlaceholderText,
                InputType = this.InputType,
                Hidden = this.Hidden && (!SystemManager.IsDesignMode || SystemManager.IsPreviewMode),
                ConfirmationTitle = this.ConfirmationTitle,
                ConfirmationPlaceholder = this.ConfirmationPlaceholder,
                ConfirmValidatorDefinition = this.ConfirmValidatorDefinition
            };

            return viewModel;
        }

        private string confirmationTitle;
    }
}

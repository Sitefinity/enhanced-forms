using System.ComponentModel;
using System.Text;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.TextField;
using Telerik.Sitefinity.Frontend.Forms.Mvc.StringResources;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Modules.Forms.Web.UI;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI.Validation.Definitions;

namespace Sitefinity.EnhancedForms.Mvc.Models.DateField
{
    /// <summary>
    /// This class represents the model used for date field widget.
    /// </summary>
    public class DateFieldModel : FormFieldModel, IHideable
    {
        public DateFieldModel()
        {
            this.InputType = TextType.Date;
        }

        /// <inheritDocs />
        public string PlaceholderText { get; set; }

        /// <inheritDocs />
        public TextType InputType { get; set; }

        /// <inheritDocs />
        public bool Hidden { get; set; }

        /// <summary>
        /// Gets or sets a validation mechanism for the field.
        /// </summary>
        /// <value>The validation.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public override ValidatorDefinition ValidatorDefinition
        {
            get
            {
                if (this.validatorDefinition == null)
                {
                    this.validatorDefinition = new ValidatorDefinition
                    {
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
        public override IMetaField GetMetaField(IFormFieldControl formFieldControl)
        {
            var metaField = base.GetMetaField(formFieldControl);

            if (string.IsNullOrEmpty(metaField.Title))
                metaField.Title = Res.Get<FieldResources>().Untitled;

            return metaField;
        }

        /// <inheritDocs />
        public override object GetViewModel(object value, IMetaField metaField)
        {
            this.Value = value;
            var viewModel = new DateFieldViewModel()
            {
                Value = value as string ?? this.MetaField.DefaultValue ?? string.Empty,
                MetaField = this.MetaField,
                ValidationAttributes = this.BuildValidationAttributes(),
                CssClass = this.CssClass,
                ValidatorDefinition = this.ValidatorDefinition,
                RequiredViolationMessage = BuildErrorMessage(this.ValidatorDefinition.RequiredViolationMessage, metaField.Title),
                PlaceholderText = this.PlaceholderText,
                InputType = this.InputType,
                Hidden = this.Hidden && (!SystemManager.IsDesignMode || SystemManager.IsPreviewMode)
            };

            return viewModel;
        }

        /// <inheritDocs />
        protected override string BuildValidationAttributes()
        {
            var attributes = new StringBuilder();

            if (this.ValidatorDefinition.Required.HasValue && this.ValidatorDefinition.Required.Value)
                attributes.Append(@"required=""required"" ");

            return attributes.ToString();
        }

        private ValidatorDefinition validatorDefinition;
    }
}
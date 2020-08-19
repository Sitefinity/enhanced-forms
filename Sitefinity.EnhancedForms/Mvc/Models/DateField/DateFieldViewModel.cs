using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.TextField;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Web.UI.Validation.Definitions;

namespace Sitefinity.EnhancedForms.Mvc.Models.DateField
{
    /// <summary>
    /// This class represents view model for date field.
    /// </summary>
    public class DateFieldViewModel
    {
        /// <summary>
        /// Gets or sets the placeholder text.
        /// </summary>
        /// <value>
        /// The placeholder text.
        /// </value>
        public string PlaceholderText { get; set; }

        /// <summary>
        /// Gets or sets the type of the date element.
        /// </summary>
        /// <value>
        /// The type of the input element.
        /// </value>
        public TextType InputType { get; set; }

        /// <summary>
        /// Gets or sets the value of the form field.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the CSS class.
        /// </summary>
        /// <value>
        /// The CSS class.
        /// </value>
        public string CssClass { get; set; }

        /// <summary>
        /// Gets the validation attributes.
        /// </summary>
        /// <value>
        /// The validation attributes.
        /// </value>
        public string ValidationAttributes { get; internal set; }

        /// <summary>
        /// Gets or sets a validation mechanism for the control.
        /// </summary>
        /// <value>
        /// The validation definition.
        /// </value>
        public ValidatorDefinition ValidatorDefinition { get; set; }

        /// <summary>
        /// Gets or sets the required error message.
        /// </summary>
        /// <value>
        /// The required error message.
        /// </value>
        public string RequiredViolationMessage { get; set; }

        /// <summary>
        /// Gets or sets the meta field.
        /// </summary>
        /// <value>
        /// The meta field.
        /// </value>
        public IMetaField MetaField { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the form field visibility.
        /// </summary>
        /// <value>
        /// Is field visible.
        /// </value>
        public bool Hidden { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel;
using Sitefinity.EnhancedForms.Mvc.Models.DateField;
using Telerik.Sitefinity.Data.Metadata;
using Telerik.Sitefinity.Forms.Model;
using Telerik.Sitefinity.Frontend.Forms;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Controllers.Base;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.TextField;
using Telerik.Sitefinity.Frontend.Forms.Mvc.StringResources;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Telerik.Sitefinity.Modules.Pages.Web.Services;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web.UI.Fields.Enums;

namespace Sitefinity.EnhancedForms.Mvc.Controllers
{
    /// <summary>
    /// This class represents the controller of the date field.
    /// </summary>
    [ControllerToolboxItem(Name = "DateField", Title = "Date", Toolbox = FormsConstants.FormControlsToolboxName, CssClass = "sfTextboxIcn sfMvcIcn", SectionName = "Common")]
    [DatabaseMapping(UserFriendlyDataType.ShortText)]
    [Localization(typeof(FieldResources))]

    public class DateFieldController : FormFieldControllerBase<DateFieldModel>, ISupportRules, ITextField
    {
        /// <inheritDocs />
        public DateFieldController()
        {
            this.DisplayMode = FieldDisplayMode.Write;
        }

        /// <inheritDocs />
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ReflectInheritedProperties]
        public override DateFieldModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new DateFieldModel();

                return this.model;
            }
        }

        IDictionary<ConditionOperator, string> ISupportRules.Operators
        {
            get
            {
                return new Dictionary<ConditionOperator, string>()
                {
                    { ConditionOperator.Equal, Res.Get<Labels>().IsOperator },
                    { ConditionOperator.IsLessThan, Res.Get<Labels>().IsBeforeOperator },
                    { ConditionOperator.IsGreaterThan, Res.Get<Labels>().IsAfterOperator },
                    { ConditionOperator.IsFilled, Res.Get<Labels>().IsFilledOperator },
                    { ConditionOperator.IsNotFilled, Res.Get<Labels>().IsNotFilledOperator }
                };
            }
        }

        TextType ITextField.InputType
        {
            get
            {
                return this.Model.InputType;
            }
        }

        string ISupportRules.Title
        {
            get
            {
                return this.MetaField.Title;
            }
        }

        private DateFieldModel model;
    }
}
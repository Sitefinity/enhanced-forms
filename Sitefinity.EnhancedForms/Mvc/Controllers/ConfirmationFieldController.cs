using System.ComponentModel;
using Sitefinity.EnhancedForms.Mvc.Models.ConfirmationField;
using Telerik.Sitefinity.Data.Metadata;
using Telerik.Sitefinity.Frontend.Forms;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Controllers;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.TextField;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web.UI.Fields.Enums;

namespace Sitefinity.EnhancedForms.Mvc.Controllers
{
     /// <summary>
     /// This class represents the controller of the confirmation field.
     /// </summary>
    [ControllerToolboxItem(Name = "ConfirmationField", Title = "Confirmation field", Toolbox = FormsConstants.FormControlsToolboxName, CssClass = "sfTextboxIcn sfMvcIcn", SectionName = "Common")]
    [DatabaseMapping(UserFriendlyDataType.ShortText)]
    [Localization(typeof(EnhancedFormsResources))]
    public class ConfirmationFieldController : TextFieldController
    {
        public ConfirmationFieldController()
        {
            this.DisplayMode = FieldDisplayMode.Write;
        }

        /// <inheritDocs />
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public override ITextFieldModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new ConfirmationFieldModel();

                return this.model;
            }
        }

        private ITextFieldModel model;
    }
}

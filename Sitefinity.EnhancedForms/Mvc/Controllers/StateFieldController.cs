using System.ComponentModel;
using Sitefinity.EnhancedForms.Mvc.Models.StateField;
using Telerik.Sitefinity.Data.Metadata;
using Telerik.Sitefinity.Frontend.Forms;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Controllers;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.DropdownListField;
using Telerik.Sitefinity.Frontend.Forms.Mvc.StringResources;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Web.UI.Fields.Enums;

namespace Sitefinity.EnhancedForms.Mvc.Controllers
{
    /// <summary>
    /// This class represents the controller of the state field.
    /// </summary>
    [Localization(typeof(FieldResources))]
    [ControllerToolboxItem(Name = "StateField", Title = "State", Toolbox = FormsConstants.FormControlsToolboxName, CssClass = "sfDropdownIcn sfMvcIcn", SectionName = "Common")]
    [DatabaseMapping(UserFriendlyDataType.ShortText)]
    public class StateFieldController : DropdownListFieldController
    {
        public StateFieldController()
        {
            this.DisplayMode = FieldDisplayMode.Write;
        }

        /// <inheritDocs />
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public override IDropdownListFieldModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new StateFieldModel();

                return this.model;
            }
        }

        private StateFieldModel model;
    }
}

using System.ComponentModel;
using Sitefinity.EnhancedForms.Mvc.Models.CountryField;
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
    /// This class represents the controller of the country field.
    /// </summary>
    [Localization(typeof(FieldResources))]
    [ControllerToolboxItem(Name = "CountryField", Title = "Country", Toolbox = FormsConstants.FormControlsToolboxName, CssClass = "sfDropdownIcn sfMvcIcn", SectionName = "Common")]
    [DatabaseMapping(UserFriendlyDataType.ShortText)]
    public class CountryFieldController : DropdownListFieldController
    {
        public CountryFieldController()
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
                    this.model = new CountryFieldModel();

                return this.model;
            }
        }

        private CountryFieldModel model;
    }
}

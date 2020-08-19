using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.DropdownListField;
using Telerik.Sitefinity.Frontend.Forms.Mvc.StringResources;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Locations;
using Telerik.Sitefinity.Locations.Configuration;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;

namespace Sitefinity.EnhancedForms.Mvc.Models.CountryField
{
    /// <summary>
    /// This class represents the model used for country field widget.
    /// </summary>
    /// <seealso cref="Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.DropdownListField.DropdownListFieldModel" />
    public class CountryFieldModel : DropdownListFieldModel
    {
        /// <inheritDocs />
        public override string BuildInitialChoicesString()
        {
            var countries = new List<string>();
            countries.Add(Res.Get<FieldResources>().OptionSelect);
            var activeCountries = Telerik.Sitefinity.Configuration.Config.Get<LocationsConfig>().Countries.Values
                .Where(x => x.CountryIsActive).OrderBy(x => x.Name).ToList();

            foreach (CountryElement country in activeCountries)
            {
                countries.Add(country.Name);
            }

            string initialChoices = new JavaScriptSerializer().Serialize(countries);

            return initialChoices;
        }

        /// <inheritDocs />
        public override IMetaField GetMetaField(IFormFieldControl formFieldControl)
        {
            var metaField = base.GetMetaField(formFieldControl);
            metaField.Title = Res.Get<EnhancedFormsResources>().Country;

            return metaField;
        }
    }
}

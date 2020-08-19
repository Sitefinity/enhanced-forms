using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.DropdownListField;
using Telerik.Sitefinity.Frontend.Forms.Mvc.StringResources;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Locations.Configuration;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;

namespace Sitefinity.EnhancedForms.Mvc.Models.StateField
{
    /// <summary>
    /// This class represents the model used for state field widget.
    /// </summary>
    /// <seealso cref="Telerik.Sitefinity.Frontend.Forms.Mvc.Models.Fields.DropdownListField.DropdownListFieldModel" />
    public class StateFieldModel : DropdownListFieldModel
    {
        /// <inheritDocs />
        public override string BuildInitialChoicesString()
        {
            var states = new List<string>();
            states.Add(Res.Get<FieldResources>().OptionSelect);
            var selectedCountryStates = this.ActiveCountriesWithStates[this.SelectedCountry];

            if (selectedCountryStates != null)
            {
                foreach (var state in selectedCountryStates)
                {
                    states.Add(state);
                }
            }

            string initialChoices = new JavaScriptSerializer().Serialize(states);

            return initialChoices;
        }

        /// <inheritDocs />
        public override IMetaField GetMetaField(IFormFieldControl formFieldControl)
        {
            var metaField = base.GetMetaField(formFieldControl);
            metaField.Title = Res.Get<EnhancedFormsResources>().State;

            return metaField;
        }

        /// <summary>
        /// Gets or sets the selected country.
        /// </summary>
        /// <value>
        /// The selected country.
        /// </value>
        public string SelectedCountry
        {
            get
            {
                if (this.selectedCountry == null)
                {
                    this.selectedCountry = this.ActiveCountriesWithStates.Keys.FirstOrDefault();
                }

                return this.selectedCountry;
            }
            set
            {
                this.selectedCountry = value;
            }
        }

        /// <summary>
        /// Gets the active countries with states serialized.
        /// </summary>
        /// <value>
        /// The active countries with states serialized.
        /// </value>
        public string ActiveCountriesWithStatesSerialized
        {
            get
            {
                if (this.activeCountriesWithStatesSerialized == null)
                {
                    this.activeCountriesWithStatesSerialized = new JavaScriptSerializer().Serialize(this.ActiveCountriesWithStates);
                }

                return this.activeCountriesWithStatesSerialized;
            }
        }

        private Dictionary<string, List<string>> ActiveCountriesWithStates
        {
            get
            {
                if (this.activeCountriesWithStates == null)
                {
                    this.activeCountriesWithStates = Telerik.Sitefinity.Configuration.Config.Get<LocationsConfig>().Countries.Values
                        .Where(x => x.CountryIsActive && x.StatesProvinces.Keys.Count > 0)
                        .ToDictionary(c => c.Name, d => d.StatesProvinces.Elements.Select(e => e.Name).ToList());
                }

                return this.activeCountriesWithStates;
            }
        }

        private string selectedCountry;
        private Dictionary<string, List<string>> activeCountriesWithStates;
        private string activeCountriesWithStatesSerialized;
    }
}

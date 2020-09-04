using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Frontend.Forms;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.Pages.Configuration;

namespace Sitefinity.EnhancedForms
{
    public sealed class Installer
    {
        private Installer()
        {
        }

        /// <summary>
        /// Subscribe to Sitefinity events
        /// </summary>
        public static void PreApplicationStart()
        {
            Bootstrapper.Bootstrapped += Installer.Bootstrapper_Bootstrapped;
        }

        private static void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
            // Register the Resource class
            Res.RegisterResource<EnhancedFormsResources>();
            OrderEnhancedFormsFields();
        }

        private static void OrderEnhancedFormsFields()
        {
            var configManager = Config.GetManager();
            var toolboxConfig = configManager.GetSection<ToolboxesConfig>();

            var toolboxItems = toolboxConfig.Toolboxes[FormsConstants.FormControlsToolboxName]
                .Sections.ToList<ToolboxSection>()
                .Where(g => g.Name == FormsConstants.CommonSectionName)
                .FirstOrDefault().Tools
                .ToList<ToolboxItem>();

            var allItemsCount = toolboxItems.Count;

            if (AreEnhancedFormsWidgetsLoaded(toolboxItems))
            {
                // Set the ordinal only if it is not already set
                if (!AreEnhancedFormsWidgetsOrdinalsSet(toolboxItems))
                {
                    toolboxItems.First(i => i.Name.Equals("CountryField")).Ordinal = allItemsCount++;
                    toolboxItems.First(i => i.Name.Equals("StateField")).Ordinal = allItemsCount++;
                    toolboxItems.First(i => i.Name.Equals("ConfirmationField")).Ordinal = allItemsCount++;
                    toolboxItems.First(i => i.Name.Equals("DateField")).Ordinal = allItemsCount;

                    using (new ElevatedModeRegion(configManager))
                    {
                        configManager.SaveSection(toolboxConfig);
                    }
                }
            }
        }

        private static bool AreEnhancedFormsWidgetsLoaded(List<ToolboxItem> toolboxItems)
        {
            if (toolboxItems.Any(i => i.Name.Equals("CountryField")) &&
                toolboxItems.Any(i => i.Name.Equals("StateField")) &&
                toolboxItems.Any(i => i.Name.Equals("ConfirmationField")) &&
                toolboxItems.Any(i => i.Name.Equals("DateField")))
            {
                return true;
            }

            return false;
        }

        private static bool AreEnhancedFormsWidgetsOrdinalsSet(List<ToolboxItem> toolboxItems)
        {
            var countryFieldOrdinal = toolboxItems.First(i => i.Name.Equals("CountryField")).Ordinal;
            var stateFieldOrdinal = toolboxItems.First(i => i.Name.Equals("StateField")).Ordinal;
            var confirmationFieldOrdinal = toolboxItems.First(i => i.Name.Equals("ConfirmationField")).Ordinal;
            var dateFieldOrdinal = toolboxItems.First(i => i.Name.Equals("DateField")).Ordinal;

            if (countryFieldOrdinal < 1 && stateFieldOrdinal < 1 && confirmationFieldOrdinal < 1 && dateFieldOrdinal < 1)
            {
                return false;
            }

            return true;
        }
    }
}

using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace Sitefinity.EnhancedForms
{
    /// <summary>
    /// Enhanced forms localization resources
    /// </summary>
    /// <seealso cref="Telerik.Sitefinity.Localization.Resource" />
    public class EnhancedFormsResources : Resource
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedFormsResources"/> class. 
        /// Initializes new instance of <see cref="EnhancedFormsResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public EnhancedFormsResources()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedFormsResources"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        public EnhancedFormsResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }

        #endregion

        /// <summary>
        /// Gets phrase : State
        /// </summary>
        [ResourceEntry("State",
            Value = "State",
            Description = "phrase : State",
            LastModified = "2019/05/14")]
        public string State
        {
            get
            {
                return this["State"];
            }
        }

        /// <summary>
        /// Gets phrase : States
        /// </summary>
        [ResourceEntry("States",
            Value = "States",
            Description = "phrase : States",
            LastModified = "2019/05/14")]
        public string States
        {
            get
            {
                return this["States"];
            }
        }

        /// <summary>
        /// Gets phrase : Country
        /// </summary>
        [ResourceEntry("Country",
            Value = "Country",
            Description = "phrase : Country",
            LastModified = "2019/05/14")]
        public string Country
        {
            get
            {
                return this["Country"];
            }
        }

        /// <summary>
        /// Gets fields do not match message
        /// </summary>
        [ResourceEntry("FieldsDoNotMatchMessage",
            Value = "The entered values do not match",
            Description = "The entered values do not match",
            LastModified = "2019/05/13")]
        public string FieldsDoNotMatchMessage
        {
            get { return this["FieldsDoNotMatchMessage"]; }
        }

        /// <summary>
        /// Gets main field label
        /// </summary>
        [ResourceEntry("MainFieldLabel",
            Value = "Main field",
            Description = "Main field",
            LastModified = "2020/06/10")]
        public string MainFieldLabel
        {
            get { return this["MainFieldLabel"]; }
        }

        /// <summary>
        /// Gets confirmation field label
        /// </summary>
        [ResourceEntry("ConfirmationFieldLabel",
            Value = "Confirmation field",
            Description = "Confirmation field",
            LastModified = "2020/06/10")]
        public string ConfirmationFieldLabel
        {
            get { return this["ConfirmationFieldLabel"]; }
        }

        /// <summary>
        /// Gets fields do not match error title
        /// </summary>
        [ResourceEntry("FieldsDoNotMatchErrorTitle",
            Value = "Error message displayed when fields don't match",
            Description = "Error message displayed when fields don't match",
            LastModified = "2019/05/14")]
        public string FieldsDoNotMatchErrorTitle
        {
            get { return this["FieldsDoNotMatchErrorTitle"]; }
        }

        /// <summary>
        /// Gets time label
        /// </summary>
        [ResourceEntry("Time",
            Value = "Time",
            Description = "Time",
            LastModified = "2019/05/14")]
        public string Time
        {
            get { return this["Time"]; }
        }

        /// <summary>
        /// Gets month label
        /// </summary>
        [ResourceEntry("Month",
            Value = "Month",
            Description = "Month",
            LastModified = "2019/05/14")]
        public string Month
        {
            get { return this["Month"]; }
        }

        /// <summary>
        /// Gets date time label
        /// </summary>
        [ResourceEntry("DateTime",
            Value = "Date and time",
            Description = "Date Time",
            LastModified = "2019/05/14")]
        public string DateTime
        {
            get { return this["DateTime"]; }
        }

        /// <summary>
        /// Gets date label
        /// </summary>
        [ResourceEntry("Date",
            Value = "Date",
            Description = "Date",
            LastModified = "2019/05/14")]
        public string Date
        {
            get { return this["Date"]; }
        }

        /// <summary>
        /// Gets phrase : Example: Date
        /// </summary>
        [ResourceEntry("ExampleDate",
            Value = "Example: Date",
            Description = "ExampleDate",
            LastModified = "2020/06/09")]
        public string ExampleDate
        {
            get { return this["ExampleDate"]; }
        }

        /// <summary>
        /// Gets phrase : Example: Password
        /// </summary>
        [ResourceEntry("ExamplePassword",
            Value = "Example: Password",
            Description = "ExamplePassword",
            LastModified = "2020/06/10")]
        public string ExamplePassword
        {
            get { return this["ExamplePassword"]; }
        }

        /// <summary>
        /// Gets phrase : Example: Confirm password
        /// </summary>
        [ResourceEntry("ExampleConfirmPassword",
            Value = "Example: Confirm password",
            Description = "ExampleConfirmPassword",
            LastModified = "2020/06/10")]
        public string ExampleConfirmPassword
        {
            get { return this["ExampleConfirmPassword"]; }
        }

        /// <summary>
        /// Gets confirm label
        /// </summary>
        [ResourceEntry("Confirm",
            Value = "Confirm",
            Description = "Confirm",
            LastModified = "2020/06/10")]
        public string Confirm
        {
            get { return this["Confirm"]; }
        }
    }
}

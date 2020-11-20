Progress® Sitefinity® CMS Enhanced MVC Forms Widgets
====================================================

> **Latest supported version**: Sitefinity CMS 13.1.7400.0

## Overview

In this repository you can find multiple MVC widgets which you can use to extend the functionality provided by the built-in [MVC forms](https://www.progress.com/documentation/sitefinity-cms/forms).

This GitHub repository contains the source code for the following widgets:

### `CountryField` and `StateField`

You use these form fields to enabe your site visitors to choose their country and state.

These controls are based on the `Dropdown list` control. To learn how to configure their properties, see [Dropdown list](https://www.progress.com/documentation/sitefinity-cms/dropdown-list).

You may change which countries are shown in these controls. To do this, perform the following:
* Open your Sitefinity CMS backend.
* Navigate to *Administration » Settings » Advanced*.
* Navigate to *Locations » Countries  » (country code)*
* Adjust the list of countries.
* To modify the states for each country, perform the following:
  * Navigate to a country as described above
  * Click *StatesProvinces* sub-node

By default, these controls are independant. You need to implement specific logic, such as changing the list of states when a country selection changes. For more information, see [Form rules](https://www.progress.com/documentation/sitefinity-cms/form-rules).

### `DateField`

You use the `DateField` to enable your site visitors to pick date and time.

This control is based on the `Textbox` control.  To learn how to configure their properties, see [Textbox](https://www.progress.com/documentation/sitefinity-cms/textbox).

Additionally, you may use this control on four modes:

* __Date__: your visitors can input only calendar date
* __Date Time__: your visitors can input both calendar date and clock time
* __Month__: your visitors can input only a specific combination of month and year
* __Time__: your visitors can input only clock time

To set the control mode, you use the control's *Type* property.

This control uses the Kendo UI DateTime picker. If you want to customize it's behavior, such as the date and time format used, refer to [kendo.ui.DateTimePicker](https://docs.telerik.com/kendo-ui/api/javascript/ui/datetimepicker).


### `ConfirmationField`

You use the `ConfirmationField` to create user interfaces where your visitors confirm their input. Using this widget, you force your visitors to enter some important piece of information, such as e-mail or password, two times and then ensure that they can submit the form content only if the two values match.
To implement this functionality, the control provides two `Textbox` input fields and validates that their content is the same.

This control is based on the `Textbox` control. To learn how to configure their properties, see [Textbox](https://www.progress.com/documentation/sitefinity-cms/textbox).

## Prerequisites

To use these widgets, you need to build them from the source code. Make sure that your development system meets the following minimal requirements:

* A valid Sitefinity CMS license.
* Sitefinity CMS 13.0 or later.
* Your setup must comply with the minimum system requirements.
For more information, see the [System requirements](https://www.progress.com/documentation/sitefinity-cms/system-requirements) for the Sitefinity CMS version you are using.
* Visual Studio 2015 or later.

## Building the widgets

This readme file assumes that you are using Visual Studio 2019. The older versions of Visual Studio may have small changes in the described UI elements but the process is very similar.

To use `Sitefinity.EnhancedForms` with your Sitefinity CMS site perform the following:

1. Download this repository it into your Sitefinity CMS solution on your local drive
2. In Visual Studio open your Sitefinity solution, for example `SitefinityWebApp.sln`.
3. Add the downloaded `Sitefinity.EnhancedForms.csproj` to your Visual Studio solution. Perform the following:
   1. Navigate to *File » Add » Existing project...*
   2. Browse to `c:\work\sitefinity-enhanced-forms`. The exact path depends on where you have cloned the repository
   3. Browse to Sitefinity.EnhancedForms
   4. Select `Sitefinity.EnhancedForms.csproj` and click *Open*.
4. In your main Sitefinity project, for example `SitefinityWebApp`, add a project reference to the `Sitefinity.EnhancedForms` project. Perform the following:
   1. Select your main Sitefinity project, for example `SitefinityWebApp` in the *Solution Explorer*
   2. In the main menu, Navigate to Project » Add Reference... A dialog opens.
   3. Navigate to *Project » Solution*.
   4. Check the `Sitefinity.EnhancedForms` in the list on the right.
   5. Click *OK*
5. Copy the new Bootstrap 4 templates in your Sitefinity project
	1. Open the `Sitefinity.EnhancedForms.csproj` file for edit.
	2. Find the Target tag with `Name="CopyFeatherPackages"`.
	3. Edit the `DestinationFolder` attribute to point to `[YourSitefinityProjectPath]\ResourcePackages\Bootstrap4\%(RecursiveDir)`.
	4. Save the file and reload the project.
6. Build your Visual Studio solution.

## Using the widgets in your project

After you build the `Sitefinity.EnhancedForms` project, you can use the new form widgets in your projects' frontend. To do this, perform the following:

* Start your Sitefinity CMS solution
* In the browser, navigate to your Sitefinity CMS backend
* Navigate to Content » Forms and create a new form or edit an exisitng one
* In the *Common controls* toolbox you see four new controls: `Country`, `State`, `Date`, and `Confirmation field`.
* Drag and drop them as any other form control.
* Click *Publish* to save your form.


*Note:* The enhanced forms project depends on specific NuGet packages for Sitefinity CMS. When you include the enhanced forms project in your solution that depends on a newer Sitefinity version, you must also update the ```Telerik.Sitefinity.Feather``` dependency of the enhanced forms project to match your Sitefinity version.

The ```Feather``` package comes with a lot of content inside the ```ResourcePackages``` folder. However, you need only the views for the enhanced forms fields.  

IMPORTANT: After you update the enhanced forms project in your solution, you must delete all of the content inside the ```ResourcePackages``` folder, except the one needed by the enhanced forms fields. Your folder structure should look like this:

 
```bash

ResourcePackages

   Bootstrap4

      MVC

         Views

            ConfirmationField

            CountryField

            DateField

            StateField

      razorgenerator.directives

 ``` 

To prevent build errors, you must delete all other files generated after the ```Telerik.Sitefinity.Feather``` package upgrade completes.

## More information

The source code in this repository is not supported by Progress. However, you may create pull requests and open issues in this repository and the Sitefinity team will address them.

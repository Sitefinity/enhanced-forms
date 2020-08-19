(function ($) {
    $(function () {

        // kedno pickers default formats
        var defaultFormats = {
            dateFormat: "M/d/yyyy",
            dateTimeLocalFormat: "M/d/yyyy h:mm tt",
            monthFormat: "MMMM yyyy",
            timeFormat: "hh:mm tt"
        };

        if (typeof FormRulesSettings !== "undefined") {

            var dateFieldDateParserFunction = function (value) {
                var dateTime = new Date(value);
                var date = new Date(dateTime.getFullYear(), dateTime.getMonth(), dateTime.getDate());

                return date.getTime();
            };

            var dateFieldDateInputTypeParserFunction = function (value) {
                // default format for kendo datepicker: M/d/yyyy
                var parsedDate = kendo.parseExactDate(value, defaultFormats.dateFormat);
                var dateTime = new Date(parsedDate);
                var date = new Date(dateTime.getFullYear(), dateTime.getMonth(), dateTime.getDate());

                return date.getTime();
            };

            var dateFieldMonthParserFunction = function (value, timezoneOffset) {
                var dateTime = new Date(value);

                if (timezoneOffset) {
                    dateTime.setTime(dateTime.getTime() + timezoneOffset);
                }

                var date = new Date(dateTime.getFullYear(), dateTime.getMonth());

                return date.getTime();
            };

            var dateFieldMonthInputTypeParserFunction = function (value, timezoneOffset) {
                // selected format for month selector : MMMM yyyy
                var parsedDate = kendo.parseExactDate(value, defaultFormats.monthFormat);
                var dateTime = new Date(parsedDate);

                if (timezoneOffset) {
                    dateTime.setTime(dateTime.getTime() + timezoneOffset);
                }

                var date = new Date(dateTime.getFullYear(), dateTime.getMonth());

                return date.getTime();
            };

            var dateFieldDateTimeParserFunction = function (value, timezoneOffset) {
                var dateTime = new Date(value);
                var date = new Date(dateTime.getFullYear(), dateTime.getMonth(), dateTime.getDate(), dateTime.getHours(), dateTime.getMinutes());

                if (timezoneOffset) {
                    date = new Date(date.getTime() + timezoneOffset);
                }

                return date.getTime();
            };

            var dateFieldDateTimeInputTypeParserFunction = function (value, timezoneOffset) {
                // default format for kendo datetimepicker: M/d/yyyy h:mm tt
                var parsedDate = kendo.parseExactDate(value, defaultFormats.dateTimeLocalFormat);
                var dateTime = new Date(parsedDate);
                var date = new Date(dateTime.getFullYear(), dateTime.getMonth(), dateTime.getDate(), dateTime.getHours(), dateTime.getMinutes());

                if (timezoneOffset) {
                    date = new Date(date.getTime() + timezoneOffset);
                }

                return date.getTime();
            };

            var dateFieldTimeParserFunction = function (value, timezoneOffset) {
                var dateTime = new Date(value);

                if (timezoneOffset) {
                    dateTime = new Date(dateTime.getTime() + timezoneOffset);
                }

                return dateTime.getHours() * 60 + dateTime.getMinutes();
            };

            var dateFieldTimeInputTypeParserFunction = function (value, timezoneOffset) {
                // default format for kendo timepicker: hh:mm tt
                var parsedDate = kendo.parseExactDate(value, defaultFormats.timeFormat);
                var dateTime = new Date(parsedDate);

                if (timezoneOffset) {
                    dateTime = new Date(dateTime.getTime() + timezoneOffset);
                }

                return dateTime.getHours() * 60 + dateTime.getMinutes();
            };

            FormRulesSettings.addFieldSelector("date-field-container", "[data-sf-role='date-field-input']");

            FormRulesSettings.addInputTypeParser("Date", dateFieldDateInputTypeParserFunction);
            FormRulesSettings.addInputTypeParser("DateTimeLocal", dateFieldDateTimeInputTypeParserFunction);
            FormRulesSettings.addInputTypeParser("Month", dateFieldMonthInputTypeParserFunction);
            FormRulesSettings.addInputTypeParser("Time", dateFieldTimeInputTypeParserFunction);

            FormRulesSettings.addRuleValueParser("Date", dateFieldDateParserFunction);
            FormRulesSettings.addRuleValueParser("DateTimeLocal", function (value) { return dateFieldDateTimeParserFunction(value, new Date(value).getTimezoneOffset() * 60000); });
            FormRulesSettings.addRuleValueParser("Month", dateFieldMonthParserFunction);
            FormRulesSettings.addRuleValueParser("Time", function (value) { return dateFieldTimeParserFunction(value, new Date(value).getTimezoneOffset() * 60000); });
        }

        function processRules(e) {
            if (typeof $.fn.processFormRules === 'function') {
                $(e.target).processFormRules();
            }
        }

        var delayTimer;
        function processRulesWithDelay(e) {
            clearTimeout(delayTimer);
            delayTimer = setTimeout(function () {
                processRules(e);
            }, 300);
        }

        function handleValidation(e) {
            if (typeof e.target.validity === 'undefined')
                return;

            if (e.target.required && e.target.validity.valueMissing) {
                var validationMessages = getValidationMessages(e.target);
                setErrorMessage(e.target, validationMessages.required);
            } else {
                setErrorMessage(e.target, '');
            }
        }

        function onChange(e) {
            handleValidation(e);
            processRules(e);
        }

        function onInput(e) {
            handleValidation(e);
            processRulesWithDelay(e);
        }

        function invalid(e) {
            if (_getErrorMessageContainer(e.target)) {
                e.preventDefault();
            }

            handleValidation(e);
        }

        function getValidationMessages(input) {
            var container = $(input).parents('[data-sf-role="date-field-container"]');
            var validationMessagesInput = $(container).find('[data-sf-role="violation-messages"]');
            var validationMessages = JSON.parse(validationMessagesInput.val());

            return validationMessages;
        }

        function setErrorMessage(input, message) {
            var errorMessagesContainer = _getErrorMessageContainer(input);

            if (errorMessagesContainer) {
                _toggleCustomErrorMessage(errorMessagesContainer, message);
            } else {
                input.setCustomValidity(message);
            }
        }

        function _toggleCustomErrorMessage(container, message) {
            container.innerText = message;

            if (message === '') {
                container.style.display = 'none';
            } else {
                container.style.display = 'block';
            }
        }

        function _getErrorMessageContainer(input) {
            var container = $(input).closest('[data-sf-role="date-field-container"]')[0];
            if (container) {
                var errorMessagesContainer = container.querySelector('[data-sf-role="error-message"]');
                return errorMessagesContainer;
            }

            return null;
        }

        function init() {
            var containers = $('[data-sf-role="date-field-container"]');

            if (!containers || containers.length < 1)
                return;

            for (var i = 0; i < containers.length; i++) {
                var input = $(containers[i]).find('[data-sf-role="date-field-input"]');

                switch (input.data("sf-input-type")) {
                    case "Date":
                        $("#" + input.attr("id")).kendoDatePicker();
                        validator(input.attr("id"), defaultFormats.dateFormat);
                        break;
                    case "DateTimeLocal":
                        $("#" + input.attr("id")).kendoDateTimePicker();
                        validator(input.attr("id"), defaultFormats.dateTimeLocalFormat);
                        break;
                    case "Month":
                        $("#" + input.attr("id")).kendoDatePicker({
                            // defines the start view
                            start: "year",

                            // defines when the calendar should return date
                            depth: "year",

                            // display month and year in the input
                            format: defaultFormats.monthFormat
                        });
                        validator(input.attr("id"), defaultFormats.monthFormat);
                        break;
                    case "Time":
                        $("#" + input.attr("id")).kendoTimePicker();
                        validator(input.attr("id"), defaultFormats.timeFormat);
                        break;
                    default:
                        break;
                }

                if (input) {
                    input.on('click', function () {
                        var calendarData = "";

                        switch ($(this).data("sf-input-type")) {
                            case "Date":
                                calendarData = "kendoDatePicker";
                                break;
                            case "DateTimeLocal":
                                calendarData = "kendoDateTimePicker";
                                break;
                            case "Month":
                                calendarData = "kendoDatePicker";
                                break;
                            case "Time":
                                calendarData = "kendoTimePicker";
                                break;
                            default:
                                break;
                        }

                        if (calendarData !== "") {
                            var calendar = $(this).data(calendarData);
                            if (calendar) {
                                calendar.open();
                            }
                        }
                    });

                    input.on('change', onChange);
                    input.on('input', onInput);
                    input.on('invalid', invalid);
                    input.on('hover',
                        function () {
                            $('.k-picker-wrap').removeClass('k-state-hover');
                        }
                    );
                    input.data('widget-validator', function () {
                        return $('[data-sf-role="error-message"]').filter(function () { return this.innerText; }).length === 0;
                    });
                }
            }
        }

        function validator(id, format) {
            $("#" + id).kendoValidator({
                rules: {
                    dateValidation: function (e) {
                        var value = $(e).val();
                        if (value !== "") {
                            var currentDate = kendo.parseExactDate(value, format);

                            if (!currentDate) {
                                var validationMessages = getValidationMessages(e);
                                setErrorMessage(e, validationMessages.invalid);
                                $(".k-invalid:last").focus();
                                return false;
                            }
                        }

                        return true;
                    }
                }
            });
        }

        init();
    });
}(jQuery));
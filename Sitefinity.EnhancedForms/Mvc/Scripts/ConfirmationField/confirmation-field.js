(function ($) {
    $(function () {
        var fieldContainerSelector = '[data-sf-role="confirmation-field-container"]';
        var confirmationFieldSelector = '[data-sf-role="text-field-confirmation-input"]';
        var textInputSelector = 'input[type="text"]';
        var violationRestrictionsInputSelector = '[data-sf-role="violation-restrictions"]';
        var errorMessageInputSelector = '[data-sf-role="error-message"]';

        if (typeof FormRulesSettings !== "undefined") {
            FormRulesSettings.addFieldSelector("confirmation-field-container", "[data-sf-role='text-field-input']");
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

        function onChange(e) {
            processRules(e);
        }

        function onInput(e) {
            processRulesWithDelay(e);
        }

        function invalid(e) {
            if (typeof e.target.validity === 'undefined')
                return;

            if (_getErrorMessageContainer(e.target)) {
                e.preventDefault();
            }

            var container = $(e.target).closest(fieldContainerSelector)[0];
            var confirmationField = container.querySelector(confirmationFieldSelector);
            setErrorMessage(e.target, '');
            setErrorMessage(confirmationField, '');

            var mainFieldValidationMessages = getValidationMessages(e.target);
            var confirmationFieldValidationMessages = getValidationMessages(confirmationField);
            var validationRestrictions = getValidationRestrictions(e.target);
            var isValidLength = e.target.value.length >= validationRestrictions.minLength;

            if (validationRestrictions.maxLength > 0)
                isValidLength &= e.target.value.length <= validationRestrictions.maxLength;

            if (!e.target.value) {
                setErrorMessage(e.target, mainFieldValidationMessages.required);

                if (!confirmationField.value) {
                    setErrorMessage(confirmationField, confirmationFieldValidationMessages.required);
                }
            }
            else if (e.target.validity.patternMismatch && !isValidLength) {
                setErrorMessage(e.target, mainFieldValidationMessages.maxLength);
            }
            else if (e.target.validity.patternMismatch && isValidLength) {
                setErrorMessage(e.target, mainFieldValidationMessages.regularExpression);
            }
            else if (!e.target.validity.valid) {
                setErrorMessage(e.target, mainFieldValidationMessages.invalid);
            }
        }

        function validateFieldsMatch(element) {
            var validationMessages = getValidationMessages(element);
            var parentContainer = $(element).parent();

            var firstInput = parentContainer.find(textInputSelector).first();
            var secondInput = parentContainer.find(textInputSelector).last();
            
            setErrorMessage(firstInput, '');
            setErrorMessage(secondInput, '');

            if (firstInput.val() !== secondInput.val()) {
                setErrorMessage(parentContainer.find(textInputSelector).last(), validationMessages.fieldsMatch);
                return false;
            }

            return true;
        }

        function getValidationMessages(input) {
            var container = $(input).parents(fieldContainerSelector);
            var validationMessagesInput = $(container).find('[data-sf-description="' + input.id + '"]');
            var validationMessages = JSON.parse(validationMessagesInput.val());

            return validationMessages;
        }

        function getValidationRestrictions(input) {
            var container = $(input).parents(fieldContainerSelector);
            var validationRestrictionsInput = $(container).find(violationRestrictionsInputSelector);
            var validationRestrictions = JSON.parse(validationRestrictionsInput.val());

            return validationRestrictions;
        }

        function setErrorMessage(input, message) {
            var errorMessagesContainer = _getErrorMessageContainer(input);

            if (errorMessagesContainer) {
                _toggleCustomErrorMessage(errorMessagesContainer, message);
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
            return $(input).next(errorMessageInputSelector)[0];
        }

        function init() {
            var containers = $(fieldContainerSelector);

            if (!containers || containers.length < 1)
                return;

            for (var i = 0; i < containers.length; i++) {
                var input = $(containers[i]).find('[data-sf-role*="text-field"]');

                if (input) {
                    input.on('change', onChange);
                    input.on('input', onInput);
                    input.on('invalid', invalid);
                    input.data('widget-validator', function () {
                        return validateFieldsMatch(input[0], true);
                    });
                }
            }
        }

        init();
    });
}(jQuery));
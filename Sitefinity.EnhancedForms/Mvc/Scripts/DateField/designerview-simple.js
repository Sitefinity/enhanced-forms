(function () {

    var simpleViewModule = angular.module('simpleViewModule', ['designer']);

    angular.module('designer').requires.push('expander', 'simpleViewModule');

    simpleViewModule.controller('SimpleCtrl', ['$scope', 'propertyService', function ($scope, propertyService) {

        // ------------------------------------------------------------------------
        // scope variables and set up
        // ------------------------------------------------------------------------

        $scope.$watch(
            'defaultValue.value',
            function (newDefaultValue, oldDefaultValue) {
                if (newDefaultValue !== oldDefaultValue) {
                    $scope.properties.Model.MetaField.DefaultValue.PropertyValue = angular.element("#predefinedValue").val();
                }
            },
            true
        );

        $scope.feedback.showLoadingIndicator = true;
        $scope.defaultValue = { value: "" };

        var onGetPropertiesSuccess = function (data) {
            if (data) {
                $scope.properties = propertyService.toHierarchyArray(data.Items);
                $scope.fieldDateType = $scope.properties.Model.InputType.PropertyValue.toString();
            }
        };

        propertyService.get()
            .then(onGetPropertiesSuccess)
            .catch(function (data) {
                $scope.feedback.showError = true;
                if (data)
                    $scope.feedback.errorMessage = data.Detail;
            })
            .finally(function () {
                $scope.feedback.showLoadingIndicator = false;
            });
    }]);
})();
(function () {
    var app = angular.module("app");

    app.directive("selecaoDeMotorista", ["api", function (api) {
        return {
            templateUrl: "/Templates/motorista/componentes/selecao-de-motorista.html",
            restrict: "E",
            scope: true,
            require: "^ngModel",
            link: function (scope, _, attrs, ngModel) {

                ngModel.$render = function () {
                    scope.id = ngModel.$viewValue;
                };

                scope.obrigatorio = angular.isDefined(attrs.obrigatorio);
                scope.atualizar = function () {
                    ngModel.$setViewValue(scope.id);
                };

                api.motoristas.listar({ apenasAtivos: true }).then(r => scope.motoristas = r.data);
            }
        }
    }]);
})();
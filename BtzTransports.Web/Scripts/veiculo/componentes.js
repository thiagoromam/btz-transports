(function () {
    var app = angular.module("app");

    app.directive("selecaoDeVeiculo", ["api", function (api) {
        return {
            templateUrl: "/Templates/veiculo/componentes/selecao-de-veiculo.html",
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

                api.veiculos.listar().then(r => scope.veiculos = r.data);
            }
        }
    }]);
})();
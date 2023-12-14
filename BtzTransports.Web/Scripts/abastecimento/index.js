(function () {
    var app = angular.module("app");

    app.controller("AbastecimentosController", ["$scope", "api", "toastr", "alert", function (scope, api, toastr, alert) {

        scope.listar = function () {
            api.abastecimentos.listar().then(r => scope.abastecimentos = r.data);
        };

        scope.remover = function (abastecimento) {
            alert.confirm("Deseja remover esse abastecimento?").then(() => {
                api.abastecimentos.remover(abastecimento.id)
                    .then(() => {
                        toastr.success("Abastecimento removido com sucesso.");
                        scope.listar();
                    })
                    .catch(r =>
                        toastr.error(r.data.message)
                    );
            });
        };
    }]);
})();
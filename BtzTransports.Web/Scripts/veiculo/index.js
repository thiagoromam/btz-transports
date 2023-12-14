(function () {
    var app = angular.module("app");

    app.controller("VeiculosController", ["$scope", "api", "toastr", "alert", function (scope, api, toastr, alert) {

        scope.listar = function () {
            api.veiculos.listar().then(r => scope.veiculos = r.data);
        };

        scope.remover = function (veiculo) {
            alert.confirm("Deseja remover esse veículo?").then(() => {
                api.veiculos.remover(veiculo.id)
                    .then(() => {
                        toastr.success("Veículo removido com sucesso.");
                        scope.listar();
                    })
                    .catch(r =>
                        toastr.error(r.data.message)
                    );
            });
        };
    }]);
})();
(function () {
    var app = angular.module("app");

    app.controller("MotoristasController", ["$scope", "api", "toastr", "alert", function (scope, api, toastr, alert) {

        scope.listar = function () {
            api.motoristas.listar().then(r => scope.motoristas = r.data);
        };

        scope.remover = function (motorista) {
            alert.confirm("Deseja remover esse motorista?").then(() => {
                api.motoristas.remover(motorista.id)
                    .then(() => {
                        toastr.success("Motorista removido com sucesso.");
                        scope.listar();
                    })
                    .catch(r =>
                        toastr.error(r.data.message)
                    );
            });
        };
    }]);
})();
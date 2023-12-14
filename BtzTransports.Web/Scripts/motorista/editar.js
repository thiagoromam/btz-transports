(function () {
    var app = angular.module("app");

    app.controller("EditarController", ["$scope", "api", "toastr", function (scope, api, toastr) {

        scope.motorista = {
            categoriaDaCnh: Enum.categoriaDaCnh.acc,
            status: Enum.statusDoMotorista.ativo
        };

        scope.carregar = function (id) {
            if (id)
                api.motoristas.buscar(id).then(r => scope.motorista = r.data);
        };

        scope.salvar = function () {
            var requisicao = !scope.motorista.id
                ? api.motoristas.adicionar(scope.motorista)
                : api.motoristas.atualizar(scope.motorista);

            requisicao
                .then(() => {
                    toastr.success("Motorista salvo com sucesso.");
                    setTimeout(() => location.href = "/Motorista", 1000);
                })
                .catch(r =>
                    toastr.error(r.data.message)
                );
        };
    }]);
})();
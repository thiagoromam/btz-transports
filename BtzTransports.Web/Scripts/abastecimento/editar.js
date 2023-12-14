(function () {
    var app = angular.module("app");

    app.controller("EditarController", ["$scope", "api", "toastr", function (scope, api, toastr) {

        scope.abastecimento = {};

        scope.carregar = function (id) {
            if (id)
                api.abastecimentos.buscar(id).then(r => scope.abastecimento = r.data);
        };

        scope.salvar = function () {
            var requisicao = !scope.abastecimento.id
                ? api.abastecimentos.adicionar(scope.abastecimento)
                : api.abastecimentos.atualizar(scope.abastecimento);

            requisicao
                .then(() => {
                    toastr.success("Abastecimento salvo com sucesso.");
                    setTimeout(() => location.href = "/Abastecimento", 1000);
                })
                .catch(r =>
                    toastr.error(r.data.message)
                );
        };
    }]);
})();
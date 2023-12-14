(function () {
    var app = angular.module("app");

    app.controller("EditarController", ["$scope", "api", "toastr", function (scope, api, toastr) {
        var combustiveis;
        
        scope.abastecimento = {
            data: new Date(),
            tipoDeCombustivel: Enum.tipoDeCombustivel.gasolina
        };

        scope.carregar = function (id) {
            if (id)
                api.abastecimentos.buscar(id).then(r => scope.abastecimento = r.data);

            api.combustiveis.listar().then(r => combustiveis = r.data);
        };

        scope.obterPrecoDoCombustivel = function () {
            if (combustiveis) {
                for (var i = 0; i < combustiveis.length; i++) {
                    var combustivel = combustiveis[i];

                    if (combustivel.tipo == scope.abastecimento.tipoDeCombustivel)
                        return combustivel.preco;
                }
            }

            return null;
        };
        scope.calcularCusto = function () {
            var quantidade = scope.abastecimento.quantidade;
            var precoDoCombustivel = scope.obterPrecoDoCombustivel();

            if (quantidade && precoDoCombustivel)
                return quantidade * precoDoCombustivel;

            return null;
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
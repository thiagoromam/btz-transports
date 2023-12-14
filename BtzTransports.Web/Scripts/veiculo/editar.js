(function () {
    var app = angular.module("app");

    app.controller("EditarController", ["$scope", "api", "toastr", function (scope, api, toastr) {

        scope.veiculo = {};

        scope.carregar = function (id) {
            if (id)
                api.veiculos.buscar(id).then(r => scope.veiculo = r.data);
        };

        scope.combustivelEstaHabilitado = function (tipo) {
            return Enum.hasFlag(scope.veiculo.tiposDeCombustivel, tipo);
        };
        scope.alternarTipoDeCombustivel = function (tipo) {
            var veiculo = scope.veiculo;

            veiculo.tiposDeCombustivel = Enum.setFlag(veiculo.tiposDeCombustivel, tipo);
        };

        scope.salvar = function () {
            var veiculo = scope.veiculo;

            if (!veiculo.tiposDeCombustivel) {
                toastr.error("É necessário informar ao menos um tipo de combustível");
                return;
            }

            var requisicao = !veiculo.id
                ? api.veiculos.adicionar(veiculo)
                : api.veiculos.atualizar(veiculo);

            requisicao
                .then(() => {
                    toastr.success("Veículo salvo com sucesso.");
                    setTimeout(() => location.href = "/Veiculo", 1000);
                })
                .catch(r =>
                    toastr.error(r.data.message)
                );
        };
    }]);
})();
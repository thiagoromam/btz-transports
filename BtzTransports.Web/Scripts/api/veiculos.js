(function () {
    var api = angular.module("api");

    api.resource("veiculos", ["$http", function (http) {
        var uri = "/api/veiculos";

        this.listar = function () {
            return http.get(uri);
        };
        this.buscar = function (id) {
            return http.get(`${uri}/${id}`);
        };
        this.adicionar = function (veiculo) {
            return http.post(uri, veiculo);
        };
        this.atualizar = function (veiculo) {
            return http.put(`${uri}/${veiculo.id}`, veiculo);
        };
        this.remover = function (id) {
            return http.delete(`${uri}/${id}`);
        };
    }]);
})();
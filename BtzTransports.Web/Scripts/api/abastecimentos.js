(function () {
    var api = angular.module("api");

    api.resource("abastecimentos", ["$http", function (http) {
        var uri = "/api/abastecimentos";

        this.listar = function () {
            return http.get(uri);
        }
        this.buscar = function (id) {
            return http.get(`${uri}/${id}`);
        };
        this.adicionar = function (abastecimento) {
            return http.post(uri, abastecimento);
        };
        this.atualizar = function (abastecimento) {
            return http.put(`${uri}/${abastecimento.id}`, abastecimento);
        };
        this.remover = function (id) {
            return http.delete(`${uri}/${id}`);
        };
    }]);
})();
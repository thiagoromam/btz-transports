(function () {
    var api = angular.module("api");

    api.resource("motoristas", ["$http", function (http) {
        var uri = "/api/motoristas";

        this.buscar = function (id) {
            return http.get(`${uri}/${id}`);
        };
        this.adicionar = function (motorista) {
            return http.post(uri, motorista);
        };
        this.atualizar = function (motorista) {
            return http.put(`${uri}/${motorista.id}`, motorista);
        };
    }]);
})();
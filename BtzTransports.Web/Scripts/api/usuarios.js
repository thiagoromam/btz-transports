(function () {
    var api = angular.module("api");

    api.resource("usuarios", ["$http", function (http) {
        var uri = "/api/usuarios";

        this.listar = function () {
            return http.get(uri);
        };
        this.buscar = function (id) {
            return http.get(`${uri}/${id}`);
        };
        this.adicionar = function (usuario) {
            return http.post(uri, usuario);
        };
        this.atualizar = function (usuario) {
            return http.put(`${uri}/${usuario.id}`, usuario);
        };
        this.remover = function (id) {
            return http.delete(`${uri}/${id}`);
        };
    }]);
})();
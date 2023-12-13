(function () {
    var api = angular.module("api");

    api.resource("contas", ["$http", function (http) {

        this.login = function (dados) {
            return http.post("/api/contas/login", dados);
        };
    }]);
})();
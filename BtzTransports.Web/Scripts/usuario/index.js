(function () {
    var app = angular.module("app");

    app.controller("UsuariosController", ["$scope", "api", "toastr", "alert", function (scope, api, toastr, alert) {

        scope.listar = function () {
            api.usuarios.listar().then(r => scope.usuarios = r.data);
        };

        scope.remover = function (usuario) {
            alert.confirm("Deseja remover esse usuário?").then(() => {
                api.usuarios.remover(usuario.id)
                    .then(() => {
                        toastr.success("Usuário removido com sucesso.");
                        scope.listar();
                    })
                    .catch(r =>
                        toastr.error(r.data.message)
                    );
            });
        };
    }]);
})();
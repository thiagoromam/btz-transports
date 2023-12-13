(function () {
    var app = angular.module("app");

    app.controller("EditarController", ["$scope", "api", "toastr", function (scope, api, toastr) {

        scope.usuario = {};

        scope.carregar = function (id) {
            if (id)
                api.usuarios.buscar(id).then(r => scope.usuario = r.data);
        };

        scope.salvar = function () {
            var usuario = scope.usuario;

            if (usuario.senha && usuario.senha != usuario.confirmacaoDaSenha) {
                toastr.error("A confirmação da senha não está correta.");
                return;
            }

            var requisicao = !usuario.id
                ? api.usuarios.adicionar(usuario)
                : api.usuarios.atualizar(usuario);

            requisicao
                .then(() => {
                    toastr.success("Usuário salvo com sucesso.");
                    setTimeout(() => location.href = "/Usuario", 1000);
                })
                .catch(r =>
                    toastr.error(r.data.message)
                );
        };

        window.teste = scope;
    }]);
})();
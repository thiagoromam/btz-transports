(function () {
    var api = angular.module("api", []);

    api.provider("api", function () {
        var services = {};

        this.addResource = function (name, service) {
            if (name in services)
                throw "O serviço '{0}' já foi registrado".format(name);

            services[name] = service;
        }

        this.$get = ["$injector", function (injector) {
            Object.getOwnPropertyNames(services).forEach(function (key) {
                services[key] = injector.instantiate(services[key]);
            });

            return services;
        }];
    });

    if (api.resource)
        throw "O método api.resource já foi definido por outro componente";

    api.resource = function (name, service) {
        api.config(["apiProvider", function (provider) {
            provider.addResource(name, service);
        }]);
    }
})();
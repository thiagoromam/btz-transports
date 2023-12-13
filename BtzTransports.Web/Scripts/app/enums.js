function Enum(options) {
    var self = this;

    self.options = options;

    options.forEach(o => {
        self[o.name] = o.value;
        self[o.value] = o.display;
    });
}

Enum.statusDoMotorista = new Enum([
    { value: 1, name: "ativo", display: "Ativo" },
    { value: 2, name: "inativo", display: "Inativo" }
]);

(function () {
    var app = angular.module("app");

    function createFilter(name) {
        app.filter(name, function () {
            return function (value) {
                return Enum[name][value];
            };
        });
    }

    createFilter("statusDoMotorista");
})();
function Enum(options, flags) {
    var self = this;

    self.options = options;
    self.flags = flags || false;

    options.forEach(o => {
        self[o.name] = o.value;
        self[o.value] = o.display;
    });
}

Enum.hasFlag = function (value, flag) {
    return (value & flag) == flag;
};
Enum.setFlag = function (value, flag) {
    if (!Enum.hasFlag(value, flag))
        return value | flag;

    return value & ~flag;
}

Enum.statusDoMotorista = new Enum([
    { value: 1, name: "ativo", display: "Ativo" },
    { value: 2, name: "inativo", display: "Inativo" }
]);

Enum.tipoDeCombustivel = new Enum([
    { value: 1 << 0, name: "gasolina", display: "Gasolina" },
    { value: 1 << 1, name: "etanol", display: "Etanol" },
    { value: 1 << 2, name: "diesel", display: "Diesel" }
], true);

Enum.categoriaDaCnh = new Enum([
    { value: 1, name: "acc", display: "ACC" },
    { value: 2, name: "a", display: "A" },
    { value: 3, name: "b", display: "B" },
    { value: 4, name: "c", display: "C" },
    { value: 5, name: "d", display: "D" },
    { value: 6, name: "e", display: "E" }
]);

(function () {
    var app = angular.module("app");

    function createFilter(name) {
        app.filter(name, function () {
            var e = Enum[name];

            return function (value, separator) {
                if (!e.flags)
                    return e[value];

                var flags = [];

                e.options.forEach(o => {
                    if (Enum.hasFlag(value, o.value))
                        flags.push(e[o.value]);
                });

                return flags.length ? flags.join(separator || ", ") : null;
            };
        });
    }

    createFilter("statusDoMotorista");
    createFilter("tipoDeCombustivel");
    createFilter("categoriaDaCnh");
})();
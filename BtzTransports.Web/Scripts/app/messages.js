(function () {
    var app = angular.module("app");

    app.decorator("$exceptionHandler", ["$delegate", function (original) {
        return function (exception) {
            if (!/^Possibly unhandled rejection.*"alertConfirmRejected":true/.test(exception))
                original.apply(this, arguments);
        };
    }]);

    app.factory("alert", ["$q", function (q) {
        var swal = window.swal;

        function alert() {
            var options = arguments;
            var defer = q.defer();

            setTimeout(function () {
                swal.apply(window, options).then(function (result) {
                    defer.resolve(result);
                });

                $(".swal-button:focus").blur();
            }, 100);

            return defer.promise;
        }

        alert.success = function (title, text) {
            return alert({ title, text, icon: "success" });
        };
        alert.error = function (text) {
            return alert({ text, icon: "error" });
        };
        alert.confirm = function (title, text, confirmText, cancelText) {
            var defer = q.defer();
            var options = {
                title,
                text,
                icon: "warning",
                buttons: {
                    cancel: {
                        text: cancelText || "Cancelar",
                        className: "btn btn-default",
                        visible: true
                    },
                    confirm: {
                        text: confirmText || "Confirmar",
                        className: "btn btn-warning"
                    }
                }
            };

            alert(options).then(function (result) {
                if (result)
                    defer.resolve();
                else
                    defer.reject({ alertConfirmRejected: true });
            });

            return defer.promise;
        };

        return alert;
    }]);
    app.service("toastr", function () {
        var toastr = window.toastr;

        toastr.options = {
            debug: false,
            newestOnTop: false,
            positionClass: "toast-top-center",
            closeButton: true,
            toastClass: "animated fadeInDown"
        };

        this.success = function (message) {
            toastr.success(message);
        };
        this.error = function (message) {
            toastr.error(message);
        }
    });
})();
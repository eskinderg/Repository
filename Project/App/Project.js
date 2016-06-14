var project = angular.module('ProjectApp', ['ngGrid', 'ngDialog']);

project.config(['ngDialogProvider', function (ngDialogProvider) {
    ngDialogProvider.setDefaults({
        className: 'ngdialog-theme-default',
        plain: false,
        showClose: true,
        closeByDocument: true,
        closeByEscape: true,
        appendTo: false,
        disableAnimation: true,
        preCloseCallback: function () {
            console.log('default pre-close callback');
        }
    });
}]);
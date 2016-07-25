//Parent Controller
project.controller('FormSubmitController', function ($scope, projectService, ngDialog) {

    $scope.folders = [];

    projectService.getAllFolders().then(function (result) {
        $scope.folders = result;
    });

    $scope.formSubmit = function (content) {
        projectService.addContent(content).then(function successCallback(newAddedContent) {
            $scope.$broadcast('submitted', newAddedContent);
        });
    };

    $scope.showLoginDialog = function () {
        ngDialog.open({
            template: 'App/Views/login.html',
            className: 'ngdialog-theme-default',
            controller: 'LoginDialogController',
            disableAnimation: true
        });
    };

});


project.controller('LoginDialogController', function ($scope, projectService, ngDialog) {

    $scope.loginBtn = function () {

        projectService.getContent(6).then(function (result) {
            alert('you are logged in succusfully: Data From Server-> ' + result.Title);
        });
    };

    $scope.showRegisterDialog = function () {

        //this.closeThisDialog();

        ngDialog.open({
                template: 'App/Views/register.html',
                className: 'ngdialog-theme-default',
                controller: 'RegisterDialogController',
                disableAnimation: true
        });

    };

    $scope.showContent = function (contentId) {
        ngDialog.open({
            template: 'App/Views/content.html',
            className: 'ngdialog-theme-default custom-width',
            controller: 'ContentDialogController',
            width: '50%',
            disableAnimation: true
        });
    };

});

project.controller('RegisterDialogController', function ($scope, projectService) {

    projectService.getAllContents().then(function (result) {
        $scope.contents = result;
    });

});


project.controller('ContentDialogController', function ($scope, projectService, ngDialog) {

        $scope.contents =[];

        projectService.getAllContents().then(function(result) {
            $scope.contents = result;
        });

        $scope.closeDialogBtn = function() {
            this.closeThisDialog();
        };

});


//Child Controller
project.controller('ExpenseGridController', function ($scope, projectService ) {

    $scope.contents = [];

    projectService.getAllContents().then(function (result) {

        $scope.contents = result;

    });

    $scope.gridOptions = {
        data: 'contents',
        enableColumnMenus: false,
        enableHorizontalScrollbar: 0,
        enableVerticalScrollbar: 3,
        //multiSelect: false,
        //noUnselect: true,
        //selectedItems: $scope.mySelections,
        //enableCellEdit: true,
        //enableColumnResize: true,
        //showFooter: true,
        columnDefs:
        [
            { field: 'Title', displayName: 'Title'},
            { field: 'XmlConfigId', displayName: 'XmlConfigId' },
            { field: 'Summary', displayName: 'Summary' },
            { field: 'Folder.Name', displayName: 'Folder' }
        ]
    };

    $scope.$on('submitted', function (event, newAddedContent)
    {
            projectService.getContent(newAddedContent.Id).then( function successCallback(result) {

                    $scope.contents.push(result); //Push the new Data to the grid view
                    $scope.$parent.content = []; // Clear the submitted form data
                    $scope.$parent.contentform.$setPristine(); // Make the form untouched

             });
    });

});

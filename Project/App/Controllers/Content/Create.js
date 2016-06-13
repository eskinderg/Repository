
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
    }

    $scope.showLoginDialog = function () {
        ngDialog.open({
            template: 'App/Views/login.html',
            className: 'ngdialog-theme-default',
            controller: 'LoginDialogController',
            disableAnimation: true
        });
    };

    $scope.showRegisterDialog = function () {
        
        this.closeThisDialog();

        ngDialog.open({
            template: 'App/Views/register.html',
            className: 'ngdialog-theme-default',
            controller: 'RegisterDialogController',
            disableAnimation: true
        });

    };
});


project.controller('LoginDialogController', function ($scope, projectService) {

 
        projectService.getAllContents().then(function (result) {
            $scope.contents = result;
        });

        $scope.loginBtn = function() {
            alert('you are logged in succusfully: Data From Server ' + $scope.contents[2].Title);
        }
 
});

project.controller('RegisterDialogController', function ($scope, projectService) {


    projectService.getAllContents().then(function (result) {
        $scope.contents = result;
    });

    $scope.loginBtn = function () {
        alert('you are logged in succusfully: Data From Server ' + $scope.contents[2].Title);
    }

});


//Child Controller
project.controller('ExpenseGridController', function ($scope, projectService ) {

    $scope.contents = [];
    
    projectService.getAllContents().then(function (result) {
        
        $scope.contents = result;
        
    });

    $scope.gridOptions = {
        data: 'contents',
        multiSelect: false,
        selectedItems: $scope.mySelections,
        enableCellEdit: true,
        enableColumnResize: true,
        showFooter: true,
        columnDefs:
        [
            { field: 'Title', displayName: 'Title'},
            { field: 'XmlConfigId', displayName: 'XmlConfigId' },
            { field: 'Summary', displayName: 'Summary' },
            { field: 'Folder.Name', displayName: 'Folder' }       
        ]
    }


    $scope.$on('submitted', function (event, newAddedContent)
    {
            projectService.getContent(newAddedContent.Id).then( function successCallback(result) {            
               
                    $scope.contents.push(result); //Push the new Data to the grid view
                    $scope.$parent.content = []; // Clear the submitted form data
                    $scope.$parent.contentform.$setPristine(); // Make the form untouched
                
             });
    });
    
});




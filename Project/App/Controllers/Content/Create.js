
//Parent Controller
project.controller('FormSubmitController', function ($scope, projectService) {

    $scope.folders = [];

    projectService.getAllFolders().then(function (result) {
        $scope.folders = result;
    });

    $scope.formSubmit = function (content) {
        projectService.addContent(content).then(function successCallback(newAddedContent) {
            $scope.$broadcast('submitted', newAddedContent);
        });
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
            { field: 'Id', displayName: 'Content ID'},
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




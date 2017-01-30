var commandeController = function ($scope, $http, apiService, $filter) {
    $scope.message = "nourriture";
    $scope.newObjets = [];


    getTypeObjets();
    function getTypeObjets(){
        apiService.getTypeObjets().then(function(d){
            $scope.typeObjets = d.data;
        }, function () {
            console.log('Erreur (type objets)');
        });
    }

    getFournisseurs();
    function getFournisseurs() {
        apiService.getFournisseurs().then(function (d) {
            $scope.fournisseurs = d.data;
        }, function () {
            console.log('Erreur (fournisseurs)');
        });
    }
    
    $scope.addCommande = function (commande, newObjets) {
        var parameters = {};
        parameters.Objets = newObjets;
        parameters.Commande = commande;
        //parameters.date = "11-27-1995";

        apiService.addCommande(parameters).then(function (d) {
            alert("Ok");
            $scope.commande = null; //reinit les champs de commande
            $scope.newObjets.length = 0; //aucun nouvel objet
        }, function () {
            console.log("Erreur lors de l'envoi");
        });
    }

    $scope.updateNewObjets = function updateNewObjets() {
        var obj = $scope.objet
        $scope.newObjets.push(obj);
        $scope.objet = null; //reinit les champs de objet
    }

    //$scope.deleteNewObjets = function (item) {
    //    //$scope.newObjets.splice($scope.newObjets.indexOf(item), 1);
    //    $scope.newObjets.splice(item, 1);
    //    alert(item);
    //}
    $scope.deleteAllNewObjets = function deleteAllNewObjets() {
        $scope.newObjets = [];
    }

    $scope.tstdate = function (dt) {
        alert(dt);
    }

}
angular.module('app')
    .controller('commandeController', commandeController)
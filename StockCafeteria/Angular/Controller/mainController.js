var mainController = function ($scope, $http, apiService, $filter) {
    $scope.message = "nourriture";

    getCommandes();
    function getCommandes() {
        apiService.getCommandes().then(function (d) {
            $scope.Commandes = d.data;
        }, function () {
            console.log('Erreur (commande)');
        });
    }

    getStock();
    function getStock() {
        apiService.getStock().then(function (d) {
            var objets = d.data;
            $scope.Stock = objets
        }, function () {
            alert("Erreur (stock)");
        })
    }

    $scope.calculer = function calculer(dateDebut, dateFin) {
        console.log(dateDebut + dateFin);
        apiService.calculer(dateDebut,dateFin).then(function (d) {
            var result = d.data;
            $scope.Profit = result;
        }, function () {
            alert("Erreur veuillez recommencer");
        })
    }

    getVentes();
    function getVentes() {
        apiService.getVentes().then(function (d) {
            var ventes = d.data;
            $scope.Ventes = ventes;
        }, function () {
            alert("Erreur (vente)");
        })
    }

    $scope.annulerVente = function annulerVente(vente) {
        r = confirm("Êtes-vous sûr ?");
        if (r) {
            apiService.annulerVente(vente).then(function (d) {
                alert('ok');
                getVentes();
                getStock();
            }, function () {
                alert("Erreur (annulation d'une vente)");
            })
        }
    }

    $scope.supprimerCommande = function supprimerCommande(commande) {
        r = confirm("Êtes-vous sûr ?");
        if (r) {
            apiService.deleteCommande(commande.IdCommande).then(function (d) {
                alert('ok');
                getCommandes();
                getStock();
                getVentes();
            }, function () {
                alert("Erreur (suppression d'une commande)")
            })
        }
    }

    /*Modal*/

    /**/
    $scope.convertToDate = function convertToDate(stringDate) {
        var dateOut = new Date(stringDate);
        dateOut.setDate(dateOut.getDate());
        return dateOut;
    }
    $scope.convert = function convert(date) {
        var dateasstring = $filter('date')(date, "dd-MM-yyyy");
        return dateasstring;
    }
    /**/
}
angular.module('app')
    .controller('mainController', mainController)
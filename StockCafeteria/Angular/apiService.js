angular.module('app').service('apiService', function ($http) {
    var dev = 'http://localhost:4011/api/';
    var prod = '';
    var url = dev;


    /*Type Objets*/
    this.getTypeObjets = function () {
        return $http.get(url + 'TypeObjetsAPI/GetTypeObjet/');
    }
    this.getTypeObjetsById = function (id) {
        return $http.get(url + 'TypeObjetsAPI/GetTypeObjetById/' + id);
    }

    /*Commandes*/
    this.getCommandes = function () {
        return $http.get(url + 'CommandesAPI/GetCommande/');
    }
    this.getCommandeById = function (id) {
        return $http.get(url + 'CommandesAPI/GetCommandeById/' + id);
    }
    this.deleteCommande = function (id) {
        return $http.delete(url + 'CommandesAPI/DeleteCommande/'+id)
    }
    this.addCommande = function (parameters) {
        return $http.post(url + "CommandesAPI/PostCommande/", parameters)
    }

    /*Objet*/
    this.getObjet = function () {
        return $http.get(url + 'ObjetsAPI/GetObjet/');
    }//
    this.getQte = function (idTypeObjet) {
        return $http.get(url + 'ObjetsAPI/GetQuantite/' + idTypeObjet);
    }
    this.getStock = function () {
        return $http.get(url + 'ObjetsAPI/GetStock/');
    }

    /*Profit*/
    this.calculer = function (dateDebut, dateFin) {
        return $http.get(url + 'ProfitsAPI/Calculer/'+ dateDebut +'T'+ dateFin);
    }

    /*Ventes*/
    this.getVentes = function () {
        return $http.get(url + 'VentesAPI/GetVente/');
    }
    this.annulerVente = function (vente) {
        return $http.delete(url + 'VentesAPI/AnnulerVenteById/' + vente.IdVente)
    }

    /*Fournisseurs*/
    this.getFournisseurs = function () {
        return $http.get(url + 'FournisseursAPI/GetFournisseur/')
    }

})

//angularModule.service('apiService', ['$http', function ($http) {
/*var apiService = function ($http) {


    var url = dev;
    var dev = 'http://localhost:4011/api/TypeObjetsAPI/';
    var prod = '';

    this.getTypeObjets = function () {
        return $http.get(url + 'GetTypeObjet/');
    }

    this.getTypeObjetsById = function (id) {
        return $http.get(url + 'GetTypeObjetById' + id);
    }

    this.postEtuds = function (newEtud) {
        return $http.post(url + 'PostTypeObjet', newEtud)
    }

    this.putEtuds = function (etud) {
        return $http.put(url + 'PutTypeObjet' + etud.Id, etud)
    }

    this.deleteEtuds = function (etud) {
        return $http.delete(url + 'DeleteTypeObjet' + etud.Id);
    }*/

//}])
//}
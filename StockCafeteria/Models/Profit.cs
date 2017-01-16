using System;
/*using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;*/

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockCafeteria
{
    public class Profit
    {
        public DateTime DateDebut
        { get; set; }

        public float Depense
        { get; set; }

        public float Vente
        { get; set; }

        public float Benefice
        { get; set; }

         public DateTime DateFin
        { get; set; }

        [Key()]
        public int IdProfit
        { get; set; }
    }
}
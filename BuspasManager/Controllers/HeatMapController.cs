using Newtonsoft.Json;
using BuspasManager;
using BuspasManager.ActionFilter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuspasManager.Controllers
{
    [Authorize, SetCulture]
    public class HeatMapController : Controller
    {
        private BPI_CRMEntities dbCoord = new BPI_CRMEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        //Fonction permettant la collecte des donnees users
        public string Get_Liste_Coordonne()
        {
            //On selectionne tous les coordonnees en fonction des dates
            var dbPrincipal = dbCoord.Mobile_Logins_Audit.Select(p => new { Lat = p.Last_Lat, ID = p.IMEI, Lon = p.Last_Lon, Time = p.Last_Position_Update_Time }).ToList();
            var model = JsonConvert.SerializeObject(dbPrincipal);

            return model;
        }



    }
}
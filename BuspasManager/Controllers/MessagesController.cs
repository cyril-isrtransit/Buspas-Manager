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
    public class MessagesController : Controller
    {
        private BPI_Public_Transport_Entities db = new BPI_Public_Transport_Entities();
        [Authorize]
        public ViewResult Index()
        {
            var messages = db.PIS_Tickers;

            return View(messages.ToList());
        }


        [HttpPost]
        public string Create(string Ticker_Text, string Tiker_Color, string Tiker_URL, string Start_Time, string Finish_Time, string IS_Valid_Hidden)
        {
            try
            {
                PIS_Tickers message = new PIS_Tickers();
                message.Is_Master = false;
                message.IS_Valid = Convert.ToBoolean(IS_Valid_Hidden);
                message.Ticker_Type = 0;
                message.Ticker_Text = Ticker_Text;
                message.Tiker_Color = Tiker_Color;
                message.Tiker_URL = Tiker_URL;
                message.Start_Time = Convert.ToDateTime(Start_Time);
                message.Finish_Time = Convert.ToDateTime(Finish_Time);
                
                db.PIS_Tickers.Add(message);
                db.SaveChanges();

                
                //Envois des informations dans le fichier de log
                //LogsController LogFile = new LogsController();
                //LogFile.add(1, message.ID.ToString(), 1, User.Identity.Name, message.Title);

                ////Appel des autres controleurs afin de sauvegarder le message d'une traite////
                //ID du message qui viens detre creer
                var newId = message.Ticker_ID;

                

                //Apres avoir tout sauvegarde retour aux details du message
                return newId.ToString();
            }
            catch
            {
                return "False";
            }
        }


        [HttpGet, ActionName("Delete")]
        public Boolean DeleteConfirmed(long id)
        {
            try
            {
                PIS_Tickers message = db.PIS_Tickers.Single(m => m.Ticker_ID == id);
                
                db.PIS_Tickers.Remove(message);
                db.SaveChanges();

                //Envois des informations dans le fichier de log
                //LogsController LogFile = new LogsController();
                //LogFile.add(1, id.ToString(), 2, User.Identity.Name, message.Title);
                return true;
            }
            catch
            {
                return false;
            }
        }


        [HttpPost]
        public Boolean Edit(long Ticker_ID, string Ticker_Text, string Tiker_Color, string Tiker_URL, string Start_Time, string Finish_Time, string IS_Valid_Hidden_Edit)
        {
            try
            {

                PIS_Tickers message = new PIS_Tickers();
                message.Is_Master = false;
                message.IS_Valid = Convert.ToBoolean(IS_Valid_Hidden_Edit);
                message.Ticker_Type = 0;
                message.Ticker_ID = Ticker_ID;
                message.Ticker_Text = Ticker_Text;
                message.Tiker_Color = Tiker_Color;
                message.Tiker_URL = Tiker_URL;
                message.Start_Time = Convert.ToDateTime(Start_Time);
                message.Finish_Time = Convert.ToDateTime(Finish_Time);
                
                db.PIS_Tickers.Attach(message);
                db.Entry(message).State = (System.Data.Entity.EntityState)EntityState.Modified;
                db.Entry(message).CurrentValues.SetValues(message);
                db.SaveChanges();

                    //Envois des informations dans le fichier de log
                    //LogsController LogFile = new LogsController();
                    //LogFile.add(3, message.ID.ToString(), 1, User.Identity.Name, message.Title);
                
                    
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
using BuspasManager;
using BuspasManager.ActionFilter;
using BuspasManager.Models.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace BuspasManager.Controllers
{

    public class MessageLists
    {
        public long Ticker_ID { get; set; }
        public String Ticker_Text { get; set; }
        public String Start_Time { get; set; }
        public String Finish_Time { get; set; }
        public Boolean IS_Valid { get; set; }
        public String Tiker_Color { get; set; }
        public String Tiker_URL { get; set; }

    }

    [Authorize, SetCulture]
    public class HomeController : Controller
    {

        private BPI_Public_Transport_Entities db = new BPI_Public_Transport_Entities();

        //Fonction permettant de changer la langue en cour
        [HttpPost]
        public ActionResult SetCulture(string id)
        {
            HttpCookie userCookie = Request.Cookies["Culture"];
            userCookie.Value = id;
            userCookie.Expires = DateTime.Now.AddYears(100);
            Response.SetCookie(userCookie);
            Session["Culture"] = id;
            if (Request.UrlReferrer == null) return Redirect("/Home");
            return Redirect(Request.UrlReferrer.ToString());
        }


        //Fonction permettant d'optenir la langue en cour
        [HttpPost]
        public string GetCulture()
        {
            return Session["Culture"].ToString();

        }
        
        
        

        [Authorize]
        public ViewResult Index()
        {
            
            var messages = db.PIS_Tickers;
            var ruleDate = Convert.ToDateTime(DateTime.Now).Date;
            var msgList = db.PIS_Tickers.Where(m => m.IS_Valid == true && m.Start_Time.Value.CompareTo(ruleDate.Date) < 1 && m.Finish_Time.Value.CompareTo(ruleDate.Date) > -1).ToList();
            ViewBag.StatActiveMessages = msgList.Count();
                
                
                /*List<MessageLists> MessageLists = new List<MessageLists>();

                //var DbRealTimeList = db.RealtimeMessages.ToList();
                foreach (var element in msgList)
                {

                    MessageLists transition = new MessageLists();
                    transition.Ticker_ID = element.Ticker_ID;
                    transition.Ticker_Text = element.Ticker_Text;
                    transition.Start_Time = element.Start_Time.ToString();
                    transition.Finish_Time = element.Finish_Time.ToString();
                    transition.IS_Valid = element.IS_Valid;
                    transition.Tiker_Color = element.Tiker_Color;
                    transition.Tiker_URL = element.Tiker_URL;

                    MessageLists.Add(transition);
                }
                ViewBag.ListMessage = MessageLists;*/

            return View(msgList);
        }


        
        public string GetMessageCalendar()
        {
            try
            {
                var messages = db.PIS_Tickers;

                var msgList = messages.ToList().Select(p => new { Ticker_ID = p.Ticker_ID, Ticker_Text = p.Ticker_Text, Start_Time = p.Start_Time.Value.ToString("yyyy-MM-dd"), Finish_Time = p.Finish_Time.Value.ToString("yyyy-MM-dd"), IS_Valid = p.IS_Valid, Tiker_Color = p.Tiker_Color, Tiker_URL = p.Tiker_URL}).ToList();


                List<MessageLists> MessageLists = new List<MessageLists>();

                //var DbRealTimeList = db.RealtimeMessages.ToList();
                foreach (var element in msgList)
                {

                    MessageLists transition = new MessageLists();
                    transition.Ticker_ID = element.Ticker_ID;
                    transition.Ticker_Text = element.Ticker_Text;
                    transition.Start_Time = element.Start_Time;
                    transition.Finish_Time = element.Finish_Time;
                    transition.IS_Valid = element.IS_Valid;
                    transition.Tiker_Color = element.Tiker_Color;
                    transition.Tiker_URL = element.Tiker_URL;
                    
                    MessageLists.Add(transition);
                }


                JavaScriptSerializer js = new JavaScriptSerializer();

                var Retour = js.Serialize(MessageLists);

                return Retour;
            }
            catch
            {
                return "";
            }
        }


        [HttpGet]
        public int GetOutdatedMessages()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = MsgStats.GetOutdatedMessages();
            
            return Retour;
        }

        public int GetInactiveMessagesInScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = MsgStats.GetInactiveMessagesInScope();
            
            return Retour;
        }

        public int GetInactiveMessagesInFutureScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = MsgStats.GetInactiveMessagesInFutureScope();
            
            return Retour;
        }

        public int GetActiveMessagesInScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = MsgStats.GetActiveMessagesInScope();
            
            return Retour;
        }

        public int GetActiveMessages()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = MsgStats.GetActiveMessages();
            
            return Retour;
        }

        public int GetMessagesInScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = MsgStats.GetMessagesInScope();
            
            return Retour;
        }

        public int GetMessagesInFutureScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = MsgStats.GetMessagesInFutureScope();
            
            return Retour;
        }


        /*
        [HttpGet]
        public string GetMediasAll()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgPerMedia.GetMessagesAll());

            return Retour;
        }

        [HttpGet]
        public string GetMediasActives()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgPerMedia.GetMessagesActives());

            return Retour;
        }

        [HttpGet]
        public string GetSupports()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgPerMedia.GetSupports());

            return Retour;
        }

        [HttpGet]
        public string GetCategoriesPub()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgPerCategories.GetMessagesPerCategoriesPub());

            return Retour;
        }

        [HttpGet]
        public string GetCategoriesAll()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgPerCategories.GetMessagesPerCategoriesAll());

            return Retour;
        }

        [HttpGet]
        public string GetCategories()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgPerCategories.GetCategories());

            return Retour;
        }

        [HttpGet]
        public string GetOutdatedMessages()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgStats.GetOutdatedMessages());

            return Retour;
        }

        public string GetInactiveMessagesInScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgStats.GetInactiveMessagesInScope());

            return Retour;
        }

        public string GetInactiveMessagesInFutureScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgStats.GetInactiveMessagesInFutureScope());

            return Retour;
        }

        public string GetActiveMessagesInScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgStats.GetActiveMessagesInScope());

            return Retour;
        }

        public string GetActiveMessages()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgStats.GetActiveMessages());

            return Retour;
        }

        public string GetMessagesInScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgStats.GetMessagesInScope());

            return Retour;
        }

        public string GetMessagesInFutureScope()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();

            var Retour = js.Serialize(MsgStats.GetMessagesInFutureScope());

            return Retour;
        }*/

    }
}
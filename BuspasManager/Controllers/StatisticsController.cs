using BuspasManager;
using BuspasManager.ActionFilter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BuspasManager.Controllers
{
    [Authorize, SetCulture]
    public class StatisticsController : Controller
    {
        private BPI_Public_Transport_EnhancmentsEntities dbQuestion = new BPI_Public_Transport_EnhancmentsEntities();
        private BPI_Public_Transport_CollectingEntities dbReponse = new BPI_Public_Transport_CollectingEntities();

        public class ItemLists
        {
            public String Value { get; set; }
            public int Type { get; set; }
            public String SubValue { get; set; }
        }

        public class ReponseLists
        {
            public long Question_ID { get; set; }
            public String Question { get; set; }
            public System.DateTime From { get; set; }
            public System.DateTime To { get; set; }
            public String Session_ID { get; set; }
            public System.DateTime Report_Time { get; set; }
            public System.DateTime Occour_Time { get; set; }
            public String Bus { get; set; }
            public String Driver { get; set; }
            public String Line { get; set; }
            public String Direction { get; set; }
            public String Comment { get; set; }
            public long Item_ID { get; set; }
            public String Item_description { get; set; }
            public String Item_type { get; set; }
            public String Answer { get; set; }
        }


        //Fonction permettant le chargement des donnees de la base dans la vue des questions//
        public ActionResult Index()
        {
            var questions = dbQuestion.Questionnaires;

            return View(questions.ToList());
        }

        //Fonction permettant le chargement des donnees de la base dans la vue des reponses//
        [Authorize]
        public ViewResult Details(long id)
        {

            List<ReponseLists> ReponseList = new List<ReponseLists>();

            var DbQuestion = dbQuestion.Questionnaries_Items.Where(l => l.Quest_ID == id).Select(p => new { Quest_ID = p.Quest_ID, Name = p.Questionnaires.Name, From_Date = p.Questionnaires.From_Date, To_Date = p.Questionnaires.To_Date, Item_Description = p.Item_Description, Item_Type = p.Item_Type, Item_ID = p.Item_ID }).ToList();
            var DbReponse = dbReponse.Questionary_Report_Items.Where(l => l.Question_ID == id.ToString()).Select(p => new { Session_ID = p.Session_ID, Report_Time = p.Questionary_Report.Report_Time, Occour_Time = p.Questionary_Report.Occour_Time, Line_Number = p.Questionary_Report.Line_Number, Value = p.Value, Driver_Name = p.Questionary_Report.Driver_Name, Comments = p.Questionary_Report.Comments, Direction = p.Questionary_Report.Direction, Bus_Number = p.Questionary_Report.Bus_Number, Item_ID = p.Item_ID }).ToList();

            foreach (var element2 in DbReponse)
            {
                
                foreach (var element in DbQuestion)
                {
                    if(element.Item_ID.ToString() == element2.Item_ID.TrimEnd())
                    {
                        ReponseLists transition = new ReponseLists();

                        transition.Question_ID = element.Quest_ID;
                        transition.Question = element.Name;
                        transition.From = (DateTime)element.From_Date;
                        transition.To = (DateTime)element.To_Date;
                        transition.Item_ID = element.Item_ID;
                        transition.Item_description = element.Item_Description;

                        switch (element.Item_Type)
                        {
                            case 1:
                                transition.Item_type = "Stars";
                                transition.Answer = element2.Value.TrimEnd()+"/5";
                                break;
                            case 2:
                                transition.Item_type = "Check box";
                                if (element2.Value.TrimEnd() == "0")
                                {
                                    transition.Answer = "False";
                                }
                                else
                                {
                                    transition.Answer = "True";
                                }
                                break;
                            case 4:
                                transition.Item_type = "Radio";
                                transition.Answer = element2.Value.TrimEnd();
                                break;
                            case 6:
                                transition.Item_type = "Multiple Check Box";
                                transition.Answer = element2.Value.TrimEnd();
                                break;
                            default:
                                transition.Item_type = "Text";
                                transition.Answer = element2.Value.TrimEnd();
                                break;
                        }
                        

                        transition.Session_ID = element2.Session_ID;
                        transition.Report_Time = (DateTime)element2.Report_Time;
                        transition.Occour_Time = (DateTime)element2.Occour_Time;
                        transition.Bus = element2.Bus_Number;
                        transition.Driver = element2.Driver_Name;
                        transition.Line = element2.Line_Number;
                        transition.Direction = element2.Direction;
                        transition.Comment = element2.Comments;
                        
                        
                        ReponseList.Add(transition);
                    }
                }
            }

            ViewBag.ReponseList = ReponseList;
            
            return View();
        }



        [HttpPost]
        public string Create(string Name, string Description, string From_Date, string To_Date, string ItemsJSON)
        {
            try
            {
                Questionnaires question = new Questionnaires();
                question.Name = Name;
                question.Description = Description;
                question.Quest_Type = 1;
                question.Quest_Provider = 1;
                question.From_Age = 0;
                question.To_Age = 120;
                question.Sex = 0;
                question.From_Date = Convert.ToDateTime(From_Date);
                question.To_Date = Convert.ToDateTime(To_Date);

                dbQuestion.Questionnaires.Add(question);
                dbQuestion.SaveChanges();

                //Envois des informations dans le fichier de log
                //LogsController LogFile = new LogsController();
                //LogFile.add(1, message.ID.ToString(), 1, User.Identity.Name, message.Title);

                ////Appel des autres controleurs afin de sauvegarder le message d'une traite////
                //ID du message qui viens detre creer
                var newId = question.Quest_ID;

                JavaScriptSerializer js = new JavaScriptSerializer();
                var Items = js.Deserialize<List<ItemLists>>(ItemsJSON);

                foreach (ItemLists item in Items)
                {
                    int caseSwitch = 0;

                    Questionnaries_Items question_item = new Questionnaries_Items();
                    question_item.Quest_ID = newId;
                    question_item.Parent_Item_ID = null;
                    question_item.Item_Type = item.Type;
                    question_item.Item_Description = item.Value;

                    if(item.SubValue != "")
                    {
                        var sousVal = item.SubValue.Split(';');

                        foreach (string SV in sousVal)
                        {
                            
                            //On case toutes les options dans chaque collone reserve
                            switch (caseSwitch)
                            {
                                case 1:
                                    question_item.Option_1 = SV;
                                    break;
                                case 2:
                                    question_item.Option_2 = SV;
                                    break;
                                case 3:
                                    question_item.Option_3 = SV;
                                    break;
                                case 4:
                                    question_item.Option_4 = SV;
                                    break;
                                case 5:
                                    question_item.Option_5 = SV;
                                    break;
                                case 6:
                                    question_item.Option_6 = SV;
                                    break;
                                case 7:
                                    question_item.Option_7 = SV;
                                    break;
                                case 8:
                                    question_item.Option_8 = SV;
                                    break;
                                case 9:
                                    question_item.Option_9 = SV;
                                    break;
                                case 10:
                                    question_item.Option_10 = SV;
                                    break;
                            }
                            caseSwitch++;
                        }
                    }
                dbQuestion.Questionnaries_Items.Add(question_item);
                dbQuestion.SaveChanges();
            }

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
                Questionnaires question = dbQuestion.Questionnaires.Single(m => m.Quest_ID == id);

                dbQuestion.Questionnaires.Remove(question);
                dbQuestion.SaveChanges();

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
        public Boolean Edit(long Quest_ID, string Name, string Description, string From_Date, string To_Date)
        {
            try
            {
                Questionnaires question = new Questionnaires();
                question.Quest_ID = Quest_ID;
                question.Name = Name;
                question.Description = Description;
                question.Quest_Type = 1;
                question.Quest_Provider = 1;
                question.From_Age = 0;
                question.To_Age = 120;
                question.Sex = 0;
                question.From_Date = Convert.ToDateTime(From_Date);
                question.To_Date = Convert.ToDateTime(To_Date);

                dbQuestion.Questionnaires.Attach(question);
                dbQuestion.Entry(question).State = (System.Data.Entity.EntityState)EntityState.Modified;
                dbQuestion.Entry(question).CurrentValues.SetValues(question);
                dbQuestion.SaveChanges();

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
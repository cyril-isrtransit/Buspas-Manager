using SivMsgWebClient.App_GlobalResources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SivMsgWebClient.Models
{

    [MetadataType(typeof(MessagesModel))]
    public partial class Messages
    {
        public class MessagesModel
        {
            public int Ticker_ID { get; set; }
            public int Tiker_Color { get; set; }
            public int Ticker_Text { get; set; }
            public Boolean Is_Master { get; set; }
            public int Ticker_Type { get; set; }
            public string Tiker_URL { get; set; }
            public DateTime Start_Time { get; set; }
            public DateTime Finish_Time { get; set; }
            public Boolean IS_Valid { get; set; }

        }
    }
}
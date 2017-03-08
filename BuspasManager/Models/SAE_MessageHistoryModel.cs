using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace BuspasManager.Models
{

    /*public partial class SAETEST_ISR_MsgHistEntities : ObjectContext
    {
        public int GetSentTodayCount()
        {
            return SIV_MsgHist.ToList().Count(m => m.SentTimeStamp.DayOfYear == DateTime.Now.DayOfYear) ;
        }

        public int GetSentThisMonthCount()
        {
            return SIV_MsgHist.Count(m => m.SentTimeStamp.Month == DateTime.Now.Month);
        }
    }*/
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BuspasManager.Models.Charts
{
    static public class MsgStats
    {
        static public BPI_Public_Transport_Entities db = new BPI_Public_Transport_Entities();
        static public int GetActiveMessagesInScope()
        {
            var dateNow = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            var dateN = DateTime.Parse(dateNow);
        
            return db.PIS_Tickers.Where(a => a.IS_Valid == true).Where(a => a.Finish_Time.Value.CompareTo(dateN) >= 0).Where(b => b.Start_Time.Value.CompareTo(DateTime.Now) <= 0).Count();
        }

        static public int GetActiveMessages()
        {
            return db.PIS_Tickers.Where(a => a.IS_Valid == true).Count();
        }


        static public int GetInactiveMessagesInFutureScope()
        {
            return db.PIS_Tickers.Where(a => a.IS_Valid == false).Where(b => b.Start_Time.Value.CompareTo(DateTime.Now) > 0).Count();
        }

        static public int GetMessagesInFutureScope()
        {
            return db.PIS_Tickers.Where(b => b.Start_Time.Value.CompareTo(DateTime.Now) > 0).Count();
        }


        static public int GetInactiveMessagesInScope()
        {
            return db.PIS_Tickers.Where(a => a.IS_Valid == false).Where(a => a.Finish_Time.Value.CompareTo(DateTime.Now) >= 0).Where(b => b.Start_Time.Value.CompareTo(DateTime.Now) <= 0).Count();
        }

        static public int GetMessagesInScope()
        {
            return db.PIS_Tickers.Where(a => a.Finish_Time.Value.CompareTo(DateTime.Now) >= 0).Where(b => b.Start_Time.Value.CompareTo(DateTime.Now) <= 0).Count();
        }


        static public int GetOutdatedMessages()
        {
            var dateNow = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            var dateN = DateTime.Parse(dateNow);
            return db.PIS_Tickers.Where(a => a.Finish_Time.Value.CompareTo(dateN) < 0).Where(a => a.IS_Valid == true).Count();
        }



    }
}



    /*static public IQueryable GetOutdatedMessages()
    {
        SIV_MessageEntities db = new SIV_MessageEntities();
        var dateNow = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day ;
        var dateN = DateTime.Parse(dateNow);
        return db.Messages.Where(a => a.EndDate.CompareTo(dateN) < 0).Where(a => a.StatusCode.Equals("PUB")).GroupBy(x => x).Select(g => new { data = g.Count() });
    }

    static public IQueryable GetInactiveMessagesInScope()
    {
        SIV_MessageEntities db = new SIV_MessageEntities();

        return db.Messages.Where(a => a.StatusCode != "PUB").Where(a => a.StatusCode != "DEL").Where(a => a.EndDate.CompareTo(DateTime.Now) >= 0).Where(b => b.StartDate.CompareTo(DateTime.Now) <= 0).GroupBy(x => x).Select(g => new { data = g.Count() });
    }
    static public IQueryable GetInactiveMessagesInFutureScope()
    {
        SIV_MessageEntities db = new SIV_MessageEntities();
        return db.Messages.Where(a => a.StatusCode != "PUB").Where(a => a.StatusCode != "DEL").Where(b => b.StartDate.CompareTo(DateTime.Now) > 0).GroupBy(x => x).Select(g => new { data = g.Count() });
    }

    static public IQueryable GetActiveMessagesInScope()
    {
        SIV_MessageEntities db = new SIV_MessageEntities();
        var dateNow = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
        var dateN = DateTime.Parse(dateNow);
        return db.Messages.Where(a => a.StatusCode.Equals("PUB")).Where(a => a.EndDate.CompareTo(dateN) >= 0).Where(b => b.StartDate.CompareTo(DateTime.Now) <= 0).GroupBy(x => x).Select(g => new { data = g.Count() });
    }

    static public IQueryable GetMessagesInScope()
    {
        SIV_MessageEntities db = new SIV_MessageEntities();
        return db.Messages.Where(a => a.EndDate.CompareTo(DateTime.Now) >= 0).Where(c => c.StatusCode != "DEL").Where(b => b.StartDate.CompareTo(DateTime.Now) <= 0).GroupBy(x => x).Select(g => new { data = g.Count() });
    }

    static public IQueryable GetActiveMessages()
    {
        SIV_MessageEntities db = new SIV_MessageEntities();
        return db.Messages.Where(a => a.StatusCode.Equals("PUB")).GroupBy(x => x).Select(g => new { data = g.Count() });
    }

    static public IQueryable GetMessagesInFutureScope()
    {
        SIV_MessageEntities db = new SIV_MessageEntities();
        return db.Messages.Where(b => b.StartDate.CompareTo(DateTime.Now) > 0).Where(a => a.StatusCode != "DEL").GroupBy(x => x).Select(g => new { data = g.Count() });
    }*/

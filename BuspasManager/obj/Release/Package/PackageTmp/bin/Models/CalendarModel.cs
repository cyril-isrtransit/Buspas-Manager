using Resources;
using System.Collections.Generic;
using System.Globalization;

namespace SivMsgWebClient.Models
{
    public static class CalendarModel
    {
        private static string GetLocalizedWeekdayName(int weekday)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)weekday];
        }
        
        public static Dictionary<int, string> DayofWeek
        {
            get
            {
                return new Dictionary<int, string>
                                  {
                                      {1, GetLocalizedWeekdayName(1)},
                                      {2,  GetLocalizedWeekdayName(2)},
                                      {3,  GetLocalizedWeekdayName(3)},
                                      {4,  GetLocalizedWeekdayName(4)},
                                      {5,  GetLocalizedWeekdayName(5)},
                                      {6,  GetLocalizedWeekdayName(6)},
                                      {7,  GetLocalizedWeekdayName(0)},
                                      {8,  LanguageResource.DayOfWeek},
                                      {9,  LanguageResource.WeekEnd},
                                      {10,  LanguageResource.AllWeek}
                                  };
            }
        }
    }
}
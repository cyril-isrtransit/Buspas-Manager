using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BuspasManager.App_Settings
{
    
    static public class ApplicationSettings
    {
        public static String InsightUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("InsightUrl");
            }
        }

        public static String Organization
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Organization");
            }
        }

        public static Boolean AudioMessageFeature
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings.Get("AudioMessageFeature"));
            }
        }

        public static String FacebookPageId
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Facebook:PageId");
            }
        }

        public static String FacebookPageAccessToken
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Facebook:PageAccessToken");
            }
        }

        public static String ExternalMessageFeature
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("ExternalMessageFeature");
            }
        }

        public static String MsgSupportRouteWithStops
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("MsgSupportRouteWithStops");
            }
        }

        public static bool LogEnabled
        {
            get
            {
                return Convert.ToBoolean(ConfigurationManager.AppSettings.Get("Log:Enabled"));
            }
        }

        public static String LogFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("Log:File Path");
            }
        }

        public static decimal? AnnounceApproachDistanceFromStop
        {
            get
            {
                return Convert.ToDecimal(ConfigurationManager.AppSettings.Get("AudioStopAnnoucement:AnnounceApproachDistanceFromStop"));
            }
        }

        public static decimal ApproachDistanceIncrementValue
        {
            get
            {
                return Convert.ToDecimal(ConfigurationManager.AppSettings.Get("AudioStopAnnoucement:ApproachDistanceIncrementValue"));
            }
        }

        public static String ConversionDistanceUnitToMeter
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("AudioStopAnnoucement:ConversionDistanceUnitToMeter");
            }
        }

        public static String AudioTriggerPointDefaultDistance
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("AudioTriggerPoint:DefaultDistance");
            }
        }

        public static int HeadsignDefaultRadius
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings.Get("Headsign:DefaultRadius"));
            }
        }

        public static String UnitDistance
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("UnitDistance");
            }
        }
     
        public static Dictionary<int, String> insightAVA_TTScodes
        {
            get
            {
                var codes = ConfigurationManager.AppSettings.Get("insight:AVA_TTScodes");

                return (Dictionary<int, String>)Newtonsoft.Json.JsonConvert.DeserializeObject(codes, typeof(Dictionary<int, String>));
            }
        }

        public static int LogDeleteAfterNumberDays
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings.Get("Log:DeleteAfterNumberDays"));
                }
                catch
                {
                    return int.MaxValue;
                }
            }
        }
    }
}

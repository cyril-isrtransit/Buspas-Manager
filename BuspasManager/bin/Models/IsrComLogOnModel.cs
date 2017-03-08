using System;

namespace BuspasManager.Models
{
    public class IsrComLogOnModel
    {
        public string username { get; set; }

        public string organization { get; set; }

        public String userLevel;

        public bool so;

        public String sessionID;

        public String lang;

        public String b;

        public RoleModel roles;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuspasManager.Models
{
    public class RoleModel
    {
        private const String moduleName = "SIV";
        private const String REALTIME_MESSAGES = "REALTIME_MESSAGES";
        private const String MANAGEMENT_EDIT = "MANAGEMENT_EDIT";
        private const String CONFIGURE_VIEW = "CONFIGURE_VIEW";

        private String roleName;

        public bool CanViewRealTimeMessages = false;
        public bool CanEditManagement = false;
        public bool CanViewConfiguration = false;

        /*public bool CanViewRealTimeMessages = true;
        public bool CanEditManagement = true;
        public bool CanViewConfiguration = true;*/


        public RoleModel()
        {
            CanViewRealTimeMessages = true;
            CanEditManagement = true;
            CanViewConfiguration = true;
        }

        /*public RoleModel(String roleName)
        {
            this.roleName = roleName;

            SAETEST_ISR_MsgHistEntities db = new SAETEST_ISR_MsgHistEntities();

            int allRoleCode = db.RolesWeb.FirstOrDefault(x => x.Name == "ALL")?.Code ?? int.MaxValue;

            int userRoleCode = db.RolesWeb.FirstOrDefault(x => x.Name == roleName)?.Code ?? 0;

            var rolesWebModules = db.RolesWebModule.Where(x => x.Module == moduleName).ToList();


            Int32 actionAllowedRoles = rolesWebModules.FirstOrDefault(x => x.Action == REALTIME_MESSAGES)?.roles ?? allRoleCode;
            CanViewRealTimeMessages = ((actionAllowedRoles == allRoleCode) || ((actionAllowedRoles & userRoleCode) > 0));

            actionAllowedRoles = rolesWebModules.FirstOrDefault(x => x.Action == MANAGEMENT_EDIT)?.roles ?? allRoleCode;
            CanEditManagement = ((actionAllowedRoles == allRoleCode) || ((actionAllowedRoles & userRoleCode) > 0));

            actionAllowedRoles = rolesWebModules.FirstOrDefault(x => x.Action == CONFIGURE_VIEW)?.roles ?? allRoleCode;
            CanViewConfiguration = ((actionAllowedRoles == allRoleCode) || ((actionAllowedRoles & userRoleCode) > 0));
        }*/
    }
}

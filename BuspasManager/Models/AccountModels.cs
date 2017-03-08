using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;
namespace BuspasManager.Models
{

    [PropertiesMustMatch("NewPassword", "ConfirmPassword", ErrorMessageResourceName = "PasswordsMustMatch", ErrorMessageResourceType = typeof(LanguageResource))]
    public class ChangePasswordModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("CurrentPassword", NameResourceType = typeof(LanguageResource))]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("NewPassword", NameResourceType = typeof(LanguageResource))]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("ConfirmPassword", NameResourceType = typeof(LanguageResource))]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [LocalizedDisplayName("UserName", NameResourceType = typeof(LanguageResource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("Password", NameResourceType = typeof(LanguageResource))]
        public string Password { get; set; }

        public bool IsrCom = false;

        public RoleModel Roles;

        public string ReturnUrl { get; set; }

        [LocalizedDisplayName("RememberMe", NameResourceType = typeof(LanguageResource))]
        public bool RememberMe { get; set; }
    }

    [PropertiesMustMatch("Password", "ConfirmPassword",
      ErrorMessageResourceName = "PasswordsMustMatch", ErrorMessageResourceType = typeof(LanguageResource))]
    public class RegisterModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [LocalizedDisplayName("UserName", NameResourceType = typeof(LanguageResource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [DataType(DataType.EmailAddress)]
        [LocalizedDisplayName("EmailAddress", NameResourceType = typeof(LanguageResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [ValidatePasswordLength]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("Password", NameResourceType = typeof(LanguageResource))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [DataType(DataType.Password)]
        [LocalizedDisplayName("ConfirmPassword", NameResourceType = typeof(LanguageResource))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(LanguageResource))]
        [DataType(DataType.Text)]
        [LocalizedDisplayName("UserRole", NameResourceType = typeof(LanguageResource))]
        public string Role { get; set; }
    }


    #region Services
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public class UserAspnet
    {
        public MembershipUser MembershipUser { get; set; }
        public string Role { get; set; }
    }

    public class UserAspnets : List<UserAspnet>
    {


        public UserAspnets()
        {
            int total;

            MembershipUserCollection coll = Membership.Provider.GetAllUsers(0, 1000, out total);
            foreach (MembershipUser user in coll)
            {
                UserAspnet userAspnet = new UserAspnet()
                {
                    MembershipUser = user,
                    Role = Roles.GetRolesForUser(user.UserName)[0]
                };
                this.Add(userAspnet);
            }
        }
    }

    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email, string role);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        bool DeleteUser(string userName);
        string ResetPassword(string userName);
        bool UpdateUser(string username, string email, string role);
        bool UnLockUser(string userName);
    }

    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException(LanguageResource.NoNulls, "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException(LanguageResource.NoNulls, "password");

            return _provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email, string role)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException(LanguageResource.NoNulls, "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException(LanguageResource.NoNulls, "password");
            //           if (String.IsNullOrEmpty(email)) throw new ArgumentException(LanguageResource.NoNulls, "email");
            if (String.IsNullOrEmpty(role)) throw new ArgumentException(LanguageResource.NoNulls, "role");

            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            Roles.AddUserToRole(userName, role);
            return status;
        }

        public bool UpdateUser(string userName, string email, string role)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException(LanguageResource.NoNulls, "userName");
            if (String.IsNullOrEmpty(role)) throw new ArgumentException(LanguageResource.NoNulls, "role");
            MembershipUser user;
            int count;
            MembershipUserCollection coll = _provider.FindUsersByName(userName, 0, 10000, out count);
            if (count == 0 || count > 1) return false;
            user = coll[userName];
            if (user.Email != email) user.Email = email;
            string[] currentRole = Roles.GetRolesForUser(userName);
            if (currentRole.Length == 0 || !currentRole[0].Equals(role))
            {
                Roles.RemoveUserFromRoles(userName, currentRole);
                Roles.AddUserToRole(userName, role);
            }

            _provider.UpdateUser(user);
            return true;
        }
        

        public bool UnLockUser(string userName)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException(LanguageResource.NoNulls, "userName");

            MembershipUser user;
            int count;
            MembershipUserCollection coll = _provider.FindUsersByName(userName, 0, 10000, out count);
            if (count == 0 || count > 1) return false;
            user = coll[userName];

            user.UnlockUser();

            _provider.UpdateUser(user);
            return true;
        }

        public bool DeleteUser(string userName)
        {
            return _provider.DeleteUser(userName, true);
        }

        public string ResetPassword(string userName)
        {
            try
            {
                return _provider.ResetPassword(userName, null);
            }
            catch
            {
                return null;
            }
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException(LanguageResource.NoNulls, "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException(LanguageResource.NoNulls, "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException(LanguageResource.NoNulls, "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException(LanguageResource.NoNulls, "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
    #endregion

    #region Validation
    public static class AccountValidation
    {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return LanguageResource.DuplicateUserName;

                case MembershipCreateStatus.DuplicateEmail:
                    return LanguageResource.DuplicateEmail;

                case MembershipCreateStatus.InvalidPassword:
                    return LanguageResource.InvalidPassword;

                case MembershipCreateStatus.InvalidEmail:
                    return LanguageResource.InvalidEmail;

                case MembershipCreateStatus.InvalidAnswer:
                    return LanguageResource.InvalidAnswer;

                case MembershipCreateStatus.InvalidQuestion:
                    return LanguageResource.InvalidQuestion;

                case MembershipCreateStatus.InvalidUserName:
                    return LanguageResource.InvalidUserName;

                case MembershipCreateStatus.ProviderError:
                    return LanguageResource.ProviderError;

                case MembershipCreateStatus.UserRejected:
                    return LanguageResource.UserRejected;

                default:
                    return LanguageResource.UnknownError;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' and '{1}' do not match.";
        private readonly object _typeId = new object();

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Object.Equals(originalValue, confirmValue);
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "{0} must be at least {1} characters long";
        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        public ValidatePasswordLengthAttribute()
            : base(_defaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            return (valueAsString != null && valueAsString.Length >= _minCharacters);
        }
    }
    #endregion
}

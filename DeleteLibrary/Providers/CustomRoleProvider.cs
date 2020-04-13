using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DeleteLibrary.Context;
using DeleteLibrary.Models;

namespace DeleteLibrary.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (LibraryContext db = new LibraryContext())
            {
                User user = db.Users.FirstOrDefault(m => m.Login == username);
                if (user != null)
                {
                    Role role = db.Roles.Find(user.RoleId);
                    if (role != null)
                    {
                        roles = new string[] { role.Name };
                    }
                }
            }
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (LibraryContext db = new LibraryContext())
            {
                var user = db.Users.FirstOrDefault(m => m.Login == username);
                var role = db.Roles.FirstOrDefault(m => m.Name.ToUpper() == roleName.ToUpper());
                if (user != null && role != null)
                {
                    if (user.RoleId == role.Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
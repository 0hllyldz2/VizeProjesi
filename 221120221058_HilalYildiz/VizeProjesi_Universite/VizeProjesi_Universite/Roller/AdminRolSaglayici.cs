using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using VizeProjesi_Universite.Models.Entity;

namespace VizeProjesi_Universite.Roller
{
    public class AdminRolSaglayici : RoleProvider
    {
        VizeProjesi_UniversiteEntities7 db = new VizeProjesi_UniversiteEntities7();
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

        public override string[] GetRolesForUser(string KullaniciAdi)
        {
            var x = db.Tbl_Admin.FirstOrDefault(y => y.AdminKullaniciAdi == KullaniciAdi);
            return new string[] { x.AdminRol };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
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
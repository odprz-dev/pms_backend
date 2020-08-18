using BR_App.AppViewModels;
using BR_BussinesRules.DBContextAccess;
using DB_ApplicationContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BR_BussinesRules.BrApp
{
    public class AppBr: DbContextApplication
    {
        public IEnumerable<UserViewModel> GetUsers()
        {
            return Db.User
                .ToList()
                .ConvertAll(e=> (UserViewModel)e);
        }

        public UserViewModel GetUserById(string id)
        {
            return Db.User.Find(id);
        }

        public UserViewModel PostUser(UserViewModel model)
        {
            var entityUser = (UserViewModel)model;
            Db.User.Add(entityUser);
            Db.SaveChanges();

            return entityUser;
        }


        public UserViewModel PutUser(string id, UserViewModel model)
        {
            var entityUser = Db.User.Find(id);
            if (entityUser == null)
            {
                return null;
            }
            entityUser.UserName = model.UserName;
            entityUser.Email = model.Email;
            entityUser.CT_Status = model.CtStatus;
            entityUser.Fk_IdSexo = model.FkIdSexo;
            entityUser.PasswordHash = model.PasswordHash;
            entityUser.TimeStamp = model.TimeStamp;


            Db.User.Add(entityUser);
            Db.SaveChanges();

            return entityUser;

        }

        public UserViewModel DeleteUser(string id)
        {
            var entityUser = Db.User.Find(id);
            if (entityUser == null)
            {
                return null;
            }

            Db.User.Remove(entityUser);
            Db.SaveChanges();

            return entityUser;
        }
    }
}

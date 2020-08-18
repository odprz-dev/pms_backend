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
        /// <summary>
        /// Retorna un listado de usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserViewModel> GetUsers()
        {
            return Db.Users
                .ToList()
                .ConvertAll(e=> (UserViewModel)e);
        }

        public UserViewModel GetUserById(string id)
        {
            return Db.Users.Find(id);
        }

        public UserViewModel PostUser(UserViewModel model)
        {
            var entityUser = (Users)model;
            Db.Users.Add(entityUser);
            Db.SaveChanges();

            return entityUser;
        }


        public UserViewModel PutUser(string id, UserViewModel model)
        {
            var entityUser = Db.Users.Find(id);
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


            Db.Users.Add(entityUser);
            Db.SaveChanges();

            return entityUser;

        }

        public UserViewModel DeleteUser(string id)
        {
            var entityUser = Db.Users.Find(id);
            if (entityUser == null)
            {
                return null;
            }

            Db.Users.Remove(entityUser);
            Db.SaveChanges();

            return entityUser;
        }
    }
}

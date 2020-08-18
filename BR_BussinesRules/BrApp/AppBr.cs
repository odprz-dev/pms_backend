using ARQ_App.SecurityTools;
using BR_App.AppViewModels;
using BR_BussinesRules.DBContextAccess;
using DB_ApplicationContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

            string passwordHashed = PassHasher.Hash(model.Password);

            entityUser.PasswordHash = passwordHashed;
            
            Db.Users.Add(entityUser);
            Db.SaveChanges();

            return entityUser;
        }


        public UserViewModel PutUser(string id, UserEditViewModel model)
        {
            var entityUser = Db.Users.Find(id);
            if (entityUser == null)
            {
                return null;
            }
            entityUser.UserName = model.UserName;
            entityUser.Email = model.Email;
            entityUser.Fk_IdSexo = model.FkIdSexo;

            // Comprobando que el password anterior coincida
            var (Verifi, _) = PassHasher.Review(entityUser.PasswordHash, model.LastPassword);

            if(!Verifi) {
                // TODO: handle ValidationException 
                var e = new Exception("El password anterior no coincide");
                throw e;
            }

            string passwordHashed = PassHasher.Hash(model.NewPassword);

            entityUser.PasswordHash = passwordHashed;

            Db.Users.Update(entityUser);
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

            entityUser.CT_Status = false;

            Db.Users.Update(entityUser);
            Db.SaveChanges();

            return entityUser;
        }

    }

}

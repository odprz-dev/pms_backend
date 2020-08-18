using ARQ_App.SecurityTools;
using BR_App.AppViewModels;
using BR_BussinesRules.DBContextAccess;
using DB_ApplicationContext.Models;
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

        public TestHash Test (TestHash test)
        {
            var (Verifi, Up) = PassHasher.Review(test.Hash, test.Password);

            test.IsEqual = Verifi;
            test.NeedUpdt = Up;

            return test;
        }
    }

    public class TestHash
    {
        public string Hash { get; set; }
        public string Password { get; set; }
        public bool IsEqual { get; set; }
        public bool NeedUpdt { get; set; }
    }
}

using DB_ApplicationContext.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BR_App.AppViewModels
{
    public class UserViewModel
    {

        public static implicit operator UserViewModel(User entity)
        {
            return new UserViewModel
            {
                PkIdUser = entity.Pk_IdUser,
                UserName = entity.UserName,
                Email = entity.Email,
                TimeStamp = entity.TimeStamp,
                CtStatus = entity.CT_Status,
                FkIdSexo = entity.Fk_IdSexo

            };
        }

        public static implicit operator User(UserViewModel model)
        {
            return new User
            {
                Fk_IdSexo = model.FkIdSexo,
                UserName = model.UserName,
                Email = model.Email,
                TimeStamp = model.TimeStamp,
                CT_Status = model.CtStatus,

            };
        }

        #region attributes
        public string PkIdUser { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(25, ErrorMessage = "El nombre de usuario debe tener entre 5 y 25 caracteres.", MinimumLength = 5)]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? TimeStamp { get; set; }
        [Required(ErrorMessage = "El estatus de usuario es obligatorio")]
        public bool CtStatus { get; set; }
        [Required(ErrorMessage = "El sexo del usuario es obligatorio")]
        public int FkIdSexo { get; set; }

        public virtual Sexo Sexo { get; set; }
        #endregion
    }
}

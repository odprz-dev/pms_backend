using DB_ApplicationContext.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BR_App.AppViewModels
{
    public class UserViewModel
    {

        public static implicit operator UserViewModel(Users entity)
        {
            return new UserViewModel
            {
                PkIdUser = entity.Pk_IdUser,
                UserName = entity.UserName,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                TimeStamp = entity.TimeStamp,
                CtStatus = entity.CT_Status,
                FkIdSexo = entity.Fk_IdSexo

            };
        }

        public static implicit operator Users(UserViewModel model)
        {
            return new Users
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
        [StringLength(25, ErrorMessage = "El nombre de usuario debe tener maximo 25 caracteres.")]
        [MinLength(7, ErrorMessage ="El nombre de usuario debe tener al menos 7 caracteres")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? TimeStamp { get; set; }
        [Required(ErrorMessage = "El estatus de usuario es obligatorio")]
        public bool CtStatus { get; set; }
        [Required(ErrorMessage = "El sexo del usuario es obligatorio")]
        public int FkIdSexo { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        [MinLength(10, ErrorMessage = "El password debe tener almenos 10 caracteres alfanumericos.")]
        [RegularExpression("^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{10,}$",
            ErrorMessage = "El nuevo password debe tener al menos un caracter en mayuscula un caracter en minuscula un caracter especial(simbolo) y un numero")]
        public string Password { get; set; }
        #endregion
    }

    public class UserEditViewModel
    {
        [Required(ErrorMessage = "El Identificador de usuario es obligatorio")]
        public string PkIdUser { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(25, ErrorMessage = "El nombre de usuario debe tener maximo 25 caracteres.")]
        [MinLength(5, ErrorMessage = "El nombre de usuario debe tener almenos 5 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "El sexo del usuario es obligatorio")]
        public int FkIdSexo { get; set; }

        [Required(ErrorMessage = "El password anterior es obligatorio")]
        public string LastPassword { get; set; }

        [Required(ErrorMessage = "El nuevo password es obligatorio")]
        [MinLength(10,ErrorMessage = "El password debe tener almenos 10 caracteres alfanumericos.")]
        [RegularExpression("^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{10,}$",
            ErrorMessage = "El nuevo password debe tener al menos un caracter en mayuscula, un caracter en minuscula, un caracter especial (simbolo) y un numero")]
        public string NewPassword { get; set; }


    }

    public class UserLoginViewModel
    {
        
        public string Usuario { get; set; }

        public string Password { get; set; }


    }
}

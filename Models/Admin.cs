using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Admin
    {
        [Key]
        public int id {get;set;}

        [Required(ErrorMessage = "Usuario não preenchido")]
        public string username {get;set;}

        [Required(ErrorMessage = "Senha não preenchida")]
        public string pwd {get;set;}

    }
}
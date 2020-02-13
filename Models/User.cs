using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class User
    {
        [Key]
        public int Id {get;set;}

        [Required(ErrorMessage = "Campo obrigatório")]
        public string name {get;set;}
        public string bio {get;set;}
        public string avatar_url {get;set;}

    }
}
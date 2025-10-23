using System.ComponentModel.DataAnnotations;

namespace Demo_App.Model.Dto
{
    public class LoginRequestDto
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

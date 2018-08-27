using System.ComponentModel.DataAnnotations;

namespace AccountingV03.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
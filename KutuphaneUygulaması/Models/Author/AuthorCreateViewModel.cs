using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulaması.Models

{
    public class AuthorCreateViewModel
    {
        [Required, StringLength(50)]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime DateOfBirth { get; set; }
    }
}

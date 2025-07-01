using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulaması.Models
{
    public class BookEditViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        
        [Display(Name = "Yazar")]
        public int AuthorId { get; set; }

        [Required, StringLength(100)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Yayın Tarihi")]
        public DateTime PublishDate { get; set; }

        [Required, StringLength(20)]
        public string ISBN { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Mevcut Kopya")]
        public int CopiesAvailable { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}

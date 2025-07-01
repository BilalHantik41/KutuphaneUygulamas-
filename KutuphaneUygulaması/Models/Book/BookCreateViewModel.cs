using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulaması.Models
{
    public class BookCreateViewModel
    {
        [Required(ErrorMessage = "Kitap başlığı zorunludur")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen bir yazar seçin")]
        [Display(Name = "Yazar")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Tür zorunludur")]
        [StringLength(100)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Yayın Tarihi")]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "ISBN zorunludur")]
        [StringLength(20)]
        public string ISBN { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Kopya sayısı negatif olamaz")]
        [Display(Name = "Mevcut Kopya")]
        public int CopiesAvailable { get; set; }

        // Bu liste validasyona dahil edilmesin diye [ValidateNever]
        [ValidateNever]
        public IEnumerable<SelectListItem> Authors { get; set; }
    }
}

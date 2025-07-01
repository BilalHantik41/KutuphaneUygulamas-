using System;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulaması.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        
        public int AuthorId { get; set; }

        [Required, StringLength(100)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required, StringLength(20)]
        public string ISBN { get; set; }

        [Range(0, int.MaxValue)]
        public int CopiesAvailable { get; set; }

        // Navigation property
        public Author Author { get; set; }
    }
}

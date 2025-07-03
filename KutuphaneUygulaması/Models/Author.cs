using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulaması.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

       
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

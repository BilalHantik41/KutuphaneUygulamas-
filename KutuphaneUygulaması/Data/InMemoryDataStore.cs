using KutuphaneUygulaması.Models;


namespace KutuphaneUygulaması.Data
{
    public static class InMemoryDataStore
    {
        static InMemoryDataStore()
        {
            Authors = new List<Author>
            {
               new Author { Id = 1, FirstName = "Ahmet", LastName = "Yılmaz", DateOfBirth = new System.DateTime(1975,5,12) },
                new Author { Id = 2, FirstName = "Ayşe", LastName = "Demir", DateOfBirth = new System.DateTime(1980,8,3) },
                new Author { Id = 3, FirstName = "Mehmet", LastName = "Kaya",       DateOfBirth = new System.DateTime(1968,  4, 21) },
                new Author { Id = 4, FirstName = "Elif",   LastName = "Şahin",      DateOfBirth = new System.DateTime(1992, 11, 30) },
                new Author { Id = 5, FirstName = "Zeynep", LastName = "Öz",         DateOfBirth = new System.DateTime(1985,  2, 14) },
                new Author { Id = 6, FirstName = "Murat",  LastName = "Arslan",     DateOfBirth = new System.DateTime(1978,  9,  5) },
                new Author { Id = 7, FirstName = "Hasan",  LastName = "Kara",       DateOfBirth = new System.DateTime(1960,  1, 18) },
                new Author { Id = 8, FirstName = "Emine",  LastName = "Koç",        DateOfBirth = new System.DateTime(1990,  7, 27) },
                new Author { Id = 9, FirstName = "Selim",  LastName = "Yıldız",     DateOfBirth = new System.DateTime(1970, 12,  3) },
                new Author { Id = 10,FirstName = "Derya",  LastName = "Öztürk",     DateOfBirth = new System.DateTime(1982,  3,  9) }
            };

            Books = new List<Book>
            {
                new Book { Id = 1, AuthorId= 2, Title = "İlk Kitap",  Genre = "Roman", PublishDate = new DateTime(2000, 1, 1), ISBN = "111-1", CopiesAvailable = 5 },
                new Book { Id = 2, AuthorId= 1, Title = "İkinci Kitap",  Genre = "Hikaye", PublishDate = new DateTime(2005, 6, 15), ISBN = "222-2", CopiesAvailable = 3 },
                new Book { Id = 3, AuthorId = 3,  Title = "Üçüncü Kitap",           Genre = "Roman",       PublishDate = new DateTime(2010,  3, 10), ISBN = "333-3",       CopiesAvailable = 4 },
                new Book { Id = 4, AuthorId = 4,  Title = "Dördüncü Hikaye",        Genre = "Hikaye",      PublishDate = new DateTime(2012,  7, 22), ISBN = "444-4",       CopiesAvailable = 2 },
                new Book { Id = 5, AuthorId = 5,  Title = "Beşinci Roman",          Genre = "Roman",       PublishDate = new DateTime(2015,  9, 15), ISBN = "555-5",       CopiesAvailable = 6 },
                new Book { Id = 6, AuthorId = 6,  Title = "Altıncı Deneme",         Genre = "Deneme",      PublishDate = new DateTime(2018, 12,  1), ISBN = "666-6",       CopiesAvailable = 1 },
                new Book { Id = 7, AuthorId = 7,  Title = "Yedinci Şiir",           Genre = "Şiir",        PublishDate = new DateTime(2020,  5,  5), ISBN = "777-7",       CopiesAvailable = 8 },
                new Book { Id = 8, AuthorId = 8,  Title = "Sekizinci Biyografi",    Genre = "Biyografi",   PublishDate = new DateTime(2021, 11, 11), ISBN = "888-8",       CopiesAvailable = 3 },
                new Book { Id = 9, AuthorId = 9,  Title = "Dokuzuncu Fantastik",    Genre = "Fantastik",   PublishDate = new DateTime(2023,  1,  1), ISBN = "999-9",       CopiesAvailable = 7 },
                new Book { Id = 10,AuthorId = 10, Title = "Onuncu Çocuk Masalı",    Genre = "Çocuk",       PublishDate = new DateTime(2024,  6, 20), ISBN = "101010-10",   CopiesAvailable = 5 }
            };
        }

        public static List<Author> Authors { get; }
        public static List<Book> Books { get; }
    }
}

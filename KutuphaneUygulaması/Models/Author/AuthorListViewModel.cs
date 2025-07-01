namespace KutuphaneUygulaması.Models
{
    public class AuthorListViewModel
    {
        public int Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

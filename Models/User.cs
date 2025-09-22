//using ECommerceALLInOne.Models\User
namespace ECommerceALLInOne.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username {get;set;}
        public required string PasswordHash {get;set;}
        public required string Email {get;set;}
        public required string Role{get;set;}
        public DateTime CreateDate{get;set;}

    }
}
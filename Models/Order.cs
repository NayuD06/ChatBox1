//using ECommerceALLInOne.Models\User
namespace ECommerceALLInOne.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string UserId {get;set;}
        public required string ProductId {get;set;}
        public required string Quantity {get;set;}
        public required string TotalPrice {get;set;}
        public required string Status {get;set;}
        public DateTime CreateDate{get;set;}

        public User? User {get;set;}
        public Products? Products {get;set;}


    }
}
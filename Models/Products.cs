//using ECommerceALLInOne.Models\User
namespace ECommerceALLInOne.Models
{
    public class Products
    {
        public int Id { get; set; }
        public required string Name {get;set;}
        public required string Dicription {get;set;}
        public required decimal Price {get;set;}
        public required int Stock{get;set;}
        public required string ImgPath{get;set;}
        public DateTime CreateDate{get;set;}

    }
}
using FinalProjectWebAPI.Model;
namespace FinalProjectWebAPI.DomainModels.ProductChildClasses
{
    public class Book : FinalProjectWebAPI.Model.Product
    {
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public int PublishingYear { get; set; }
    }
}

using FinalProjectWebAPI.Model;

namespace FinalProjectWebAPI.DomainModels.ProductChildClasses
{
    public class Toy : FinalProjectWebAPI.Model.Product
    {
        public string Manufacturer { get; set; }
        public string Material { get; set; }
    }
}

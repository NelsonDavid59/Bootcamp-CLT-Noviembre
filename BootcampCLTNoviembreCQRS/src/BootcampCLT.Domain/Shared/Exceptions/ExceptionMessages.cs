using BootcampCLT.Domain.Products;
namespace BootcampCLT.Domain.Shared.Exceptions;

public static class ExceptionMessages
{
    public static class Products
    {
        public static readonly string NameRequired = 
            GenerateRequiredFieldMsg(nameof(ProductEntity.Name));
        
        public static readonly string DescriptionRequired = 
            GenerateRequiredFieldMsg(nameof(ProductEntity.Description));
        
        public static readonly string PriceNonNegative = 
            GenerateNonNegativeFieldMsg(nameof(ProductEntity.Price));

        public static readonly string ProductNotFound = "The product with id {0} was not found.";
    }

    private static string GenerateRequiredFieldMsg(string fieldName)
    {
        return $"The field '{fieldName}' is required.";
    }

    private static string GenerateNonNegativeFieldMsg(string fieldName)
    {
        return $"The field '{fieldName}' cannot be a negative value.";
    }
}
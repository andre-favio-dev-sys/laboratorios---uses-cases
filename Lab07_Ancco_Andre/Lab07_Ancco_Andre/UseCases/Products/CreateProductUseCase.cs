using Lab07_Ancco_Andre.DTOs;

namespace Lab07_Ancco_Andre.UseCases.Products;

public class CreateProductUseCase
{
    public string Execute(CreateProductDto product)
    {
        return "Product created successfully.";
    }
}

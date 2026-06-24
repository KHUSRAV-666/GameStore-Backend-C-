using System.Collections.Generic;
using GameStore.Api.Models;
namespace GameStore.Api.Services {
  public interface IProductService {
    IEnumerable<Product> GetProducts();
    Product GetProductById(Guid id);
    void AddProduct(Product product);
  }
}
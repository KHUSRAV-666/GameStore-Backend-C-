using System.Collections.Generic;
using System.Linq;
using GameStore.Api.Models;
using GameStore.Api.Data;
namespace GameStore.Api.Services {
  public class ProductService : IProductService {
    private readonly GameStoreContext _context;
    public ProductService(GameStoreContext context) {
      _context = context;
      // Seed data if database is empty
      if (!_context.Products.Any()) {
        _context.Products.AddRange(new Product { Name = "Laptop" },
                                   new Product { Name = "Smartphone" });
        _context.SaveChanges();
      }
    }
    public IEnumerable<Product> GetProducts() => _context.Products.ToList();
    public Product GetProductById(Guid id) => _context.Products.Find(id);
    public void AddProduct(Product product) {
      _context.Products.Add(product);
      _context.SaveChanges();
    }
  }
}
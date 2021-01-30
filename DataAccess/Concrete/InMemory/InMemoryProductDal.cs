using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle veya SQL den geliyormus gibi simüle verdim.
            _products = new List<Product> {
                new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId=2,ProductId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{CategoryId=3,ProductId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{CategoryId=4,ProductId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{CategoryId=5,ProductId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Referans tipi .Remove ile Linq bilmezsen böyle silersin Bu kod kötü..
            // => Lambda işareti
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //LINQ- Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
            //Tüm listeyi veritabanına alıyor.
        }

        public List<Product> GetByCategory(int categoryId)
        {
            //İçindeki şarta uyan btün elemanları yeni liste haline getirir ve onu döndürür.
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}

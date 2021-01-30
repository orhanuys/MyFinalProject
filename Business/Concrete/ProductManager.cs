using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Bu class her newlendiğinde Bu injectiondaki metodları kullan.Soyutlama için çok önemli
        //Yarın öbür gün Memoryden değil SQL den istenebilir.
        //Gidip Bir SQL Concrete i yaratıp IProductDal implementasyonu yapılır.
        //Ve herhangi bir DB e bağlı kalmadan kodumuzu yazmış olduk.
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş kodlarıvarsa
            return _productDal.GetAll();
        }
    }
}

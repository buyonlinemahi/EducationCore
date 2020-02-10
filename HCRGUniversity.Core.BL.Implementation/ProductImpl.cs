using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ProductImpl : IProduct
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductShoppingRepository _productShoppingRepository;

        private readonly IProductQuantityRepository _productQuantityRepository;

        public ProductImpl(IProductRepository productRepository, IProductShoppingRepository productShoppingRepository, IProductQuantityRepository productQuantityRepository)
        {
            _productRepository = productRepository;
            _productShoppingRepository = productShoppingRepository;
            _productQuantityRepository = productQuantityRepository;
        }

        #region Product

        public int AddProduct(Product product)
        {
            return _productRepository.Add(product).ProductID;
        }

        public int UpdateProduct(Product product)
        {
            return _productRepository.Update(product);
        }
        public void DeleteProduct(int productID)
        {
            _productRepository.Delete(_productRepository.GetById(productID));
        }

        public Product GetProductByID(int productID)
        {
            return (_productRepository.GetById(productID));
        }

        public IEnumerable<ProductShopping> GetProductShoppingAllByProductID(int productID)
        {
            return _productShoppingRepository.GetAll(rk => rk.ProductID == productID).ToList();
        }


        public BLModel.Paged.Product GetPagedProductByProductName(string productName, int skip, int take)
        {
            return new BLModel.Paged.Product
            {
                TotalCount = _productRepository.GetDbSet().ToList().Where(pro => (pro.ProductName.ToLower().StartsWith(productName.ToLower()))).Count(),
                Products = _productRepository.GetDbSet().ToList().Where(pro => (pro.ProductName.ToLower().StartsWith(productName.ToLower()))).OrderByDescending(product => product.ProductID).Skip(skip).Take(take).ToList()

            };
        }
        public BLModel.Paged.ProductPurchaseDetail GetPagedProductByProductType(string productType, int userid, int skip, int take)
        {
            var detail = _productRepository.GetDbSet().ToList().
                Join(_productShoppingRepository.GetDbSet().ToList(), pro => pro.ProductID, pshop => pshop.ProductID,
                (pro, pshop) => new { pro.ProductID, pro.ProductName, pro.ProductFile, pro.ProductImage, pro.ProductPrice, pro.ProductType, pro.ProductDesc, pshop.Date, pshop.UserID })
                .Where(p => p.ProductType.ToLower() == productType.ToLower() && p.UserID == userid).OrderByDescending(p => p.Date)
                .Skip(skip).Take(take).AsQueryable();
            return new BLModel.Paged.ProductPurchaseDetail
            {
                TotalCount = _productRepository.GetDbSet().ToList().Join(_productShoppingRepository.GetDbSet().ToList(), pro => pro.ProductID, pshop => pshop.ProductID, (pro, pshop) => new { pro, pshop }).Where(p => p.pro.ProductType.ToLower() == productType.ToLower() && p.pshop.UserID == userid).Count(),
                ProductPurchaseDetails = detail.Select(pro => new BLModel.ProductPurchase().InjectFrom(pro)).Cast<BLModel.ProductPurchase>().ToList()
            };

        }

        public BLModel.Paged.Product GetPagedProduct(int skip, int take)
        {

            IQueryable<Product> ProList = _productRepository.GetAll().OrderByDescending(product => product.ProductID).Skip(skip).Take(take).AsQueryable();
            return new BLModel.Paged.Product
            {
                TotalCount = _productRepository.GetDbSet().ToList().Count(),
                Products = ProList.ToList()

            };
        }
        #endregion

        #region Product Quantity

        public int AddProductQuantity(ProductQuantity productQuantity)
        {
            return _productQuantityRepository.Add(productQuantity).ProductQuantityID;
        }

        public int UpdateProductQuantity(ProductQuantity productQuantity)
        {
            return _productQuantityRepository.Update(productQuantity);
        }


        public ProductQuantity GetProductQuantityByID(int id)
        {
            return (_productQuantityRepository.GetById(id));
        }

        public BLModel.Paged.ProductQuantityDetail GetProductQuantityDetailByProductID(int productID, int skip, int take)
        {
            return new BLModel.Paged.ProductQuantityDetail
            {
                TotalCount = _productQuantityRepository.GetDbSet().ToList().Where(proqty => (proqty.ProductID == productID)).Count(),
                ProductQuantityDetails = _productQuantityRepository.GetDbSet().ToList().Where(proqty => (proqty.ProductID == productID)).OrderByDescending(proqty => proqty.ProductQuantityID).Skip(skip).Take(take).ToList()

            };
        }

        public BLModel.Paged.ProductQuantityDetail GetProductQuantityByProductID(int productID)
        {
            return new BLModel.Paged.ProductQuantityDetail
            {
                TotalCount = _productQuantityRepository.GetDbSet().ToList().Where(proqty => (proqty.ProductID == productID)).Count(),
                ProductQuantityDetails = _productQuantityRepository.GetDbSet().ToList().Where(proqty => (proqty.ProductID == productID)).OrderByDescending(proqty => proqty.ProductQuantityID).ToList()
            };
        }

        #endregion

    }
}

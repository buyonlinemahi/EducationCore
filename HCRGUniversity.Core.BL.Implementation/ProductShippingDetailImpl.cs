using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ProductShippingDetailImpl : IProductShippingDetail
    {
        private readonly IProductShippingDetailRepository _productShippingDetailRepository;
        private readonly IProductShoppingRepository _productShoppingRepository;
        private readonly IShippingPaymentRepository _shippingPaymentRepository;
        private readonly IShippingAddressRepository _shippingAddressRepository;

        private readonly IProductRepository _productRepository;

        public ProductShippingDetailImpl(IProductShippingDetailRepository productShippingDetailRepository, IProductShoppingRepository productShoppingRepository, IShippingPaymentRepository shippingPaymentRepository, IShippingAddressRepository shippingAddressRepository, IProductRepository productRepository)
        {
            _productShippingDetailRepository = productShippingDetailRepository;
            _productShoppingRepository = productShoppingRepository;
            _shippingPaymentRepository = shippingPaymentRepository;
            _shippingAddressRepository = shippingAddressRepository;
            _productRepository = productRepository;
        }
        public int AddProductShippingDetail(DLModel.ProductShippingDetail _productShippingDetail)
        {
            if (_productShippingDetailRepository.GetAll(rk => rk.ShippingPaymentID == _productShippingDetail.ShippingPaymentID).Count() == 0)
                return _productShippingDetailRepository.Add((DLModel.ProductShippingDetail)new DLModel.ProductShippingDetail().InjectFrom(_productShippingDetail)).ProductShippingDetailID;
            else
                return UpdateProductShippingDetailByShippingPaymentID(_productShippingDetail);
        }
        public int UpdateProductShippingDetail(DLModel.ProductShippingDetail _productShippingDetail)
        {
            return _productShippingDetailRepository.Update((DLModel.ProductShippingDetail)new DLModel.ProductShippingDetail().InjectFrom(_productShippingDetail));
        }

        public int UpdateProductShippingDetailByShippingPaymentID(DLModel.ProductShippingDetail _productShippingDetail)
        {
            _productShippingDetailRepository.UpdateProductShippingDetailByShippingPaymentID(_productShippingDetail);
            return 0;
        }

        public DLModel.ProductShippingDetail GetProductShippingDetailByID(int _productShippingDetailID)
        {
            return (DLModel.ProductShippingDetail)new DLModel.ProductShippingDetail().InjectFrom(_productShippingDetailRepository.GetById(_productShippingDetailID));
        }

        public DLModel.ProductShippingDetail GetProductShippingDetailByProductShippingID(int? _shippingPaymentID)
        {
            return (DLModel.ProductShippingDetail)new DLModel.ProductShippingDetail().InjectFrom(_productShippingDetailRepository.GetAll(rk => rk.ShippingPaymentID == _shippingPaymentID.Value).SingleOrDefault());
        }

        public BLModel.Paged.ProductShippingDetail GetProductShippingDetail(int _skip, int _take)
        {
            return new BLModel.Paged.ProductShippingDetail
            {
                TotalCount = _productShippingDetailRepository.GetAll().Count(),
                ProductShippingDetails = _productShippingDetailRepository.GetAll().Skip(_skip).Take(_take).ToList()
            };
        }
        public BLModel.ProductShippingAddressDetailByID GetProductShippingAddressDetailByID(int? _shippingPaymentID)
        {
            int _shippingAddressID = _shippingPaymentRepository.GetById(_shippingPaymentID.Value).ShippingAddressID.Value;
            return (BLModel.ProductShippingAddressDetailByID)new BLModel.ProductShippingAddressDetailByID().InjectFrom(_shippingAddressRepository.GetById(_shippingAddressID));
        }

        public BLModel.Paged.ProductPurchaseDetail GetProductPurchaseDetailByID(int? _shippingPaymentID, int _skip, int _take)
        {
            var detail = _productRepository.GetDbSet().ToList().
              Join(_productShoppingRepository.GetDbSet().ToList(), pro => pro.ProductID, pshop => pshop.ProductID,
              (pro, pshop) => new { pro.ProductID, pro.ProductName, pro.ProductFile, pro.ProductImage, pro.ProductPrice, pro.ProductType, pro.ProductDesc, pshop.Date, pshop.UserID, pshop.ProductShoppingID, pshop.ShippingPaymentID })
              .Where(pshop => pshop.ShippingPaymentID == _shippingPaymentID.Value).Where(p => p.ProductType.ToLower() == "hard copy").OrderByDescending(p => p.Date)
              .AsQueryable();

            return new BLModel.Paged.ProductPurchaseDetail
            {
                TotalCount = _productRepository.GetDbSet().ToList().Join(_productShoppingRepository.GetDbSet().ToList(), pro => pro.ProductID, pshop => pshop.ProductID, (pro, pshop) => new { pro, pshop }).Where(ps => ps.pshop.ShippingPaymentID == _shippingPaymentID.Value).Where(p => p.pro.ProductType.ToLower() == "hard copy").Count(),
                ProductPurchaseDetails = detail.Select(pro => new BLModel.ProductPurchase().InjectFrom(pro)).Cast<BLModel.ProductPurchase>().Skip(_skip).Take(_take).ToList()
            };
        }

        public BLModel.Paged.ProductPurchasesRecord GetProductPurchaseDetail(int _skip, int _take, int organizationID)
        {
            return new BLModel.Paged.ProductPurchasesRecord
            {
                TotalCount = _productRepository.GetProductPurchaseDetailCount(_skip, _take, organizationID),
                ProductPurchasesRecords = _productRepository.GetProductPurchaseDetail(_skip, _take, organizationID).Select(pro => new BLModel.ProductPurchase().InjectFrom(pro)).Cast<BLModel.ProductPurchase>().ToList()
            };
        }
    }
}

using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ShippingPaymentImpl : IShippingPayment
    {
        private readonly IShippingPaymentRepository _shippingPaymentRepository;
        private readonly IEducationShoppingTempRepository _educationShoppingTempRepository;
        
        private readonly IEducationShoppingRepository _educationShoppingRepository;
        private readonly IProductShoppingRepository _productShoppingRepository;
        private readonly IProductShoppingTempRepository _productShoppingTempRepository;
        private readonly IMyEducationRepository _myEducationRepository;
        private readonly IProductQuantityRepository _productQuantityRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMyEducation _myEducatoinBL;
        private readonly IOrderRepository _orderRepository;

        private readonly IEducationShoppingTemp _educationShoppingTempBL;

        public ShippingPaymentImpl(IOrderRepository orderRepository 
            ,IShippingPaymentRepository shippingPaymentRepository
            , IMyEducationRepository myEducationRepository
            ,IEducationModuleFileRepository educationModuleFileRepository
            ,IMyEducationModuleRepository myEducationModuleRepository
            , IEducationShoppingTempRepository educationShoppingTempRepository
            , IEducationShoppingRepository educationShoppingRepository
            , IProductShoppingRepository productShoppingRepository
            , IProductShoppingTempRepository productShoppingTempRepository, IProductQuantityRepository productQuantityRepository
            , IProductRepository productRepository)
        {
            _shippingPaymentRepository = shippingPaymentRepository;
            _educationShoppingTempRepository = educationShoppingTempRepository;
            _educationShoppingRepository = educationShoppingRepository;
            _productShoppingRepository = productShoppingRepository;
            _orderRepository = orderRepository;
            _myEducatoinBL = new MyEducationImpl(myEducationRepository, myEducationModuleRepository, educationModuleFileRepository);
            _educationShoppingTempBL = new EducationShoppingTempImpl(_educationShoppingTempRepository, _productShoppingTempRepository, _myEducationRepository, _productRepository);
            _productShoppingTempRepository = productShoppingTempRepository;
            _productQuantityRepository = productQuantityRepository;
            _productRepository = productRepository;

        }
        public int addShippingPayment(DLModel.ShippingPayment shippingPayment)
        {
            return _shippingPaymentRepository.Add((DLModel.ShippingPayment)new DLModel.ShippingPayment().InjectFrom(shippingPayment)).ShippingPaymentID;
        }
        public int updateShippingPayment(DLModel.ShippingPayment shippingPayment)
        {
            return _shippingPaymentRepository.Update((DLModel.ShippingPayment)new DLModel.ShippingPayment().InjectFrom(shippingPayment));
        }
        public void deleteShippingPayment(int id)
        {
            _shippingPaymentRepository.Delete(getShippingPaymentByID(id));
        }
        public DLModel.ShippingPayment getShippingPaymentByID(int id)
        {
            return _shippingPaymentRepository.GetById(id);
        }
        public BLModel.Paged.ShippingPayment getAllShippingPaymentByUserID(int UserID, int skip, int take)
        {
            return new BLModel.Paged.ShippingPayment
            {
                TotalCount = _shippingPaymentRepository.GetAll(rk => rk.UserID == UserID).Count(),
                ShippingPayments = _shippingPaymentRepository.GetAll(rk => rk.UserID == UserID).Skip(skip).Take(take).Select(rk => (DLModel.ShippingPayment)new DLModel.ShippingPayment().InjectFrom(rk)).ToList().OrderBy(rk => rk.CreatedOn)
            };
        }

        public DLModel.ShippingPayment getPendingShippingPaymentByUserID(int userID)
        {
            return _shippingPaymentRepository.GetAll(rk => rk.UserID == userID && rk.IsPaymentRecevied == false).SingleOrDefault();
        }

        public void UpdateEducationShoppingCartTempByShippingPaymentID(int _educationShoppingTempID, int _shippingPaymentID ,string PType)
        {
            if (PType.ToLower().Contains("online"))
            {
                Data.Model.EducationShoppingTemp _educationShoppingTemp = new DLModel.EducationShoppingTemp();
                _educationShoppingTemp = _educationShoppingTempRepository.GetById(_educationShoppingTempID);
                _educationShoppingTemp.ShippingPaymentID = _shippingPaymentID;
                _educationShoppingTemp.ProcessedDate = DateTime.Now;
                _educationShoppingTempRepository.Update(_educationShoppingTemp);
            }
            else
            {
                Data.Model.ProductShoppingTemp _productShoppingTemp = new DLModel.ProductShoppingTemp();
                _productShoppingTemp = _productShoppingTempRepository.getProductShoppingTempByID(_educationShoppingTempID);
                _productShoppingTemp.ShippingPaymentID = _shippingPaymentID;
                _productShoppingTemp.IsProcessed = true;
                _productShoppingTemp.ProcessedDate = DateTime.Now;
                _productShoppingTempRepository.Update(_productShoppingTemp);
            }
        }

        public void addEducationShoppingRecordByShippingPaymentID(int _shippingPaymentID)
        {
            IEnumerable<EducationShoppingCart> _educationShoppingCart = _educationShoppingTempRepository.GetEducationShoppingTempByShippingPaymentID(_shippingPaymentID).ToList();
            if (_educationShoppingCart.Count() > 0)
            {
                AddEducationShoppingOrder(_educationShoppingCart);
                _educationShoppingTempBL.DeleteEducationShoppingCartByShippingPaymentID(_shippingPaymentID);
                // _educationShoppingTempBL.DeleteProductShoppingCartByShippingPaymentID(_shippingPaymentID);
            }
        }

        public void AddEducationShoppingOrder(IEnumerable<DLModel.EducationShoppingCart> shoppingcart)
        {
            DLModel.Order order = new DLModel.Order();
            order.UserID = shoppingcart.FirstOrDefault().UserID;
            order.OrderDate = DateTime.Now;
            order.OrderNumber = System.DateTime.Now.ToShortDateString().Replace("/", "").ToString();
            int orderID = AddShoppingOrder(order);

            foreach (var item in shoppingcart)
            {
                if (item.TempID > 0)
                {
                    if (item.CartType == "Course")
                    {
                        DLModel.EducationShopping educationShopping = new DLModel.EducationShopping();
                        educationShopping.OrderID = orderID;
                        educationShopping.CoupanID = item.CoupanID;
                        educationShopping.Date = DateTime.Now;
                        educationShopping.EducationID = item.EduorProID;
                        educationShopping.EducationTypeID = item.EducationTypeID;
                        educationShopping.Quantity = item.Quantity;
                        educationShopping.Grandtotal = item.Price * item.Quantity;
                        educationShopping.UserID = item.UserID;
                        educationShopping.ShippingPaymentID = item.ShippingPaymentID.Value;
                        educationShopping.TaxPercentage = 0;
                        _educationShoppingRepository.Add((DLModel.EducationShopping)new DLModel.EducationShopping().InjectFrom(educationShopping));

                        DLModel.MyEducation myEducation = new DLModel.MyEducation();
                        myEducation.UserID = item.UserID;
                        myEducation.EducationTypeID = item.EducationTypeID;
                        myEducation.EducationID = item.EduorProID;
                        myEducation.PurchaseDate = System.DateTime.Now.Date;
                        myEducation.CredentialID = item.CredentialID;
                        int MEID = _myEducatoinBL.AddMyEducation(myEducation);
                        _myEducatoinBL.AddEducationModuleToMyEducationByEducationID(MEID, item.EduorProID);
                    }
                    else
                    {
                        DLModel.ProductShopping productShopping = new DLModel.ProductShopping();
                        productShopping.OrderID = orderID;
                        productShopping.CoupanID = item.CoupanID;
                        productShopping.Date = DateTime.Now;
                        productShopping.ProductID = item.EduorProID;
                        productShopping.Quantity = item.Quantity;
                        productShopping.Grandtotal = item.Price * item.Quantity;
                        productShopping.UserID = item.UserID;
                        productShopping.ShippingPaymentID = item.ShippingPaymentID.Value;
                        productShopping.TaxPercentage = item.TaxPercentage;
                        // _productShoppingRepository.Add((DLModel.ProductShopping)new DLModel.ProductShopping().InjectFrom(productShopping));
                        _productShoppingRepository.Add(productShopping);

                        HCRGUniversity.Core.Data.Model.ProductQuantity _productQuantity = new DLModel.ProductQuantity();
                        _productQuantity.ProdQuantity = productShopping.Quantity;
                        _productQuantity.ProdQuantityDate = DateTime.Now;
                        _productQuantity.ProductID = productShopping.ProductID;
                        _productQuantity.UserID = productShopping.UserID;
                        _productQuantity.Mode = "Sold";
                        _productQuantityRepository.Add(_productQuantity);

                        ////

                        //HCRGUniversity.Core.Data.Model.Product _product = _productRepository.GetById(_productQuantity.ProductID);
                        //_product.ProductCurrentBalance = _product.ProductCurrentBalance.Value - _productQuantity.ProdQuantity;
                        //_productRepository.Update((DLModel.Product)new DLModel.Product().InjectFrom(_product));
                    }
                }

            }



            //_educationShoppingTempBL.DeleteEducationShoppingCartByUserID(shoppingcart.FirstOrDefault().UserID);
            //_educationShoppingTempBL.DeleteProductShoppingCartByUserID(shoppingcart.FirstOrDefault().UserID);

        }

        public int AddShoppingOrder(DLModel.Order order)
        {
            return _orderRepository.Add((DLModel.Order)new DLModel.Order().InjectFrom(order)).OrderID;
        }


        public ShippingPayment GetShippingPaymentByUserID(int uid)
        {
            var Shipping = _shippingPaymentRepository.GetAll(s => s.UserID == uid && s.IsPaymentRecevied.Value == false).FirstOrDefault();
            return Shipping != null ? (ShippingPayment)new ShippingPayment().InjectFrom(Shipping) : null;
        }

    }
}

using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationShoppingImpl : IEducationShopping
    {
        private readonly IEducationShoppingRepository _educationShoppingRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IEducationShoppingTemp _educationShoppingTempBL;

        private readonly IMyEducation _myEducatoinBL;

        private readonly IProductShoppingRepository _productShoppingRepository;
        private readonly IProductShoppingTempRepository _productShoppingTempRepository;

        private readonly IProductQuantityRepository _productQuantityRepository;

        private readonly IProductRepository _productRepository;

        public EducationShoppingImpl(IEducationShoppingRepository educationShoppingRepository, IOrderRepository orderRepository, IEducationShoppingTempRepository educationShoppingTempBL, IMyEducationRepository myEducationRepository, IMyEducationModuleRepository myEducationModuleRepository, IEducationModuleFileRepository educationModuleFileRepository, IProductShoppingTempRepository productShoppingTempRepository, IProductShoppingRepository productShoppingRepository, IProductQuantityRepository productQuantityRepository, IProductRepository productRepository)
        {
            _educationShoppingRepository = educationShoppingRepository;
            _productShoppingTempRepository = productShoppingTempRepository;
            _productShoppingRepository = productShoppingRepository;
            _orderRepository = orderRepository;
            _educationShoppingTempBL = new EducationShoppingTempImpl(educationShoppingTempBL, productShoppingTempRepository, myEducationRepository, _productRepository);
            _myEducatoinBL = new MyEducationImpl(myEducationRepository, myEducationModuleRepository, educationModuleFileRepository);
            _productQuantityRepository = productQuantityRepository;
            _productRepository = productRepository;

        }

        public int AddShoppingOrder(DLModel.Order order)
        {
            return _orderRepository.Add((DLModel.Order)new DLModel.Order().InjectFrom(order)).OrderID;
        }

        public int UpdateShoppingOrder(DLModel.Order order)
        {
            return _orderRepository.Update((DLModel.Order)new DLModel.Order().InjectFrom(order));
        }

        public DLModel.Order GetOrderByID(int orderID)
        {
            return (DLModel.Order)new DLModel.Order().InjectFrom(_orderRepository.GetById(orderID));
        }

        public void DeleteShoppingOrder(DLModel.Order order)
        {
            _orderRepository.Delete(order);
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



            //_educationShoppingTempBL.DeleteEducationShoppingCartByUserID(shoppingcart.FirstOrDefault().UserID);
            //_educationShoppingTempBL.DeleteProductShoppingCartByUserID(shoppingcart.FirstOrDefault().UserID);

        }


        public void AddEducationShoppingOrderAllAccessPass(DLModel.EducationShoppingCart shoppingcart)
        {
            DLModel.Order order = new DLModel.Order();
            order.UserID = shoppingcart.UserID;
            order.OrderDate = DateTime.Now;
            order.OrderNumber = System.DateTime.Now.ToShortDateString().Replace("/", "").ToString();
            int orderID = AddShoppingOrder(order);

            DLModel.EducationShopping educationShopping = new DLModel.EducationShopping();
            educationShopping.OrderID = orderID;
            educationShopping.CoupanID = shoppingcart.CoupanID;
            educationShopping.Date = DateTime.Now;
            educationShopping.EducationID = shoppingcart.EduorProID;
            educationShopping.EducationTypeID = shoppingcart.EducationTypeID;
            educationShopping.Quantity = shoppingcart.Quantity;
            educationShopping.Grandtotal = shoppingcart.Price * shoppingcart.Quantity;
            educationShopping.UserID = shoppingcart.UserID;
            educationShopping.ShippingPaymentID = shoppingcart.ShippingPaymentID;
            educationShopping.UserAllAccessPassID = shoppingcart.UserAllAccessPassID;
            _educationShoppingRepository.Add((DLModel.EducationShopping)new DLModel.EducationShopping().InjectFrom(educationShopping));

            DLModel.MyEducation myEducation = new DLModel.MyEducation();
            myEducation.UserID = shoppingcart.UserID;
            myEducation.EducationTypeID = shoppingcart.EducationTypeID;
            myEducation.EducationID = shoppingcart.EduorProID;
            myEducation.PurchaseDate = System.DateTime.Now.Date;
            myEducation.CredentialID = shoppingcart.CredentialID;
            int MEID = _myEducatoinBL.AddMyEducation(myEducation);
            _myEducatoinBL.AddEducationModuleToMyEducationByEducationID(MEID, shoppingcart.EduorProID);


        }

        public int UpdateEducationShoppingOrder(DLModel.EducationShopping educationShopping)
        {
            return _educationShoppingRepository.Update((DLModel.EducationShopping)new DLModel.Order().InjectFrom(educationShopping));
        }

        public int UpdateProductShoppingOrder(DLModel.ProductShopping productShopping)
        {
            return _productShoppingRepository.Update((DLModel.ProductShopping)new DLModel.Order().InjectFrom(productShopping));
        }
    }
}

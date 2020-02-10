using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class EducationShoppingTest
    {
        private IEducationShoppingRepository _educationShoppingRepository;
        private IEducationShopping _educationShoppingBL;
        private IEducationShoppingTempRepository _educationShoppingTemp;
        private IProductShoppingTempRepository _productShoppingTemp;
        private IProductQuantityRepository _productQuantityRepository;
        private IProductRepository _productRepository;
        private IProductShoppingRepository _productShopping;
        private IOrderRepository _order;
        private IMyEducationRepository _myEducationRepository;
        private IMyEducationModuleRepository _myEducationModuleRepository;
        private IEducationModuleFileRepository _educationModuleFileRepository;
        private HCRGUniversity.Core.Data.Model.EducationShopping BLModel = new HCRGUniversity.Core.Data.Model.EducationShopping();
        private HCRGUniversity.Core.Data.Model.EducationShoppingCart BLTempModel = new HCRGUniversity.Core.Data.Model.EducationShoppingCart();
        private HCRGUniversity.Core.Data.Model.Order DLModel = new HCRGUniversity.Core.Data.Model.Order();

        [TestInitialize]
        public void EducationInitialize()
        {
            _educationShoppingRepository = new EducationShoppingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productShopping = new ProductShoppingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productRepository = new ProductRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productShoppingTemp = new ProductShoppingTempRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _order = new OrderRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationShoppingTemp = new EducationShoppingTempRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationRepository = new MyEducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationModuleRepository = new MyEducationModuleRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productQuantityRepository = new ProductQuantityRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationShoppingBL = new EducationShoppingImpl(_educationShoppingRepository, _order,
                                               _educationShoppingTemp, _myEducationRepository,
                                                     _myEducationModuleRepository, _educationModuleFileRepository, _productShoppingTemp, _productShopping, _productQuantityRepository, _productRepository);
            _educationModuleFileRepository = new EducationModuleFileRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
        }

        [TestMethod]
        public void addEducationShoppingOrder()
        {
            IList<EducationShoppingCart> obj = new List<EducationShoppingCart>();
            //EducationShoppingCart o = new EducationShoppingCart
            //{
            //    Amount = 34,
            //    PName = "aa",
            //    TempID = 39,
            //    UserID = 123,
            //    CartType="Course",
            //    PType = "Hard",
            //    CoupanID = null,
            //    Date = DateTime.Now,
            //    Price = 34,
            //    Quantity = 1
            //};

            EducationShoppingCart o1 = new EducationShoppingCart
            {
                Amount = 34,
                PName = "aa",
                TempID = 5,
                UserID = 171,
                EduorProID = 2,
               CartType="Product",
                PType = "Hard",
                CoupanID = null,
                Date = DateTime.Now,
                Price = 34,
                Quantity = 1
            };

           // obj.Add(o);
            obj.Add(o1);
            _educationShoppingBL.AddEducationShoppingOrder(obj);
        }

        [TestMethod]
        public void AddShoppingOrder()
        {
            DLModel.UserID = 1;
            DLModel.OrderNumber = "11";
            DLModel.OrderDate = DateTime.Now;
            int result = _educationShoppingBL.AddShoppingOrder(DLModel);
        }
    }
}

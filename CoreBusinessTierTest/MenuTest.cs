using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class MenuTest
    {
        private IMenuRepository _menuRepository;
        private IMenu _MenuBL;
        private HCRGUniversity.Core.Data.Model.Menu DLModelEvent = new HCRGUniversity.Core.Data.Model.Menu();

        [TestInitialize]
        public void MenuInitialize()
        {
            _menuRepository = new MenuRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _MenuBL = new MenuImpl(_menuRepository);
        }

        [TestMethod]
        public void GetAllMenu()
        {
            var result = _MenuBL.getAllMenu();

        }

        [TestMethod]
        public void Get_MenuListByGroupID()
        {
            var menuDetail = _MenuBL.GetUserMenuByGroupID(1);
            Assert.IsTrue(menuDetail != null, "true");
        }
    }
}

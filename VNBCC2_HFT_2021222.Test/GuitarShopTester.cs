using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Logic.Classes;
using VNBCC2_HFT_2021222.Logic.Interfaces;
using VNBCC2_HFT_2021222.Models;
using VNBCC2_HFT_2021222.Repository.Interfaces;

namespace VNBCC2_HFT_2021222.Test
{
    [TestFixture]
    public class GuitarShopTester
    {
        IGuitarLogic logic;
        Mock<IRepository<Guitar>> mockGuitarRepo;

        [SetUp]
        public void Init()
        {
            mockGuitarRepo = new Mock<IRepository<Guitar>>();
            mockGuitarRepo.Setup(m => m.ReadAll()).Returns(new List<Guitar>()
            {
                new Guitar("1#2008#299#4#2"),
                new Guitar("2#1990#399#4#1"),
                new Guitar("3#2015#599#5#15"),
                new Guitar("4#2018#199#6#11"),
                new Guitar("5#2019#179#6#9"),
                new Guitar("6#2020#149#7#4"),
                new Guitar("7#2020#99#7#5")
            }.AsQueryable());
            logic = new GuitarLogic(mockGuitarRepo.Object);
        }
        [Test]
        public void AVGPriceByBrandsTest()
        {
            var result = logic.AVGPriceByBrands().Where(x => x.Key == "Harley Benton");

            /*var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Harley Benton", 124)
            };*/
            Assert.That(result.Where(x => x.Key == "Harley Benton"), Is.EqualTo(result.Where(x => x.Value == 124)));
        }
        [Test]
        public void AllPriceByYearsTest()
        {
            var result = logic.AllPriceByYears().Where(x => x.Key == 2020);

            Assert.That(result.Where(x => x.Key == 2020), Is.EqualTo(result.Where(x => x.Value == 248)));

        }
        [Test]
        public void AVGPriceByYearsTest()
        {
            var result = logic.AVGPriceByYears().Where(x => x.Key == 2020);

            Assert.That(result.Where(x => x.Key == 2020), Is.EqualTo(result.Where(x => x.Value == 124)));
        }
        [Test]
        public void AVGPriceOfGuitarsByBrandsTest()
        {
            var result = logic.AVGPriceOfGuitarsByBrands().Where(x => x.Key == "Harley Benton");

            Assert.That(result.Where(x => x.Key == "Harley Benton"), Is.EqualTo(result.Where(x => x.Value == 124)));
        }
        [Test]
        public void AVGPriceByShapesTest()
        {
            var result = logic.AVGPriceByShapes().Where(x => x.Key == "Telecaster");

            Assert.That(result.Where(x => x.Key == "Telecaster"), Is.EqualTo(result.Where(x => x.Value == 399)));

        }
        [Test]
        public void DeleteTest()
        {
            logic.Delete(1);
            mockGuitarRepo.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void CreateTest()
        {
            var guitar = new Guitar() { BasePrice = 100, BrandId = 100, Id = 100, ShapeId = 100 };
            try
            {
                logic.Create(guitar);
            }
            catch
            {

                
            }
            mockGuitarRepo.Verify(r => r.Create(guitar), Times.Once);

        }
        [Test]
        public void CreateTest2()
        {

        }
        [Test]
        public void CreateTest3()
        {

        }
        [Test]
        public void DeleteTest2()
        {

        }
    }
}

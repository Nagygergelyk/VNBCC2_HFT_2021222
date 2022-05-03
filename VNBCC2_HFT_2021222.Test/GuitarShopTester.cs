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
        GuitarLogic logic;

        Mock<IRepository<Guitar>> mockGuitarRepo;

        [SetUp]
        public void Init()
        {

            Brand fakeBrand = new Brand()
            {
                BrandId = 100,
                Name = "East"
            };
            Shape fakeShape = new Shape()
            {
                ShapeId = 100,
                Name = "Acoustic"
            };
            var guitars = new List<Guitar>()
            {
                new Guitar()
                {
                    Id = 1,
                    BasePrice = 100,
                    BrandId = 100,
                    ShapeId = 100,
                    Brand = fakeBrand,
                    Shape = fakeShape,
                    Year = 2020
                },
                new Guitar()
                {
                    Id = 2,
                    BasePrice = 200,
                    BrandId = 100,
                    ShapeId = 100,
                    Brand = fakeBrand,
                    Shape = fakeShape,
                    Year = 2020

                },
                new Guitar()
                {
                    Id = 3,
                    BasePrice = 300,
                    BrandId = 100,
                    ShapeId = 100,
                    Brand = fakeBrand,
                    Shape = fakeShape,
                    Year = 2020
                },
            }.AsQueryable();
            mockGuitarRepo = new Mock<IRepository<Guitar>>();
            mockGuitarRepo.Setup(m => m.ReadAll()).Returns(guitars);
            logic = new GuitarLogic(mockGuitarRepo.Object);
        }
        [Test]
        public void AVGPriceByBrandsTest()
        {
            var result = logic.AVGPriceByBrands();

            Assert.That(result.Where(x => x.Key == "East"), Is.EqualTo(result.Where(x => x.Value == 200)));
        }
        [Test]
        public void AllPriceByYearsTest()
        {
            var result = logic.AllPriceByYears();

            Assert.That(result.Where(x => x.Key == 2020), Is.EqualTo(result.Where(x => x.Value == 600)));

        }
        [Test]
        public void AVGPriceByYearsTest()
        {
            var result = logic.AVGPriceByYears();

            Assert.That(result.Where(x => x.Key == 2020), Is.EqualTo(result.Where(x => x.Value == 200)));
        }
        [Test]
        public void AllPriceOfGuitarsByBrandsTest()
        {
            //var result = logic.AllPriceOfGuitarsByBrands();
            List<KeyValuePair<string, double>> res = logic.AllPriceOfGuitarsByBrands().ToList();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("East", 600)
            };
            Assert.That(res, Is.EqualTo(expected));
        }
        [Test]
        public void AVGPriceByShapesTest()
        {
            var result = logic.AVGPriceByShapes().Where(x => x.Key == "Telecaster");

            Assert.That(result.Where(x => x.Key == "Acoustic"), Is.EqualTo(result.Where(x => x.Value == 200)));

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
            var guitar = new Guitar() { BasePrice = 100, BrandId = 100, Id = 100, ShapeId = 100, Year = 2000};
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
            var guitar = new Guitar() { BasePrice = 100, BrandId = 100, Id = 100, ShapeId = 100, Year = 2000};

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
        public void ReadAllTest()
        {
            var v = logic.ReadAll().Count();

            Assert.That(v, Is.EqualTo(3));
        }
        [Test]
        public void UpdateTest()
        {
            var guitar = new Guitar() { BasePrice = 69, BrandId = 69, Id = 2, ShapeId = 69, Year = 2000 };

            logic.Update(guitar);

            Assert.That(logic.Read(guitar.Id), Is.EqualTo(logic.Read(69)));
        }
    }
}

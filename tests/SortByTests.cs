using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooliesX.Exercises.Extensions;
using WooliesX.Exercises.Models;
using WooliesX.Exercises.Enums;
using System.Linq;

namespace tests
{
    [TestClass]
    public class SortByTests
    {

        [TestMethod]
        public void SortRecommended_Tests()
        {
            var histories = new[]{
                new ShopperHistory(){ CustomerId = 1, Products = new[]{
                    new Product(){Name="Delta",Price= 23m,Quantity =1},
                    new Product(){Name="Gamma",Price= 34m,Quantity =2},
                    new Product(){Name="Alpha",Price= 1m,Quantity =3}}},
                new ShopperHistory(){ CustomerId = 1, Products = new[]{
                    new Product(){Name="Delta",Price= 9m,Quantity =4},
                    new Product(){Name="Gamma",Price= 123m,Quantity =4},
                    new Product(){Name="Zeta",Price= 0.4m,Quantity =5}}},
                new ShopperHistory(){ CustomerId = 1, Products = new[]{
                    new Product(){Name="Delta",Price= 12m,Quantity =6},
                    new Product(){Name="Alpha",Price= 90m,Quantity =7},
            }}};

            // alpha total = 10
            // Delta total = 11
            // Gamma total = 6
            // Zeta total = 5

            var recommended = histories.SortRecommended().ToArray();            
            Assert.AreEqual("Delta",recommended[0].Name);
            Assert.AreEqual("Alpha",recommended[1].Name);
            Assert.AreEqual("Gamma",recommended[2].Name);
            Assert.AreEqual("Zeta",recommended[3].Name);

            Assert.AreEqual(11,recommended[0].Quantity);
            Assert.AreEqual(10,recommended[1].Quantity);
            Assert.AreEqual(6,recommended[2].Quantity);
            Assert.AreEqual(5,recommended[3].Quantity);
        }

        [TestMethod]
        public void SortBy_Option_Tests()
        {
            // setup
            var products = new[]{
                new Product(){Name="Beta",Price= 23m,Quantity =12},
                new Product(){Name="Gamma",Price= 34m,Quantity =12},
                new Product(){Name="Alpha",Price= 1m,Quantity =12},
                new Product(){Name="Delta",Price= 9m,Quantity =12},
                new Product(){Name="Epsilon",Price= 123m,Quantity =12},
                new Product(){Name="Zeta",Price= 0.4m,Quantity =12},
                new Product(){Name="Eta",Price= 12m,Quantity =12},
                new Product(){Name="Theta",Price= 90m,Quantity =12},
            };

            // act
            var nameAscending = products.Sort(SortBy.Ascending).ToArray();
            var nameDescending = products.Sort(SortBy.Descending).ToArray();
            var priceHigh = products.Sort(SortBy.High).ToArray();
            var priceLow = products.Sort(SortBy.Low).ToArray();

            // assert
            // name ascending
            Assert.AreSame(nameAscending[0], products[2]);
            Assert.AreSame(nameAscending[1], products[0]);
            Assert.AreSame(nameAscending[2], products[3]);
            Assert.AreSame(nameAscending[3], products[4]);
            Assert.AreSame(nameAscending[4], products[6]);
            Assert.AreSame(nameAscending[5], products[1]);
            Assert.AreSame(nameAscending[6], products[7]);
            Assert.AreSame(nameAscending[7], products[5]);

            // name descending
            Assert.AreSame(nameDescending[7], products[2]);
            Assert.AreSame(nameDescending[6], products[0]);
            Assert.AreSame(nameDescending[5], products[3]);
            Assert.AreSame(nameDescending[4], products[4]);
            Assert.AreSame(nameDescending[3], products[6]);
            Assert.AreSame(nameDescending[2], products[1]);
            Assert.AreSame(nameDescending[1], products[7]);
            Assert.AreSame(nameDescending[0], products[5]);

            // price highest first
            Assert.AreSame(priceHigh[0], products[4]);
            Assert.AreSame(priceHigh[1], products[7]);
            Assert.AreSame(priceHigh[2], products[1]);
            Assert.AreSame(priceHigh[3], products[0]);
            Assert.AreSame(priceHigh[4], products[6]);
            Assert.AreSame(priceHigh[5], products[3]);
            Assert.AreSame(priceHigh[6], products[2]);
            Assert.AreSame(priceHigh[7], products[5]);

            // price lowest first
            Assert.AreSame(priceLow[7], products[4]);
            Assert.AreSame(priceLow[6], products[7]);
            Assert.AreSame(priceLow[5], products[1]);
            Assert.AreSame(priceLow[4], products[0]);
            Assert.AreSame(priceLow[3], products[6]);
            Assert.AreSame(priceLow[2], products[3]);
            Assert.AreSame(priceLow[1], products[2]);
            Assert.AreSame(priceLow[0], products[5]);
        }
    }
}
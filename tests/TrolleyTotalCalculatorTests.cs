using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WooliesX.Exercises;
using WooliesX.Exercises.Models;

namespace tests
{
    [TestClass]
    public class TrolleyTotalCalculatorTests
    {
        [TestMethod]
        public void TrolleyTotalCalculator_Calculate_Tests()
        {
            Dictionary<string, KeyValuePair<Trolley, decimal>> cases = new Dictionary<string, KeyValuePair<Trolley, decimal>>(){
                { "NoSpecials", KeyValuePair.Create(new Trolley(){
                    Products = new []{ new ProductInfo(){ Name ="Product0" , Price =12}},
                    Specials = new Special[0],
                    Quantities = new []{new ProductQuantity(){Name = "Product0", Quantity = 5}}
                },60m) },
                { "OneProductSpecial", KeyValuePair.Create(new Trolley(){
                    Products = new []{ new ProductInfo(){ Name ="Product0" , Price =12}},
                    Specials = new []{new Special(){ Total =50, Quantities = new []{ new ProductQuantity(){Name = "Product0", Quantity = 5}} }},
                    Quantities = new []{new ProductQuantity(){Name = "Product0", Quantity = 5}}
                },50m) },
                { "ZeroStandardPrice", KeyValuePair.Create(new Trolley(){
                    Products = new []{ new ProductInfo(){ Name ="Product0" , Price =0}},
                    Specials = new []{new Special(){ Total =50, Quantities = new []{ new ProductQuantity(){Name = "Product0", Quantity = 5}} }},
                    Quantities = new []{new ProductQuantity(){Name = "Product0", Quantity = 5}}
                },0m) },
                { "ZeroSpecialPrice", KeyValuePair.Create(new Trolley(){
                    Products = new []{ new ProductInfo(){ Name ="Product0" , Price =0}},
                    Specials = new []{new Special(){ Total =0, Quantities = new []{ new ProductQuantity(){Name = "Product0", Quantity = 5}} }},
                    Quantities = new []{new ProductQuantity(){Name = "Product0", Quantity = 5}}
                },0m) },
                { "TwoSpecialOffers", KeyValuePair.Create(new Trolley(){
                    Products = new []{ new ProductInfo(){ Name ="Product0" , Price =5}},
                    Specials = new []{
                            new Special(){ 
                                Total =10, 
                                Quantities = new []{ new ProductQuantity(){Name = "Product0", Quantity = 5}} 
                                },
                            new Special(){ 
                                Total =20, 
                                Quantities = new []{ new ProductQuantity(){Name = "Product0", Quantity = 5}} 
                                }
                            },
                    Quantities = new []{new ProductQuantity(){Name = "Product0", Quantity = 5}}
                },10m) },
                { "MultipleProducts", KeyValuePair.Create(new Trolley(){
                    Products = new []{ 
                        new ProductInfo(){ Name ="Product0" , Price =5},
                        new ProductInfo(){ Name ="Product1" , Price =10}
                    },
                    Specials = new []{
                            new Special(){ 
                                Total =10, 
                                Quantities = new []{ 
                                    new ProductQuantity(){Name = "Product0", Quantity = 2},
                                    new ProductQuantity(){Name = "Product1", Quantity = 2}
                                } 
                            },
                        },
                    Quantities = new []{
                        new ProductQuantity(){Name = "Product0", Quantity = 50},
                        new ProductQuantity(){Name = "Product1", Quantity = 25},
                    }
                },260m) }
            };

            foreach (var item in cases)
            {
                AssertLowestTotal(item.Key, item.Value);
            }
        }

        private void AssertLowestTotal(string message, KeyValuePair<Trolley, decimal> source)
        {
            Assert.AreEqual(source.Value, new TrolleyTotalCalculator().Calculate(source.Key), message);
        }
    }
}

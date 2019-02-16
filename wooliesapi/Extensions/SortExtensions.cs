using System.Collections.Generic;
using WooliesX.Exercises;
using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using WooliesX.Exercises.Enums;
using WooliesX.Exercises.Models;

namespace WooliesX.Exercises.Extensions
{
    public static class SortExtensions
    {
        // sorts products based on sortby option chosen
        public static IEnumerable<Product> Sort(this IEnumerable<Product> items, SortBy sortBy)
        {
            switch (sortBy)
            {
                case SortBy.Low:
                    return items.OrderBy(x => x.Price);
                case SortBy.High:
                    return items.OrderByDescending(x => x.Price);
                case SortBy.Ascending:
                    return items.OrderBy(x => x.Name);
                case SortBy.Descending:
                    return items.OrderByDescending(x => x.Name);
                default:
                    throw new Exception("Sort option not supported");
            }
        }
        
        // returns product based on quantity sold in shopping history with highest first
        public static IEnumerable<Product> SortRecommended(this IEnumerable<ShopperHistory> history)
        {
            var products = new Dictionary<string, Product>();
            // gather how much of an item is sold across all customers
            foreach(var order in history)
            {
                foreach(var product in order.Products)
                {
                    if(!products.ContainsKey(product.Name))
                    {
                        products.Add(product.Name,new Product(){ 
                            Name = product.Name,
                            Price = product.Price,
                            Quantity = Convert.ToInt32(product.Quantity)
                        });
                    }
                    else
                    {
                        products[product.Name].Quantity += Convert.ToInt32(product.Quantity);
                    }
                }
            }

            // Sort by total quantity
            return products.OrderByDescending(product=> product.Value.Quantity).Select(product=>product.Value);

        }

    }
}
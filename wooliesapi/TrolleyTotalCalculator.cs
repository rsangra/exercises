using System.Collections.Generic;
using WooliesX.Exercises.Models;
using System.Linq;
using System;

namespace WooliesX.Exercises
{
    // Calculates the lowest possible total based on provided lists of prices, specials and quantities. 
    public class TrolleyTotalCalculator
    {
        private Dictionary<string,decimal> productPrices = new Dictionary<string, decimal>();
        private Dictionary<string,int> productQuantities = new Dictionary<string, int>();
        
        public decimal Calculate(Trolley trolley)
        {
            var gTotal = 0.0m;
            // Read product names to default Prices
            foreach(var product in trolley.Products)
            {
                productPrices.Add(product.Name,product.Price);
            }
            // Read product names to quantities in trolley
            foreach(var quantity in trolley.Quantities)
            {
                productQuantities.Add(quantity.Name,quantity.Quantity);
            }

            var discocunts = new Dictionary<Special, double>();

            // Prepopulate standard price for various specials
            foreach(var special in trolley.Specials)
            {
                 // Standard Price for bundle
                var bStandardPrice = 0m;
                foreach(var item in special.Quantities)
                {
                    bStandardPrice += productPrices[item.Name] * item.Quantity;
                }               
                special.StandardPrice = bStandardPrice;
            } 
            
            bool specialsApplicable = true;
            // loop while any special can be applied
            while(specialsApplicable)
            {
                decimal discount = 0m;
                Special bestSpecial=null;
                // iterate on specials
                foreach(var special in trolley.Specials)
                {       
                    // if the quantity is 0, move to next         
                    if(special.Quantities.Sum(ProductQuantity=>ProductQuantity.Quantity)==0)
                    {
                        continue;
                    }
                    // if the trolley quantities matches special offer
                    if(trolleyHasMatchingQuantity(special))
                    {
                        // calculate discount
                        var itemDiscount = special.StandardPrice - special.Total;
                        // if this special offers better dicount then last best special, replace with this one
                        if(itemDiscount>0 && itemDiscount > discount)
                        {
                            discount = itemDiscount;
                            bestSpecial = special;
                        }
                    }
                }
                // if no special found, break from finding more                
                if(bestSpecial==null)
                {
                    specialsApplicable = false;
                }
                else
                {
                    // apply the special to remaining items
                    foreach(var item in bestSpecial.Quantities)
                    {
                        productQuantities[item.Name] = productQuantities[item.Name] - item.Quantity;
                    }
                    // update trolley total
                    gTotal+= bestSpecial.Total;
                }
            }
            
            // any quantities left are added as the default price
            foreach(var quantity in productQuantities)
            {
                gTotal += productPrices[quantity.Key] * quantity.Value;
            }

            return gTotal;
        }

        // Matches if the special matches the remaining items in the product quantities in a shopping cart
        private bool trolleyHasMatchingQuantity(Special special)
        {
            var bSpecialMatch = false;
            foreach(var item in special.Quantities)
            {                
                if(productQuantities.ContainsKey(item.Name) && productQuantities[item.Name] >= item.Quantity)
                {
                    bSpecialMatch = true;
                }
                else
                {
                    bSpecialMatch = false;
                    break;
                }
            }
            return bSpecialMatch;
        }
    }
}
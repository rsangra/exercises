# exercise-wx
This is a set of APIs as part of woolies-x tech challenge. It has involved writing three apis hosted with azure functions. 

## Assumptions

1. Recommended Sort - I based my recommendation sort on how many of a product quantity is sold. It however fails in the tests provided by woolies. I tried several other approaches but none of them return a positive result.

## Functions (FX)

1. UserFx - Returns my name and my token
2. SortFx - Sorts the products after retrieving it from woolies resource service based on option. In case the option is recommendation, it calls shoppinghistory and returns ordered list based items that are sold most first.
3. TrolleyTotalFx - It finds the lowest total for all the items in the trolley after applying all the specials that are also provided with the trolley model.

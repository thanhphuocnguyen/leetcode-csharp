int MaxBottlesDrunk(int numBottles, int numExchange)
{
    int fullBottles = numBottles;
    int emptyBottles = 0;
    int ans = 0;
    while ((fullBottles + emptyBottles) >= numExchange)
    {
        int bottlesCanDrink = Math.Min(numExchange, fullBottles);
        ans += bottlesCanDrink;
        fullBottles -= bottlesCanDrink;
        emptyBottles += bottlesCanDrink;
        if (emptyBottles >= numExchange)
        {
            fullBottles++;
            emptyBottles -= numExchange;
        }
        numExchange++;
    }
    return ans + fullBottles;
}

Console.WriteLine(MaxBottlesDrunk(13, 6));
public class FoodRatings
{
    Dictionary<string, FoodItem> foodMap;
    Dictionary<string, PriorityQueue<FoodItem, FoodItem>> cuisineMpHeap;
    public class FoodItem
    {
        public string name;
        public string cuisine;
        public int rating;
        public FoodItem(string name, string cuisine, int rating)
        {
            this.name = name;
            this.rating = rating;
            this.cuisine = cuisine;

        }
    }
    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        foodMap = new();
        cuisineMpHeap = new();
        for (int i = 0; i < foods.Length; i++)
        {
            string name = foods[i], cuisine = cuisines[i];
            int rating = ratings[i];
            var footItem = new FoodItem(name, cuisine, ratings[i]);
            foodMap[foods[i]] = footItem;
            if (!cuisineMpHeap.ContainsKey(cuisine))
            {
                cuisineMpHeap[cuisine] = new(Comparer<FoodItem>.Create((a, b) => a.rating == b.rating ? a.name.CompareTo(b.name) : b.rating.CompareTo(a.rating)));
            }
            cuisineMpHeap[cuisine].Enqueue(footItem, footItem);
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        var foodItem = foodMap[food];
        var newFoodItem = new FoodItem(food, foodItem.cuisine, newRating);
        foodMap[food] = new FoodItem(food, foodItem.cuisine, newRating);
        cuisineMpHeap[foodItem.cuisine].Enqueue(newFoodItem, newFoodItem);
    }

    public string HighestRated(string cuisine)
    {
        var top = cuisineMpHeap[cuisine].Peek();
        while (foodMap[top.name].rating != top.rating)
        {
            cuisineMpHeap[cuisine].Dequeue();
            top = cuisineMpHeap[cuisine].Peek();
        }

        return top.name;
    }
}
public class Program
{
    public static void Main()
    {
        var foodRatings = new FoodRatings(["kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi"], ["korean", "japanese", "japanese", "greek", "japanese", "korean"], [9, 12, 8, 15, 14, 7]);
        foodRatings.HighestRated("korean"); // return "kimchi"
                                            // "kimchi" is the highest rated korean food with a rating of 9.
        foodRatings.HighestRated("japanese"); // return "ramen"
                                              // "ramen" is the highest rated japanese food with a rating of 14.
        foodRatings.ChangeRating("sushi", 16); // "sushi" now has a rating of 16.
        foodRatings.HighestRated("japanese"); // return "sushi"
                                              // "sushi" is the highest rated japanese food with a rating of 16.
        foodRatings.ChangeRating("ramen", 16); // "ramen" now has a rating of 16.
        foodRatings.HighestRated("japanese"); // return "ramen"
                                              // Both "sushi" and "ramen" have a rating of 16.
                                              // However, "ramen" is lexicographically smaller than "sushi".

    }
}

/**
 * Your FoodRatings object will be instantiated and called as such:
 * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
 * obj.ChangeRating(food,newRating);
 * string param_2 = obj.HighestRated(cuisine);
 */
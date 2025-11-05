public class MovieRentingSystem
{
    SortedSet<(int price, int shop, int movie)> rented;
    Dictionary<int, SortedSet<(int price, int shop, int movie)>> unrentedMovies;
    Dictionary<(int, int), int> priceByShopMovie;
    public MovieRentingSystem(int n, int[][] entries)
    {
        var comparer = Comparer<(int price, int shop, int movie)>.Create((a, b) => a.price == b.price ? a.shop.CompareTo(b.shop) : a.price.CompareTo(b.price));
        rented = new();
        unrentedMovies = new();
        priceByShopMovie = new();
        foreach (int[] entry in entries)
        {
            int shop = entry[0], movie = entry[1], price = entry[2];
            priceByShopMovie[(shop, movie)] = price;
            if (!unrentedMovies.ContainsKey(movie))
            {
                unrentedMovies[movie] = new(comparer);
            }
            unrentedMovies[movie].Add((price, shop, movie));
        }
    }

    public IList<int> Search(int movie)
    {
        if (!unrentedMovies.ContainsKey(movie))
        {
            return [];
        }
        return unrentedMovies[movie].Take(5).Select(x => x.shop).ToArray();
    }

    public void Rent(int shop, int movie)
    {
        int price = priceByShopMovie[(shop, movie)];
        rented.Add((price, shop, movie));
        unrentedMovies[movie].Remove((price, shop, movie));
    }

    public void Drop(int shop, int movie)
    {
        int price = priceByShopMovie[(shop, movie)];
        rented.Remove((price, shop, movie));
        unrentedMovies[movie].Add((price, shop, movie));
    }

    public IList<IList<int>> Report()
    {
        return rented.Take(5).Select(x => new int[] { x.shop, x.movie }).ToArray();
    }

    public static void Main()
    {
        var sln = new MovieRentingSystem(1, [[0, 1, 3], [0, 5, 3], [0, 7, 3], [0, 6, 3], [0, 2, 3], [0, 3, 3], [0, 4, 3], [0, 8, 3]]);
        sln.Rent(0, 1);
        sln.Report();
        sln.Rent(0, 4);
        sln.Report();
        sln.Rent(0, 3);
        sln.Report();
        sln.Rent(0, 2);
        sln.Report();
        sln.Rent(0, 6);
        sln.Rent(0, 7);
        sln.Report();
    }
}

/**
 * Your MovieRentingSystem object will be instantiated and called as such:
 * MovieRentingSystem obj = new MovieRentingSystem(n, entries);
 * IList<int> param_1 = obj.Search(movie);
 * obj.Rent(shop,movie);
 * obj.Drop(shop,movie);
 * IList<IList<int>> param_4 = obj.Report();
 */
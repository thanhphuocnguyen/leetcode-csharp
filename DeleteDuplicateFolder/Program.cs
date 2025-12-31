public class Solution
{
    public class Trie
    {
        public string serial;
        public Dictionary<string, Trie> children;
        public Trie()
        {
            serial = "";
            children = new();
        }
    }

    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
    {
        var root = new Trie();
        foreach (IList<string> path in paths)
        {
            var curr = root;
            foreach (string name in path)
            {
                if (!curr.children.ContainsKey(name))
                {
                    curr.children[name] = new();
                }
                curr = curr.children[name];
            }
        }

        Dictionary<string, int> serialFreq = new();

        SerialFolders(root, serialFreq);
        IList<IList<string>> ans = new List<IList<string>>();
        List<string> tempPath = new();
        FilterFolders(root, serialFreq, ans, tempPath);

        return ans;
    }

    private void SerialFolders(Trie trie, Dictionary<string, int> serialFreq)
    {
        if (trie.children.Count == 0)
        {
            return;
        }
        List<string> serials = new();
        foreach (var pair in trie.children)
        {
            SerialFolders(pair.Value, serialFreq);
            serials.Add(pair.Key + "(" + pair.Value.serial + ")");
        }
        serials.Sort();
        trie.serial = string.Join(",", serials);
        serialFreq[trie.serial] = serialFreq.GetValueOrDefault(trie.serial, 0) + 1;

    }

    private void FilterFolders(Trie trie, Dictionary<string, int> serialFreq, IList<IList<string>> paths, List<string> path)
    {
        if (serialFreq.ContainsKey(trie.serial) && serialFreq[trie.serial] > 1)
        {
            return;
        }
        if (path.Count > 0)
        {
            paths.Add([.. path]);
        }

        foreach (var pair in trie.children)
        {
            path.Add(pair.Key);
            FilterFolders(pair.Value, serialFreq, paths, path);
            path.RemoveAt(path.Count - 1);
        }
    }

    public static void Main()
    {
        var sln = new Solution();
        sln.DeleteDuplicateFolder([["a"], ["c"], ["d"], ["a", "b"], ["c", "b"], ["d", "a"]]);
    }
}
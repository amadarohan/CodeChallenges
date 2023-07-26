class DictionaryNodeRoot
{
    DictionaryNode _root = new DictionaryNode();

    public void AddWord(string value)
    {
        // Add nodes from string chars.
        DictionaryNode current = this._root;
        for (int i = 0; i < value.Length; i++)
        {
            current = current.Add(value[i]);
        }
        // Set state.
        current.SetWord(value);
    }

    public bool ContainsWord(string value)
    {
        // Get existing nodes from string chars.
        DictionaryNode current = this._root;
        for (int i = 0; i < value.Length; i++)
        {
            current = current.Get(value[i]);
            if (current == null)
            {
                return false;
            }
        }
        // Return state.
        return current != null && current.GetWord() != null;
    }
}

class DictionaryNode
{
    string _word;
    Dictionary<char, DictionaryNode> _dict; // Slow.

    public DictionaryNode Add(char value)
    {
        // Add individual node as child.
        // ... Handle null field.
        if (this._dict == null)
        {
            this._dict = new Dictionary<char, DictionaryNode>();
        }
        // Look up and return if possible.
        DictionaryNode result;
        if (this._dict.TryGetValue(value, out result))
        {
            return result;
        }
        // Store.
        result = new DictionaryNode();
        this._dict[value] = result;
        return result;
    }

    public DictionaryNode Get(char value)
    {
        // Get individual child node.
        if (this._dict == null)
        {
            return null;
        }
        DictionaryNode result;
        if (this._dict.TryGetValue(value, out result))
        {
            return result;
        }
        return null;
    }

    public void SetWord(string word)
    {
        this._word = word;
    }

    public string GetWord()
    {
        return this._word;
    }
}

class Program1
{
    static void Main1()
    {
        // Create a tree.
        DictionaryNodeRoot tree = new DictionaryNodeRoot();
        // Add three words to the tree.
        tree.AddWord("dot");
        tree.AddWord("net");
        tree.AddWord("perls");

        // Search for strings in the tree.
        Console.WriteLine(tree.ContainsWord("perls"));
        Console.WriteLine(tree.ContainsWord("nothing"));
    }
}
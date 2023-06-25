using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class HuffmanTree
{
    private List<Node> nodeList = new List<Node>();
    public Node rootNode;
    public Dictionary<char, int> frequency = new Dictionary<char, int>();


    // build the huffman tree of the input file
    public void buildTree(string input)
    {
        foreach (char c in input)
        {
            if (!frequency.ContainsKey(c))
            {
                // add the character in tree
                frequency.Add(c, 0);
            }
            frequency[c]++;
        }

        foreach (KeyValuePair<char, int> symbol in frequency)
        {
            nodeList.Add(new Node() { character = symbol.Key, frequency = symbol.Value });
        }



        List<Node> orderedNodes = new List<Node>();
        while (nodeList.Count > 1)
        {
            // ordering the nodes on the basis of frequency
            orderedNodes = QuickSortByFrequency(nodeList);

            if (orderedNodes.Count >= 2)
            {
                // Take first two items
                List<Node> takenNode = orderedNodes.Take(2).ToList<Node>();

                // Create a parent node by combining the frequencies
                Node parent = new Node()
                {
                    character = '*',
                    frequency = takenNode[0].frequency + takenNode[1].frequency,
                    leftNode = takenNode[0],
                    rightNode = takenNode[1]
                };

                nodeList.Remove(takenNode[0]);
                nodeList.Remove(takenNode[1]);
                nodeList.Add(parent);
            }

            this.rootNode = nodeList.FirstOrDefault();

        }

    }
    public List<Node> QuickSortByFrequency(List<Node> nodes)
    {
        if (nodes.Count <= 1)
        {
            return nodes;
        }

        int pivotIndex = nodes.Count / 2;
        Node pivotNode = nodes[pivotIndex];

        List<Node> less = new List<Node>();
        List<Node> equal = new List<Node>();
        List<Node> greater = new List<Node>();

        foreach (Node node in nodes)
        {
            if (node.frequency < pivotNode.frequency)
            {
                less.Add(node);
            }
            else if (node.frequency == pivotNode.frequency)
            {
                equal.Add(node);
            }
            else
            {
                greater.Add(node);
            }
        }

        List<Node> sortedList = new List<Node>();
        sortedList.AddRange(QuickSortByFrequency(less));
        sortedList.AddRange(equal);
        sortedList.AddRange(QuickSortByFrequency(greater));

        return sortedList;
    }

    // Encode function for encoding the characters in binary form
    public BitArray Encode(string input)
    {
        List<bool> encodedInput = new List<bool>();

        for (int i = 0; i < input.Length; i++)
        {
            List<bool> encodedCharacter = this.rootNode.Traverse_Tree(input[i], new List<bool>());
            encodedInput.AddRange(encodedCharacter);
        }

        BitArray BitArray = new BitArray(encodedInput.ToArray());

        return BitArray;
    }

    public string Decode(BitArray BitArray)
    {
        Node currentNode = this.rootNode;
        string decoded = "";

        foreach (bool bit in BitArray)
        {
            if (bit)
            {
                if (currentNode.rightNode != null)
                {
                    currentNode = currentNode.rightNode;
                }
            }
            else
            {
                if (currentNode.leftNode != null)
                {
                    currentNode = currentNode.leftNode;
                }
            }

            if (IsLeaf(currentNode))
            {
                decoded += currentNode.character;
                currentNode = this.rootNode;
            }
        }

        return decoded;
    }

    public bool IsLeaf(Node node)
    {

        return (node.leftNode == null && node.rightNode == null);

    }
}
#pragma warning disable // This is an example implementation code, therefore warnings are disabled
public class Node<T>
{
    public int Index { get; set; }
    public T Data { get; set; }
    public List<Node<T>> Neighbors { get; set; } = new List<Node<T>>();
    public List<int> Weights { get; set; } = new List<int>();

    public override string ToString()
    {
        return $"Node with an index [{Index}], value = {Data}, Neighbors count: {Neighbors.Count}"
            + $"\nNeighbors indexes: {string.Join(", ", Neighbors.Select(n => n.Index))}\n";
    }
}

public class Edge<T>
{
    public Node<T> From { get; set; }
    public Node<T> To { get; set; }
    public int Weight { get; set; }

    public override string ToString()
    {
        return $"Edge from {From.Index} to {To.Index} with a weight of {Weight}";
    }
}

public class Graph<T>
{
    private bool _isDirected = false;
    private bool _isWeighted = false;
    public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

    public Graph(bool isDirected, bool isWeighted)
    {
        _isDirected = isDirected;
        _isWeighted = isWeighted;
    }

    public Edge<T> this[int from, int to]
    {
        get
        {
            Node<T> nodeFrom = Nodes[from];
            Node<T> nodeTo = Nodes[to];
            int i = nodeFrom.Neighbors.IndexOf(nodeTo);
            if (i >= 0)
            {
                Edge<T> edge = new Edge<T>()
                {
                    From = nodeFrom,
                    To = nodeTo,
                    Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
                };
                return edge;
            }
            return null;
        }
    }

    public Node<T> AddNode(T value)
    {
        Node<T> node = new Node<T>() { Data = value };
        Nodes.Add(node);
        UpdateIndices();
        return node;
    }

    public void AddEdge(Node<T> from, Node<T> to, int weight = 0)
    {
        from.Neighbors.Add(to);
        if (_isWeighted)
        {
            from.Weights.Add(weight);
        }
        if (!_isDirected)
        {
            to.Neighbors.Add(from);
            if (_isWeighted)
            {
                to.Weights.Add(weight);
            }
        }
    }

    public void RemoveNode(Node<T> nodeToRemove)
    {
        Nodes.Remove(nodeToRemove);
        UpdateIndices();
        foreach (var node in Nodes)
        {
            RemoveEdge(node, nodeToRemove);
        }
    }

    public void RemoveEdge(Node<T> from, Node<T> to)
    {
        int index = from.Neighbors.FindIndex(n => n == to);
        if (index >= 0)
        {
            from.Neighbors.RemoveAt(index);
            if (_isWeighted)
            {
                from.Weights.RemoveAt(index);
            }
        }
    }

    public List<Edge<T>> GetEdges()
    {
        List<Edge<T>> edges = new List<Edge<T>>();
        foreach (Node<T> from in Nodes)
        {
            for (int i = 0; i < from.Neighbors.Count; i++)
            {
                Edge<T> edge = new Edge<T>()
                {
                    From = from,
                    To = from.Neighbors[i],
                    Weight = i < from.Weights.Count ? from.Weights[i] : 0
                };
                edges.Add(edge);
            }
        }
        return edges;
    }

    private void UpdateIndices()
    {
        int i = 0;
        Nodes.ForEach(n => n.Index = i++);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Graph<int> graph = new Graph<int>(true, true);

        Node<int> n1 = graph.AddNode(1);
        Node<int> n2 = graph.AddNode(2);
        Node<int> n3 = graph.AddNode(3);
        Node<int> n4 = graph.AddNode(4);
        Node<int> n5 = graph.AddNode(5);
        Node<int> n6 = graph.AddNode(6);
        Node<int> n7 = graph.AddNode(7);
        Node<int> n8 = graph.AddNode(8);

        graph.AddEdge(n1, n2, 9);
        graph.AddEdge(n1, n3, 5);
        graph.AddEdge(n2, n1, 3);
        graph.AddEdge(n2, n4, 18);
        graph.AddEdge(n3, n4, 12);
        graph.AddEdge(n4, n2, 2);
        graph.AddEdge(n4, n8, 8);
        graph.AddEdge(n5, n4, 9);
        graph.AddEdge(n5, n6, 2);
        graph.AddEdge(n5, n7, 5);
        graph.AddEdge(n5, n8, 3);
        graph.AddEdge(n6, n7, 1);
        graph.AddEdge(n7, n5, 4);
        graph.AddEdge(n7, n8, 6);
        graph.AddEdge(n8, n5, 3);

        Console.WriteLine(" ----------- n1 info ----------- ");
        Console.WriteLine(n1);

        Console.WriteLine(" ------- Display all edges ------- ");
        var edges = graph.GetEdges();
        foreach (var edge in edges)
        {
            Console.WriteLine(edge);
        }

        graph.RemoveNode(n8);
        graph.RemoveNode(n7);
        graph.RemoveNode(n6);
        graph.RemoveNode(n5);
        Console.WriteLine("\n ------- Remove nodes 5 - 8 -------");

        edges = graph.GetEdges();
        foreach (var edge in edges)
        {
            Console.WriteLine(edge);
        }
    }
}
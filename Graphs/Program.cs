#pragma warning disable // This is an example implementation code, therefore warnings are disabled
using Priority_Queue;

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
        return $"Edge from {From.Data} to {To.Data} with a weight of {Weight}";
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

    public List<Node<T>> DFS()
    {
        bool[] isVisited = new bool[Nodes.Count];
        List<Node<T>> result = new List<Node<T>>();
        DFS(isVisited, Nodes[0], result);
        return result;
    }

    private void DFS(bool[] isVisited, Node<T> node, List<Node<T>> result)
    {
        result.Add(node);
        isVisited[node.Index] = true;
        foreach (Node<T> neighbor in node.Neighbors)
        {
            if (!isVisited[neighbor.Index])
            {
                DFS(isVisited, neighbor, result);
            }
        }
    }

    public List<Node<T>> BFS()
    {
        return BFS(Nodes[0]);
    }

    private List<Node<T>> BFS(Node<T> node)
    {
        bool[] isVisited = new bool[Nodes.Count];
        isVisited[node.Index] = true;
        List<Node<T>> result = new List<Node<T>>();
        Queue<Node<T>> queue = new Queue<Node<T>>();
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            Node<T> next = queue.Dequeue();
            result.Add(next);
            foreach (Node<T> neighbor in next.Neighbors)
            {
                if (!isVisited[neighbor.Index])
                {
                    isVisited[neighbor.Index] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
        return result;
    }

    public List<Edge<T>> MinimumSpanningTreeKruskal()
    {
        List<Edge<T>> edges = GetEdges();
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        Queue<Edge<T>> queue = new Queue<Edge<T>>(edges);
        Subset<T>[] subsets = new Subset<T>[Nodes.Count];
        for (int i = 0; i < Nodes.Count; i++)
        {
            subsets[i] = new Subset<T>() { Parent = Nodes[i] };
        }
        List<Edge<T>> result = new List<Edge<T>>();
        while (result.Count < Nodes.Count - 1)
        {
            Edge<T> edge = queue.Dequeue();
            Node<T> from = GetRoot(subsets, edge.From);
            Node<T> to = GetRoot(subsets, edge.To);
            if (from != to)
            {
                result.Add(edge);
                Union(subsets, from, to);
            }
        }
        return result;
    }

    public class Subset<T>
    {
        public Node<T> Parent { get; set; }
        public int Rank { get; set; }
        public override string ToString()
        {
            return $"Subset ar rank {Rank}, parent: {Parent.Data} (index: {Parent.Index})";
        }
    }

    private Node<T> GetRoot(Subset<T>[] subsets, Node<T> node)
    {
        if (subsets[node.Index].Parent != node)
        {
            subsets[node.Index].Parent = GetRoot(
            subsets,
            subsets[node.Index].Parent);
        }
        return subsets[node.Index].Parent;
    }

    private void Union(Subset<T>[] subsets, Node<T> a, Node<T> b)
    {
        if (subsets[a.Index].Rank > subsets[b.Index].Rank)
        {
            subsets[b.Index].Parent = a;
        }
        else if (subsets[a.Index].Rank < subsets[b.Index].Rank)
        {
            subsets[a.Index].Parent = b;
        }
        else
        {
            subsets[b.Index].Parent = a;
            subsets[a.Index].Rank++;
        }
    }

    public List<Edge<T>> MinimumSpanningTreePrim()
    {
        int[] previous = new int[Nodes.Count];
        previous[0] = -1;

        int[] minWeight = new int[Nodes.Count];
        Fill(minWeight, int.MaxValue);
        minWeight[0] = 0;

        bool[] isInMST = new bool[Nodes.Count];
        Fill(isInMST, false);

        for (int i = 0; i < Nodes.Count - 1; i++)
        {
            int minWeightIndex = GetMinimumWeightIndex(minWeight, isInMST);
            isInMST[minWeightIndex] = true;

            for (int j = 0; j < Nodes.Count; j++)
            {
                Edge<T> edge = this[minWeightIndex, j];
                int weight = edge != null ? edge.Weight : -1;
                if (edge != null && !isInMST[j] && weight < minWeight[j])
                {
                    previous[j] = minWeightIndex;
                    minWeight[j] = weight;
                }
            }
        }

        List<Edge<T>> result = new List<Edge<T>>();
        for (int i = 1; i < Nodes.Count; i++)
        {
            Edge<T> edge = this[previous[i], i];
            result.Add(edge);
        }
        return result;
    }

    private void Fill<Q>(Q[] array, Q value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }

    private int GetMinimumWeightIndex(int[] weights, bool[] isInMST)
    {
        int minValue = int.MaxValue;
        int minIndex = 0;
        for (int i = 0; i < Nodes.Count; i++)
        {
            if (!isInMST[i] && weights[i] < minValue)
            {
                minValue = weights[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    public List<Edge<T>> GetShortestPathDijkstra(Node<T> source, Node<T> target)
    {
        int[] previous = new int[Nodes.Count];
        Fill(previous, -1);
        int[] distances = new int[Nodes.Count];
        Fill(distances, int.MaxValue);
        distances[source.Index] = 0;

        SimplePriorityQueue<Node<T>> nodes = new SimplePriorityQueue<Node<T>>();
        for (int i = 0; i < Nodes.Count; i++)
        {
            nodes.Enqueue(Nodes[i], distances[i]);
        }
        while (nodes.Count != 0)
        {
            Node<T> node = nodes.Dequeue();
            for (int i = 0; i < node.Neighbors.Count; i++)
            {
                Node<T> neighbor = node.Neighbors[i];
                int weight = i < node.Weights.Count
                ? node.Weights[i] : 0;
                int weightTotal = distances[node.Index] + weight;
                if (distances[neighbor.Index] > weightTotal)
                {
                    distances[neighbor.Index] = weightTotal;
                    previous[neighbor.Index] = node.Index;
                    nodes.UpdatePriority(neighbor,
                    distances[neighbor.Index]);
                }
            }
        }
        List<int> indices = new List<int>();
        int index = target.Index;
        while (index >= 0)
        {
            indices.Add(index);
            index = previous[index];
        }

        indices.Reverse();
        List<Edge<T>> result = new List<Edge<T>>();
        for (int i = 0; i < indices.Count - 1; i++)
        {
            Edge<T> edge = this[indices[i], indices[i + 1]];
            result.Add(edge);
        }
        return result;
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

        Console.WriteLine("\n------> Remove nodes 5 - 8 <------");

        graph.RemoveNode(n8);
        graph.RemoveNode(n7);
        graph.RemoveNode(n6);
        graph.RemoveNode(n5);
        Console.WriteLine("\n ------- Display all edges ------- ");

        edges = graph.GetEdges();
        foreach (var edge in edges)
        {
            Console.WriteLine(edge);
        }

        Console.WriteLine();
        Console.WriteLine("Depth First Search");
        List<Node<int>> dfsNodes = graph.DFS();
        dfsNodes.ForEach(n => Console.WriteLine($"DFS: Found Node[{n.Index}]"));

        Console.WriteLine();
        Console.WriteLine("Breadth-First Search");
        List<Node<int>> bfsNodes = graph.BFS();
        bfsNodes.ForEach(n => Console.WriteLine($"BFS: Found Node[{n.Index}]"));

        Graph<int> graph2 = new Graph<int>(false, true);
        Node<int> m1 = graph2.AddNode(1);
        Node<int> m2 = graph2.AddNode(2);
        Node<int> m3 = graph2.AddNode(3);
        Node<int> m4 = graph2.AddNode(4);
        Node<int> m5 = graph2.AddNode(5);
        Node<int> m6 = graph2.AddNode(6);
        Node<int> m7 = graph2.AddNode(7);
        Node<int> m8 = graph2.AddNode(8);

        graph.AddEdge(m1, m2, 3);
        graph.AddEdge(m1, m3, 5);
        graph.AddEdge(m2, m4, 4);
        graph.AddEdge(m3, m4, 12);
        graph.AddEdge(m4, m5, 9);
        graph.AddEdge(m4, m8, 8);
        graph.AddEdge(m5, m6, 4);
        graph.AddEdge(m5, m7, 5);
        graph.AddEdge(m5, m8, 1);
        graph.AddEdge(m6, m7, 6);
        graph.AddEdge(m7, m8, 20);

        Console.WriteLine();
        Console.WriteLine("Minimum Spanning Tree Kruskal Algorithm");
        List<Edge<int>> mstKruskal = graph2.MinimumSpanningTreeKruskal();
        mstKruskal.ForEach(e => Console.WriteLine(e));

        Console.WriteLine();
        Console.WriteLine("Minimum Spanning Tree Prime Algorithm");
        List<Edge<int>> mstPrim = graph2.MinimumSpanningTreePrim();
        mstPrim.ForEach(e => Console.WriteLine(e));

        Console.WriteLine();
        Console.WriteLine("Dijkstra's algorithm");
        List<Edge<int>> path = graph2.GetShortestPathDijkstra(m1, m5);
        path.ForEach(e => Console.WriteLine(e));
    }
}
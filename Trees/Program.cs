#pragma warning disable // This is an example implementation code, therefore warnings are disabled
namespace Trees
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; }
    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }
    }

    public class BinaryTreeNode<T> : TreeNode<T>
    {
        public BinaryTreeNode() => Children = new List<TreeNode<T>>() { null, null };
        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> LeftChild
        {
            get => Children[0] as BinaryTreeNode<T>;
            set => Children[0] = value;
        }
        public BinaryTreeNode<T> RightChild
        {
            get => Children[1] as BinaryTreeNode<T>;
            set => Children[1] = value;
        }

        public int GetHeight()
        {
            int height = 1;
            BinaryTreeNode<T> node = this;
            while (node.Parent != null)
            {
                height++;
                node = node.Parent;
            }
            return height;
        }

        // ToString() overload for the sake of the example and fun
        public override string ToString()
        {
            string value = Data != null ? Data.ToString() : "null";
            string parentValue = Parent != null ? Parent.Data.ToString() : "null";
            string leftChildValue = LeftChild != null ? LeftChild.Data.ToString() : "null";
            string rightChildValue = RightChild != null ? RightChild.Data.ToString() : "null";
            return $"Value: {value}, Parent value: {parentValue}, LeftChild value: {leftChildValue}, RightChild value: {rightChildValue}";
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }
        public int Count { get; set; }

        private void TraversePreOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> nodes)
        {
            if (node == null) return;

            nodes.Add(node);
            TraversePreOrder(node.LeftChild, nodes);
            TraversePreOrder(node.RightChild, nodes);
        }
    }

    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
    {
        public bool Contains(T value)
        {
            BinaryTreeNode<T> node = Root;
            while (node != null)
            {
                int result = node.Data.CompareTo(value);
                if (result > 0)
                {
                    node = node.LeftChild;
                }
                else if (result < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(T data)
        {
            BinaryTreeNode<T> parent = GetParentForNewNode(data);
            BinaryTreeNode<T> node = new BinaryTreeNode<T> { Data = data, Parent = parent };

            if (parent == null)
                Root = node;

            else if (data.CompareTo(parent.Data) < 0)
                parent.LeftChild = node;

            else
                parent.RightChild = node;

            Count++;
        }

        public void Remove(T data)
        {
            Remove(Root, data);
        }

        private BinaryTreeNode<T> GetParentForNewNode(T data)
        {
            BinaryTreeNode<T> current = Root;
            BinaryTreeNode<T> parent = null;
            while (current != null)
            {
                parent = current;
                int result = data.CompareTo(current.Data);
                if (result > 0)
                {
                    current = current.RightChild;
                }
                else if (result < 0)
                {
                    current = current.LeftChild;
                }
                else
                {
                    throw new ArgumentException("Value already exists in tree");
                }
            }
            return parent;
        }

        private void Remove(BinaryTreeNode<T> node, T data)
        {
            if (node == null)
                throw new ArgumentException("Value does not exist in tree");

            else if (data.CompareTo(node.Data) < 0)
                Remove(node.LeftChild, data);

            else if (data.CompareTo(node.Data) > 0)
                Remove(node.RightChild, data);

            else
            {
                if (node.LeftChild == null && node.RightChild == null)
                {
                    ReplaceInParent(node, null);
                    Count--;
                }
                else if (node.RightChild == null)
                {
                    ReplaceInParent(node, node.LeftChild);
                    Count--;
                }
                else if (node.LeftChild == null)
                {
                    ReplaceInParent(node, node.RightChild);
                    Count--;
                }
                else
                {
                    BinaryTreeNode<T> successor = FindMinimumInSubtree(node.RightChild);
                    node.Data = successor.Data;
                    Remove(successor, successor.Data);
                }
            }
        }

        private void ReplaceInParent(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            if (node.Parent != null)
            {
                if (node.Parent.LeftChild == node)
                    node.Parent.LeftChild = newNode;
                else
                    node.Parent.RightChild = newNode;
            }
            else
                Root = newNode;

            if (newNode != null)
                newNode.Parent = node.Parent;
        }

        private BinaryTreeNode<T> FindMinimumInSubtree(BinaryTreeNode<T> node)
        {
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinaryTreeNode<int> { Data = 100 };
            tree.Root.LeftChild = new BinaryTreeNode<int> { Data = 50, Parent = tree.Root };
            tree.Root.RightChild = new BinaryTreeNode<int> { Data = 150 };
            tree.Count = 3;


            Console.WriteLine($"Contains(100):{tree.Contains(100)}");
            Console.WriteLine($"Contains(2):{tree.Contains(2)}\n");

            Console.WriteLine(tree.Root);
            Console.WriteLine(tree.Root.LeftChild + "\n");

            tree.Add(60);
            Console.WriteLine("tree.Add(60)");
            Console.WriteLine(tree.Root.LeftChild + "\n");

            tree.Add(40);
            Console.WriteLine("tree.Add(40)");
            Console.WriteLine(tree.Root.LeftChild + "\n");

            tree.Remove(60);
            Console.WriteLine("tree.Remove(60)");
            Console.WriteLine(tree.Root.LeftChild + "\n");

            Console.WriteLine("Height = 1 is for root");
            Console.WriteLine(tree.Root.Data + ".GetHeight(): " + tree.Root.GetHeight());
            Console.WriteLine(tree.Root.LeftChild.Data + ".GetHeight(): " + tree.Root.LeftChild.GetHeight());
            Console.WriteLine(tree.Root.LeftChild.LeftChild.Data + ".GetHeight(): " + tree.Root.LeftChild.LeftChild.GetHeight());
            Console.WriteLine();
        }
    }
}

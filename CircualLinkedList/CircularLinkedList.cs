#pragma warning disable
// Implementation of CircularLinkedList
using System.Collections;
public class CircularLinkedList<T> : LinkedList<T>
{
    // IEnumerator allows to iterate through a list foreach loop
    public new IEnumerator GetEnumerator()
    {
        return new CircularLinkedListEnumerator<T>(this);
    }
}

public class CircularLinkedListEnumerator<T> : IEnumerator<T>
{
    private LinkedListNode<T> _current;

    public T Current => _current.Value;

    object IEnumerator.Current => Current;

    public CircularLinkedListEnumerator(LinkedList<T> list)
    {
        _current = list.First;
    }

    public bool MoveNext()
    {
        if (_current is null)  return false;

        _current = _current.Next ?? _current.List.First; // infinite iterating through a list
        return true;
    }

    public void Reset()
    {
        _current = _current.List.First;
    }

    public void Dispose()
    {
        // Empty - Dispose() method is not needed
    }
}

// Extension methods
public static class CircularLinkedListExtensions
{
    // Checks if node exists and if list is available
    public static LinkedListNode<T> Next<T> (this LinkedListNode<T> node)
    {
        if (node != null && node.List != null)  return node.Next ?? node.List.First;

        return null;
    }
    // Works the same way as above
    public static LinkedListNode<T> Previous<T> (this LinkedListNode<T> node)
    {
        if (node != null && node.List != null) return node.Previous ?? node.List.Last;
        return null;
    }
}
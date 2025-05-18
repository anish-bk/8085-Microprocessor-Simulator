using System;

class Node
{
    public string data;
    public Node next;

    public Node() { }

    public Node(string data)
    {
        this.data = data;
        next = null;
    }
}

class CStack
{
    private Node top;

    public CStack()
    {
        top = null;
    }

    public bool IsEmpty()
    {
        return (top == null);
    }

    public void Push(string val)
    {
        Node newNode = new Node(val);
        if (top == null)
        {
            top = newNode;
            return;
        }
        newNode.next = top;
        top = newNode;
    }

    public string Pop()
    {
        string temp;
        Node ptr = top;
        temp = ptr.data;
        top = top.next;
        ptr = null;
        return temp;
    }

    public void Display()
    {
        Node temp = top;
        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }
        Console.WriteLine();
    }
}
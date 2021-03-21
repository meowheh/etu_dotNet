using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    public class BinaryTreeNode<T> : IComparable<T> where T: IComparable
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public BinaryTreeNode<T> Left  { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
    public class BinaryTree<T> where T: IComparable
    {
        private BinaryTreeNode<T> _first;
        private int                count;
        private void AddToNode(BinaryTreeNode<T> node, T data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(data);
                }
                else
                {
                    AddToNode(node.Left, data);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(data);
                }
                else
                {
                    AddToNode(node.Right, data);
                }
            }
        }
        //добавление нового элемента
        public void Add(T data)
        {
            if (_first == null)
                _first = new BinaryTreeNode<T>(data);
            else
                AddToNode(_first, data);
            count++;
        }
        //поиск элемента по значению data
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startingNode = null)
        {
            if (startingNode == null)
                startingNode = _first;
            var diff = data.CompareTo(startingNode.Data);
            if (diff == 0)
            {
                return startingNode;
            }
            if(diff < 0)
            {
                return (startingNode.Left != null) ? FindNode(data, startingNode.Left) : null;
            }
            return (startingNode.Right != null) ? FindNode(data, startingNode.Right) : null;
        }
        private BinaryTreeNode<T> FindParent(T data)
        {
            var current = _first;
            BinaryTreeNode<T> parent = null;
            while (current != null)
            {
                var diff = current.CompareTo(data);
                if (diff > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (diff < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return parent;
        }
        //удаление узла из дерева
        public void Remove(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                count--;
                var parent = FindParent(node.Data);
                if (node.Right == null)
                {
                    if (parent == null)
                    {
                        _first = node.Left;
                    }
                    else
                    {
                        var diff = parent.CompareTo(node.Data);
                        if (diff > 0)
                        {
                            parent.Left = node.Left;
                        }
                        else if (diff < 0)
                        { 
                            parent.Right = node.Left;
                        } 
                    } 
                }
                else if (node.Right.Left == null) 
                { 
                    node.Right.Left = node.Left;
                    if (parent == null)
                    {
                        _first = node.Right;
                    } 
                    else 
                    { 
                        var diff = parent.CompareTo(node.Data);
                        if (diff > 0)
                        {
                            parent.Left = node.Right;
                        }
                        else if (diff < 0)
                        {
                            parent.Right = node.Right;
                        } 
                    } 
                }
                else 
                { 
                    var leftmost = node.Right.Left; 
                    var leftmostParent = node.Right;
                    while (leftmost.Left != null)
                    {
                        leftmostParent = leftmost; 
                        leftmost = leftmost.Left;
                    } 
                    leftmostParent.Left = leftmost.Right;
                    leftmost.Left = node.Left;
                    leftmost.Right = node.Right;
                    if (parent == null)
                    {
                        _first = leftmost;
                    } 
                    else
                    { 
                        var diff = parent.CompareTo(node.Data);
                        if (diff > 0)
                        {
                            parent.Left = leftmost;
                        }
                        else if (diff < 0)
                        {
                            parent.Right = leftmost;
                        }
                    }
                }
            }
        }
        //удаление элемента по значению data
        public void Remove(T data)
        {
            var node = FindNode(data);
            Remove(node);
        }

    }
}
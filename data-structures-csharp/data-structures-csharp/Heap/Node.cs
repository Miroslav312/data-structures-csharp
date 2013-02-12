﻿using System;
using System.Diagnostics.Contracts;


namespace DataStructures.HeapSpace
{
    /// <summary>
    /// Node of Heap
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    [Serializable]
    public class Node<T>
        where T : IComparable<T>
    {
        private T val;

        public T Value
        {
            get { return val; }
            internal set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                val = value;
            }
        }
        public int Height { get; internal set; }
        internal Node<T> Parent { get; set; }
        internal Node<T> Left { get; set; }
        internal Node<T> Right { get; set; }

        public Node(T val, Node<T> parent)
        {
            Contract.Requires<ArgumentNullException>(val != null);

            this.val = val;
            Parent = parent;
            Left = null;
            Right = null;
        }

        public bool Equals(Node<T> otherNode)
        {
            if (otherNode == null)
            {
                return false;
            }
            return val.Equals(otherNode.Value);
        }

        public override bool Equals(object obj)
        {
            Node<T> otherNode = obj as Node<T>;
            if (otherNode == null)
            {
                return false;
            }
            return val.Equals(otherNode.Value);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + val.GetHashCode();
                return hash;
            }
        }
    }
}

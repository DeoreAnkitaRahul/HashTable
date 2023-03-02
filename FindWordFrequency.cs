﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class FindWordFrequency<K, V>
    {
        
        private readonly int size;
        private readonly LinkedList<MyMapNode<K, V>>[] items;

        public FindWordFrequency(int size)
        {
            this.size = size;
            items = new LinkedList<MyMapNode<K, V>>[size];
        }
        private int GetArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = hash % size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<MyMapNode<K, V>> linkedList = GetLinkedList(position);
            foreach (MyMapNode<K, V> node in linkedList)
            {
                if (node.Key.Equals(key))
                {
                    return node.Value;
                }
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<MyMapNode<K, V>> linkedList = GetLinkedList(position);
            MyMapNode<K, V> node = new MyMapNode<K, V>() { Key = key, Value = value };
            linkedList.AddLast(node);
        }
        private LinkedList<MyMapNode<K, V>> GetLinkedList(int position)
        {
            LinkedList<MyMapNode<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<MyMapNode<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public void Display()
        {
            foreach (LinkedList<MyMapNode<K, V>> linkedList in items)
            {
                if (linkedList != null)
                {
                    foreach (MyMapNode<K, V> node in linkedList)
                    {
                        Console.WriteLine($"word = {node.Key}, frequency = {node.Value}");
                    }
                }
            }
        }
    }
}
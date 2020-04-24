using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections;

namespace LinkedListQuickSort

{
    class LinkedList
    {
        LinkedNode? head = null;
        int Length = 0;
        bool IsNull = true;

        public LinkedList() { }
        public LinkedList(int num)
        {
            head = new LinkedNode(num);
            IsNull = false;
            Length = 1;

        }
        public LinkedList(LinkedNode newHead)
        {
            head = newHead;
            IsNull = false;
            Length = 1;
        }
        public void Add(int num)
        {
            if (this.IsNull) { head = new LinkedNode(num); IsNull = false; Length++; }
            else
            {
                this.GetLast().Add(num);
                Length++;
            }
        }
        public void Add(LinkedNode node)
        {
            if (this.IsNull) { head = node; IsNull = false; Length++; }
            else
            {
                this.GetLast().next = node;
                Length++;
            }
        }
        public void Add(LinkedList list)
        {
            if (this.IsNull) { head = list.head; IsNull = false; Length = list.Length; }
            else
            {
                this.GetLast().next = list.head;
                Length =  Length +list.Length;
            }
        }
        public LinkedNode GetLast()
        {
            if (this.IsNull) return null;
            else  {return head.GetLast();}
        }
        public LinkedList QuickSort()
        {
            if (IsNull||Length ==1) return this;
            else
            {   
                LinkedNode pivot = GetLast();
                LinkedList LessThan = new LinkedList();
                LinkedList GreaterThan = new LinkedList();
                int index = 0;
                LinkedNode currentNode = this.head;
                while (index < Length - 1)
                {
                    index++;
                    if (currentNode.data < pivot.data) { LessThan.Add(currentNode.data); }
                    else { GreaterThan.Add(currentNode.data); }
                    currentNode = currentNode.next;
                }
                LinkedList sortedLessThan = LessThan.QuickSort();
                LinkedList sortedGreaterThan = GreaterThan.QuickSort();
                sortedLessThan.Add(pivot);
                sortedLessThan.Add(sortedGreaterThan);

                return sortedLessThan;

            }
        }
        public void PrintAll()
        {
            if (IsNull) { Console.WriteLine("Null List"); }
            else { head.PrintAll(); }
        }
    }
    class LinkedNode
    {
        public int data { get; set; }
        public LinkedNode? next { get; set; } = null ;

        public LinkedNode(int num)
        {
            data = num;
        }
        public LinkedNode(int num, LinkedNode newNext)
        {
            data = num;
            next = newNext;
        }
        public void Add(int num)
        {
            this.next = new LinkedNode(num);
        }
        public LinkedNode GetLast()
        {
            if (next == null) { return this; }
            else { return next.GetLast(); }
        }
        public void PrintAll()
        {
            Console.Write(data);
            if (this.next != null) { next.PrintAll(); }
        }
    
    static void Main(string[] args)
    {
        }
}
}

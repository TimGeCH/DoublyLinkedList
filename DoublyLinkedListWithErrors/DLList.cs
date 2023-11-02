using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedListWithErrors
{
    public class DLList
    {
        public DLLNode head; // pointer to the head of the list
        public DLLNode tail; // pointer to the tail of the list
        public DLList() { head = null; tail = null; } // constructor
        /*-------------------------------------------------------------------
        * The methods below includes several errors. Your  task is to write
        * unit test to discover these errors. During delivery the tutor may
        * add or remove errors to adjust the scale of the effort required by
        */
        public void addToTail(DLLNode p)
        {

            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                tail.next = p;
                p.previous = tail; // Fix: Previously, 'tail' was mistakenly set as 'p.previous'
                tail = p;
            }
        } // end of addToTail

        public void addToHead(DLLNode p)
        {
            if (head == null)
            {
                head = p;
                tail = p;
            }
            else
            {
                p.next = this.head;
                this.head.previous = p;
                head = p;
            }
        } // end of addToHead

        public void removeHead()
        {
            if (this.head == null) return;
            if (head.next != null)
            {
                head.next.previous = null;
            }
            this.head = this.head.next;
            // Check if the list is empty after removing the head
            if (head == null)
                tail = null;
        } // removeHead

        public void removeTail()
        {
            if (this.tail == null) return;
            if (this.tail.previous != null)
            {
                tail.previous.next = null;
            }
            this.tail = this.tail.previous;
            // Check if the list is empty after removing the tail
            if (tail == null)
                head = null;
        } // remove tail

        /*-------------------------------------------------
         * Return null if the string does not exist.
         * ----------------------------------------------*/
        public DLLNode search(int num)
        {
            DLLNode p = head;
            while (p != null)
            {
                p = p.next;
                if (p.num == num) break;
            }
            return (p);
        } // end of search (return pionter to the node);

        public void removeNode(DLLNode p)
        {
            if (p == null) return;

            if (p.next != null)
            {
                p.next.previous = p.previous;
            }
            else
            {
                tail = p.previous; // Fix: When removing tail node, tail should move backwards
            }

            if (p.previous != null)
            {
                p.previous.next = p.next;
            }
            else
            {
                head = p.next; // Fix: When removing head node, head should move forwards
            }
        } // end of remove a node

        public int total()
        {
            DLLNode p = head;
            int tot = 0;
            while (p != null)
            {
                tot += p.num;
                p = p.next; // Fix: Should move forward by one node at each iteration
            }
            return tot;
        } // end of total
    } // end of DLList class
}

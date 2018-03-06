using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSs
{

    class LinkedList<T>:IDS<T>
    {
        private LinkedNode<T> head;
        private LinkedNode<T> last;
        public T Last
        {
            get
            {
                return last.data;
            }
        }
        private int count;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= count) throw new IndexOutOfRangeException();
                LinkedNode<T> current = head;
                for(int i = 0;i<index;i++)
                {
                    current = current.next;
                }
                return current.data;
            }
            set
            {
                if (index >= count) throw new IndexOutOfRangeException();
                LinkedNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }
                current.data = value;  
                
            }
        }

        public LinkedList()
        {
            count = 0;
        }
        public LinkedList(T obj)
        {
            head = new LinkedNode<T>(obj);
            count = 1;
        }
        public void Add(T obj)
        {
            if(head == null)
            {
                head = new LinkedNode<T>(obj);
                last = head;
                count++;
                return;
            }
            LinkedNode<T> current = head;
            while(current.next!=null)
            {
                current = current.next;
            }
            current.next = new LinkedNode<T>(obj);
            current.next.pre = current;
            last = current.next;
            count++;
        }
        public void Add(LinkedNode<T> obj)
        {
            if(head==null)
            {
                head = obj;
                last = head;
                count++;
                return;
            }
            LinkedNode<T> current = head;
            while(current.next!=null)
            {
                current = current.next;
            }
            current.next = obj;
            obj.pre = current;
            last = current.next;
            count++;
        }
        public void Delete(T obj)
        {
            LinkedNode<T> current = head;
            while(current != null&& !current.data.Equals(obj) )
            {
                current = current.next;
            }
            if (current == null) return;

            LinkedNode<T> pre = current.pre;
            LinkedNode<T> next = current.next;

            if (pre != null) pre.next = next;
            else head = next;
            if (next != null) next.pre = pre;
            if (current == last) last = pre;
            count--;
        }
        public void DeleteAtIndex(int index)
        {
            if (index >= count) throw new IndexOutOfRangeException();
            LinkedNode<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            LinkedNode<T> pre = current.pre;
            LinkedNode<T> next = current.next;

            if (pre != null) pre.next = next;
            else head = next;
            if (next != null) next.pre = pre;
            if (current == last) last = pre;
            count--;              
        }
        public void DeleteAtKey(int key)
        {
            LinkedNode<T> current = head;
            while(current!=null&&current.Key!=key)
            {
                current = current.next;
            }
            if (current == null) return;

            LinkedNode<T> pre = current.pre;
            LinkedNode<T> next = current.next;

            if (pre != null) pre.next = next;
            else head = next;
            if (next != null) next.pre = pre;
            if (current == last) last = pre;
            count--;
        }
        public T SearchAtKey(int key)
        {
            LinkedNode<T> current = head;
            while(current!=null&&current.Key!=key)
            {
                current = current.next;
            }
            if (current == null) return default(T);
            else return current.data;
        }
        public override string ToString()
        {
            string res = "Count:"+count.ToString()+"   ";
            LinkedNode<T> current = head;
            while(current!=null)
            {
                res += current.data.ToString() + "   ";
                current = current.next;
            }
            return res;
        }

    }
    class LinkedNode<T>
    {
        public T data;
        private int key;
        public int Key
        {
            get
            {
                return key;
            }
        }
        public LinkedNode<T> next;
        public LinkedNode<T> pre;
        public LinkedNode()
        {

        }
        public LinkedNode(T obj)
        {
            data = obj;
            key = obj.GetHashCode();
        }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSs
{
    class BST<T>:IDS<T>
    {
        protected BSTnode<T> root;
        protected int count;

        public BST()
        {
            count = 0;
        }
        public BST(T obj)
        {
            root = new BSTnode<T>(obj);
            count = 1;
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public void Add(T obj)
        {
            if(root==null)
            {
                root = new BSTnode<T>(obj);
                count++;
                return;
            }
            BSTnode<T> current = root;
            BSTnode<T> curP = null;
            BSTnode<T> NEW = new BSTnode<T>(obj);
            while (current!=null)
            {
                curP = current;
                current = (NEW.Key < current.Key) ? current.left_child : current.right_child;   
            }
            
            NEW.parent = curP;
            if(NEW.Key<curP.Key)
            {
                curP.left_child = NEW;
            }
            else
            {
                curP.right_child = NEW;
            }
            count++;    
        }
        public T SearchAtKey(int key)
        {
            BSTnode<T> current = root;
            while(current!=null)
            {
                if (key < current.Key)
                {
                    current = current.left_child;
                }
                else if (key > current.Key)
                {
                    current = current.right_child;
                }
                else return current.data;
            }
            return default(T);              
        }
        private BSTnode<T> SearchAtKey_node(int key)
        {
            BSTnode<T> current = root;
            while (current != null)
            {
                if (key < current.Key)
                {
                    current = current.left_child;
                }
                else if (key > current.Key)
                {
                    current = current.right_child;
                }
                else return current;
            }
            return null;
        }
        private BSTnode<T> SearchAtT_node(T obj)
        {
            BSTnode<T> current = root;
            int key = obj.GetHashCode();
            while (current != null)
            {
                if(current.data.Equals(obj))
                {
                    return current;
                }
                else if (key < current.Key)
                {
                    current = current.left_child;
                }
                else
                {
                    current = current.right_child;
                }                       
            }
            return null;
        }
        public void Delete(T obj)
        {
            BSTnode<T> toDel = this.SearchAtT_node(obj);
            if (toDel == null) return;
            Delete(toDel);
        }
        public void DeleteAtKey(int key)
        {
            BSTnode<T> toDel = this.SearchAtKey_node(key);   
            Delete(toDel);
        }
        private void Delete(BSTnode<T> obj)
        {
            BSTnode<T> toReplace = null;
            if (obj.left_child==null||obj.right_child==null)
            {
                
                if(obj.left_child!=null)
                {
                    toReplace = obj.left_child;   
                }
                else if (obj.right_child!=null)
                {
                    toReplace = obj.right_child;  
                }
            }
            else
            {
                toReplace = obj.right_child.Min();
                Delete(toReplace);
                count++;
                          
                toReplace.left_child = obj.left_child;
                toReplace.right_child = obj.right_child;

            }
            if (obj.parent == null)
            {
                root = toReplace;
            }
            else
            {
                if (obj == obj.parent.left_child)
                {
                    obj.parent.left_child = toReplace;
                }
                else
                {
                    obj.parent.right_child = toReplace;
                }
                if(toReplace!=null)toReplace.parent = obj.parent;
            }
            count--;

        }
        public void PrintSelf()
        {    
            Console.WriteLine("Count = " + count.ToString());
            if (root == null) return;
            root.PrintSelf(0);
        }
    }
    class BSTnode<T>
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
        public BSTnode<T> left_child;
        public BSTnode<T> right_child;
        public BSTnode<T> parent;

        public BSTnode(T target)
        {
            data = target;
            key = target.GetHashCode();
        }
        public BSTnode<T> Min()
        {
            BSTnode<T> current = this;
            while(current.left_child!=null)
            {
                current = current.left_child;
            }
            return current;
        }
        public BSTnode<T> Successor()
        {
            if (this == null) return null;
            if (right_child != null) return right_child.Min();
            if (parent != null && this == parent.left_child) return parent;
            return null;   
        }
        public void PrintSelf(int start)
        {
            string prefix = new string(' ', start);
            string dataStr = data.ToString();
            Console.WriteLine(prefix + dataStr);
            if (right_child == null && left_child == null) return;
            if (right_child == null)
            {
                Console.WriteLine(new string(' ', start + 4) + "RIGHT is NULL");
            }
            else right_child.PrintSelf(start + 4);
            if (left_child == null)
            {
                Console.WriteLine(new string(' ', start + 4) + "LEFT is NULL");
            }
            else left_child.PrintSelf(start + 4);
        }
    }
}

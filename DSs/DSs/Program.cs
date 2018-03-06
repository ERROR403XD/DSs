using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSs
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            Student[] students = new Student[10];
            for(int i =0;i<10;i++)
            {
                students[i] = new Student(rd);
                Console.WriteLine(students[i].ToString());
            }
            //LinkedList<Student> stuList = new LinkedList<Student>();
            BST<Student> stuList = new BST<Student>();
            foreach(Student t in students)
            {
                stuList.Add(t);
            }


            //Console.WriteLine(stuList);
            //Console.WriteLine(stuList[1]);
            stuList.PrintSelf();
            
            while(true)
            {
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input=='a')
                {
                    stuList.Add(new Student(rd));
                }
                if(input == 's')
                {
                    Console.WriteLine(stuList.SearchAtKey(students[4].Key).ToString());
                    //stuList.Delete(stuList.Last);
                }      
                if(input == 'q')
                {
                    stuList.Delete(students[4]); 
                    //stuList.DeleteAtIndex(1);
                }
                if('0'<=input&&'9'>=input)
                {
                    //stuList.DeleteAtIndex(input - '0');
                }
                if(input=='k')
                {
                    //stuList.DeleteAtKey(stuList[1].Key);
                }
                stuList.PrintSelf();
                Console.WriteLine();
                //Console.WriteLine(stuList);     
            }


            Console.ReadKey();
        }

    }
    interface IDS<T>
    {
        void Add(T obj);
        void Delete(T obj);
        void DeleteAtKey(int key);
        T SearchAtKey(int key);
    }
    class Student:SearchData,IComparer<Student>
    {
        private string name;  
        private int num;    
        public Student(Random rd)
        {                     
            name = GetWord(rd)+" "+GetWord(rd);
            num = rd.Next(1000000);
            key = this.GetHashCode();
        }
        public override string ToString()
        {
            return name + " " + num.ToString() + " (" + key.ToString() + ")";
        }
        private string GetWord(Random rd)
        {
            int num = rd.Next(2, 5);
            char[] res = new char[num + 1];
            res[0] = (char)rd.Next('A', 'Z');
            for(int i = 1;i<res.Length;i++)
            {
                res[i] = (char)rd.Next('a', 'z');
            }
            return new string(res);
        }
        public int Compare(Student X,Student Y)
        {
            return X.Key.CompareTo(Y.Key);
        }
        public override int GetHashCode()
        {
            return name.GetHashCode() / 2 + num.GetHashCode() / 2;
        }
    }
    abstract class SearchData
    {
        protected int key;
        public int Key
        {
            get
            {
                return key;
            }
        }
    }

}

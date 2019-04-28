using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Library
{
    public class MyToDo
    {
        public MyToDo(string value)
        {
            Value = value;
        }

        public MyToDo(Guid id, string value, bool completed)
        {
            Id = id;
            Value = value;
            Completed = completed;
        }

        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Value { get; set; }
        public bool Completed { get; set; } = false;
        public override string ToString()
        {
            return Id + "\t" + Value + "\t" + Completed;
        }
    }
    public class ToDoTaskList
    {
       

        private List<MyToDo> myList;

        public bool IsEmpty => myList == null;

        public int Count => myList.Count;

        public void Add(string s)
        {
            if (IsEmpty)
            {
                myList = new List<MyToDo>();
                myList.Add(new MyToDo(s));
            }
            else
            {
                myList.Add(new MyToDo(s));
            }
        }
        public void Add(MyToDo mtd)
        {
            if (IsEmpty)
            {
                myList = new List<MyToDo>();
                myList.Add(mtd);
            }
            else
            {
                myList.Add(mtd);
            }
        }
        public void Compleat(string s)
        {
            foreach (var item in myList)
            {
                if (item.Value == s)
                {
                    item.Completed = true;
                }

            };
        }
        public void CompleatAll(bool b)
        {
            foreach (var item in myList)
            {
                if (b)
                {
                    item.Completed = true;
                }
                else
                    item.Completed = false;


            };
        }

        public void Remove(string s)
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("List is Empty!");
            }

            MyToDo m = null;
            int c = -1;
            foreach (var item in myList)
            {
                if (item.Value == s)
                {
                    m = item;
                    c = 1;
                    break;
                }

            };
            if (c  == 1)
            {
                myList.Remove(m);
            }
            else throw new Exception("string wasn't found!");

        }

        public void RemoveAll(bool b)
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("List is Empty!");
            }
            myList.RemoveAll(x => x.Completed == b);
        }

        public IEnumerable<string> GetAll()
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("List is Empty!");
            }
            return myList.Select(x => x.Value);
        }

        public IEnumerable<string> GetAll(bool b)
        {
            if (IsEmpty)
            {
                throw new NullReferenceException("List is Empty!");
            }
            return myList.Where(x => x.Completed == b).Select(x => x.Value);
        }

        public MyToDo this[string s]
        {
            get
            {
                foreach(MyToDo m in myList)
                {
                    if(m.Value == s)
                    {
                        return m;
                    }

                }
                throw new Exception();
            }
            set
            {
                for (int i =0;i<myList.Count;i++)
                {
                    if (myList[i].Value == s)
                    {
                        myList[i] = value;
                    }

                }
            }
        }
        public MyToDo this[int i]
        {
            get
            {

                return myList[i];
            }
            set
            {
                myList[i] = value;
            }
        }
    }
}

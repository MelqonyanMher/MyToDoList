using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Library
{
    public class ToDoTaskList
    {
        private class MyToDo
        {
            public MyToDo(string value)
            {
                Value = value;
            }

            public Guid Id { get; set; }
            public string Value { get; set; }
            public bool Completed { get; set; } = false;
            public override string ToString()
            {
                return Id + "\t" + Value + "\t" + Completed;
            }
        }

        private List<MyToDo> myList;

        public bool IsEmpty => myList == null;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Task2.Models;

namespace WebApp.Task2.Services
{
    public class ToDoListServices: IToDoListServices
    {
        public static List<ToDoListModel> MyList = new List<ToDoListModel>();

        public ToDoListServices() { }

        public List<ToDoListModel> List()
        {
            return MyList;
        }

        public ToDoListModel Get(int Id)
        {
            return MyList.FirstOrDefault(x => x.Id == Id);
        }
        public ToDoListModel Add(ToDoListModel model)
        {
            MyList.Add(model);
            return model;
        }
        public ToDoListModel Edit(int Id, ToDoListModel model)
        {
            var oldValue = MyList.FirstOrDefault(x => x.Id == Id);
            if (oldValue == null)
                throw new Exception("Item Not Found!");
            oldValue.Id = model.Id;
            oldValue.WhatToDo = model.WhatToDo;
            oldValue.WhenToDo = model.WhenToDo;
            oldValue.Notes = model.Notes;
            return model;
        }
        public ToDoListModel Delete(int Id)
        {
            var oldValue = MyList.FirstOrDefault(x => x.Id == Id);
            if (oldValue == null)
                throw new Exception("Item Not Found!");
            MyList.Remove(oldValue);
            return oldValue;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Task2.Models;

namespace WebApp.Task2.Services
{
    public interface IToDoListServices
    {
        List<ToDoListModel> List();
        ToDoListModel Get(int Id);
        ToDoListModel Add(ToDoListModel model);
        ToDoListModel Edit(int Id, ToDoListModel model);
        ToDoListModel Delete(int Id);
    }
}


using System;
using System.Collections;
using System.Collections.Generic;

namespace CRUDList.Models
{
    public interface ITask
    {
        Task GetTask(int Id);
        IEnumerable<Task> GetAllTask(string title);
        Task AddTask(Task task);
        Task UpdateTask(Task task);
        void DeleteTask(int id);
    }
}

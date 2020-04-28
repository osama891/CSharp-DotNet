using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDList.Models
{
    public class MockTaskRepository: ITask
    {
        private List<Task> _TaskList;
        public MockTaskRepository()
        {
            _TaskList = new List<Task>()
            {
                new Task(){Id=1,Title="Chem",
                Description="Chemistry",
                Priority=Priority.Low,
                Status=Status.InProgress
                }, new Task(){Id=2,Title="Math",
                Description="Mathematics",
                Priority=Priority.High,
                Status=Status.Completed
                },
                 new Task(){Id=3,Title="Chem",
                Description="Chemistry",
                Priority=Priority.Medium,
                Status=Status.Cancelled
                }
            };
}

        public Task AddTask(Task task)
        {
            task.Id = _TaskList.Max(e => e.Id) + 1;
            _TaskList.Add(task);
            return task;
        }

        public void DeleteTask(int id)
        {
            var del= this._TaskList.FirstOrDefault(e => e.Id == id);
            _TaskList.Remove(del);
        }

        public IEnumerable<Task> GetAllTask(string title)
        {
            return this._TaskList.Where(e => e.Title == title);
        }

        public Task GetTask(int Id)
        {
            return this._TaskList.FirstOrDefault(e => e.Id ==Id);
        }

        public Task UpdateTask(Task task)
        {
            Task FirstOcuurence = _TaskList.Where(i => i.Id == task.Id).First();
            var index = _TaskList.IndexOf(FirstOcuurence);

            if (index != -1)
                _TaskList[index] = task;
            return task;
        }
    }
}

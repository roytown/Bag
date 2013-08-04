using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Model;

namespace TaskModule
{
    public static class TaskBll
    {
        public static bool AddTask(Task info)
        {
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Add(info);
        }
    }
}

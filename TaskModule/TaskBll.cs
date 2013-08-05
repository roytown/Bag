﻿using System;
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

        public static Task GetTask(int id)
        {
            if (id<=0)
            {
                return null;
            }
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Get(id);
        }

        public static bool UpdateTask(Task task, params string[] modifyParameters)
        {
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Update(task,modifyParameters);
        }

        public static string GetTaskState(TaskState state)
        {
            string str = "";
            switch (state)
            {
                case TaskState.New:
                    str = "新任务，待确认";
                    break;
                case TaskState.CanDevelop:
                    str = "已确认，可研发";
                    break;
                case TaskState.Designing:
                    str = "设计中";
                    break;
                case TaskState.Plate:
                    str = "设计结束，制版中";
                    break;
                case TaskState.Sampling:
                    str = "制版结束，打样中";
                    break;
                case TaskState.WaitCustomConfirm:
                    str = "样包已完成，等待客户确认";
                    break;
                case TaskState.Ordering:
                    str = "订单生产中";
                    break;
                case TaskState.Stocking:
                    str = "样包待入库";
                    break;
                case TaskState.Stocked:
                    str = "样包已入库";
                    break;
                default:
                    break;
            }

            return str;
        }
    }
}
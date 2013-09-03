using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Database;
using Model;
using ExpressionExtended;
namespace TaskModule
{
    public static class TaskBll
    {
        public static bool AddTask(Task info)
        {
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Add(info);
        }

        public static bool DeleteTask(int id)
        {
            if (id<=0)
            {
                return false;
            }
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Delete(id);
        }

        public static Task GetTask(int id,bool includeLog=false,bool includeOrder=false,bool includeStockLog=false)
        {
            if (id<=0)
            {
                return null;
            }
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Get(id, includeLog, includeOrder, includeStockLog);
        }

        public static Task GetTask(string code, bool includeLog = false, bool includeOrder = false, bool includeStockLog = false)
        {
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Get(code, includeLog, includeOrder, includeStockLog);
        }

        public static bool UpdateTask(Task task, params string[] modifyParameters)
        {
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Update(task,modifyParameters);
        }

        public static IList<Task> GetTaskList(int page, int pageSize, Expression<Func<Task, bool>> expression, out int count, bool includeLog = false, bool includeOrder = false, bool includeStockLog = false)
        {
            ITask taskProvider = new TaskDal(EFContext.Instance);

            return taskProvider.GetList(page, pageSize, includeLog, includeOrder, includeStockLog,expression, out count); 
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
                case TaskState.DevelopConfirmed:
                    str = "研发确认，可开始研发";
                    break;
                case TaskState.Designing:
                    str = "设计中";
                    break;
                case TaskState.DesignEnd:
                    str = "设计结束，可制版";
                    break;
                case TaskState.Plating:
                    str = "制版中";
                    break;
                case TaskState.PlateEnd:
                    str = "制版结束，可打样";
                    break;
                case TaskState.Sampling:
                    str = "打样中";
                    break;
                case TaskState.SampleEnd:
                    str = "打样结束，可生产样包";
                    break;
                case TaskState.Packageing:
                    str = "样包生产中";
                    break;
                case TaskState.PackageEndAndWaitConfirm:
                    str = "样包生产结束，待客户确认";
                    break;
                
                case TaskState.WaitOrderConfirm:
                    str = "订单待确认";
                    break;
                case TaskState.Ordering:
                    str = "订单生产中";
                    break;
                case TaskState.Stocking:
                    str = "待入库";
                    break;
                case TaskState.Stocked:
                    str = "入库完成";
                    break;
                default:
                    str = "未知";
                    break;
            }
            

            return str;
        }
    }
}

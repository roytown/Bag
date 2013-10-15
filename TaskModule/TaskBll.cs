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
            return taskProvider.Get(m=>m.Id==id, includeLog, includeOrder, includeStockLog);
        }

        public static Task GetTask(string code, bool includeLog = false, bool includeOrder = false, bool includeStockLog = false)
        {
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Get(m=>m.Code==code, includeLog, includeOrder, includeStockLog);
        }

        public static Task GetTaskByEpc(string epc, bool includeLog = false, bool includeOrder = false, bool includeStockLog = false)
        {
            if (string.IsNullOrEmpty(epc))
            {
                return null;
            }
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Get(m => m.Ecp == epc, includeLog, includeOrder, includeStockLog);
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

        public static int Count(Expression<Func<Task, bool>> expression)
        {
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Count(expression);
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
                    str = "制版结束，可打样生产";
                    break;
                case TaskState.Sampling:
                    str = "打样生产中";
                    break;
                case TaskState.SampleEnd:
                    str = "打样生产结束，可交付";
                    break;
                case TaskState.Packageing:
                    str = "交付中";
                    break;
                case TaskState.PackageEndAndWaitConfirm:
                    str = "已交付，待客户确认";
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

        public static bool CheckEcpInUse(string ecp)
        {
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Count(m=>m.Ecp==ecp)>0;
        }

        public static bool CheckCodeInUse(string code)
        {
            ITask taskProvider = new TaskDal(EFContext.Instance);
            return taskProvider.Count(m => m.Code == code) > 0;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Task
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(20)]
        public string Customer { get; set; }

        [StringLength(20)]
        public string TelePhone { get; set; }

        [StringLength(20)]
        public string MobilePhone { get; set; }

        public TaskState Status { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public DateTime AddTime { get; set; }

        public string UserName { get; set; }//发布者

        public string SaleUserName { get; set; }//销售负责人

        public string DevelopUserName { get; set; }//研发负责人

        public virtual List<Order> Orders { get; set; }
        public virtual List<Log> Logs { get; set; }
        public virtual List<StockLog> StockLogs { get; set; }

        public int ModifyTimes { get; set; }
    }
}

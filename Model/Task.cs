using System;
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

        //扩展
        [StringLength(100)]
        public string Model { get; set; }//型号
        [StringLength(100)]
        public string Type { get; set; }//款式
        [StringLength(100)]
        public string Materail { get; set; }//材质
        [StringLength(100)]
        public string Quality { get; set; }//品质
        [StringLength(100)]
        public string Brand { get; set; }
        [StringLength(100)]
        public string Color { get; set; }
        [StringLength(100)]
        public string Hardness { get; set; }
        [StringLength(100)]
        public string Fineness { get; set; }//成色
        [StringLength(100)]
        public string Size { get; set; }
        [StringLength(100)]
        public string Pattern { get; set; }//图案
        [StringLength(100)]
        public string Bigness { get; set; }//大小
        [StringLength(100)]
        public string Price { get; set; }
        [StringLength(100)]
        public string Style { get; set; }//风格
        [StringLength(100)]
        public string Texture { get; set; }//里料质地
        [StringLength(100)]
        public string InternalStructure { get; set; }//内部结构
        [StringLength(100)]
        public string CarryPart { get; set; }//提拎部件
        public bool Collapse { get; set; }//可否折叠
        [StringLength(100)]
        public string Situation { get; set; }//场合
        [StringLength(100)]
        public string PopularElement { get; set; }//流行元素
        [StringLength(30)]
        public string Ecp { get; set; }
    }
}

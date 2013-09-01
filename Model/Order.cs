using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Task Task { get; set; }
        [Required]
        [StringLength(100)]
        public string Time { get; set; }
        [Required]
        [StringLength(100)]
        public string Num{get;set;}
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public DateTime AddTime { get; set; }
        [StringLength(50)]
        public string PublishUserName { get; set; }//生产负责人
        [StringLength(50)]
        public string QualityUserName { get; set; }//质检负责人
        public virtual List<OrderExpand> Expands { get; set; }
        public OrderStatus Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderExpand
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Order Order { get; set; }
        [StringLength(200)]
        [Required]
        public string Num { get; set; }
        [StringLength(200)]
        [Required]
        public string Time { get; set; }
        public DateTime AddTime { get; set; }
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }
}

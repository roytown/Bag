using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StockLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime AddTime { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public Task Task { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public bool HasOrder { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime? RangeBegin { get; set; }
        public DateTime? RangeEnd { get; set; }

        public LogType Type { get; set; }
        public LogAction Action { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public Task Task { get; set; }

        public int Extend { get; set; }
    }
}

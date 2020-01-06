using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum.ButtonLogic
{
    public class DictionaryPassword
    {
        [Key]
        public int ID { get; set; }
        [Index]
        [StringLength(500)]
        public string Password { get; set; }
        [Index]
        [StringLength(500)]
        public string Plaintext { get; set; }
        public DateTime? CreateDate { get; set; }
        [Index]
        [StringLength(50)]
        public string PwdType { get; set; }
    }
}

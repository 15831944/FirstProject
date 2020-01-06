using System;
using System.ComponentModel.DataAnnotations;

namespace T4ConsoleApplication.Entities
{    

    public class ButtonDate
    {
        [Key]
        public int ID { get; set; }
              
        public int Index { get; set; }
              
        public string Name { get; set; }
              
        public string Url { get; set; }
              
        public string Browser { get; set; }
              
        public string Type { get; set; }
              
        public string State { get; set; }
              
        public DateTime? CreateDate { get; set; }
         
        public string CreateIP { get; set; }
        public string CreateMac { get; set; }


    }
}


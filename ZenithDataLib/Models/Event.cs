using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZenithDataLib
{
    public class Event
    {
        
        public int Id { get; set; }

        [Display(Name = "From Date")]
        [DataType(DataType.DateTime)]
        public DateTime FromDateTime { get; set; }

        [Display(Name = "To Date")]
        [DataType(DataType.DateTime)]
        public DateTime ToDateTime { get; set; }

        [Display(Name = "Created By")]
        public String Username { get; set; }

        [Display(Name = "Activity")]
        public int ActivityId { get; set; }

        [Display(Name = "Created on")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }


    }
}

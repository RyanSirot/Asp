using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib
{
    public class Event
    {
        public int Id { get; set; }        
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public String Username { get; set; }
        public int ActivityId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }

    }
}

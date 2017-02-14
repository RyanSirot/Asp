using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ZenithDataLib
{
    public class Activity
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Activity Description")]
        public String Description { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreationDate { get; set; }

    }
}

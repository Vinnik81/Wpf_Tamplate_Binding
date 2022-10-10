using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp_ToDo_Items.Models
{
   public class MyTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }
    }
}

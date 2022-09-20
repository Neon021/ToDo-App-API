using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body{ get; set; }
        public DateTime Created{ get; set; } = DateTime.Now;
        public bool Done{ get; set; }
    }
}

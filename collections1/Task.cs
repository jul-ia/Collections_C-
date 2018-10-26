using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections1
{
    class Task
    {
        public string Name { get; set; }
        public bool State { get; set; }

        public Task()
        {
            Name = "NewTask";
            State = false;
        }

        public Task(string task, bool state = false)
        {
            this.Name = task;
            this.State = state;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Task
    {
        public string task_id { get; set; }
        public string task_title { get; set; }
        public bool task_completed { get; set; }
        public string card_id { get; set; }


        public Task(string task_id, string task_title, bool task_completed, string card_id)
        {
            this.task_id = task_id;
            this.task_title = task_title;
            this.task_completed = task_completed;
            this.card_id = card_id;
        }

        public Task(string task_title, bool task_completed, string card_id)
        {
            this.task_title = task_title;
            this.task_completed = task_completed;
            this.card_id = card_id;
        }
    }
}

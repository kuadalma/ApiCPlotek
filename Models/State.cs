﻿namespace api_task.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Quest> Tasks { get; set; }
    }
}

﻿namespace ApiCPlotek.Models
{
    public class Priority
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Quest> Tasks { get; set; }
    }
}

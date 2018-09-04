using System;
using System.Collections.Generic;
using System.Text;

namespace KeyRingApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AnswerId { get; set; }
    }
}

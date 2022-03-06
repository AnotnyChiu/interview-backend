using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class InterviewStage
    {
        public int Id { get; set; }
        public int StageCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Passed { get; set; }
    }
}

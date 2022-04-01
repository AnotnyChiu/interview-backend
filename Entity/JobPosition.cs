using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Workplace { get; set; }
        public bool CurrentOpened { get; set; }
    }
}

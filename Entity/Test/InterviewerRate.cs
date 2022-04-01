using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Test
{
    [Table("interviewer_rate", Schema = "Test")]
    public class InterviewerRate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public Interviewer Interviewer { get; set; }
        // 面試題目
    }
}

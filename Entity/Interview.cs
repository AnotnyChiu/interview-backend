using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    [Table("interview")]
    public class Interview
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("candidate")]
        public Candidate Candidate { get; set; }
        [Column("interviewer")]
        public Interviewer Interviewer { get; set; }
        [Column("interview_time")]
        public DateTimeOffset InterviewTime { get; set; }
    }
}

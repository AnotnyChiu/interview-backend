using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("candidate")]
    public class Candidate
    {
        [Key]   
        public int Id { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public JobPosition JobPosition { get; set; }
        public InterviewStage CurrentStage { get; set; }
    }
}

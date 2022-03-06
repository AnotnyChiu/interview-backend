using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    [Table("interviewer")]
    public class Interviewer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("emp_id")]
        public string EmpId { get; set; }
    }
}

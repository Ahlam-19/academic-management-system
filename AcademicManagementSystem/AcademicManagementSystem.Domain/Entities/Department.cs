using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademicManagementSystem.Domain.Entities
{
    public class Department : BaseEntity
    {


        [Required, StringLength(50)]
        public string Name { get; set; }


        public Guid HodId { get; set; }


        public string? Location { get; set; }

    }
}

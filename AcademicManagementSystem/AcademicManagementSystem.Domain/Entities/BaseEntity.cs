using System;
using System.Collections.Generic;
using System.Text;

namespace AcademicManagementSystem.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

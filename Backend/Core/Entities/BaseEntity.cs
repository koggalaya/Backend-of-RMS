﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Entities
{    

    //shared class
    
    public abstract class BaseEntity 
    {
        [Key]
        public long ID { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; }= true;
    }
}

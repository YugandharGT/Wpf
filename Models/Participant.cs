using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Participant
    {
        [Required]
        [MaxLength(2)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true,DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Batchid { get; set; }

        [Required]
        public string CourseRegistered { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfRegistration { get; set; }
        
        //public virtual Batch Batch { get; set; }
    }
}

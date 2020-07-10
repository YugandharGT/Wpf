using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Faculty
    {
        [Required]
        [MaxLength(10)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(2)]
        public int PreviousExperience { get; set; }

        [Required]
        [MaxLength(150)]
        public string Qualification { get; set; }

        //public virtual Batch Batches { get; set; }
        //public ObservableCollection<Faculty> faculties;
    }
}

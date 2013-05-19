using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ProjectRevision5.Models
{
    [MetadataType(typeof(TaskMetadata))]
    public partial class Task { }

    public partial class TaskMetadata
    {

        [DisplayName("Row_")]
        [Required]
        public int Row_ID { get; set; }

        [DisplayName("Task")]
        [Required]
        [MaxLength(30)]
        public string Task_Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Time")]
        [Required]
        public Nullable<System.DateTime> Start_Time { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("End Time")]
        [Required]
        public Nullable<System.DateTime> End_Time { get; set; }

        [DisplayName("Indent")]
        [Required]
        public int Indent_Counter { get; set; }

        [DisplayName("Predecessor")]
        [Required]
        [Range(0, 1000, ErrorMessage = "Must be greater than 0")]
        public int Predecessor { get; set; }
    }
}


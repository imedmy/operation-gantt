

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_16.Models
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
    [MaxLength(50)]
    public string Task_Name { get; set; }

    [DataType(DataType.Date)]
    [DisplayName("Start_ Time")]
    public Nullable<System.DateTime> Start_Time { get; set; }

    [DataType(DataType.Date)]
    [DisplayName("End_ Time")]
    public Nullable<System.DateTime> End_Time { get; set; }	
    }
}


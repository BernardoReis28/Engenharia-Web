using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tutorial_06.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] //para não ser identity
    public int Number { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    public int? ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual Class? Class { get; set; }
}

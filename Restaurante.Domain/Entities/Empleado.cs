using System.ComponentModel.DataAnnotations;
using Restaurante.Domain.Core.EntityBase;

namespace Restaurante.Domain.Entities;

public partial class Empleado : Person
{
    [Key]
    public int IdEmpleado { get; set; }

    public string Cargo { get; set; }
}
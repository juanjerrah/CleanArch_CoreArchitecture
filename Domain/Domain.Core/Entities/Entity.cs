using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Domain.Core.Entities;

public abstract class Entity<T>: AbstractValidator<T>
{
    public Guid Id { get; protected set; }
    [Required]
    public DateTimeOffset DataInclusao { get; protected set; }
    [Required]
    public DateTimeOffset DataAlteracao { get; protected set; }
    [NotMapped]
    public ValidationResult ValidationResult { get; protected set; } = new();

    public abstract bool IsValid();

    public void SetDateInc(DateTimeOffset dataInc) => DataInclusao = dataInc;
    public void SetDateAlter(DateTimeOffset dataAlter) => DataAlteracao = dataAlter;
}
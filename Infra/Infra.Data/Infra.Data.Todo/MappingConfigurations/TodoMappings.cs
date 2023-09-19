using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Todo.MappingConfigurations;

public class TodoMappings: IEntityTypeConfiguration<Domain.Todo.Todo>
{
    public void Configure(EntityTypeBuilder<Domain.Todo.Todo> builder)
    {
        builder.ToTable("Tod_Todo", "Todo");
        
        builder.HasKey(x => x.Id)
            .HasName("PK_Tod_TodoId");

        builder.Property(x => x.Task)
            .HasColumnName("Tod_Task");
        builder.Property(x => x.Made)
            .HasColumnName("Tod_Made");
        
        builder.Ignore(x => x.ValidationResult);
        builder.Ignore(x => x.CascadeMode);
    }
}
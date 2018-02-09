// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.5
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace ConsolePlay.ef.poco
{

    // AssociatedAlloc
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.33.0.0")]
    public class AssociatedAllocConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AssociatedAlloc>
    {
        public AssociatedAllocConfiguration()
            : this("dbo")
        {
        }

        public AssociatedAllocConfiguration(string schema)
        {
            ToTable("AssociatedAlloc", schema);
            HasKey(x => x.AllocationId);

            Property(x => x.AllocationId).HasColumnName(@"AllocationId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.AssociatedId).HasColumnName(@"AssociatedId").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.Associated).WithMany(b => b.AssociatedAllocs).HasForeignKey(c => c.AssociatedId).WillCascadeOnDelete(false); // FK_AssociatedAlloc_AssociatedAlloc
        }
    }

}
// </auto-generated>

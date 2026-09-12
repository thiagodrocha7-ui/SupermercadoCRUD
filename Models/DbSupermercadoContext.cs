using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SupermercadoCrud.Models;

public partial class DbSupermercadoContext : DbContext
{
    public DbSupermercadoContext()
    {
    }

    public DbSupermercadoContext(DbContextOptions<DbSupermercadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Cpf, "UQ_CPF").IsUnique();

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");
            entity.Property(e => e.Statuss)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("statuss");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.CodigoCompra);

            entity.ToTable("Compra");

            entity.Property(e => e.CodigoCompra).HasColumnName("codigoCompra");
            entity.Property(e => e.CodigoCliente).HasColumnName("codigoCliente");
            entity.Property(e => e.DataCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("dataCompra");
            entity.Property(e => e.TipoPagamento)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipoPagamento");
            entity.Property(e => e.ValorTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valorTotal");

            entity.HasOne(d => d.CodigoClienteNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.CodigoCliente)
                .HasConstraintName("FK_Cliente_Compra");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

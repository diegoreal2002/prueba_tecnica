﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyBankingApp.Infrastructure.Migrations
{
    [DbContext(typeof(BankingDbContext))]
    [Migration("20250125163243_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBankingApp.Domain.Entities.BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BankAccountId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("BankAccountId");

                    b.HasIndex("CustomerId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("MyBankingApp.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MyBankingApp.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BankAccountDestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("BankAccountOriginId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.HasIndex("BankAccountDestinationId");

                    b.HasIndex("BankAccountOriginId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MyBankingApp.Domain.Entities.BankAccount", b =>
                {
                    b.HasOne("MyBankingApp.Domain.Entities.Customer", "Customer")
                        .WithMany("BankAccounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MyBankingApp.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("MyBankingApp.Domain.Entities.BankAccount", "BankAccountDestination")
                        .WithMany("TransaccionesDestino")
                        .HasForeignKey("BankAccountDestinationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyBankingApp.Domain.Entities.BankAccount", "BankAccountOrigin")
                        .WithMany("TransaccionesOrigen")
                        .HasForeignKey("BankAccountOriginId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BankAccountDestination");

                    b.Navigation("BankAccountOrigin");
                });

            modelBuilder.Entity("MyBankingApp.Domain.Entities.BankAccount", b =>
                {
                    b.Navigation("TransaccionesDestino");

                    b.Navigation("TransaccionesOrigen");
                });

            modelBuilder.Entity("MyBankingApp.Domain.Entities.Customer", b =>
                {
                    b.Navigation("BankAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}

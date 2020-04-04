// <auto-generated />
using System;
using MAVN.Service.Vouchers.MsSqlRepositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAVN.Service.Vouchers.MsSqlRepositories.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191210214622_VoucherCodeLength")]
    partial class VoucherCodeLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("vouchers")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAVN.Service.Vouchers.MsSqlRepositories.Entities.CustomerVoucherEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<decimal>("AmountInBaseCurrency")
                        .HasColumnName("amount_in_base_currency");

                    b.Property<string>("AmountInTokens")
                        .IsRequired()
                        .HasColumnName("amount_in_tokens");

                    b.Property<Guid>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnName("purchase_date");

                    b.Property<Guid>("VoucherId")
                        .HasColumnName("voucher_id");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VoucherId")
                        .IsUnique();

                    b.ToTable("customer_vouchers");
                });

            modelBuilder.Entity("MAVN.Service.Vouchers.MsSqlRepositories.Entities.TransferEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnName("amount");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created");

                    b.Property<Guid>("CustomerId")
                        .HasColumnName("customer_id");

                    b.Property<Guid>("SpendRuleId")
                        .HasColumnName("spend_rule_id");

                    b.Property<short>("Status")
                        .HasColumnName("status");

                    b.Property<Guid>("VoucherId")
                        .HasColumnName("voucher_id");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId");

                    b.ToTable("transfers");
                });

            modelBuilder.Entity("MAVN.Service.Vouchers.MsSqlRepositories.Entities.VoucherEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("varchar(15)");

                    b.Property<Guid>("SpendRuleId")
                        .HasColumnName("spend_rule_id");

                    b.Property<short>("Status")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("SpendRuleId");

                    b.ToTable("vouchers");
                });

            modelBuilder.Entity("MAVN.Service.Vouchers.MsSqlRepositories.Entities.CustomerVoucherEntity", b =>
                {
                    b.HasOne("MAVN.Service.Vouchers.MsSqlRepositories.Entities.VoucherEntity")
                        .WithOne("CustomerVoucher")
                        .HasForeignKey("MAVN.Service.Vouchers.MsSqlRepositories.Entities.CustomerVoucherEntity", "VoucherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MAVN.Service.Vouchers.MsSqlRepositories.Entities.TransferEntity", b =>
                {
                    b.HasOne("MAVN.Service.Vouchers.MsSqlRepositories.Entities.VoucherEntity")
                        .WithMany()
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

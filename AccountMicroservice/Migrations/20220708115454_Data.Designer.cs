// <auto-generated />
using AccountMicroservice.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountMicroservice.Migrations
{
    [DbContext(typeof(AccountDbContext))]
    [Migration("20220708115454_Data")]
    partial class Data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountMicroservice.CustomerAccount", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CurrentAccountId")
                        .HasColumnType("int");

                    b.Property<int>("SavingsAccountId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("customerAccounts");

                    b.HasData(
                        new
                        {
                            CustomerId = "JhonSmith",
                            CurrentAccountId = 201,
                            SavingsAccountId = 202
                        });
                });

            modelBuilder.Entity("AccountMicroservice.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("accounts");

                    b.HasData(
                        new
                        {
                            Id = 201,
                            Balance = 1000.0
                        },
                        new
                        {
                            Id = 202,
                            Balance = 500.0
                        });
                });

            modelBuilder.Entity("AccountMicroservice.Models.AccountStatement", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("AccountId");

                    b.ToTable("accountStatements");

                    b.HasData(
                        new
                        {
                            AccountId = 202
                        },
                        new
                        {
                            AccountId = 201
                        });
                });

            modelBuilder.Entity("AccountMicroservice.Models.AccountStatement", b =>
                {
                    b.OwnsOne("System.Collections.Generic.List<AccountMicroservice.Models.Statement>", "Statements", b1 =>
                        {
                            b1.Property<int>("AccountStatementAccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Capacity")
                                .HasColumnType("int");

                            b1.HasKey("AccountStatementAccountId");

                            b1.ToTable("accountStatements");

                            b1.WithOwner()
                                .HasForeignKey("AccountStatementAccountId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

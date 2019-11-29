﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kangoeroes.infrastructure;

namespace kangoeroes.infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191111102437_MakeDecimalsSaneSize")]
    partial class MakeDecimalsSaneSize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("char(36)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnName("accountType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Balance")
                        .HasColumnName("balance")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnName("lastUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OwnerId")
                        .HasColumnName("ownerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("account");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnName("accountId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Leiding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumGestopt")
                        .HasColumnName("datumGestopt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LeidingSinds")
                        .HasColumnName("leidingSinds")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("TakId")
                        .HasColumnName("takId")
                        .HasColumnType("int");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnName("voornaam")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("TakId");

                    b.ToTable("leiding");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Drank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnName("imageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("InStock")
                        .HasColumnName("inStock")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int?>("TypeId")
                        .HasColumnName("typeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.HasIndex("TypeId");

                    b.ToTable("poef.drank");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.DrankType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.ToTable("poef.drankType");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderedById")
                        .HasColumnName("orderedById")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderedById");

                    b.ToTable("poef.order");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Orderline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("DrankId")
                        .HasColumnName("drankId")
                        .HasColumnType("int");

                    b.Property<decimal>("DrinkPrice")
                        .HasColumnName("drinkPrice")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("OrderId")
                        .HasColumnName("orderId")
                        .HasColumnType("int");

                    b.Property<int>("OrderedForId")
                        .HasColumnName("orderedForId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DrankId");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderedForId");

                    b.ToTable("poef.orderline");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Prijs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DrankId")
                        .HasColumnName("drankId")
                        .HasColumnType("int");

                    b.Property<decimal>("Waarde")
                        .HasColumnName("waarde")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("DrankId");

                    b.ToTable("poef.prijs");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Tak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Volgorde")
                        .HasColumnName("volgorde")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tak");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.Adjectief", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("totems.adjectief");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.Totem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("totems.totem");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.TotemEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int?>("AdjectiefId")
                        .HasColumnName("adjectiefId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumGegeven")
                        .HasColumnName("datumGegeven")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LeidingId")
                        .HasColumnName("leidingId")
                        .HasColumnType("int");

                    b.Property<int?>("TotemId")
                        .HasColumnName("totemId")
                        .HasColumnType("int");

                    b.Property<int?>("VoorouderId")
                        .HasColumnName("voorouderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdjectiefId");

                    b.HasIndex("LeidingId");

                    b.HasIndex("TotemId");

                    b.HasIndex("VoorouderId");

                    b.ToTable("totems.entry");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.Account", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Leiding", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.Transaction", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Accounting.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Leiding", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Tak", "Tak")
                        .WithMany("Leiding")
                        .HasForeignKey("TakId");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Drank", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Poef.DrankType", "Type")
                        .WithMany("Dranken")
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Order", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Leiding", "OrderedBy")
                        .WithMany("Orders")
                        .HasForeignKey("OrderedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Orderline", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Poef.Drank", "Drank")
                        .WithMany("Orderlines")
                        .HasForeignKey("DrankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kangoeroes.core.Models.Poef.Order", "Order")
                        .WithMany("Orderlines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kangoeroes.core.Models.Leiding", "OrderedFor")
                        .WithMany("Consumpties")
                        .HasForeignKey("OrderedForId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Prijs", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Poef.Drank", "Drank")
                        .WithMany("Prijzen")
                        .HasForeignKey("DrankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.TotemEntry", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Totems.Adjectief", "Adjectief")
                        .WithMany()
                        .HasForeignKey("AdjectiefId");

                    b.HasOne("kangoeroes.core.Models.Leiding", "Leiding")
                        .WithMany()
                        .HasForeignKey("LeidingId");

                    b.HasOne("kangoeroes.core.Models.Totems.Totem", "Totem")
                        .WithMany()
                        .HasForeignKey("TotemId");

                    b.HasOne("kangoeroes.core.Models.Totems.TotemEntry", "Voorouder")
                        .WithMany("Afstammelingen")
                        .HasForeignKey("VoorouderId");
                });
#pragma warning restore 612, 618
        }
    }
}

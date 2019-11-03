﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kangoeroes.infrastructure;

namespace kangoeroes.infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<decimal>("Balance")
                        .HasColumnName("balance");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnName("lastUpdated");

                    b.Property<string>("account_type")
                        .IsRequired()
                        .HasColumnName("account_type");

                    b.HasKey("Id");

                    b.ToTable("account");

                    b.HasDiscriminator<string>("account_type").HasValue("Account");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.DebtTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<Guid?>("DebtAccountId")
                        .HasColumnName("debtAccountId");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.HasIndex("DebtAccountId");

                    b.ToTable("DebtTransaction");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.TabTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnName("amount");

                    b.Property<int?>("ConsumptionsId")
                        .HasColumnName("consumptionsId");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<Guid?>("TabAccountId")
                        .HasColumnName("tabAccountId");

                    b.HasKey("Id");

                    b.HasIndex("ConsumptionsId");

                    b.HasIndex("TabAccountId");

                    b.ToTable("TabTransaction");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Leiding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DatumGestopt")
                        .HasColumnName("datumGestopt");

                    b.Property<Guid?>("DebtAccountId")
                        .HasColumnName("debtAccountId");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<DateTime>("LeidingSinds")
                        .HasColumnName("leidingSinds");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.Property<Guid?>("TabAccountId")
                        .HasColumnName("tabAccountId");

                    b.Property<int?>("TakId")
                        .HasColumnName("takId");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnName("voornaam");

                    b.HasKey("Id");

                    b.HasIndex("DebtAccountId");

                    b.HasIndex("TabAccountId");

                    b.HasIndex("TakId");

                    b.ToTable("leiding");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Drank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ImageUrl")
                        .HasColumnName("imageUrl");

                    b.Property<bool>("InStock")
                        .HasColumnName("inStock");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.Property<int?>("TypeId")
                        .HasColumnName("typeId");

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
                        .HasColumnName("id");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.HasKey("Id");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.ToTable("poef.drankType");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn");

                    b.Property<int?>("OrderedById")
                        .IsRequired()
                        .HasColumnName("orderedById");

                    b.HasKey("Id");

                    b.HasIndex("OrderedById");

                    b.ToTable("poef.order");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Orderline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("DrankId")
                        .IsRequired()
                        .HasColumnName("drankId");

                    b.Property<decimal>("DrinkPrice")
                        .HasColumnName("drinkPrice");

                    b.Property<int?>("OrderId")
                        .IsRequired()
                        .HasColumnName("orderId");

                    b.Property<int?>("OrderedForId")
                        .IsRequired()
                        .HasColumnName("orderedForId");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

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
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn");

                    b.Property<int?>("DrankId")
                        .IsRequired()
                        .HasColumnName("drankId");

                    b.Property<decimal>("Waarde")
                        .HasColumnName("waarde");

                    b.HasKey("Id");

                    b.HasIndex("DrankId");

                    b.ToTable("poef.prijs");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Tak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.Property<int>("Volgorde")
                        .HasColumnName("volgorde");

                    b.HasKey("Id");

                    b.ToTable("tak");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.Adjectief", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.HasKey("Id");

                    b.ToTable("totems.adjectief");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.Totem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("createdOn");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnName("naam");

                    b.HasKey("Id");

                    b.ToTable("totems.totem");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Totems.TotemEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("AdjectiefId")
                        .HasColumnName("adjectiefId");

                    b.Property<DateTime>("DatumGegeven")
                        .HasColumnName("datumGegeven");

                    b.Property<int?>("LeidingId")
                        .HasColumnName("leidingId");

                    b.Property<int?>("TotemId")
                        .HasColumnName("totemId");

                    b.Property<int?>("VoorouderId")
                        .HasColumnName("voorouderId");

                    b.HasKey("Id");

                    b.HasIndex("AdjectiefId");

                    b.HasIndex("LeidingId");

                    b.HasIndex("TotemId");

                    b.HasIndex("VoorouderId");

                    b.ToTable("totems.entry");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.DebtAccount", b =>
                {
                    b.HasBaseType("kangoeroes.core.Models.Accounting.Account");


                    b.ToTable("DebtAccount");

                    b.HasDiscriminator().HasValue("account_debt");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.TabAccount", b =>
                {
                    b.HasBaseType("kangoeroes.core.Models.Accounting.Account");


                    b.ToTable("TabAccount");

                    b.HasDiscriminator().HasValue("account_tab");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.DebtTransaction", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Accounting.DebtAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("DebtAccountId");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Accounting.TabTransaction", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Poef.Orderline", "Consumptions")
                        .WithMany()
                        .HasForeignKey("ConsumptionsId");

                    b.HasOne("kangoeroes.core.Models.Accounting.TabAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("TabAccountId");
                });

            modelBuilder.Entity("kangoeroes.core.Models.Leiding", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Accounting.Account", "DebtAccount")
                        .WithMany()
                        .HasForeignKey("DebtAccountId");

                    b.HasOne("kangoeroes.core.Models.Accounting.Account", "TabAccount")
                        .WithMany()
                        .HasForeignKey("TabAccountId");

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
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Orderline", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Poef.Drank", "Drank")
                        .WithMany("Orderlines")
                        .HasForeignKey("DrankId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("kangoeroes.core.Models.Poef.Order", "Order")
                        .WithMany("Orderlines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("kangoeroes.core.Models.Leiding", "OrderedFor")
                        .WithMany("Consumpties")
                        .HasForeignKey("OrderedForId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("kangoeroes.core.Models.Poef.Prijs", b =>
                {
                    b.HasOne("kangoeroes.core.Models.Poef.Drank", "Drank")
                        .WithMany("Prijzen")
                        .HasForeignKey("DrankId")
                        .OnDelete(DeleteBehavior.Cascade);
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

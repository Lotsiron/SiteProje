﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Models;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(KuaforYonetimContext))]
    partial class KuaforYonetimContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Calisan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("KuaforId")
                        .HasColumnType("integer");

                    b.Property<int>("SalonId")
                        .HasColumnType("integer");

                    b.Property<string>("Uzmanlik")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.ToTable("Calisanlar");
                });

            modelBuilder.Entity("WebApplication1.Models.CalisanHizmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalisanId")
                        .HasColumnType("integer");

                    b.Property<int>("HizmetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HizmetId");

                    b.HasIndex("CalisanId", "HizmetId")
                        .IsUnique();

                    b.ToTable("CalisanHizmetler");
                });

            modelBuilder.Entity("WebApplication1.Models.CalisanUygunluk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("BaslangicSaati")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("BitisSaati")
                        .HasColumnType("interval");

                    b.Property<int>("CalisanId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("GecerlilikTarihiBas")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("GecerlilikTarihiSon")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Gun")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.HasIndex("CalisanId");

                    b.ToTable("CalisanUygunluklar");
                });

            modelBuilder.Entity("WebApplication1.Models.Hizmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("numeric");

                    b.Property<int>("Sure")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Hizmetler");
                });

            modelBuilder.Entity("WebApplication1.Models.Randevu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("BaslangicSaati")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("BitisSaati")
                        .HasColumnType("interval");

                    b.Property<int>("CalisanId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("numeric");

                    b.Property<int>("HizmetId")
                        .HasColumnType("integer");

                    b.Property<int>("KuaforId")
                        .HasColumnType("integer");

                    b.Property<int>("SalonId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CalisanId");

                    b.HasIndex("HizmetId");

                    b.HasIndex("SalonId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("WebApplication1.Models.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("acilis_saati")
                        .HasColumnType("interval");

                    b.Property<string>("ad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<TimeSpan>("kapanis_saati")
                        .HasColumnType("interval");

                    b.Property<string>("tur")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("Kuaforler");
                });

            modelBuilder.Entity("WebApplication1.Models.Calisan", b =>
                {
                    b.HasOne("WebApplication1.Models.Salon", "Salon")
                        .WithMany("Calisanlar")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("WebApplication1.Models.CalisanHizmet", b =>
                {
                    b.HasOne("WebApplication1.Models.Calisan", "Calisan")
                        .WithMany("CalisanHizmetler")
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Hizmet", "Hizmet")
                        .WithMany()
                        .HasForeignKey("HizmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");

                    b.Navigation("Hizmet");
                });

            modelBuilder.Entity("WebApplication1.Models.CalisanUygunluk", b =>
                {
                    b.HasOne("WebApplication1.Models.Calisan", "Calisan")
                        .WithMany("CalisanUygunluklar")
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");
                });

            modelBuilder.Entity("WebApplication1.Models.Randevu", b =>
                {
                    b.HasOne("WebApplication1.Models.Calisan", "Calisan")
                        .WithMany()
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Hizmet", "Hizmet")
                        .WithMany()
                        .HasForeignKey("HizmetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Salon", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calisan");

                    b.Navigation("Hizmet");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("WebApplication1.Models.Calisan", b =>
                {
                    b.Navigation("CalisanHizmetler");

                    b.Navigation("CalisanUygunluklar");
                });

            modelBuilder.Entity("WebApplication1.Models.Salon", b =>
                {
                    b.Navigation("Calisanlar");
                });
#pragma warning restore 612, 618
        }
    }
}

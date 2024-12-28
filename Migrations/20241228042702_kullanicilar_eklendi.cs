using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class kullanicilareklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanHizmetler_Calisanlar_CalisanId",
                table: "CalisanHizmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_CalisanHizmetler_Hizmetler_HizmetId",
                table: "CalisanHizmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Kuaforler_SalonId",
                table: "Calisanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_CalisanUygunluklar_Calisanlar_CalisanId",
                table: "CalisanUygunluklar");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Calisanlar_CalisanId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetId",
                table: "Randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Kuaforler_SalonId",
                table: "Randevular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Randevular",
                table: "Randevular");

            migrationBuilder.DropIndex(
                name: "IX_Randevular_CalisanId",
                table: "Randevular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kuaforler",
                table: "Kuaforler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hizmetler",
                table: "Hizmetler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar");

            migrationBuilder.DropIndex(
                name: "IX_Calisanlar_SalonId",
                table: "Calisanlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalisanUygunluklar",
                table: "CalisanUygunluklar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalisanHizmetler",
                table: "CalisanHizmetler");

            migrationBuilder.DropColumn(
                name: "CalisanId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "Calisanlar");

            migrationBuilder.RenameTable(
                name: "Randevular",
                newName: "randevular");

            migrationBuilder.RenameTable(
                name: "Kuaforler",
                newName: "kuaforler");

            migrationBuilder.RenameTable(
                name: "Hizmetler",
                newName: "hizmetler");

            migrationBuilder.RenameTable(
                name: "Calisanlar",
                newName: "calisanlar");

            migrationBuilder.RenameTable(
                name: "CalisanUygunluklar",
                newName: "calisan_uygunluk");

            migrationBuilder.RenameTable(
                name: "CalisanHizmetler",
                newName: "calisan_hizmetler");

            migrationBuilder.RenameColumn(
                name: "Tarih",
                table: "randevular",
                newName: "tarih");

            migrationBuilder.RenameColumn(
                name: "Fiyat",
                table: "randevular",
                newName: "fiyat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "randevular",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SalonId",
                table: "randevular",
                newName: "kuafor_id");

            migrationBuilder.RenameColumn(
                name: "KuaforId",
                table: "randevular",
                newName: "hizmet_id");

            migrationBuilder.RenameColumn(
                name: "HizmetId",
                table: "randevular",
                newName: "calisan_id");

            migrationBuilder.RenameColumn(
                name: "BitisSaati",
                table: "randevular",
                newName: "bitis_saati");

            migrationBuilder.RenameColumn(
                name: "BaslangicSaati",
                table: "randevular",
                newName: "baslangic_saati");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_SalonId",
                table: "randevular",
                newName: "IX_randevular_kuafor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_HizmetId",
                table: "randevular",
                newName: "IX_randevular_calisan_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "kuaforler",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Sure",
                table: "hizmetler",
                newName: "sure");

            migrationBuilder.RenameColumn(
                name: "Fiyat",
                table: "hizmetler",
                newName: "fiyat");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "hizmetler",
                newName: "ad");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "hizmetler",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Uzmanlik",
                table: "calisanlar",
                newName: "uzmanlik");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "calisanlar",
                newName: "ad");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "calisanlar",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "KuaforId",
                table: "calisanlar",
                newName: "kuafor_id");

            migrationBuilder.RenameColumn(
                name: "Gun",
                table: "calisan_uygunluk",
                newName: "gun");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "calisan_uygunluk",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "GecerlilikTarihiSon",
                table: "calisan_uygunluk",
                newName: "gecerlilik_tarihi_son");

            migrationBuilder.RenameColumn(
                name: "GecerlilikTarihiBas",
                table: "calisan_uygunluk",
                newName: "gecerlilik_tarihi_bas");

            migrationBuilder.RenameColumn(
                name: "CalisanId",
                table: "calisan_uygunluk",
                newName: "calisan_id");

            migrationBuilder.RenameColumn(
                name: "BitisSaati",
                table: "calisan_uygunluk",
                newName: "bitis_saati");

            migrationBuilder.RenameColumn(
                name: "BaslangicSaati",
                table: "calisan_uygunluk",
                newName: "baslangic_saati");

            migrationBuilder.RenameIndex(
                name: "IX_CalisanUygunluklar_CalisanId",
                table: "calisan_uygunluk",
                newName: "IX_calisan_uygunluk_calisan_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "calisan_hizmetler",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "HizmetId",
                table: "calisan_hizmetler",
                newName: "hizmet_id");

            migrationBuilder.RenameColumn(
                name: "CalisanId",
                table: "calisan_hizmetler",
                newName: "calisan_id");

            migrationBuilder.RenameIndex(
                name: "IX_CalisanHizmetler_HizmetId",
                table: "calisan_hizmetler",
                newName: "IX_calisan_hizmetler_hizmet_id");

            migrationBuilder.RenameIndex(
                name: "IX_CalisanHizmetler_CalisanId_HizmetId",
                table: "calisan_hizmetler",
                newName: "IX_calisan_hizmetler_calisan_id_hizmet_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "tarih",
                table: "randevular",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "musteri_adi",
                table: "randevular",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefon",
                table: "randevular",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "gecerlilik_tarihi_son",
                table: "calisan_uygunluk",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "gecerlilik_tarihi_bas",
                table: "calisan_uygunluk",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_randevular",
                table: "randevular",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kuaforler",
                table: "kuaforler",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hizmetler",
                table: "hizmetler",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calisanlar",
                table: "calisanlar",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calisan_uygunluk",
                table: "calisan_uygunluk",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calisan_hizmetler",
                table: "calisan_hizmetler",
                column: "id");

            migrationBuilder.CreateTable(
                name: "roller",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roller", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kullanicilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    sifre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    soyad = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    telefon = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    rolid = table.Column<int>(name: "rol_id", type: "integer", nullable: false),
                    olusturmatarihi = table.Column<DateTime>(name: "olusturma_tarihi", type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicilar", x => x.id);
                    table.ForeignKey(
                        name: "FK_kullanicilar_roller_rol_id",
                        column: x => x.rolid,
                        principalTable: "roller",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "roller",
                columns: new[] { "id", "ad" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "kullanicilar",
                columns: new[] { "id", "ad", "email", "olusturma_tarihi", "rol_id", "sifre", "soyad", "telefon" },
                values: new object[] { 1, "Admin", "G221210075@sakarya.edu.tr", new DateTime(2024, 12, 28, 7, 27, 2, 334, DateTimeKind.Local).AddTicks(5548), 1, "sau", "Pekdemir", "551-086-9404" });

            migrationBuilder.CreateIndex(
                name: "IX_randevular_hizmet_id",
                table: "randevular",
                column: "hizmet_id");

            migrationBuilder.CreateIndex(
                name: "IX_calisanlar_kuafor_id",
                table: "calisanlar",
                column: "kuafor_id");

            migrationBuilder.CreateIndex(
                name: "IX_kullanicilar_rol_id",
                table: "kullanicilar",
                column: "rol_id");

            migrationBuilder.AddForeignKey(
                name: "FK_calisan_hizmetler_calisanlar_calisan_id",
                table: "calisan_hizmetler",
                column: "calisan_id",
                principalTable: "calisanlar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_calisan_hizmetler_hizmetler_hizmet_id",
                table: "calisan_hizmetler",
                column: "hizmet_id",
                principalTable: "hizmetler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_calisan_uygunluk_calisanlar_calisan_id",
                table: "calisan_uygunluk",
                column: "calisan_id",
                principalTable: "calisanlar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_calisanlar_kuaforler_kuafor_id",
                table: "calisanlar",
                column: "kuafor_id",
                principalTable: "kuaforler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_randevular_calisanlar_calisan_id",
                table: "randevular",
                column: "calisan_id",
                principalTable: "calisanlar",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_randevular_hizmetler_hizmet_id",
                table: "randevular",
                column: "hizmet_id",
                principalTable: "hizmetler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_randevular_kuaforler_kuafor_id",
                table: "randevular",
                column: "kuafor_id",
                principalTable: "kuaforler",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_calisan_hizmetler_calisanlar_calisan_id",
                table: "calisan_hizmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_calisan_hizmetler_hizmetler_hizmet_id",
                table: "calisan_hizmetler");

            migrationBuilder.DropForeignKey(
                name: "FK_calisan_uygunluk_calisanlar_calisan_id",
                table: "calisan_uygunluk");

            migrationBuilder.DropForeignKey(
                name: "FK_calisanlar_kuaforler_kuafor_id",
                table: "calisanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_randevular_calisanlar_calisan_id",
                table: "randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_randevular_hizmetler_hizmet_id",
                table: "randevular");

            migrationBuilder.DropForeignKey(
                name: "FK_randevular_kuaforler_kuafor_id",
                table: "randevular");

            migrationBuilder.DropTable(
                name: "kullanicilar");

            migrationBuilder.DropTable(
                name: "roller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_randevular",
                table: "randevular");

            migrationBuilder.DropIndex(
                name: "IX_randevular_hizmet_id",
                table: "randevular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kuaforler",
                table: "kuaforler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hizmetler",
                table: "hizmetler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_calisanlar",
                table: "calisanlar");

            migrationBuilder.DropIndex(
                name: "IX_calisanlar_kuafor_id",
                table: "calisanlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_calisan_uygunluk",
                table: "calisan_uygunluk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_calisan_hizmetler",
                table: "calisan_hizmetler");

            migrationBuilder.DropColumn(
                name: "musteri_adi",
                table: "randevular");

            migrationBuilder.DropColumn(
                name: "telefon",
                table: "randevular");

            migrationBuilder.RenameTable(
                name: "randevular",
                newName: "Randevular");

            migrationBuilder.RenameTable(
                name: "kuaforler",
                newName: "Kuaforler");

            migrationBuilder.RenameTable(
                name: "hizmetler",
                newName: "Hizmetler");

            migrationBuilder.RenameTable(
                name: "calisanlar",
                newName: "Calisanlar");

            migrationBuilder.RenameTable(
                name: "calisan_uygunluk",
                newName: "CalisanUygunluklar");

            migrationBuilder.RenameTable(
                name: "calisan_hizmetler",
                newName: "CalisanHizmetler");

            migrationBuilder.RenameColumn(
                name: "tarih",
                table: "Randevular",
                newName: "Tarih");

            migrationBuilder.RenameColumn(
                name: "fiyat",
                table: "Randevular",
                newName: "Fiyat");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Randevular",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "kuafor_id",
                table: "Randevular",
                newName: "SalonId");

            migrationBuilder.RenameColumn(
                name: "hizmet_id",
                table: "Randevular",
                newName: "KuaforId");

            migrationBuilder.RenameColumn(
                name: "calisan_id",
                table: "Randevular",
                newName: "HizmetId");

            migrationBuilder.RenameColumn(
                name: "bitis_saati",
                table: "Randevular",
                newName: "BitisSaati");

            migrationBuilder.RenameColumn(
                name: "baslangic_saati",
                table: "Randevular",
                newName: "BaslangicSaati");

            migrationBuilder.RenameIndex(
                name: "IX_randevular_kuafor_id",
                table: "Randevular",
                newName: "IX_Randevular_SalonId");

            migrationBuilder.RenameIndex(
                name: "IX_randevular_calisan_id",
                table: "Randevular",
                newName: "IX_Randevular_HizmetId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Kuaforler",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "sure",
                table: "Hizmetler",
                newName: "Sure");

            migrationBuilder.RenameColumn(
                name: "fiyat",
                table: "Hizmetler",
                newName: "Fiyat");

            migrationBuilder.RenameColumn(
                name: "ad",
                table: "Hizmetler",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Hizmetler",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "uzmanlik",
                table: "Calisanlar",
                newName: "Uzmanlik");

            migrationBuilder.RenameColumn(
                name: "ad",
                table: "Calisanlar",
                newName: "Ad");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Calisanlar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "kuafor_id",
                table: "Calisanlar",
                newName: "KuaforId");

            migrationBuilder.RenameColumn(
                name: "gun",
                table: "CalisanUygunluklar",
                newName: "Gun");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CalisanUygunluklar",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "gecerlilik_tarihi_son",
                table: "CalisanUygunluklar",
                newName: "GecerlilikTarihiSon");

            migrationBuilder.RenameColumn(
                name: "gecerlilik_tarihi_bas",
                table: "CalisanUygunluklar",
                newName: "GecerlilikTarihiBas");

            migrationBuilder.RenameColumn(
                name: "calisan_id",
                table: "CalisanUygunluklar",
                newName: "CalisanId");

            migrationBuilder.RenameColumn(
                name: "bitis_saati",
                table: "CalisanUygunluklar",
                newName: "BitisSaati");

            migrationBuilder.RenameColumn(
                name: "baslangic_saati",
                table: "CalisanUygunluklar",
                newName: "BaslangicSaati");

            migrationBuilder.RenameIndex(
                name: "IX_calisan_uygunluk_calisan_id",
                table: "CalisanUygunluklar",
                newName: "IX_CalisanUygunluklar_CalisanId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CalisanHizmetler",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "hizmet_id",
                table: "CalisanHizmetler",
                newName: "HizmetId");

            migrationBuilder.RenameColumn(
                name: "calisan_id",
                table: "CalisanHizmetler",
                newName: "CalisanId");

            migrationBuilder.RenameIndex(
                name: "IX_calisan_hizmetler_hizmet_id",
                table: "CalisanHizmetler",
                newName: "IX_CalisanHizmetler_HizmetId");

            migrationBuilder.RenameIndex(
                name: "IX_calisan_hizmetler_calisan_id_hizmet_id",
                table: "CalisanHizmetler",
                newName: "IX_CalisanHizmetler_CalisanId_HizmetId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Tarih",
                table: "Randevular",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "CalisanId",
                table: "Randevular",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "Calisanlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GecerlilikTarihiSon",
                table: "CalisanUygunluklar",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GecerlilikTarihiBas",
                table: "CalisanUygunluklar",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Randevular",
                table: "Randevular",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kuaforler",
                table: "Kuaforler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hizmetler",
                table: "Hizmetler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalisanUygunluklar",
                table: "CalisanUygunluklar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalisanHizmetler",
                table: "CalisanHizmetler",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_CalisanId",
                table: "Randevular",
                column: "CalisanId");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_SalonId",
                table: "Calisanlar",
                column: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanHizmetler_Calisanlar_CalisanId",
                table: "CalisanHizmetler",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanHizmetler_Hizmetler_HizmetId",
                table: "CalisanHizmetler",
                column: "HizmetId",
                principalTable: "Hizmetler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Kuaforler_SalonId",
                table: "Calisanlar",
                column: "SalonId",
                principalTable: "Kuaforler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanUygunluklar_Calisanlar_CalisanId",
                table: "CalisanUygunluklar",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Calisanlar_CalisanId",
                table: "Randevular",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetId",
                table: "Randevular",
                column: "HizmetId",
                principalTable: "Hizmetler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Kuaforler_SalonId",
                table: "Randevular",
                column: "SalonId",
                principalTable: "Kuaforler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpCMS.Migrations
{
    public partial class Updated_CompanyData_20102412443761 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BienDongCaoThap",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "BienDongGia",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "CN",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "DiemGia",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "GiaTheoPhanTram",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "GiaTriNN",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "KL",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "KLPhanTram",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "LinkThamKhao",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "LuuY",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "NN",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "NNMuaCongBan",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "NNMuaTruBan",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "Percent",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "SucManh",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "TN",
                table: "AppCompanyDatas");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "AppCompanyDatas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "AppCompanyDatas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AppCompanyDatas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "AppCompanyDatas");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AppCompanyDatas");

            migrationBuilder.AddColumn<string>(
                name: "BienDongCaoThap",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BienDongGia",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CN",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AppCompanyDatas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DiemGia",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gia",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GiaTheoPhanTram",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GiaTriNN",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KL",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KLPhanTram",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkThamKhao",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LuuY",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NN",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NNMuaCongBan",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NNMuaTruBan",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Percent",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SucManh",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TN",
                table: "AppCompanyDatas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

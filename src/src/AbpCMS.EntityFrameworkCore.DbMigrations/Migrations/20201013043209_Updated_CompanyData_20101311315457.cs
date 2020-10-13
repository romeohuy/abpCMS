using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpCMS.Migrations
{
    public partial class Updated_CompanyData_20101311315457 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KLPhanTram",
                table: "AppCompanyDatas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KLPhanTram",
                table: "AppCompanyDatas");
        }
    }
}

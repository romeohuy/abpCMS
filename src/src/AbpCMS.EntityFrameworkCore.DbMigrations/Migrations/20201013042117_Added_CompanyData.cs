using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpCMS.Migrations
{
    public partial class Added_CompanyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCompanyDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Percent = table.Column<string>(nullable: true),
                    CN = table.Column<string>(nullable: true),
                    TN = table.Column<string>(nullable: true),
                    Gia = table.Column<string>(nullable: true),
                    GiaTheoPhanTram = table.Column<string>(nullable: true),
                    BienDongGia = table.Column<string>(nullable: true),
                    BienDongCaoThap = table.Column<string>(nullable: true),
                    LuuY = table.Column<string>(nullable: true),
                    KL = table.Column<string>(nullable: true),
                    NN = table.Column<string>(nullable: true),
                    GiaTriNN = table.Column<string>(nullable: true),
                    NNMuaCongBan = table.Column<string>(nullable: true),
                    NNMuaTruBan = table.Column<string>(nullable: true),
                    SucManh = table.Column<string>(nullable: true),
                    DiemGia = table.Column<string>(nullable: true),
                    LinkThamKhao = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCompanyDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCompanyDatas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiShop.Migrations
{
    public partial class PopulaCategories : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categories(Name)Values('Eletronics')");
            mb.Sql("Insert into Categories(Name)Values('Computers')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categories");
        }
    }
}

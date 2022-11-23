using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiShop.Migrations
{
    public partial class PopulaSellers : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Sellers(Name, Description)Values('Jorge Store', 'The number one seller')");
            mb.Sql("Insert into Sellers(Name, Description)Values('Maria Eletronics', 'We not have competition')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Sellers");
        }
    }
}

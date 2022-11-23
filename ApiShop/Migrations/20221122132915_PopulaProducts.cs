using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiShop.Migrations
{
    public partial class PopulaProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Description, Amount, Value, CategoryId, SellerId)" +
                "Values('Notebook', 'Notebook 8GB-RAM, SDD 240gb', 3, 2400.00, 1, 2)");

            mb.Sql("Insert into Products(Name, Description, Amount, Value, CategoryId, SellerId)" +
                "Values('TV', 'Smart tv 40', 2, 2900.00, 1, 2)");

            mb.Sql("Insert into Products(Name, Description, Amount, Value, CategoryId, SellerId)" +
                "Values('Memory RAM', 'Memory RAM 4GB', 16, 120.00, 2, 1)");

            mb.Sql("Insert into Products(Name, Description, Amount, Value, CategoryId, SellerId)" +
                "Values('SSD', 'SSD 500GB', 11, 400.00, 2, 1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Products");
        }
    }
}

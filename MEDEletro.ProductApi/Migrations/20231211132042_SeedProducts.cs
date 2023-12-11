using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEDEletro.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                "Values('Caderno', 7.55,'Caderno Capa dura',10,'caderno.jpg',1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
               "Values('Lápis', 3.55,'Lápis Preto',20,'lapis.jpg',1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
               "Values('Clips', 1.59,'Clips',50,'clips.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Productus");
        }
    }
}

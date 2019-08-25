using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginApp.Migrations
{
    public partial class addingTableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("SET IDENTITY_INSERT Customers ON INSERT INTO Customers (CustomerID, Name) VALUES (1, 'Yaseen Patel') SET IDENTITY_INSERT Customers OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Customers ON INSERT INTO Customers (CustomerID, Name) VALUES (2, 'Jonathan Croft') SET IDENTITY_INSERT Customers OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Customers ON INSERT INTO Customers (CustomerID, Name) VALUES (3, 'Hamza Shahid') SET IDENTITY_INSERT Customers OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Customers ON INSERT INTO Customers (CustomerID, Name) VALUES (4, 'Benjamin Franklin') SET IDENTITY_INSERT Customers OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Customers ON INSERT INTO Customers (CustomerID, Name) VALUES (5, 'David Halar') SET IDENTITY_INSERT Customers OFF");

            migrationBuilder.Sql("SET IDENTITY_INSERT Items ON INSERT INTO Items (ItemID, Name, Price) VALUES (1, 'Cheese Burger', CAST(3.50 AS Decimal(18,2))) SET IDENTITY_INSERT Items OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Items ON INSERT INTO Items (ItemID, Name, Price) VALUES (2, 'Chips', CAST(1.99 AS Decimal(18,2))) SET IDENTITY_INSERT Items OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Items ON INSERT INTO Items (ItemID, Name, Price) VALUES (3, 'Grilled Sandwitch', CAST(1.00 AS Decimal(18,2))) SET IDENTITY_INSERT Items OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Items ON INSERT INTO Items (ItemID, Name, Price) VALUES (4, 'Chicken Burger', CAST(3.50 AS Decimal(18,2))) SET IDENTITY_INSERT Items OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Items ON INSERT INTO Items (ItemID, Name, Price) VALUES (5, 'Bean Burger', CAST(4.50 AS Decimal(18,2))) SET IDENTITY_INSERT Items OFF");




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

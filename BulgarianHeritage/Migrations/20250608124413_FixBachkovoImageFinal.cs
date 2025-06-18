using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianHeritage.Migrations
{
    /// <inheritdoc />
    public partial class FixBachkovoImageFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // FINAL FIX: Update Bachkovo Monastery to use the new bachkovo-new.jpg image
            migrationBuilder.Sql(
                "UPDATE PointsOfInterest SET MainImageUrl = '/images/bachkovo-new.jpg' WHERE Name = 'Bachkovo Monastery'"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert to previous image path
            migrationBuilder.Sql(
                "UPDATE PointsOfInterest SET MainImageUrl = '/images/bachkovo.jpg' WHERE Name = 'Bachkovo Monastery'"
            );
        }
    }
}

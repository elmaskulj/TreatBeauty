using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatBeauty.Migrations
{
    public partial class uspGetTermsBySearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE usp_GetTermsBySearch
                               @Location NVARCHAR(50) NULL,
                               @Date DATETIME NULL,
                               @ServiceName NVARCHAR(50) NULL
                               AS
BEGIN
                              SELECT T1.Id 'Id',T4.Id 'SalonId', T4.Name 'SalonName',T4.Photo 'SalonPhoto', T5.Name 'CityName', T4.Location, T2.Name 'ServiceName', T2.Price 'ServicePrice', T2.Id 'ServiceId', T1.Date 'TermDate'
                              FROM Terms T1 JOIN Services T2 ON T1.ServiceId = T2.Id
                              JOIN Employees T3 ON T3.Id = T1.EmployeeId
                              JOIN Salons T4 ON T4.Id = T3.SalonId 
                              JOIN Cities T5 ON T5.Id = T4.CityId
                              WHERE ((T2.Name LIKE '%' + @ServiceName + '%' AND @ServiceName IS NOT NULL AND @ServiceName != '') OR @ServiceName IS NULL) AND ((T1.Date = @Date AND @Date IS NOT NULL) OR @Date IS NULL) AND (( (T4.Location LIKE '%' + @Location + '%' OR T5.Name LIKE '%' + @Location + '%') AND @Location IS NOT NULL AND @Location != '')OR @Location IS NULL) 
                              END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure usp_GetTermsBySearch";
            migrationBuilder.Sql(procedure);
        }
    }
}

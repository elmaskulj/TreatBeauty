using Microsoft.EntityFrameworkCore;
using System.IO;
using TreatBeauty.Database;


namespace TreatBeauty
{
    public class SetupService
    {
        public void Init(MyContext context)
        {
            context.Database.Migrate();
        }

        public void InsertData(MyContext context)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Script", "beauty.sql");
            var query = File.ReadAllText(path);
            context.Database.ExecuteSqlRaw(query);
        }
    }
}
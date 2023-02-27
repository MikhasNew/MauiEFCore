using EntityFremworkHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFremworkHelper.Context
{
    public class DataItemContext : DbContext
    {
        #region TABLES

        public DbSet<DataItem> DataItems { get; set; }
       
        #endregion

        #region CONSTRUCTOR

        //parameterless constructor must be above the others,
        //as it seems that EF Tools migrator just takes the .First() of them

        /// <summary>
        /// Constructor for creating migrations
        /// </summary>
        public DataItemContext()
        {
            File = Path.Combine("../", "UsedByMigratorOnly1.db3");
            Initialize();
        }

        /// <summary>
        /// Constructor for mobile app
        /// </summary>
        /// <param name="filenameWithPath"></param>
        public DataItemContext(string filenameWithPath)
        {
            File = filenameWithPath;
            Initialize();
        }

        void Initialize()
        {
            if (!Initialized)
            {
                Initialized = true;

                SQLitePCL.Batteries_V2.Init();

                Database.Migrate();
            }
        }

        public static string File { get; protected set; }
        public static bool Initialized { get; protected set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite($"Filename={File}");
        }

        #endregion

        public void Reload()
        {
            Database.CloseConnection();
            Database.OpenConnection();
        }

    }
}


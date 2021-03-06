using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Database;
using System.Linq;
using System.Web;

namespace ScaffoldMVC3.Models
{
    public class ScaffoldMVC3Context : DbContext
    {
        public DbSet<ScaffoldMVC3.Models.Team> Teams { get; set; }
    
        public ScaffoldMVC3Context()
        {
            // Instructions:
            //  * You can add custom code to this file. Changes will *not* be lost when you re-run the scaffolder.
            //  * If you want to regenerate the file totally, delete it and then re-run the scaffolder.
            //  * You can delete these comments if you wish
            //  * If you want Entity Framework to drop and regenerate your database automatically whenever you 
            //    change your model schema, uncomment the following line:
			    //DbDatabase.SetInitializer(new DropCreateDatabaseIfModelChanges<ScaffoldMVC3Context>());
        }
    }
}
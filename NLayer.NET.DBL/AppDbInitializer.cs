﻿using NLayer.NET.DBL.Entities;
using System.Data.Entity;

namespace NLayer.NET.DBL
{
    /// <summary>
    /// It will create the database if none exists as per the configuration. 
    /// However, if you change the model class and then run the application with this initializer, then it will throw an exception.
    /// <see cref="http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx"/>
    /// </summary>
    public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext db)
        {
            db.Users.Add(new User { Name = "Nick", Email = "nick@gmail.com" });
        }
    }
}

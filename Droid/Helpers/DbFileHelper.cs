using System;
using System.IO;
using SqliteApp.Droid.Helpers;
using SqliteApp.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbFileHelper))]
namespace SqliteApp.Droid.Helpers
{
    public class DbFileHelper : IDbFileHelper
    {
        public string GetLocalDbFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}

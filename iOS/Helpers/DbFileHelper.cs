using System;
using System.IO;
using SqliteApp.Helpers;
using SqliteApp.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbFileHelper))]
namespace SqliteApp.iOS.Helpers
{
    public class DbFileHelper : IDbFileHelper
    {

        public string GetLocalDbFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}

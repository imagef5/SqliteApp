using System;
namespace SqliteApp.Helpers
{
    public interface IDbFileHelper
    {
        string GetLocalDbFilePath(string filename);
    }
}

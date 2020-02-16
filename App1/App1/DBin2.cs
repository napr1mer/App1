using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
//using XPlat.Storage;
using Windows.Storage;


[assembly: Dependency(typeof(App1.DBin2))]
namespace App1
{
    public class DBin2 : ISQLite
    {
        public DBin2() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            // для доступа к файлам используем API Windows.Storage
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), sqliteFilename);
            return path;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using System.Threading.Tasks;

namespace FixedAssets_BarCode.Models.Models
{
    public static class Constants
    {
        public const string DatabaseFilename = "CEDBSQLite.db";
        public const string pathFolder = @"/sdcard/Android/data/com.tunitrack.fixedassets_barcode_/setting.txt";
        public const string pathFolderInstall = @"/sdcard/Android/data/com.tunitrack.fixedassets_barcode_";
        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = @"/sdcard/Android/data/com.tunitrack.fixedassets_barcode_/CEDB.db";     
            if (File.Exists(path) == true)
            {
                return path;
            }
            else
            {
                return path;
            }
        }    
    }
}

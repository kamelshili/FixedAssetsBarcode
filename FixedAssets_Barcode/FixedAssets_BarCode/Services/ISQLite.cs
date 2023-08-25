using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssets_BarCode.Data
{
    //interface qui permet de travailler avec android et ios ensemble .... 
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

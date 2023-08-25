
using FixedAssets_BarCode.Models.Models;
using FixedAssets_BarCode.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
////using Xamarin.Forms;
using System.Threading.Tasks;
using FixedAssets_BarCode.Views;

namespace FixedAssets_BarCode.Data
{
    class SettingDatabaseController
    {
        static object locker = new object();
        //SQLiteConnection database;

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            //return new SQLiteAsyncConnection(Constants.DatabasePath().Result, Constants.Flags);
            return new SQLiteAsyncConnection(Constants.DatabasePath(), Constants.Flags);
        });
        static SQLiteAsyncConnection database => lazyInitializer.Value;
        static bool initialized = false;

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!database.TableMappings.Any(m => m.MappedType.Name == typeof(FixedAssets_BarCode.Models.Setting).Name))
                {
                    await database.CreateTablesAsync(CreateFlags.None, typeof(FixedAssets_BarCode.Models.Setting)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
        public SettingDatabaseController()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        public Task<FixedAssets_BarCode.Models.Setting> GetSetting()
        {
            lock (locker)
            {
                if (database.Table<FixedAssets_BarCode.Models.Setting>().CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<FixedAssets_BarCode.Models.Setting>().FirstAsync();
            }
        }
        public Task<FixedAssets_BarCode.Models.Setting> GetSettingById(int id)
        {

            lock (locker)
            {
                if (database.Table<FixedAssets_BarCode.Models.Setting>().Where(i => i.Id == id).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<FixedAssets_BarCode.Models.Setting>()
                            .Where(i => i.Id == id)
                            .FirstAsync();
            }
        }
        public Task<FixedAssets_BarCode.Models.Setting> GetDescriptionBySetting(int id)
        {

            lock (locker)
            {
                if (database.Table<FixedAssets_BarCode.Models.Setting>().Where(i => i.Id == id).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<FixedAssets_BarCode.Models.Setting>()
                            .Where(i => i.Id == id)
                            .FirstAsync();
            }
        }
     


        public Task<List<FixedAssets_BarCode.Models.Setting>> GetAllSetting()
        {
            return database.Table<FixedAssets_BarCode.Models.Setting>().ToListAsync();
        }
        public Task<FixedAssets_BarCode.Models.Setting> GetFirstSetting()
        {
            return database.Table<FixedAssets_BarCode.Models.Setting>().FirstOrDefaultAsync();
        }

        public Task<int> SaveSetting(FixedAssets_BarCode.Models.Setting Setting)
        {
            lock (locker)
            {
                if (GetSettingById(Setting.Id) != null)
                {
                    return database.UpdateAsync(Setting);
                }
                else
                    return database.InsertOrReplaceAsync(Setting);
            }
        }

        public Task<int> DeleteSetting(string id)
        {
            lock (locker)
            {
                return database.DeleteAsync<FixedAssets_BarCode.Models.Setting>(id);
            }
        }
    }
}

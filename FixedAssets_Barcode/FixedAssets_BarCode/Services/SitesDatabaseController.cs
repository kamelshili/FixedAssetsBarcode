using FixedAssets_BarCode.Models.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
////using Xamarin.Forms;
using System.Threading.Tasks;

namespace FixedAssets_BarCode.Data
{
    class SitesDatabaseController
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
                if (!database.TableMappings.Any(m => m.MappedType.Name == typeof(Sites).Name))
                {
                    await database.CreateTablesAsync(CreateFlags.None, typeof(Sites)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }


        public SitesDatabaseController()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        public  Task<Sites> GetSiteAsync()
        {
            lock (locker)
            {
                if (database.Table<Sites>().CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Sites>().FirstAsync();
            }
        }
        public Task<Sites> GetSiteById(string id)
        {

            lock (locker)
            {
                if (database.Table<Sites>().Where(i => i.Site == id).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Sites>()
                            .Where(i => i.Site == id)
                            .FirstAsync();
            }
        }


        public Task<List<Sites>> GetSiteBySiteList(string site)
        {

            lock (locker)
            {
                if (site == "")
                    return GetAllSites();
                else if (database.Table<Sites>().Where(i => i.Site.ToLower().Contains(site.ToLower())).CountAsync().Result == 0)
                    return null;
                return database.Table<Sites>()
                        .Where(i => i.Site.ToLower().Contains(site.ToLower()))
                        .ToListAsync();
            }
        }

        public Task<List<Sites>> GetAllSites()
        {
            string AllSites = "select * from Sites order by Site";
            return database.QueryAsync<Sites>(AllSites);
        }


        public Task<int> SaveSite(Sites site)
        {
            lock (locker)
            {
                if (GetSiteById(site.Site) != null)
                {
                    return database.UpdateAsync(site);
                }
                else
                    return database.InsertOrReplaceAsync(site);
            }
        }

        public Task<int> DeleteSite(string id)
        {
            lock (locker)
            {
                return database.DeleteAsync<Sites>(id);
            }
        }
    }
}

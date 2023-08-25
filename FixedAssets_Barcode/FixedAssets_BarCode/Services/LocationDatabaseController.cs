using FixedAssets_BarCode.Models.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location = FixedAssets_BarCode.Models.Models.Location;

namespace FixedAssets_BarCode.Data
{
    class LocationDatabaseController
    {
        static object locker = new object();

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            // return new SQLiteAsyncConnection(Constants.DatabasePath().Result, Constants.Flags);
            return new SQLiteAsyncConnection(Constants.DatabasePath(), Constants.Flags);
        });
        static SQLiteAsyncConnection database => lazyInitializer.Value;
        static bool initialized = false;

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!database.TableMappings.Any(m => m.MappedType.Name == typeof(Location).Name))
                {
                    await database.CreateTablesAsync(CreateFlags.None, typeof(Location)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
        public LocationDatabaseController()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        public Task<Location> GetLocation()
        {
            lock (locker)
            {
                if (database.Table<Location>().CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Location>().FirstAsync();
            }
        }
        public Task<Location> GetLocationById(string idSite ,string idBinLoc )
        {

            lock (locker)
            {
                if (database.Table<Location>().Where(i => i.BinLoc == idBinLoc && i.Site == idSite).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Location>()
                            .Where(i => i.BinLoc == idBinLoc && i.Site == idSite)
                            .FirstAsync();
            }
        }

        public Task<List<Location>> GetListLocationBySiteBinLoc(string idSite, string idBinLoc)
        {

            lock (locker)
            {
                if (database.Table<Location>().Where(i => i.BinLoc == idBinLoc && i.Site == idSite).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Location>()
                            .Where(i => i.BinLoc == idBinLoc && i.Site == idSite)
                            .ToListAsync();
            }
        }

        public Task<int> GetLocationByIdPos(string idSite, string idBinLoc)
        {

            lock (locker)
            {
                if (database.Table<Location>().Where(i => i.BinLoc == idBinLoc && i.Site == idSite).CountAsync().Result == 0)
                    return Task.FromResult(-1);
                else
                {
                    Task<List<Location>> liste = database.Table<Location>().Where(i => i.Site == idSite).ToListAsync();

                    // .Where(i => i.BinLoc == idBinLoc && i.Site == idSite)
                    //.First();
                    int j = -1;
                    foreach(var l in liste.Result)
                    {
                        j++;
                        if (l.Site == idSite && l.BinLoc == idBinLoc)
                            return Task.FromResult(j);
                    }
                    return Task.FromResult(j);
                }
            }
        }
        public Task<List<Location>> GetLocationByIdList(string idSite, string idBinLoc)
        {
            lock (locker)
            {
                if (database.Table<Location>().Where(i => i.BinLoc == idBinLoc && i.Site == idSite).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Location>()
                            .Where(i => i.BinLoc == idBinLoc && i.Site == idSite)
                            .ToListAsync();
            }
        }

        public Task<List<Location>> GetLocationBySite(string idSite)
        {

            lock (locker)
            {
                var q = database.QueryAsync <Location> ("select * from Location where Site =? order by BinLoc", idSite);
                if (q.Result.Count == 0)
                    return null;
                else
                    return q;
            }
        }
        public Task<List<Location>> GetLocationBySiteList(string idSite)
        {

            lock (locker)
            {
                if (database.Table<Location>().Where(i => i.Site.ToLower().Contains(idSite.ToLower())).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Location>()
                            .Where(i => i.Site.ToLower().Contains(idSite.ToLower()))
                            .ToListAsync();
            }

        }
        public Task<List<Location>> GetLocationByBinLocList(string binloc)
        {

            lock (locker)
            {
                if (binloc == "")
                    return GetAllLocation();
                else if (database.Table<Location>().Where(i => i.BinLoc.ToLower().Contains(binloc.ToLower())).CountAsync().Result == 0)
                    return null;
                return database.Table<Location>()
                        .Where(i => i.BinLoc.ToLower().Contains(binloc.ToLower()))
                        .ToListAsync();
            }
        }


        public Task<List<Location>> GetAllLocation()
        {
            return database.Table<Location>().ToListAsync();
        }

        public Task<int> SaveLocation(Location location)
        {
            lock (locker)
            {
                if (GetLocationById(location.BinLoc,location.Site) != null)
                {
                    return database.UpdateAsync(location);
                }
                else
                    return database.InsertAsync(location);
            }
        }

        public Task<int> DeleteLocation(string idSite, string idBinLoc)
        {
            lock (locker)
            {
                Task<Location> location = GetLocationById(idSite, idBinLoc);
                if (location  != null)
                {
                    return database.DeleteAsync<Location>(location.Result.Id);
                }
                return Task.FromResult(-1);
            }
        }
    }
}

using FixedAssets_BarCode.Models.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace FixedAssets_BarCode.Data
{
    class InventoryDatabaseController
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
                if (!database.TableMappings.Any(m => m.MappedType.Name == typeof(Inventory).Name))
                {
                    await database.CreateTablesAsync(CreateFlags.None, typeof(Inventory)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public InventoryDatabaseController()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        public Task<Inventory> GetInventory()
        {
            lock (locker)
            {
                if (database.Table<Inventory>().CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Inventory>().FirstAsync();
            }
        }

        public Task<int> GetCountInventory()
        {
            lock (locker)
            {
              return   (database.Table<Inventory>().CountAsync());
                   
            }
        }

        public Task<Inventory> GetInventoryById(string id)
        {
            lock (locker)
            {             
                if (database.Table<Inventory>().Where(i => i.AssetNo == id).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Inventory>()
                            .Where(i => i.AssetNo == id)
                            .FirstAsync();
            }
        }


        public int GetCountInventoryItemByIdFilter(string id)
        {
            lock (locker)
            {
                return database.Table<InventoryItem>().Where(i => i.AssetNo.ToLower().Contains(id.ToLower())).CountAsync().Result;                
            }
        }

        public int GetCountInventoryItemById(string id)
        {
            lock (locker)
            {
                return database.Table<InventoryItem>().Where(i => i.AssetNo == id).CountAsync().Result;
            }
        }

        public int GetCountInventoryById(string id)
        {
            lock (locker)
            {
                return database.Table<Inventory>().Where(i => i.AssetNo == id).CountAsync().Result;
            }
        }

        public Task<List<InventoryItem>> GetInventoryItemById(string id)
        {

            lock (locker)
            {
                if (database.Table<InventoryItem>().Where(i => i.AssetNo.ToLower().Contains(id.ToLower())).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<InventoryItem>()
                            .Where(i => i.AssetNo.ToLower().Contains(id.ToLower()))
                            .ToListAsync();
            }
        }
        public Task<List<InventoryItem>> GetAllInventory()
        {
            return database.Table<InventoryItem>().ToListAsync();           
        }
        public Task<List<InventoryItem>> GetListInventoryBySiteBinLoc(string idSite, string idBinLoc)
        {

            lock (locker)
            {
                if (database.Table<InventoryItem>().Where(i => i.BinLoc == idBinLoc && i.Site == idSite).CountAsync().Result == 0)
                return database.Table<InventoryItem>()
                           .Where(i => i.BinLoc == idBinLoc && i.Site == idSite)
                           .ToListAsync();
                else
                    return database.Table<InventoryItem>()
                            .Where(i => i.BinLoc == idBinLoc && i.Site == idSite)
                            .ToListAsync();
            }
        }
        public Task<int> SaveInventory(Inventory inventory)
        {
            lock (locker)
            {
                if (GetInventoryById(inventory.AssetNo) != null)
                {
                    return database.UpdateAsync(inventory);
                }
                else
                    return database.InsertOrReplaceAsync(inventory);
            }
        }

        public Task<int> DeleteInventory(string inventoryId)
        {
            lock (locker)
            {
                return database.DeleteAsync<Inventory>(inventoryId);
            }
        }
    }
}

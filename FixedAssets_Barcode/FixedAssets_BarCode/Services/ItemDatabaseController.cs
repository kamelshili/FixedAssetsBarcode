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
    class ItemDatabaseController
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
                if (!database.TableMappings.Any(m => m.MappedType.Name == typeof(Item).Name))
                {
                    await database.CreateTablesAsync(CreateFlags.None, typeof(Item)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public ItemDatabaseController()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        public Task<Item> GetItem()
        {
            lock (locker)
            {
                if (database.Table<Item>().CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Item>().FirstAsync();
            }
        }
        public Task<Item> GetItemById(string id)
        {

            lock (locker)
            {
                if (database.Table<Item>().Where(i => i.Item_ == id).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Item>()
                            .Where(i => i.Item_ == id)
                            .FirstAsync();
            }
        }

        public int GetIndexItemById(string id)
        {
            lock (locker)
            {
                if (database.Table<Item>().Where(i => i.Item_ == id).CountAsync().Result == 0)
                    return -1;
                else
                {
                    List<Item> list = GetAllItem().Result;
                    int j = 0;
                    foreach(var lst in list)
                    {
                        if(lst.Item_ == id)
                        {
                            return j;
                        }
                        j++;
                    }                
                }
                return -1;
            }
        }

        public int GetItemByDescrip(string descrip)
        {

            lock (locker)
            {
                return database.Table<Item>().Where(i => i.Description.ToLower().Contains(descrip.ToLower())).CountAsync().Result;
            }
        }
       

        public Task<Item> GetDescriptionByItem(string id)
        {

            lock (locker)
            {
                if (database.Table<Item>().Where(i => i.Item_ == id).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Item>()
                            .Where(i => i.Item_ == id)
                            .FirstAsync();
            }
        }
        public Task<List<Item>> GetItemByDescriptionList(string descrip)
        {

            lock (locker)
            {
                if (descrip == "")
                    return GetAllItem();
                else if(database.Table<Item>().Where(i => i.Description.ToLower().Contains(descrip.ToLower())).CountAsync().Result == 0)
                    return null; 
                    return database.Table<Item>()
                            .Where(i => i.Description.ToLower().Contains(descrip.ToLower()))
                            .ToListAsync();
            }
        }

        public Task<List<Item>> GetAllItem()
        {
            return database.Table<Item>().OrderBy(i => i.Description).ToListAsync();
        }

        public Task<int> SaveItem(Item item)
        {
            lock (locker)
            {
                if (GetItemById(item.Item_) != null)
                {
                    return database.UpdateAsync(item);
                }
                else
                    return database.InsertOrReplaceAsync(item);
            }
        }

        public Task<int> DeleteItem(string id)
        {
            lock (locker)
            {
                return database.DeleteAsync<Item>(id);
            }
        }
    }
}

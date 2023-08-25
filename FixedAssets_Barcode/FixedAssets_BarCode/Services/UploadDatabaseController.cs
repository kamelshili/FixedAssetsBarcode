using FixedAssets_BarCode.Models.Models;
using SQLite;
////using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using System.Linq;

namespace FixedAssets_BarCode.Data
{
    class UploadDatabaseController
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
                if (!database.TableMappings.Any(m => m.MappedType.Name == typeof(Upload).Name))
                {
                    await database.CreateTablesAsync(CreateFlags.None, typeof(Upload)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public UploadDatabaseController()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        public Task<Upload> GetUpload()
        {
            lock (locker)
            {
                if (database.Table<Upload>().CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Upload>().FirstAsync();
            }
        }
        public Task<Upload> GetUploadById(string id)
        {

            lock (locker)
            {
               
                if (database.Table<Upload>().Where(i => i.AssetNo == id).CountAsync().Result == 0)
                    return null;
                else
                    return database.Table<Upload>()
                            .Where(i => i.AssetNo == id)
                            .FirstAsync();
            }
        }
        public int GetCountUploadByIdSearch(string keyword)
        {
            return database.Table<Upload>().Where(i => i.AssetNo.ToLower().Contains(keyword.ToLower())).CountAsync().Result;
        }

        public Task<List<Upload>> GetUploadByIdSearch(string keyword)
        {
            return database.Table<Upload>().Where(i => i.AssetNo.ToLower().Contains(keyword.ToLower())).ToListAsync();
        }
        public Task<List<Upload>> GetAllUpload()
        {
            return database.Table<Upload>().ToListAsync();          
        }
        public Task<int> SaveUpload(Upload upload)
        {
            lock (locker)
            {                             
                if (GetUploadById(upload.AssetNo) == null)
                    return database.InsertAsync(upload);
                else
                {
                    upload.TransID = GetUploadById(upload.AssetNo).Result.TransID;
                    return database.UpdateAsync(upload);
                }                
            }
        }

        public Task<int> DeleteUpload(long uploadId)
        {
            lock (locker)
            {
                return database.DeleteAsync<Upload>(uploadId);
            }
        }

        public Task<int> DeleteAllUpload()
        {
            lock (locker)
            {
                return database.DeleteAllAsync<Upload>();
            }
        }
    }
}

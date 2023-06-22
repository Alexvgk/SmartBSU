using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBSU.Services.DataStore
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item,string path);
        Task<bool> UpdateItemAsync(T item,string path);
        Task<bool> DeleteItemAsync(Guid id,string path);
        Task<T> GetItemAsync(Guid id, string path);
        Task<IEnumerable<T>> GetItemsAsync( string path, bool forceRefresh = false);
    }
}

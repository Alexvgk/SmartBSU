using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Java.Net;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using Model.Base;
using Newtonsoft.Json;

namespace SmartBSU.Services.DataStore
{
    [Serializable]
    public class DBDataStore<Model> : IDataStore<Model> where Model : BaseModel
    {
        readonly List<Model> items;

        public DBDataStore()
        {
            items = new List<Model>();
        }

        public async Task<bool> AddItemAsync(Model item, string path)
        {
            try
            {
                using (var http = new HttpClient())
                {

                    var json_item = JsonConvert.SerializeObject(item);
                    // var json_code = JsonConvert.SerializeObject(regCode);
                    http.BaseAddress = new Uri("https://smart.dev.rfct.info");
                    var relativeUri = path;
                    // Создаем контент запроса
                    var content_item = new StringContent(json_item, Encoding.UTF8, "application/json");
                    // Отправка POST-запроса
                    var response = await http.PostAsync(relativeUri, content_item);
                    if (response.IsSuccessStatusCode)
                        return await Task.FromResult(true);
                    else { return await Task.FromResult(false); }
                }
            }
            catch(UnknownHostException e )
            { throw e;}
        }

        public async Task<bool> UpdateItemAsync(Model item, string path)
        {
            try
            {
                using (var http = new HttpClient())
                {

                    var json_item = JsonConvert.SerializeObject(item);
                    // var json_code = JsonConvert.SerializeObject(regCode);
                    http.BaseAddress = new Uri("https://smart.dev.rfct.info");
                    var relativeUri = path + '/' + item.Id.ToString();
                    // Создаем контент запроса
                    var content_item = new StringContent(json_item, Encoding.UTF8, "application/json");
                    // Отправка POST-запроса
                    var response = await http.PutAsync(relativeUri, content_item).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
                return await Task.FromResult(true);
            }
            catch(UnknownHostException e) { throw e;}
        }

        public async Task<bool> DeleteItemAsync(Guid id, string path)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri("https://smart.dev.rfct.info");
                    var relativeUri = path + '/' + id;

                    var response = await http.DeleteAsync(relativeUri).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (UnknownHostException e) { throw e;}
        }

        public async Task<Model> GetItemAsync(Guid id, string path)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri("https://smart.dev.rfct.info");
                    var relativeUri = path + '/' + id.ToString();
                    var response = await http.GetAsync(relativeUri).ConfigureAwait(false);
                    var json = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var item = JsonConvert.DeserializeObject<Model>(json);
                        return item;
                    }
                    else
                    {
                        // Обработка ошибки
                        // ...
                        return null;
                    }
                }
            }
            catch(UnknownHostException e) { throw e; }
        }

        public async Task<IEnumerable<Model>> GetItemsAsync(string path,bool forceRefresh = false)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri("https://smart.dev.rfct.info");
                    var relativeUri = path;
                    var response = await http.GetAsync(relativeUri).ConfigureAwait(false);
                    var json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        var item = JsonConvert.DeserializeObject<List<Model>>(json);
                        return item;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (UnknownHostException e) { throw e; }
        }

        async Task<Model> IDataStore<Model>.GetItemAsync(Guid id, string path)
        {
            return await Task.FromResult(items.FirstOrDefault(w => w.Id == id));
        }
    }
}
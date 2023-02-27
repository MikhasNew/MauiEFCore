using EntityFremworkHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFremworkHelper.Context
{
    public static class DbAdapter
    {
        private static readonly string dbFullPath = Path.Combine(FileSystem.AppDataDirectory, "SQLite001.db3");

        public static List<DataItem> DataItemsList { get; set; }

        public static async Task LoadDataFromDb()
        {
            if (DataItemsList == null)
            {
                DataItemsList = new();
                var list = await GetDataItemsAsync();
                DataItemsList.AddRange(list);
            }
        }

        public static async Task<List<DataItem>> GetDataItemsAsync()
        {
            var list = new List<DataItem>();
            using (var db = new DataItemContext(dbFullPath))
            {
                list = await db.DataItems.ToListAsync();
            }
            return list;
        }
        public static async Task RemoveDataItem(DataItem dataItem)
        {
            if (dataItem != null)
            {
                using (var db = new DataItemContext(dbFullPath))
                {
                    await  Task.Run(async () =>
                    {
                        db.DataItems.Remove(dataItem);
                        await db.SaveChangesAsync();
                   
                    }).ConfigureAwait(false);
                }
            }
        }
        public static async Task AddDataItem(DataItem dataItem)
        {
            if (dataItem != null)
            {
                using (var db = new DataItemContext(dbFullPath))
                {
                    await Task.Run(async () =>
                    {
                        db.DataItems.Add(dataItem);
                        await db.SaveChangesAsync();
                    }).ConfigureAwait(false);
                    DataItemsList.Add(dataItem);
                }
            }
        }

    }
}

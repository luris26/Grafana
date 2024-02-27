using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsRUs.ClassLib.Data;
using TicketsRUs.ClassLib.Services;

namespace TicketsRUs.Maui.Init
{
    public class LocalDataBaseInit
    {

        //I add this becausse I trully belive ourdata base is wrong!
        IDatabaseLocation _data;
        public LocalDataBaseInit(IDatabaseLocation data)
        {
            this._data = data; 
        }

        public async Task<SQLiteAsyncConnection> InitLocalDatabase()
        {
            var db = EstablishConnection();
            await db.CreateTableAsync<AvailableEvent>();
            await db.CreateTableAsync<Ticket>();

            return db;
        }

        public SQLiteAsyncConnection EstablishConnection()
        {
            if (!Directory.Exists(_data.DatabaseDirectory))Directory.CreateDirectory(_data.DatabaseDirectory);

            var databasePath = Path.Combine(_data.DatabaseDirectory, _data.DatabaseName);
            var database = new SQLiteAsyncConnection(databasePath);

            return database;
        }

        public async Task EmptyDatabase()
        {
            var db = EstablishConnection();

            await db.DeleteAllAsync<Ticket>();
            await db.DeleteAllAsync<AvailableEvent>();
        }
    }
}

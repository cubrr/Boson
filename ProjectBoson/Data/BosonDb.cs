// Copyright (c) 2015 Joona Heikkilä
//
// This file is part of Boson.
// 
// Boson is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Boson is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

/*using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using InfinityScript;
using Mono.Data.Sqlite;

namespace ProjectBoson.Data
{
    public class BosonDb : IDisposable
    {
        public SqliteConnection Connection;
        private readonly Mutex _dbMutex;

        public BosonDb(string dbFile)
        {
            _dbMutex = new Mutex(false, dbFile);

            if (!File.Exists(dbFile))
            {
                Log.Info("Creating new database file: " + Path.GetFullPath(dbFile));
            }

            Connection = new SqliteConnection("Data Source=" + dbFile + "; Version=3;");
            Connection.Open();

            using (var cmd = Connection.CreateCommand())
            {
                Log.Info("Creating tables if they don't already exist.");
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS [Preferences](" +
                                  "[Id] INTEGER NOT NULL PRIMARY KEY," +
                                  "[Key] TEXT UNIQUE," +
                                  "[Value] TEXT);";
                cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && Connection != null)
            {
                Connection.Dispose();
                Connection = null;
            }
        }
    }
}
*/
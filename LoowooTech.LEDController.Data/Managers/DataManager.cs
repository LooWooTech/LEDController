using LoowooTech.LEDController.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;

namespace LoowooTech.LEDController.Data
{
    public class DataManager
    {
        private DataManager()
        { }

        public readonly static DataManager Instance = new DataManager();
        private readonly static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        private SQLiteConnection GetConn()
        {
            return new SQLiteConnection("Data Source=" + System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConnectionString));
        }

        private int ExecuteSql(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConn())
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                var result =  cmd.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }

        private object ExecuteScalar(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConn())
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                var result = cmd.ExecuteScalar();
                conn.Close();
                return result;
            }
        }

        private DataTable GetDataTable(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = GetConn())
            {
                conn.Open();
                var cmd = new SQLiteCommand(sql, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                var da = new SQLiteDataAdapter(cmd);
                var ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
        }


        private void SaveDataModel(Data model)
        {
            if (model.ID == 0)
            {
                ExecuteSql("INSERT INTO Data (Type,CreateTime,Data) VALUE(@Type,@CreateTime,@Data)",
                    new SQLiteParameter("@Type", (int)model.Type),
                    new SQLiteParameter("@CreateTime", model.CreateTime),
                    new SQLiteParameter("@Data", model.DataJson)
                    );
            }
            else
            {
                ExecuteSql("UPDATE Data SET Data = @Data WHERE Type=@Type",
                    new SQLiteParameter("@Type", (int)model.Type),
                    new SQLiteParameter("@Data", model.DataJson)
                );
            }

        }

        private Data GetDataModel<T>()
        {
            var type = GetType<T>();
            var dt = GetDataTable(string.Format("SELECT * FROM [Data] WHERE Type = {0} LIMIT 0,1", (int)type));
            var dr = dt.Rows[0];
            return new Data
            {
                ID = int.Parse(dr["ID"].ToString()),
                CreateTime = DateTime.Parse(dr["CreateTime"].ToString()),
                Type = (DataType)int.Parse(dr["Type"].ToString()),
                DataJson = dr["Data"].ToString()
            };

        }

        public List<T> GetList<T>()
        {
            var model = GetDataModel<T>();
            var result = new List<T>();
            if (model != null)
            {
                result = model.GetObject<List<T>>();
            }
            return result == null ? new List<T>() : result;
        }

        public ClientWindow GetClientWindow(string clientId)
        {
            var windows = GetList<ClientWindow>();
            foreach (var win in windows)
            {
                if (win.ID == clientId)
                {
                    return win;
                }
            }
            return null;
        }

        public void Save<T>(List<T> list)
        {
            var model = GetDataModel<T>() ?? new Data
            {
                Type = GetType<T>()
            };
            model.SetObject(list);
            SaveDataModel(model);
        }

        private DataType GetType<T>()
        {
            var typeName = typeof(T).Name;
            var enumType = typeof(DataType);

            foreach (var name in Enum.GetNames(enumType))
            {
                if (typeName.Contains(name))
                {
                    return (DataType)Enum.Parse(enumType, name);
                }
            }
            return 0;
        }
    }
}

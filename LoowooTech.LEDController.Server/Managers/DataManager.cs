using LoowooTech.LEDController.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoowooTech.LEDController.Server.Managers
{
    public class DataManager
    {
        private static void SaveDataModel(Data model)
        {
            using (var db = new DataContext())
            {
                var entity = db.Datas.FirstOrDefault(e => e.ID == model.ID);
                if (entity != null)
                {
                    entity.DataBytes = model.DataBytes;
                }
                else
                {
                    db.Datas.Add(model);
                }
                db.SaveChanges();
            }
        }

        private static Data GetDataModel<T>()
        {
            using (var db = new DataContext())
            {
                var type = GetType<T>();
                return db.Datas.FirstOrDefault(e => e.Type == type);
            }
        }

        public static List<T> GetList<T>()
        {
            var model = GetDataModel<T>();
            return model == null ? new List<T>() : model.GetObject<List<T>>();
        }

        public static void Save<T>(List<T> list)
        {
            var model = GetDataModel<T>() ?? new Data();
            model.SetObject(list);
            SaveDataModel(model);
        }

        private static DataType GetType<T>()
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

using System;
using System.Collections.Generic;

using System.Text;

namespace LoowooTech.LEDController.Server.Managers
{
    public class HistoryManager
    {
        private HistoryManager()
        { }

        public readonly static HistoryManager Instance = new HistoryManager();

        public void Add(History model)
        {
            using (var db = new DataContext())
            {
                db.Histories.Add(model);
                db.SaveChanges();
            }
        }

        public List<History> GetList(string clientId, int pageIndex, int pageSize, out int pageCount)
        {
            using (var db = new DataContext())
            {

                var query = db.Histories.AsQueryable();

                if (!string.IsNullOrEmpty(clientId))
                {
                    query = query.Where(e => e.ClientId == clientId);
                }

                var recordCount = query.Count();

                pageCount = recordCount / 20;
                if (recordCount % 20 > 0) pageCount++;

                return query.OrderByDescending(e => e.ID).Skip(pageIndex * pageSize - pageSize).Take(pageSize).ToList();
            }
        }
    }
}

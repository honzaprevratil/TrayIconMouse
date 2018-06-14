using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrayIcon
{
    public class MouseSettingDatabase
    {
        private SQLiteConnection database = new SQLiteConnection("MouseProfiles.db3");
        public MouseSettingDatabase()
        {
            database.CreateTable<MouseProfile>();

            if (GetItems().Count < 1)
            {
                SaveItem(new MouseProfile(1, "Slow", 5, 500, 2));
                SaveItem(new MouseProfile(2, "Medium", 7, 500, 3));
                SaveItem(new MouseProfile(3, "Fast", 9, 500, 4));
            }
        }
        public List<MouseProfile> GetItems()
        {
            return database.Table<MouseProfile>().ToList();
        }
        
        public int SaveItem(MouseProfile mouseProfile)
        {
            if (mouseProfile != null && mouseProfile.Id > 0)
            {
                return database.Update(mouseProfile);
            }
            else
            {
                return database.Insert(mouseProfile);
            }
        }
    }
}

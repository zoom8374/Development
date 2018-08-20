using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryManager
{
    public class CHistoryManager
    {
        private static HistoryWindow HistoryWnd = new HistoryWindow();

        public bool IsShowHistoryWindow = false;

        public enum LOG_TYPE { INFO = 0, WARN, ERR }
        private static string[] LogType = new string[3] { "INFO", "WARN", "ERR" };

        public CHistoryManager(int _ProjectType)
        {
            //Screenshot Path 번호 지정
            HistoryWnd.Initialize(_ProjectType);
        }

        /// <summary>
        /// AddHistory(RecipeName, LastResult, ID Result, InspImagePath) 
        /// </summary>
        /// <param name="HistoryItem"></param>
        public static void AddIDHistory(string[] HistoryItem)
        {
            string INSERT_string = "INSERT INTO HistoryFile (Date, RecipeName, LastResult, IDResult, InspImagePath) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');";

            DateTime _NowDate = DateTime.Now;
            string _NowDateFormat = _NowDate.ToString("yyyy-MM-dd HH:mm:ss.ffff");

            SqlQuery.HistoryInsertQuery(string.Format(INSERT_string, _NowDateFormat, HistoryItem[0], HistoryItem[1], HistoryItem[2], HistoryItem[3]));
        }

        /// <summary>
        /// AddHistory(RecipeName, LastResult, ID Result, InspImagePath) 
        /// </summary>
        /// <param name="HistoryItem"></param>
        public static void AddLEADHistory(string[] HistoryItem)
        {
            string INSERT_string = "INSERT INTO HistoryFile (Date, RecipeName, LastResult, IDResult, InspImagePath) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');";

            DateTime _NowDate = DateTime.Now;
            string _NowDateFormat = _NowDate.ToString("yyyy-MM-dd HH:mm:ss.ffff");

            SqlQuery.HistoryInsertQuery(string.Format(INSERT_string, _NowDateFormat, HistoryItem[0], HistoryItem[1], HistoryItem[2], HistoryItem[3]));
        }

        public void ShowLogWindow(bool _IsShow)
        {
            IsShowHistoryWindow = _IsShow;

            if (true == _IsShow)
            {
                HistoryWnd.Show();
            }

            else if (false == _IsShow)
            {
                HistoryWnd.Hide();
            }
        }

        public void ShowHistoryWindow()
        {
            if (true == HistoryWnd.CheckDBFile())
            {
                HistoryWnd.ClearDataGridViewHistory();
                HistoryWnd.ClearSearchOption();
                HistoryWnd.ShowDialog();
            }
        }
    }
}

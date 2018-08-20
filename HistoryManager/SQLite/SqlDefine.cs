using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HistoryManager
{
    public class SqlDefine
    {
        string InspType = "";
        internal const string INSERT_HISTORY = "INSERT INTO HistoryFile (Date, RecipeName, Result, ResultX, ResultTheta, InspResult, SendResult, InspImagePath) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');";
        internal const string CREATE_TABLE = "CREATE TABLE HistoryFile (Date Datetime, RecipeName char, Result char, ResultX char, ResultTheta char, InspResult char, SendResult char, InspImagePath char);";
        internal const string SELECT = "SELECT * FROM HistoryFile";
        internal const string SEARCH_DATE = "SELECT * FROM HistoryFile WHERE";
        internal const string SEARCH_RECIPENAME = "RecipeName in";
        internal const string SEARCH_RESULTNAME = "LastResult in";
        internal const string SEARCH_NGTYPENAME = "ResultType in";
        internal const string DELETE_RECORD = "DELETE FROM HistoryFile WHERE";
        internal const string GET_IMAGEPATH = "SELECT InspImagePath FROM HistoryFile WHERE rowID = 1";
    }
}
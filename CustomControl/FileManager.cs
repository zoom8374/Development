using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomControl
{
    //LDH, 2018.09.21, File Write/Read 용 class
    public class FileManager
    {
        #region txt File Write/Read
        public void txtFileWrite(string FilePath, List<string> WriteList)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
                System.Threading.Thread.Sleep(100);
            }

            StreamWriter FileWriter = new StreamWriter(FilePath);

            foreach (string ContentsLine in WriteList)
            {
                FileWriter.WriteLine(ContentsLine);
            }

            FileWriter.Close();
        }

        public List<string> txtFileRead(string FilePath)
        {
            List<string> ReadList = new List<string>();

            if (File.Exists(FilePath))
            {
                StreamReader FileReader = new StreamReader(FilePath, Encoding.Default);

                foreach (string ReadString in FileReader.ReadToEnd().Split('\n'))
                {
                    ReadList.Add(ReadString.Replace("\r", ""));
                }
            }
            else
            {
                ReadList = null;
            }

            return ReadList;
        }
        #endregion txt File Write/Read

        public void iniFileWrite(string FilePath)
        {

        }

        public void iniFileReae(string FilePath)
        {

        }
    }
}

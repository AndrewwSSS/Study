using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task4_5
{
    public class IdenticalFilesInfo
    {
        public List<string> IdenticalFiles { get; set; } = new List<string>();

        public IdenticalFilesInfo()
        {
           
        }

        public bool AddIdenticalFile(string pathToFile)
        {
            if(new FileInfo(pathToFile).Exists)
            {
                IdenticalFiles.Add(pathToFile);
                return true;
            }
            return false;

        }

        public bool CopyUniqueFileToDirectory(string dir)
        {
            if (Directory.Exists(dir))
            {
                try { File.Copy(IdenticalFiles.First(), Path.Combine(dir, new FileInfo(IdenticalFiles.First()).Name), false); }
                catch
                {
                    return false;
                }

                return true;

            }
            return false;
        }
    }
}

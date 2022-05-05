using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task4_5
{
    public class FindAndSelectUniqueFiles
    {
        public string DirectoryToSelect { get; set; }
        public string HubDirectory { get; set; }

        public List<string> FilesInAnalysis { get; set; } = new List<string>();
        public List<IdenticalFilesInfo> IdenticalFilesInfos { get; set; } = new List<IdenticalFilesInfo>();
        public List<string> UniqueFiles { get; set; } = new List<string>();
        public List<string> Contents { get; set; } = new List<string>();


        public FindAndSelectUniqueFiles(string DirectoryToSelect, string HubDirectory)
        {
            if(!Directory.Equals(DirectoryToSelect, HubDirectory))
            {
                this.DirectoryToSelect = DirectoryToSelect;
                this.HubDirectory = HubDirectory;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Identical directorys");
            }
            
        }

        public void StartAnalysis()
        {
            if(ReadContents())
            {
                while (FilesInAnalysis.Count > 0)
                {
                    if (FilesInAnalysis.Count == 1)
                    {
                        UniqueFiles.Add(FilesInAnalysis[0]);
                        FilesInAnalysis.RemoveAt(0);
                        break;
                    }

                    IdenticalFilesInfo TempInfo = null;
                    bool isUnique = true;
                    List<int> ListTemp = new List<int>();

                    for (int j = 1; j < FilesInAnalysis.Count; j++)
                    {
                        if (Contents[0] == Contents[j])
                        {
                            if (TempInfo == null)
                            {
                                TempInfo = new IdenticalFilesInfo();
                                TempInfo.AddIdenticalFile(FilesInAnalysis[0]);
                            }


                            TempInfo.AddIdenticalFile(FilesInAnalysis[j]);
                            ListTemp.Add(j);

                            isUnique = false;
                        }

                    }

                    if (!isUnique)
                    {
                        // Delete already processed files
                        foreach (int item in ListTemp)
                        {
                            FilesInAnalysis.RemoveAt(item);
                            Contents.RemoveAt(item);
                        }
                        IdenticalFilesInfos.Add(TempInfo);
                    }
                    else
                    {
                        UniqueFiles.Add(FilesInAnalysis[0]);
                        FilesInAnalysis.RemoveAt(0);
                        Contents.RemoveAt(0);
                    }
                }


                foreach (IdenticalFilesInfo item in IdenticalFilesInfos)
                {
                    item.CopyUniqueFileToDirectory(HubDirectory);
                }

                foreach (string item in UniqueFiles)
                {
                    try { File.Copy(item, Path.Combine(HubDirectory, new FileInfo(item).Name), false); }
                    catch { }

                }
            }

        }

        public string GenerateStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Number of identical files: {IdenticalFilesInfos.Select((iff) => iff.IdenticalFiles.Count).Sum()}");
            stringBuilder.AppendLine();

            stringBuilder.AppendLine("Identical files:");

            for(int j = 0; j < IdenticalFilesInfos.Count; j++)
            {

                stringBuilder.Append($"{j+1}. ");

                for(int i = 0; i < IdenticalFilesInfos[j].IdenticalFiles.Count; i++)
                {
                    stringBuilder.Append($"{new FileInfo(IdenticalFilesInfos[j].IdenticalFiles[i]).Name}");

                    if (i != IdenticalFilesInfos[j].IdenticalFiles.Count - 1)
                        stringBuilder.Append(" | ");
                }
        

                if (j != IdenticalFilesInfos.Count - 1)
                    stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private bool ReadContents()
        {
            try
            {
                FilesInAnalysis = Directory.GetFiles(DirectoryToSelect).ToList();
            }
            catch (Exception)
            {
                return false;
            }


            for (int i = 0; i < FilesInAnalysis.Count; i++)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(FilesInAnalysis[i]))
                    {
                        Contents.Add(sr.ReadToEnd());
                    }
                }catch (Exception) { return false; }
             
            }

            return true;

        }
    }
}

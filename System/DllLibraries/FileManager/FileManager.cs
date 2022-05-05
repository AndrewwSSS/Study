using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace File_Manager
{
    public static class FileManager
    {

        public static bool CopyFile(string SourcePath, string NewPath)
        {
            try { File.Copy(SourcePath, NewPath, false); } catch { return false; }
            return true;

        }

        public static bool CopyDirectory(string SourceDir, string DestinationDir)
        {
            if (!Directory.Exists(DestinationDir))
                return false;


            string NewDirectoryPath = Path.Combine(DestinationDir, new DirectoryInfo(SourceDir).Name);
            try { Directory.CreateDirectory(NewDirectoryPath); } catch { return false; }

            try
            {
                foreach (var item in Directory.GetFiles(SourceDir))
                {
                    new FileInfo(item).CopyTo(Path.Combine(NewDirectoryPath, new FileInfo(item).Name));
                }
            }
            catch { return false; }


            return true;


        }

        public static bool DeleteFilesByNames(List<string> Names, string Dir)
        {
            if (!Directory.Exists(Dir))
                return false;


            try
            {
                foreach (string item in Directory.GetFiles(Dir))
                {
                    if (Names.IndexOf(new FileInfo(item).Name) != -1)
                        File.Delete(item);
                }
            }
            catch { return false; }


            return true;
        }

        public static bool DeleteFileByName(string Name, string Dir)
        {
            if (!Directory.Exists(Dir))
                return false;

            try
            {

                string res = Directory.GetFiles(Dir).Where(d => new FileInfo(d).Name == Name).FirstOrDefault();
                if (res != null) {
                    File.Delete(res);
                }

            }
            catch { return false; }


            return true;
        }

        public static bool DeleteFileByMask(string Mask, string Dir)
        {
            if (Directory.Exists(Dir))
            {
                try
                {
                    foreach (string item in Directory.GetFiles(Dir, Mask))
                        new FileInfo(item).Delete();
                }
                catch
                {
                    return false;
                }

                return true;

            }
            else
                return false;
        }

        public static bool MoveFile(string SourcePath, string DestinationPath)
        {
            if (File.Exists(SourcePath))
            {
                try { new FileInfo(SourcePath).MoveTo(DestinationPath); } catch { return false; }
                return true;
            }
            else
                return false;
        }

        public static bool CountOccurencesWordInFile(string Word, string PathToFile, string PathToDirForReport)
        {
            if(File.Exists(PathToFile) && Directory.Exists(PathToDirForReport))
            {
                try
                {
                    int NumberOfOccurences;
                    using (StreamReader reader = new StreamReader(PathToFile))
                    {
                        NumberOfOccurences = new Regex(reader.ReadToEnd()).Matches(Word).Cast<Match>().Count();
                    }

                    using (StreamWriter writer = new StreamWriter(Path.Combine(PathToDirForReport, "/Report.txt")))
                    {
                        writer.WriteLine("Full path: " + PathToFile);
                        writer.WriteLine( $"Number Occurences of word({Word}): " + NumberOfOccurences);
                    }
                    
                }
                catch { return false; }
                return true;
            }
            else
                return false;
        }

        public static bool CountOccurencesWordInDirectory(string Word, string PathToDir, string PathToDirForReport)
        {
            if (Directory.Exists(PathToDirForReport) && Directory.Exists(PathToDirForReport) && !string.IsNullOrWhiteSpace(Word))
            {
                try
                {
                    StringBuilder  stringBuilder = new StringBuilder();
                    foreach (string item in Directory.GetFiles(PathToDir))
                    {
                        int NumberOfOccurences;
                        using (StreamReader reader = new StreamReader(item))
                        {
                            NumberOfOccurences = new Regex(reader.ReadToEnd()).Matches(Word).Cast<Match>().Count();
                        }

                        
                        stringBuilder.AppendLine("Full path: " + item);
                        stringBuilder.AppendLine($"Number Occurences of word({Word}): " + NumberOfOccurences);
                        stringBuilder.AppendLine();


                    }


                    using(StreamWriter writer = new StreamWriter(Path.Combine(PathToDirForReport, "/Report.txt")))
                    {
                        writer.Write(stringBuilder.ToString());
                    }
                    return true;

                }
                catch { return false; }



            }
            else
                return false;
        }
    }
}

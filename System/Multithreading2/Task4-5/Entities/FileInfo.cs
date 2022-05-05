using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task4_5.Entities
{
    public class FileInfo
    {
        public string Path { get; set; }
        
        public string SearchString { get; set; }

        public int NumberOfOccurrences { get; set; }
        public string FileName => System.IO.Path.GetFileName(Path);

        public FileInfo(string Path, string WordToFind)
        {
            this.Path = Path;
            this.SearchString = WordToFind;
            
        }

        public void StartFinding()
        {
            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    string content = sr.ReadToEnd();
                    NumberOfOccurrences = Regex.Matches(content, SearchString).Cast<Match>().Count();
                }
            }
        }

    }
}

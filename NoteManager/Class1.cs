using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace KindleNote
{
    public class Note
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string NotePosition { get; set; }
        public DateTime NoteDateTime { get; set; }
        public string NoteContent { get; set; }
    }
    
    public class NoteManager
    {
        public string NotePath;
        public string AllNotes;
        public NoteManager(string _path)
        {
            NotePath = _path;
            AllNotes = File.ReadAllText(_path);
        }
        
        public string[] SpiltEveryNotes()
        {
            string[] everyNote = Regex.Split(AllNotes,"==========",RegexOptions.IgnoreCase);
            return everyNote;
        }

        public string[] GetBookNames()
        {
            try
            {
                string[] all = SpiltEveryNotes();
                List<string> result = new List<string>();
               // List<string> books = new List<string>();
                List<string> bookListResult = new List<string>();

                for (int i = 0; i < all.Length; i++)
                {
                   // int lastBlank = 0;
                    string[] secondSpilt;
                    string[] lastSpilt;
                    secondSpilt= all[i].Split('\\');
                    lastSpilt = secondSpilt[0].Split(new char[] {' '});
                    //lastSpilt = secondSpilt[0];
                    //for (int j = 0; j < lastSpilt.Length; j++)
                    //{
                    //    if (lastSpilt[j] == ' ')
                    //        lastBlank = j;
                    //}

                    //for (int k = 0; k < lastBlank; k++)
                    //{
                    //    result.Add(lastSpilt[k].ToString());
                    //}
                    result.Add(lastSpilt[0]);
                }


                string[] resultArrayRAW = result.ToArray<string>();

                foreach(string eachBook in resultArrayRAW)
                {
                    if (!bookListResult.Contains(eachBook))
                        bookListResult.Add(eachBook);
                }

                //foreach (string single in bookListResult)
                //{
                //    string enterRemoved;
                //    if (single.Contains("\r\n"))
                //    {
                //        bookListResult.Remove(single);
                //        enterRemoved = single.Replace("\r\n",string.Empty);
                //        bookListResult.Add(enterRemoved);
                //    }
                //}


                return bookListResult.ToArray<string>();
            }
            catch
            {
                return null;
            }
        }

        public string[] SearchByBook(string _bookName)
        {
            try
            {
                string[] spilted = SpiltEveryNotes();
                List<string> result = new List<string>();
                for (int i = 0; i < spilted.Length; i++)
                {
                    if (spilted[i].Contains(_bookName))
                    {
                        result.Add(spilted[i]);
                    }
                }
                return result.ToArray<string>();
            }
            catch
            {
                return null;
            }

        }

    }
}

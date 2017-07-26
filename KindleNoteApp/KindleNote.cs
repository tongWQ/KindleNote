using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace KindleNoteApp
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
            string[] everyNote = Regex.Split(AllNotes, "==========", RegexOptions.IgnoreCase);
            return everyNote;
        }

        public string[] GetBookInformation()
        {
            try
            {
                string[] all = SpiltEveryNotes();
                List<string> result = new List<string>();
                // List<string> books = new List<string>();
                List<string> bookListResult = new List<string>();
                //List<string> secondSplit = new List<string>();

                string lastSpiltSingle = string.Empty;
                for (int i = 0; i < all.Length; i++)
                {
                    string[] secondSpilt;
                    secondSpilt = all[i].Split('\r','\n');
                    if(secondSpilt.Length<11)
                    {
                        lastSpiltSingle = secondSpilt[0];
                        result.Add(lastSpiltSingle);
                    }
                    else
                    {
                        lastSpiltSingle = secondSpilt[2];
                        result.Add(lastSpiltSingle);
                    }

                }

                string[] resultArrayRAW = result.ToArray<string>();

                foreach (string eachBook in resultArrayRAW)
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
                string lastSpiltSingle = string.Empty;
                string lastSpiltSingle2 = string.Empty;
                for (int i = 0; i < spilted.Length; i++)
                {
                    //if (spilted[i].Contains(_bookName))
                    //{
                    //    result.Add(spilted[i]);
                    //}
                    string[] secondSpilt;
                    secondSpilt = spilted[i].Split('\r', '\n');
                    if (secondSpilt.Length < 11)
                    {
                        if(secondSpilt[0].Contains(_bookName))
                        {
                            lastSpiltSingle = secondSpilt[2];
                            result.Add(lastSpiltSingle);
                            lastSpiltSingle2 = secondSpilt[6];
                            result.Add(lastSpiltSingle2);
                        }

                    }
                    else
                    {
                        if(secondSpilt[2].Contains(_bookName))
                        {
                            lastSpiltSingle = secondSpilt[4];
                            result.Add(lastSpiltSingle);
                            lastSpiltSingle2 = secondSpilt[8];
                            result.Add(lastSpiltSingle2);
                        }
                    }

                }
                return result.ToArray<string>();
            }
            catch
            {
                return null;
            }

        }


        //public string GetAuthor(string _bookName)
        //{
        //    Note n = new Note();
        //    try
        //    {
        //        string[] allNotes = SpiltEveryNotes();

        //        string[] allNames = GetBookNames();

        //        string[] spilted=null;
                
        //        //foreach(string bookToFind in allNames)
        //        //{
        //        //    if(bookToFind==_bookName)
        //        //    {
        //        //        n.BookName = _bookName;
        //        //    }
        //        //}

        //        for (int i = 0; i < AllNotes.Length; i++)
        //        {
        //            spilted = allNotes[i].Split('\\');
        //        }

        //        for (int j = 0; j < spilted.Length; j++)
        //        {
        //            if(spilted[j].Contains(_bookName))
        //            {
        //                string[] lastSpilt = spilted[j].Split(new char[] { ' ' });
        //                n.BookName = lastSpilt[lastSpilt.Length - 1].TrimStart('(');
        //                n.BookName = lastSpilt[lastSpilt.Length - 1].TrimEnd(')');
        //            }
        //            break;
        //        }

        //        return n.BookName;

        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}

    }
}

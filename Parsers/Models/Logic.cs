using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Windows;
using Microsoft.Win32;

namespace Parsers.Models
{
    sealed class Content
    {
        // Main variables
        public string Result { get; set; }

        public string Path { get; set; }

        // Filter variables

        public bool TakeItems { get; set; }

        public bool OrderByRatings { get; set; }

        public bool WhereBirthYearMore { get; set; }

        // Functions

        public string ReadAndParseFile(string Path)
        {
            //Result = String.Empty;
            if (!string.IsNullOrEmpty(Path))
            {
                IEnumerable<ChessPlayer> list;
                if (TakeItems)
                {
                    list = File.ReadAllLines(Path)
                        .Skip(1)
                        .Select(ChessPlayer.ParseFileChessPlayer)
                        .Take(10);
                }
                else if (OrderByRatings)
                {
                    list = File.ReadAllLines(Path)
                        .Skip(1)
                        .Select(ChessPlayer.ParseFileChessPlayer)
                        .OrderBy(player => player.Ratings);
                }
                else if (WhereBirthYearMore)
                {
                    list = File.ReadAllLines(Path)
                        .Skip(1)
                        .Select(ChessPlayer.ParseFileChessPlayer)
                        .Where(player => player.BirthYear >= 1980);
                }
                else
                {
                    list = File.ReadAllLines(Path)
                        .Skip(1)
                        .Select(ChessPlayer.ParseFileChessPlayer);
                }
                Result = string.Join("\n", list);
            }
            else
            {
                MessageBox.Show("File directory is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Result;
        }

        public string BtnClickBrowse()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv";
            bool? response = ofd.ShowDialog();
            if (response == true)
            {
                string filepth = ofd.FileName;
                Path = filepth;
            }
            return Path;
        }

        public string DropFile(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filename = files[0];
                Path = filename;
            }
            return Path;
        }
    }
}

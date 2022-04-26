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
        public string Result { get; set; }

        public string Path { get; set; }
        //public string LastName { get; set; }

        //public DateTime BirthDate { get; set; }
        public string ReadAndParseFile(string Path)
        {
            if (!string.IsNullOrEmpty(Path))
            {
                IEnumerable<ChessPlayer> list = File.ReadAllLines(Path)
                    .Skip(1)
                    .Select(ChessPlayer.ParseFileChessPlayer)
                    //.Where(player => player.BirthYear > 1980)
                    .OrderBy(player => player.Ratings);
                    //.Take(10);
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
    }
}

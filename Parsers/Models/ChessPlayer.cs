using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsers.Models
{
    internal class ChessPlayer
    {
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Ratings { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full name = {FirstName + " " + LastName}, Ratings = {Ratings}, born in = {BirthYear}, Country = {Country}, id = {Id}";
        }

        public static ChessPlayer ParseFileChessPlayer(string text)
        {
            string[] parts = text.Replace('"'.ToString(), String.Empty).Split(";");
            return new ChessPlayer() 
            { 
                Id = int.Parse(parts[0]), 
                FirstName = parts[1], //.Split(',')[0].Trim(), 
                LastName = parts[2], //.Split(',')[1].Trim(), 
                Country = parts[4],
                Ratings = int.Parse(parts[5]),
                BirthYear = int.Parse(parts[7])
            };
        }
    }
}

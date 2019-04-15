using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class Users
    {
        public string PlayerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string GamesPlayed { get; set; }
        public string GamesWon { get; set; }
        public string Status { get; set; }


        public Users(string playerId, string name, string email, string username, string gamesPlayed, string gamesWon,string status)
        {
            PlayerId = playerId;
            Name = name;
            Email = email;
            Username = username;
            GamesPlayed = gamesPlayed;
            GamesWon = gamesWon;
            Status = status;



        }

        public Users()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using TicTacToe.Model;


namespace TicTacToe
{
    public class GlobalItems
    {
        public static List<Users> OnlineUsers = new List<Users>();
        public static int TotalPlayersOnline = 0;
        public static List<GameRequests> Requests = new List<GameRequests>();

        public static List<LiveMatch> OngoingMatches=new List<LiveMatch>(); 


    }
}
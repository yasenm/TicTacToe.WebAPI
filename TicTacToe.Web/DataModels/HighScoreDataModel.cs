namespace TicTacToe.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using TicTacToe.Models;

    public class HighScoreDataModel
    {
        public static Expression<Func<User, HighScoreDataModel>> FromUsers
        {
            get
            {
                return u => new HighScoreDataModel
                {
                    UserId = u.Id,
                    Username = u.UserName,
                    GamesWon = u.GamesWon,
                    DrawGames = u.DrawGames,
                    GamesLost = u.GamesLost,
                    Score = u.Score,
                };
            }
        }

        public string UserId { get; set; }

        public string Username { get; set; }

        public int GamesWon { get; set; }

        public int DrawGames { get; set; }

        public int GamesLost { get; set; }

        public int Score { get; set; }
    }
}
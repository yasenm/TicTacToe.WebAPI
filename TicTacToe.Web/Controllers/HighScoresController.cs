namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using TicTacToe.Data;
    using TicTacToe.GameLogic;
    using TicTacToe.Models;
    using TicTacToe.Web.DataModels;
    using TicTacToe.Web.Infrastructure;

    public class HighScoresController : BaseApiController
    {
        private const int MAX_HIGH_RESULTS = 10;
        private IGameResultValidator resultValidator;
        private IUserIdProvider userIdProvider;

        public HighScoresController(
            ITicTacToeData data,
            IGameResultValidator resultValidator,
            IUserIdProvider userIdProvider)
            : base(data)
        {
            this.resultValidator = resultValidator;
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        public IHttpActionResult GetScores()
        {
            return GetScores(0);
        }

        [HttpGet]
        public IHttpActionResult GetScores(int page)
        {
            var result = this.GetHighScores(page);
            return Ok(result);
        }

        private IQueryable<HighScoreDataModel> GetHighScores(int page)
        {
            var result = this.data.Users.All()
                             .OrderByDescending(u => u.Score)
                             .Skip(page * MAX_HIGH_RESULTS)
                             .Take(MAX_HIGH_RESULTS)
                             .Select(HighScoreDataModel.FromUsers);

            return result;
        }
    }
}
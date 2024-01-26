using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightRaffle.APIHelpers.Web.PollHome
{
    public partial class PollHome
    {
        public static void AssertPollVoteResponse(PollResponse response)
        {
            

            var result = (int)(response.Travel + response.Home + response.Share);
            Assert.That(Math.Abs(CalculatePercentage() - result), Is.LessThanOrEqualTo(0), $"Error: Voted sum is {result}");
        }

        private static int CalculatePercentage()
        {
            var allVotes = AppDbHelper.Votes.GetAllVotes();
            var homeVotes = allVotes.Where(votes => votes.Value == "home").Select(votes => votes).ToList();
            var travelVotes = allVotes.Where(votes => votes.Value == "travel").Select(votes => votes).ToList();
            var shareVotes = allVotes.Where(votes => votes.Value == "share").Select(votes => votes).ToList();

            var SumEqual100 = ((int)Math.Round(((double)homeVotes.Count / allVotes.Count) * 100) +
                      (int)Math.Round(((double)travelVotes.Count / allVotes.Count) * 100) +
                      (int)Math.Round(((double)shareVotes.Count / allVotes.Count) * 100));

            bool isSumEqual100 = SumEqual100 == 100;

            return isSumEqual100 ? 100 : throw new Exception($"Sum is {SumEqual100}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    public class Customer
    {
        public int BureauScore { get; }

        public int MissedPaymentCount { get; }

        public int CompletedPaymentCount { get; }

        public int AgeInYears { get; }

        public Customer(int bureauScore, int missedPaymentCount,
            int completedPaymentCount, int ageInYears)
        {
            BureauScore = bureauScore;
            MissedPaymentCount = missedPaymentCount;
            CompletedPaymentCount = completedPaymentCount;
            AgeInYears = ageInYears;
        }
    }
}

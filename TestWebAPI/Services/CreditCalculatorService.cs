using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Interfaces;
using TestWebAPI.Models;

namespace TestWebAPI.Services
{
    public class CreditCalculatorService : ICreditCalculator
    {
        public decimal CalculateCredit(Customer customer)
        {
            decimal Credit = 0;
            int points = 0;
            
            if (customer == null) return Credit;

            //point calculation for credit score
            if (customer.BureauScore <= 450)
                return Credit; // this could be considered a special case where user is will get an error
            else if (customer.BureauScore <= 700)
                points += 1;
            else if (customer.BureauScore <= 850)
                points += 2;
            else if (customer.BureauScore <= 1000)
                points += 3;
            else
            {
                points = 0;
                //log warning
            }

            //point calculation for missed payments
            if (customer.MissedPaymentCount == 0)
                points += 0;
            else if (customer.MissedPaymentCount == 1)
                points += -1;
            else if (customer.MissedPaymentCount == 2)
                points += -3;
            else if (customer.MissedPaymentCount >= 3)
                points += -6;
            else
            {
                points += 0;
                //log warning
            }

            //point calculation for completed payments
            if (customer.CompletedPaymentCount == 0)
                points += 0;
            else if (customer.CompletedPaymentCount == 1)
                points += 2;
            else if (customer.CompletedPaymentCount == 2)
                points += 3;
            else if (customer.CompletedPaymentCount >= 3)
                points += 4;
            else
            {
                points += 0;
                //log warning
            }

            //point calculation for age
            if (customer.AgeInYears >= 18)
            {
                if (customer.AgeInYears <= 25 && points >3)
                    points = 3;
                else if (customer.AgeInYears <= 35 && points > 4)
                    points = 4;
                else if (customer.AgeInYears <= 50 && points > 5)
                    points = 5;
                else if (customer.AgeInYears >= 51 && points > 6)
                    points = 6;
            }
            else
            {
                points = 0;
                //log warning
            }
            //avialable credit calculation
            if (points <= 0)
                Credit = 0;
            else if (points == 1)
                Credit = 100;
            else if (points == 2)
                Credit = 200;
            else if (points == 3)
                Credit = 300;
            else if (points == 4)
                Credit = 400;
            else if (points == 5)
                Credit = 500;
            else if (points >= 6)
                Credit = 600;

            return Credit;
        }
    }
}

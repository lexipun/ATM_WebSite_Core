using ATM_WebSite_Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM_WebSite_Core.Controllers
{
    public class AutorizationAndRegistration : ControllerBase
    {
        public void Registration(User user, string password)
        {
            ATMContext db;
            Card newCard;
            Card lastRecordOfCard;
            int indexOfCard;
            Transaction newTransaction;

            //validation
            if (user == null
                || string.IsNullOrEmpty(user.Name)
                || string.IsNullOrEmpty(user.SurName))
            {

                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                return;
            }

            db = new ATMContext();
            newCard = new Card();

            db.Users.Add(user);
            lastRecordOfCard = db.Cards.LastOrDefault() ?? new Card();

            if (string.IsNullOrEmpty(lastRecordOfCard.NumberOfCard))
            {
                lastRecordOfCard.NumberOfCard = "4441414100001000";
            }

            indexOfCard = lastRecordOfCard.NumberOfCard.Length - 1;

            while (true)
            {
                if (lastRecordOfCard.NumberOfCard[indexOfCard] == '9')
                {
                    --indexOfCard;
                    continue;
                }

                break;
            }

            newCard.NumberOfCard = string.Concat(
                    lastRecordOfCard.NumberOfCard.Substring(0, indexOfCard)
                    , (char)((int)lastRecordOfCard.NumberOfCard[indexOfCard] + 1)
                    , new string('0', lastRecordOfCard.NumberOfCard.Length - indexOfCard - 1));

            user.Cards = new List<Card>() { newCard };

            newCard.Balance = 0;
            newCard.PinCode = password;

            newTransaction = new Transaction() { Time = DateTime.Now, Name = "Create card", CountMoney = 0 };

            newCard.Transactions = new List<Transaction>() { newTransaction };

            db.Cards.Add(newCard);
            db.Transactions.Add(newTransaction);

            db.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class Wallet
    {
        private int amount;
        private int depositedAmount;

        public int DepositedAmount
        {
            get
            {
                return this.depositedAmount;
            }
            set
            {
                this.depositedAmount = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public Wallet(int amount)
        {
            this.amount = amount;
        }

        public string ShowMoney()
        {
            return "Your Wallet Balance: " + this.amount + " Kr.";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="money"></param>
        /// Deposits money from wallet
        /// <returns></returns>
        public string DepositMoney(int money)
        {
            if (money > this.amount)
            {
                return "Not enough money, you only have " + this.amount + " in your wallet";
            }
            else
            {
                this.depositedAmount = this.depositedAmount + money;
                this.amount = this.amount - money;
                return money + " has been deposited";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="money"></param>
        /// removes deposited money and returns the rest to user
        /// <returns></returns>
        public string WithdrawMoney(int money)
        {
            if (money > depositedAmount)
            {
                return "Not enough money";
            }
            else
            {
                int tempMoney = this.depositedAmount - money;
                this.depositedAmount = 0;
                this.amount = this.amount + tempMoney;
                return "Item has been bought " + tempMoney + " has been returned to your wallet";
            }
        }
    }
}

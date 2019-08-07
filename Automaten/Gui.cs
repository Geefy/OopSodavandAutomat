using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class Gui
    {
        VendingMachine vendingMachine = new VendingMachine(15, 12);
        Wallet bigMoney = new Wallet(500);

        /// <summary>
        /// array of choices for gui        
        /// </summary>
        private string[] mainMenu = new string[]
        {
            "Show Your Wallet",
            "Show Items",
            "Buy Items",
            "Refill Items",
            "Deposit Money",
            "Show Deposited Money"
        };

        private string CurrentMoney()
        {
            return "You have " + Convert.ToString(bigMoney.DepositedAmount) + " in the machine";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// Gets user input, used to ask user a question
        /// <returns></returns>
        private string GetUserInput(string question)
        {

            Console.WriteLine(question);
            Console.WriteLine("\nChoice: ");
            string answ = Console.ReadLine();

            return answ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// Gets user input, used to ask an array of questions
        /// <returns></returns>
        private string GetUserInput(string[] question)
        {
            for (int i = 0; i < question.Length; i++)
            {
                Console.WriteLine(i.ToString() + ". " + question[i]);
            }
            Console.WriteLine("\nChoice: ");
            string answ = Console.ReadLine();

            return answ;
        }

        /// <summary>
        /// Main method to control everything
        /// </summary>
        public void Start()
        {
            int answ = 0;
            try
            {
                answ = Int32.Parse(this.GetUserInput(mainMenu));
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                this.Start();
            }
            try
            {
                switch (answ)
                {

                    case 0:
                        Console.Clear();
                        Console.WriteLine(bigMoney.ShowMoney());
                        this.Start();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine(this.vendingMachine.ToString());
                        this.Start();
                        break;
                    case 2:
                        Console.Clear();
                            Console.WriteLine(this.vendingMachine.BuyItem());
                            Console.WriteLine(this.bigMoney.WithdrawMoney(this.vendingMachine.ItemBought(Convert.ToInt32(GetUserInput("What would you like? ")))));
                            this.Start();
                        break;
                    case 3:
                        Console.Clear();
                        this.vendingMachine.Refill();
                        this.Start();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine(this.bigMoney.DepositMoney(Convert.ToInt32(GetUserInput("How much would you like to deposit? "))));
                        this.Start();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine(this.CurrentMoney());
                        this.Start();
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                this.Start();
            }
            
        }
    }
}

// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Drink> drinks = new List<Drink>();
            //Drink drink1 = new Drink() {  namespace = "紅茶" , Size = "大杯" , Price = 50};
            drinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 50 });
            drinks.Add(new Drink() { Name = "紅茶", Size = "小杯", Price = 30 });
            drinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 50 });
            drinks.Add(new Drink() { Name = "綠茶", Size = "小杯", Price = 30 });
            drinks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 60 });
            drinks.Add(new Drink() { Name = "咖啡", Size = "小杯", Price = 40 });


            //for (int i=0; i<drinks.Count; i++)
            //{
            //   Console.WriteLine($"{drink[i].Name} {drink[i].Size} {drink[i].Price}");
            //}

            private static void OrderDrink (List<Drink> myDrinks, List<OrderItem> myDrink)
            {
                Console.WriteLine();
                Console.WriteLine("請開始訂購飲料,按下x鍵離開");
                string s;
                int index, guantity, subtotal;
                while (true)
                {
                    Console.WriteLine("請輸入品名? ");
                    s = Console.ReadLine();
                    if (s == "x")
                    {
                        Console.WriteLine("謝謝惠顧,歡迎下次再來。");
                        break;
                    }
                    else index = Convert.ToInt32(s);
                    Drink drink = myDrinks[index];

                    Console.WriteLine("請輸入數量? ");
                    s = Console.ReadLine();

                    if (s == "x")
                    {
                        Console.WriteLine("謝謝惠顧,歡迎下次再來。");
                        break;
                    }
                    else guantity = Convert.ToInt32(s);
                    subtotal = drink.Price * guantity;




                }
            }

            private static void DisplayDrinkMenu(List<Drink> myDrinks) 
            { 
                Console.WriteLine("飲料清單\n") ;
                Console.WriteLine(String.Format("{0,-5}{1,-5}{2,5}{3,7}", "標號", "品名", "大小杯", "價格"));
                int i=0 ;
                foreach (Drink drink in myDrinks)
                {
                    Console.WriteLine($"{i,-7}{drink.Name,-8} {drink.Size,-5} {drink.Price,5:C1}");
                    i++;
                }
            }
           


            Console.WriteLine($"品名    大小杯    價格");
            foreach (Drink drink in drinks)
            {
                Console.WriteLine($"{drink.Name,-5} {drink.Size,-3}     {drink.Price,-5:C1}");
            }
        }
    }
}
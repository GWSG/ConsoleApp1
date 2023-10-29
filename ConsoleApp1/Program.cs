using System; 
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program// 定義一個內部類別Program
    {
    
        private static void Main(string[] args)// 主要進入點
        {
            List<Drink> drinks = new List<Drink>(); // 創建一個List來儲存Drink對象
            List<OrderItem> orders = new List<OrderItem>();// 創建一個List來儲存OrderItem對象

            //新增飲料品項
            // 調用AddNewDrink方法，將新的飲料項目添加到'drinks' List中
            AddNewDrink(drinks);

            //列出所有飲料品項
            // 調用DisplayDrinkMenu方法，列出'drinks' List中的所有飲料項目
            DisplayDrinkMenu(drinks);


            //訂購飲料
            // 調用OrderDrink方法，處理飲料訂購過程，並將訂購的飲料添加到'orders' List中
            OrderDrink(drinks, orders);

            //計算售價
            // 調用CalculateAmount方法，計算'orders' List中所有訂購項目的總價格
            CalculateAmount(orders);

        }

        // 定義一個用於計算訂單總價的方法
        private static void CalculateAmount(List<OrderItem> myOrders)
        {
            double total = 0.0;// 初始化總價為0
            string message = "";// 初始化優惠信息為空字符串
            double sellPrice = 0.0;// 初始化實際售價為0

            Console.WriteLine("-------------------------------------------------------");

            // 使用 foreach 迴圈遍歷 myOrders 列表中的每一個 OrderItem 物件
            // 並將每一個 OrderItem 的 Subtotal（小計）加到 total 變數上
            foreach (OrderItem orderItem in myOrders) total += orderItem.Subtotal;

            // 根據總價決定打折信息
            if (total >= 500)
            {
                message = "訂購滿500元以上者8折";
                sellPrice = total * 0.8;
            }
            else if (total >= 300)
            {
                message = "訂購滿300元以上者85折";
                sellPrice = total * 0.85;
            }
            else if (total >= 200)
            {
                message = "訂購滿200元以上者9折";
                sellPrice = total * 0.9;
            }
            else
            {
                message = "訂購未滿200元不打折";
                sellPrice = total;
            }

            // 輸出最終計價信息
            Console.WriteLine($"您總共訂購{myOrders.Count}項飲料，總計{total}元。{message}，總計需付款{sellPrice}元。");
            Console.WriteLine("-------------------------------------------------------");
        }

        private static void OrderDrink(List<Drink> myDrinks, List<OrderItem> myOrders)
        {
            Console.WriteLine();// 輸出一個空行，作為視覺分隔
            Console.WriteLine("請開始訂購飲料，按下x鍵，並按下Enter鍵結束訂單。"); // 提示用戶開始訂購
            string s;
            int index, quantity, subtotal;
            while (true)// 進入無窮迴圈，除非用戶選擇退出
            {
                
                Console.Write("請輸入品名編號？ ");// 提示用戶輸入飲料的編號
                s = Console.ReadLine();// 讀取用戶輸入

                if (s == "x")// 如果用戶輸入的是"x"，則退出迴圈
                {
                 
                    Console.WriteLine("謝謝惠顧，歡迎下次再來。");
                    break;
                }
                
                else index = Convert.ToInt32(s);// 否則，將用戶輸入轉換為整數

                if (index <= -1 || index >= 6)// 檢查用戶輸入的編號是否在有效範圍內
                {
                        Console.WriteLine("沒有這個編號，請輸入目前已出現的編號");
                        continue; // 如果無效，則返回迴圈開始，重新提示用戶
                }
                
                Drink drink = myDrinks[index];// 從myDrinks列表中根據索引獲取相應的飲料對象

                Console.Write("請輸入數量？ ");// 提示用戶輸入數量
                s = Console.ReadLine();// 讀取用戶輸入
                if (s == "x") // 如果用戶輸入的是"x"，則退出迴圈
                {

                    Console.WriteLine("謝謝惠顧，歡迎下次再來。");
                    break;
                }
                else quantity = Convert.ToInt32(s); // 否則，將用戶輸入轉換為整數



                subtotal = drink.Price * quantity;// 計算小計：飲料價格 * 數量

                // 使用 Console.WriteLine 函數和字串插值（String Interpolation）顯示客戶的訂購資訊
                // {drink.Name} - 顯示飲料的名稱
                // {drink.Size} - 顯示飲料的大小（例如，大杯、中杯）
                // {quantity} - 顯示客戶訂購的數量（多少杯）
                // {drink.Price} - 顯示每一杯飲料的價格
                // {subtotal} - 顯示這個項目的小計（價格 x 數量）
                Console.WriteLine($"您訂購{drink.Name}{drink.Size}{quantity}杯，每杯{drink.Price}元，小計{subtotal}元");

                // 將訂單項目添加到myOrders列表中
                // Index - 設定為選擇的飲料編號（index）
                // Quantity - 設定為客戶選擇的數量（quantity）
                // Subtotal - 設定為這項訂單的小計（subtotal）
                myOrders.Add(new OrderItem() { Index = index, Quantity = quantity, Subtotal = subtotal });
            }
        }

        private static void DisplayDrinkMenu(List<Drink> myDrinks)
        {
            //列出所有飲料品項
            //for (int i=0; i< drinks.Count; i++)
            //{
            //    Console.WriteLine($"{drinks[i].Name} {drinks[i].Size} {drinks[i].Price}");
            //}

            // 輸出一行文字來表示這是飲料清單，用於用戶識別
            Console.WriteLine("飲料清單\n");


            // 使用 String.Format 來格式化並輸出表頭。
            // 我們在這裡指定了每個字段的寬度，以便它們對齊。
            Console.WriteLine(String.Format("{0,-5}{1,-5}{2,5}{3,7}","編號","品名","大中","價格"));

            // 初始化一個整數 i 作為飲料項目的編號。從 0 開始。
            int i = 0;

            // 使用 foreach 迴圈遍歷 myDrinks 清單中的每一個 Drink 對象。
            foreach (Drink drink in myDrinks)
            {

                // 使用內插字符串來格式化每一行輸出。
                // 這裡同樣指定了字段寬度。
                Console.WriteLine($"{i,-7}{drink.Name,-8}{drink.Size,-3}{drink.Price,9:C1}");
                i++;
            }
        }

        private static void AddNewDrink(List<Drink> myDrinks)
        {
            //新增飲料品項
            //Drink drink1 = new Drink() { Name = "紅茶", Size = "大杯", Price = 30 };
            //drinks.Add(drink1);
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "大杯", Price = 30 });
            myDrinks.Add(new Drink() { Name = "紅茶", Size = "中杯", Price = 20 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "大杯", Price = 25 });
            myDrinks.Add(new Drink() { Name = "綠茶", Size = "中杯", Price = 20 });
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "大杯", Price = 60 });
            myDrinks.Add(new Drink() { Name = "咖啡", Size = "中杯", Price = 50 });
        }
    }
}

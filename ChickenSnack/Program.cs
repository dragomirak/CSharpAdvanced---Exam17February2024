namespace ChickenSnack;

public class Program
{
    static void Main()
    {
        int[] moneyArray = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] foodArray = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Stack<int> money = new Stack<int>(moneyArray);
        Queue<int> food = new Queue<int>(foodArray);
        int foodCount = 0;

        while (money.Count > 0 && food.Count > 0)
        {
            int currentMoney = money.Peek();
            int currentFood = food.Peek();

            if (currentMoney == currentFood)
            {
                money.Pop();
                food.Dequeue();
                foodCount++;
            }
            else if (currentMoney > currentFood)
            {
                int change = currentMoney - currentFood;
                foodCount++;
                food.Dequeue();
                if (money.Count > 2)
                {
                    money.Pop();
                    money.Push(money.Pop() + change);
                }
                else
                {
                    money.Pop();
                }
                
            }
            else if (currentMoney < currentFood)
            {
                money.Pop();
                food.Dequeue();
            }
        }

        if (foodCount == 0)
        {
            Console.WriteLine("Henry remained hungry. He will try next weekend again.");
        }
        else if (foodCount == 1)
        {
            Console.WriteLine($"Henry ate: {foodCount} food.");
        }
        else if (foodCount > 1 && foodCount < 4)
        {
            Console.WriteLine($"Henry ate: {foodCount} foods.");
        }
        else
        {
            Console.WriteLine($"Gluttony of the day! Henry ate {foodCount} foods.");
        }
    }
}
using System;
using System.Threading.Tasks;

class AsyncAwait
{
    static async Task Main(string[] args)
    {
        await CallMethod();
        Console.ReadKey();
    }

    public static async Task CallMethod()
    {
        await Method2Async();
        var count = await Method1();
        Method3(count);
    }

    public static async Task<int> Method1()
    {
        int count = 0;
        await Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                i.
                Console.WriteLine(" Method 1");
                count += 1;
            }
        });
        return count;
    }

    public static async Task Method2Async()
    {
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine(" Method 2");
            await Task.Delay(100); // Simulate an asynchronous operation
        }
    }

    public static void Method3(int count)
    {
        Console.WriteLine("Total count is " + count);
        Console.ReadLine();
    }
}

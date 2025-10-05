using System;

namespace ConsoleApplication42
{
    public delegate void MyEventHandler(string message);

    class Publisher
    {
        public event MyEventHandler Active;

        public void DoActive(int number)
        {
            if (number % 10 == 0)
                Active("Active!" + number);
            else
                Console.WriteLine(number);
        }
    }

    class Subscriber
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            publisher.Active += new MyEventHandler(MyHandler);

            for (int i = 1; i < 50; i++)
                publisher.DoActive(i);

            Console.ReadLine();
        }
    }
}
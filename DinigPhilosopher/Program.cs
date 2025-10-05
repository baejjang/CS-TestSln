using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace DinigPhilosopher
{
    // 식사하는 철학자
    // 5명의 철학자(쓰레드)가 5개의 공유 자원(포크)중에 
    // 2개의 공유 자원을 가져야만 식사를 할 수 있는 것

    // Table 클래스가 있고, 5개의 포크(뮤텍스)
    // 철학자를 뜻하는 Philosopher 클래스
    // 테이블 클래스를 이용하여 포크를 얻어서 식사도 하고, 생각을 하기도 한다
    //  각각의 식사 시간과 생각하는 시간을 불규칙적으로 하기 위해 Random 클래스를 사용하여
    // 1부터 100 사이의 임의의 시간을 이용하도록 했다.

    class Table
      {
        // 생성하는 쓰레드에서 뮤텍스의 소유권을 갖도록 할 것이 아니므로 false를 사용하여 생성한다.
        static Mutex gM1 = new Mutex(false);
        static Mutex gM2 = new Mutex(false);
        static Mutex gM3 = new Mutex(false);
        static Mutex gM4 = new Mutex(false);
        static Mutex gM5 = new Mutex(false);

        // gFork는 5개의 뮤텍스에 대한 컨테이너로 사용
        // 식사하는 철학자 문제에서 포크
        static Mutex[] gFork = new Mutex[5];

        // bContinue는 식사하는 철학자 프로그램을 계속 실행할지를 결정하기 위해 사용
        static bool bContinue;

        // 생성자에서는 bContinue = true로 설정하고, 각각의 포크를 컨테이너 gFork에 넣어둔다.
        public Table()
        {
            bContinue = true;

            gFork[0] = gM1;
            gFork[1] = gM2;
            gFork[2] = gM3;
            gFork[3] = gM4;
            gFork[4] = gM5;
        }

        public bool Continue
        {
          get
          {
            return bContinue;
          }

          set
          {
            bContinue = value;
          }
        }

        // 식사하는 철학자 프로그램을 끝내기 위해 호출
        public void Stop()
        {
          bContinue = false;
        }

        public void GetForks(int threadID)
        {
          Mutex[] IFork = new Mutex[2];
          IFork[0] = gFork[threadID];
          IFork[1] = gFork[(threadID + 1) % 5];

          WaitHandle.WaitAll(IFork);
        }

        public void DropForks(int threadID)
        {
          gFork[threadID].ReleaseMutex();
          gFork[(threadID + 1) % 5].ReleaseMutex();

        }
      }

    class Philosopher
    {
        Random rand = new Random(DateTime.Now.Millisecond);

        private int ThreadID;
        private Table aTable;

        public Philosopher(int threadId, Table table)
        {
          this.ThreadID = threadId;
          this.aTable = table;
        }

        private void Think()
        {
          Console.WriteLine(Thread.CurrentThread.Name + " Thinking.");
          Thread.Sleep(rand.Next(1, 200));
        }

        private void Eat()
        {
          Console.WriteLine(Thread.CurrentThread.Name + " Eating.");
          Thread.Sleep(rand.Next(1, 200));
        }

        public void Philosophize()
        {
          while (aTable.Continue)
          {
            aTable.GetForks(ThreadID);
            //Eat
            this.Eat();
            aTable.DropForks(ThreadID);
            //Think
            this.Think();
          }
        }
    }

    class AppMain
    {
        static void Main(string[] args)
        {
            Table table = new Table();
            Philosopher[] IPhil = new Philosopher[5];
            Thread[] IThread = new Thread[5];

            for (int loopctr = 0; loopctr < 5; loopctr++)
            {
            IPhil[loopctr] = new Philosopher(loopctr, table);
            IThread[loopctr] = new Thread(new ThreadStart(IPhil[loopctr].Philosophize) );
            IThread[loopctr].Name = "Philosopher " + loopctr;
            IThread[loopctr].Start();
            }

            Thread.Sleep(5000);
            table.Stop();

            Thread.Sleep(1000);
            Console.WriteLine("Primary Thread ended.");
            Console.WriteLine("Press any key to return.");
            Console.Read();
        }
    }
}

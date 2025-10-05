using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ExamThreadTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().TimeTick();

            //// 타이머 생성 및 시작
            //Timer timer = new System.Timers.Timer();
            //timer.Interval =  1000; // 1 초
            ////timer.Interval = 60 * 1000; // 1 분
            ////timer.Interval = 60 * 60 * 1000; // 1 시간
            //timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            //timer.Start();

            //Console.WriteLine("Press Enter to exit");
            //Console.ReadLine();
        }

        //static void timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        //}


        private void TimeTick()
        {
            // 타이머 생성 및 시작
            Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // 1 초
            //timer.Interval = 60 * 1000; // 1 분
            //timer.Interval = 60 * 60 * 1000; // 1 시간
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed1);
            timer.Start();

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        private void timer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
    }
}

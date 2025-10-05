using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExamThreadUnsafe
{
    class Program
    {
        private int counter = 1000;

        public void Run()
        {
            // 10개의 쓰레드가 동일 메서드 실행
            for (int i = 0; i < 10; i++)
            {
                new Thread(UnsafeCalc).Start();
            }
        }

        // Thread-Safe하지 않은 메서드 
        private void UnsafeCalc()
        {
            // 객체 필드를 모든 쓰레드가 
            // 자유롭게 변경
            counter++;

            // 가정 : 다른 복잡한 일을 한다
            for (int i = 0; i < counter; i++)
                for (int j = 0; j < counter; j++) ;

            // 필드값 읽기
            Console.WriteLine(counter);
        }

        static void Main(string[] args)
        {
            new Program().Run();
            Console.ReadLine();
        }
    }
}

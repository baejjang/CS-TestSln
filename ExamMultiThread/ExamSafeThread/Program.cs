using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/*쓰레드 동기화 - Thread-Safe 
 * 한 메서드를 복수의 쓰레드가 동시에 실행하고 
 * 그 메서드에서 클래스 객체의 필드들을 읽거나 쓸 때, 
 * 복수의 쓰레드가 동시에 필드값들은 변경할 수 있게 된다. 
 * 객체의 필드값은 모든 쓰레드가 자유롭게 엑세스할 수 있기 때문에, 
 * 메서드 실행 결과가 잘못될 가능성이 크다. 
 * 이렇게 쓰레드들이 공유된 자원(예를 들어 객체 필드)을 
 * 동시에 접근하는 것을 막고, 각 쓰레드들이 순차적으로 혹은 
 * 제한적으로 접근하도록 하는 것이 쓰레드 동기화 (Thread Synchronization)이다. 
 * 또한 이렇게 쓰레드 동기화를 구현한 메서드나 클래스를 Thread-Safe하다고 한다. 
 * .NET의 많은 클래스들은 Thread-Safe하지 않는데, 
 * 이는 Thread-Safe를 구현하려면 Locking 오버헤드와 보다 많은 코딩을 요구하는데, 
 * 실제 실무에서 이러한 Thread-Safe를 필요로 하지 않는 경우가 더 많기 때문이다.
 */

/*쓰레드 동기화를 위한 .NET 클래스들 
 * 쓰레드 동기화를 위하여 .NET에는 (Version에 따라 다르지만) 많은 클래스와
 * 메서드들이 있다. 이 중 중요한 것들로서 Monitor, Mutex, Semaphore, 
 * SpinLock, ReaderWriterLock, AutoResetEvent, ManualResetEvent 등이 있으며, 
 * C# 키워드로는 lock, await 등이 있다. 
 * 쓰레드 동기화를 위해 자주 사용되는 방식으로서,
 * (1) Locking으로 공유 리소스에 대한 접근을 제한하는 방식으로
 * C# lock, Monitor, Mutex, Semaphore, SpinLock, ReaderWriterLock 등이 사용되며, 
 * (2) 타 쓰레드에 신호(Signal)을 보내 쓰레드 흐름을 제어하는 방식으로
 * AutoResetEvent, ManualResetEvent, CountdownEvent 등이 있다.
 */
namespace ExamThreadsafe
{
    public class Test
    {
        private object objLock = new object();
        private static Mutex mutex = new Mutex();

        // 동시 엔트리수 지정가능
        private static Semaphore oSemaphore = new Semaphore(2, 4);

        public void Calculation()
        {
            // RaceCondition
            #region RaceCondition

            //for (int i = 0; i < 10; i++)
            //{
            //    Thread.Sleep(new Random().Next(5));
            //    Console.Write("{0} : {1}, \r\n", Thread.CurrentThread.Name, i);
            //}
            //Console.WriteLine();

            #endregion // RaceCondition

            // Synchronization

            // lock 사용
            #region lock 사용

            //lock (objLock)
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(new Random().Next(5));
            //        Console.Write("{0} : {1}, \r\n", Thread.CurrentThread.Name, i);
            //    }
            //    Console.WriteLine();
            //}

            #endregion // lock 사용

            // Monitor 사용
            #region Monitor 사용

            //Monitor.Enter(objLock);
            //try
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(new Random().Next(5));
            //        Console.Write("{0} : {1}, \r\n", Thread.CurrentThread.Name, i);
            //    }
            //}
            //catch { }
            //finally
            //{
            //    Monitor.Exit(objLock);
            //}
            //Console.WriteLine();

            #endregion // Monitor 사용

            // Mutex 사용
            #region Mutex 사용
            
            //try
            //{
            //    // Wait until it is safe to enter.
            //    mutex.WaitOne();

            //    for (int i = 0; i < 10; i++)
            //    {
            //        Thread.Sleep(new Random().Next(5));
            //        Console.Write("{0} : {1}, \r\n", Thread.CurrentThread.Name, i);
            //    }
            //}
            //catch { }
            //finally
            //{
            //    mutex.ReleaseMutex();
            //}
            //Console.WriteLine();

            #endregion // Mutex 사용

            // Semaphore 사용
            #region Semaphore 사용

            Console.WriteLine(Thread.CurrentThread.Name + "-->>Wants to Get Enter");
            try
            {
                oSemaphore.WaitOne();
                Console.WriteLine(Thread.CurrentThread.Name + " is in!");

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(5));
                    Console.Write("[ {0} ] Wirte Value = {1}, \r\n", Thread.CurrentThread.Name, i);
                }

                Console.WriteLine(Thread.CurrentThread.Name + "<<-- is Evacuating.");
            }
            catch { }
            finally
            {
                oSemaphore.Release();
            }
            Console.WriteLine();

            #endregion // Semaphore 사용
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            Thread[] tr = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                tr[i] = new Thread(new ThreadStart(t.Calculation));
                tr[i].Name = String.Format("Working Thread: {0}", i);
            }

            //Start each thread
            foreach (Thread x in tr)
            {
                x.Start();
            }
            Console.ReadKey();
        }
    }

    // 나쁜예
    # region 나쁜예
    //class Program
    //{
    //    private int counter = 1000;

    //    // lock문에 사용될 객체
    //    private object lockObject = new object();

    //    public void Run()
    //    {
    //        // 10개의 쓰레드가 동일 메서드 실행
    //        for (int i = 0; i < 10; i++)
    //        {
    //            new Thread(safeCalc).Start();
    //        }
    //    }

    //    /// Thread-Safe 메서드 
    //    private void safeCalc()
    //    {
    //        // 한번에 한 쓰레드만 lock블럭 실행
    //        lock (lockObject)
    //        {
    //            counter++;

    //            // 가정 : 다른 복잡한 일을 한다
    //            for (int i = 0; i < counter; i++)
    //                for (int j = 0; j < counter; j++) ;

    //            // 필드값 읽기
    //            Console.WriteLine(counter);
    //        }
    //    }

    //    static void Main(string[] args)
    //    {
    //        new Program().Run();
    //        Console.ReadLine();
    //    }
    //}
    # endregion
    
}

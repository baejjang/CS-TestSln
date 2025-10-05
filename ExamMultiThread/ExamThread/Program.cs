using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    public class Worker
    {
        // This method will be called when the thread is started.
        public void DoWork()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("worker thread: DoWork Method working...");
            }
            Console.WriteLine("worker thread: terminating gracefully.");
            Console.ReadLine();
        }

        // parameter를 object 타입으로 받아들임
        public void NamedDoWork(object sThreadName)
        {
            while (!_shouldStop)
            {
                Console.WriteLine("worker thread: NamedDoWork Method working... started by " + sThreadName);
            }

            Console.WriteLine("worker thread: terminating gracefully. terminated by " + sThreadName);
            Console.ReadLine();
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }

        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;
    }

    public class WorkerThreadExample
    {
        static void Main()
        {
            // Create the thread object. This does not start the thread.
            Worker workerObject = new Worker();

            //////////////////////////////////////////////////////////////////////////////////////
            #region 스레드 생성 방법 1 : 컴파일러가 메소드 추론

            //// 컴파일러가 Run() 메서드의 함수 프로토타입으로부터
            //// ThreadStart Delegate객체를 추론하여 생성함
            //Thread workerThread = new Thread(workerObject.DoWork);
            //// Start the worker thread.
            //workerThread.Start();

            #endregion // 스레드 생성 방법 1 : 컴파일러가 메소드 추론

            //////////////////////////////////////////////////////////////////////////////////////
            #region 스레드 생성 방법 2 : 익명메서드 사용

            //// 익명메서드(Anonymous Method)를 사용하여
            //// 쓰레드 생성
            //Thread workerthread2 = new Thread(delegate()
            //    {
            //        workerObject.DoWork();
            //    });
            //workerthread2.Start();

            #endregion // 스레드 생성 방법 2 : 익명메서드 사용

            //////////////////////////////////////////////////////////////////////////////////////
            #region 스레드 생성 방법 3 : 람다식 사용

            //// 람다식 (Lambda Expression)을 사용하여
            //// 쓰레드 생성
            //Thread workerThread3 = new Thread(() => workerObject.DoWork());
            //workerThread3.Start();

            #endregion // 스레드 생성 방법 3 : 람다식 사용

            //////////////////////////////////////////////////////////////////////////////////////
            #region 스레드 생성 방법 4 : 람다식 사용 간략표현

            //// 간략한 표현
            //new Thread(() => workerObject.DoWork()).Start();

            #endregion 스레드 생성 방법 3 : 람다식 사용 간략표현

            //////////////////////////////////////////////////////////////////////////////////////
            #region Thread 클래스 파라미터 전달

            //// 컴파일러가 Run() 메서드의 함수 프로토타입으로부터
            //// ThreadStart Delegate객체를 추론하여 생성함
            //// ParameterizedThreadStart 파라미터 전달
            //// Start()의 파라미터로 radius 전달
            //Thread NamedworkerThread = new Thread(new ParameterizedThreadStart(workerObject.NamedDoWork));
            //NamedworkerThread.Name = "NamedworkerThread";
            //NamedworkerThread.Start(NamedworkerThread.Name);

            //// ThreadStart에서 파라미터 전달
            //Thread t3 = new Thread(() => workerObject.NamedDoWork("t3"));
            //t3.Start();

            #endregion // Thread 클래스 파라미터 전달

            //////////////////////////////////////////////////////////////////////////////////////
            #region 스레드풀 사용

            //ThreadPool.QueueUserWorkItem(workerObject.DoWork);
            ThreadPool.QueueUserWorkItem(workerObject.NamedDoWork, "ThreadPool1");
            ThreadPool.QueueUserWorkItem(workerObject.NamedDoWork, "ThreadPool2");
            ThreadPool.QueueUserWorkItem(workerObject.NamedDoWork, "ThreadPool3");

            //// 컴파일러가 Run() 메서드의 함수 프로토타입으로부터
            //// ThreadStart Delegate객체를 추론하여 생성함
            //// ParameterizedThreadStart 파라미터 전달
            //// Start()의 파라미터로 radius 전달
            //Thread NamedworkerThread = new Thread(new ParameterizedThreadStart(workerObject.NamedDoWork));
            //NamedworkerThread.Name = "NamedworkerThread";
            //NamedworkerThread.Start(NamedworkerThread.Name);

            //// ThreadStart에서 파라미터 전달
            //Thread t3 = new Thread(() => workerObject.NamedDoWork("t3"));
            //t3.Start();

            #endregion // 스레드풀 사용

            Console.WriteLine("main thread: Starting worker thread...");

            // Loop until worker thread activates.
//            while (!workerThread.IsAlive) ;

            // Put the main thread to sleep for 1 millisecond to
            // allow the worker thread to do some work:
            Thread.Sleep(1);

            // Request that the worker thread stop itself:
            workerObject.RequestStop();

            //// Main thread에서 실행
            //workerObject.DoWork();
            //workerObject.RequestStop();

            // Use the Join method to block the current thread 
            // until the object's thread terminates.
            //workerThread.Join();
            Console.WriteLine("main thread: Worker thread has terminated.");
            Console.ReadLine();
        }
    }

}

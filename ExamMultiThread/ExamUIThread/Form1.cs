using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

/*쓰레드 선호도 (Thread Affinity) 
 * .NET에서 UI Application을 만들기 위해 Windows Forms(윈폼)이나
 * WPF (Windows Presentation Foundation)을 사용한다. 
 * 이들 WinForm이나 WPF는 그 UI 컨트롤을 생성한 쓰레드만(UI 쓰레드)이 
 * 해당 UI 객체를 엑세스할 수 있다는 쓰레드 선호도(Thread Affinity) 규칙
 * 을 지키도록 설계되었다. 
 * 만약 개발자 이러한 기본 규칙을 따르지 않는다면, 
 * 에러가 발생하거나 예기치 못한 오동작을 할 수 있다. 
 * UI 컨트롤을 생성하고 이 컨트롤의 윈도우 핸들을 소유한 쓰레드를
 * UI Thread라 부르고, 이러한 UI 컨트롤들을 갖지 않는 쓰레드를
 * 작업쓰레드 (Worker Thread)라 부른다. 
 * 일반적으로 UI 프로그램은 하나의 UI Thread (주로 메인쓰레드)를 가지며, 
 * 여러 개의 작업 쓰레드를 갖는다. 
 * 하지만 필요한 경우 여러 개의 UI 쓰레드를 갖게 하는 것도 가능하다. 
 */

/*윈폼 UI Thread 
 * WinForm의 UI 컨트롤들은 Control 클래스로부터 파생된 클래스들이며, 
 * Control 클래스는 UI 컨트롤이 UI 쓰레드에서 돌고 있는지를 체크하는 
 * InvokeRequired 속성을 갖고 있으며, 
 * 만약 작업쓰레드에서 실행되고 있는 경우 
 * Control클래스의 Invoke()나 BeginInvoke() 메소드를 사용하여
 * UI 쓰레드로 작업 요청을 보낸다.
 */
namespace ExamUIThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 작업 쓰레드 시작
            Thread worker = new Thread(Run);
            worker.Start();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // UI 쓰레드에서 TextBox 갱신
            UpdateTextBox(string.Empty);
        }

        private void Run()
        {
            // Long DB query
            Thread.Sleep(1000);
            string dbData = "Query Result";

            // 작업쓰레드에서 TextBox 갱신
            UpdateTextBox(dbData);
        }

        private void UpdateTextBox(string data)
        {
            // 호출한 쓰레드가 작업쓰레드인가?
            if (textBox1.InvokeRequired)
            {
                // 작업쓰레드인 경우
                textBox1.BeginInvoke(new Action(() => textBox1.Text += data+"\r\n"));
            }
            else
            {
                // UI 쓰레드인 경우
                textBox1.Text = data;
            }
        }
    }
}

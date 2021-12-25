using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHandlerTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SomethingEvent EventCreator = new SomethingEvent();

                // 03. Event Subscribe
                EventCreator.eventSomthingHappend += EventCreator_eventSomthingHappend;
                EventCreator.RaiseEvent("이벤트 발생!!!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EventCreator_eventSomthingHappend(object sender, EventArgs e)
        {
            try
            {
                TestEventArgs evtArgs = e as TestEventArgs;
                MessageBox.Show(evtArgs.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    // 01. Event Arguments Class
    public class TestEventArgs : EventArgs
    {
        public string Message { get; set; }
        public List<Object> Data { get; set; }
    }

    // 02. Raise Event Class
    internal class SomethingEvent
    {
        public event EventHandler eventSomthingHappend;

        public void RaiseEvent(string Message )
        {
            try
            {
                if (eventSomthingHappend != null)
                {
                    TestEventArgs evtArgs = new TestEventArgs();
                    evtArgs.Message = Message;
                    evtArgs.Data = new List<object>();
                    evtArgs.Data.Add(1234);
                    evtArgs.Data.Add("abcdef");
                    evtArgs.Data.Add(new List<string>());
                    eventSomthingHappend(null, evtArgs);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}

using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MouseClick.Form1;

namespace MouseClick.plugins
{
    class TeamControlPlugin : ISubscribe
    {
        private bool Subscribed = false;

        private IKeyboardMouseEvents KMEvents;

        public void SubscribeHandler(bool subscribe, IKeyboardMouseEvents KMEvents)
        {
            try
            {
                if (subscribe)
                {
                    this.Subscribed = subscribe;
                    this.KMEvents = KMEvents;
                    this.KMEvents.KeyDown += KMEvents_KeyPress;
                }
                else
                {
                    this.KMEvents.KeyDown -= KMEvents_KeyPress;
                    this.KMEvents = null;
                }
            }
            catch { }
        }

        private void KMEvents_KeyPress(object sender, KeyEventArgs e)
        {
            Console.WriteLine($"KeyCode: {e.KeyCode}, KeyValue: {e.KeyValue}, KeyData: {e.KeyData}");
            if (e.KeyCode.ToString().Equals("Q"))
            {
                KeyboardSimulator.KeyPress(Keys.D6);
            } else if (e.KeyCode.ToString().Equals("W"))
            {
                KeyboardSimulator.KeyPress(Keys.D7);
            } else if (e.KeyCode.ToString().Equals("E"))
            {
                KeyboardSimulator.KeyPress(Keys.D8);
            } else if (e.KeyCode.ToString().Equals("R"))
            {
                KeyboardSimulator.KeyPress(Keys.D9);
            }
        }
    }
}

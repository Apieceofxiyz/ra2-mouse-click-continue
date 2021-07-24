using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MouseClick.Form1;

namespace MouseClick.plugins
{
    class TeamControlPlugin : ISubscribe
    {
        private string keyMappingFilePath = Path.Combine(Config.AppRoot, "plugins", "KeyMappings.txt");
        private Dictionary<string, int> keyMapping;

        private bool Subscribed = false;

        private IKeyboardMouseEvents KMEvents;

        public TeamControlPlugin()
        {
            string[] lines = File.ReadAllLines(keyMappingFilePath);
            this.keyMapping = new Dictionary<string, int>(lines.Length);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("//"))
                {
                    continue;
                }
                string[] oneMapping = line.Split('=');
                if (oneMapping.Length != 2) continue;
                string key = oneMapping[0];
                string value = oneMapping[1];
                keyMapping.Add(key, int.Parse(value));
            }
        }

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
            string key = e.KeyCode.ToString();
            if (keyMapping.ContainsKey(key))
            {
                KeyboardSimulator.KeyPress((Keys)keyMapping[key]);
            }
            //if (e.KeyCode.ToString().Equals("Q"))
            //{
            //    KeyboardSimulator.KeyPress(Keys.D6);
            //} else if (e.KeyCode.ToString().Equals("W"))
            //{
            //    KeyboardSimulator.KeyPress(Keys.D7);
            //} else if (e.KeyCode.ToString().Equals("E"))
            //{
            //    KeyboardSimulator.KeyPress(Keys.D8);
            //} else if (e.KeyCode.ToString().Equals("R"))
            //{
            //    KeyboardSimulator.KeyPress((Keys)57);
            //}
        }
    }
}

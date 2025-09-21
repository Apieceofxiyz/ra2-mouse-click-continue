using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick
{
    public class Config : NotifyingEntity
    {
        public readonly static string AppRoot = AppDomain.CurrentDomain.BaseDirectory;
        public readonly string ConfigFile = Path.Combine(AppRoot, "config.ini");

        public readonly string ClickingOnLabel = "已开启连点(点击关闭)";
        public readonly string ClickingOffLabel = "已关闭连点(点击开启)";

        public Config()
        {
            // 转换配置文件编码为 Encoding.Default 否则无法读取配置
            if (GetFileEncoding(ConfigFile) != Encoding.Default)
            {
                string configStr = File.ReadAllText(ConfigFile);
                File.WriteAllText(ConfigFile, configStr, Encoding.Default);
            }
        }

        public bool ClickOn
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = bool.Parse(getCoreConfig("ClickOn"));
                    SetValueWithNotify(val);
                }
                return GetValue<bool>();
            }
            set
            {
                SetValueWithNotify(value);
                writeCoreConfig("ClickOn", value.ToString());
            }
        }

        public int ClickCounts
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = int.Parse(getCoreConfig("ClickCounts"));
                    SetValueWithNotify(val);
                }
                return GetValue<int>();
            }
            set
            {
                SetValueWithNotify(value);
                writeCoreConfig("ClickCounts", value.ToString());
            }
        }

        public bool UseRa2olStyle
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = bool.Parse(getCoreConfig("UseRa2olStyle"));
                    SetValueWithNotify(val);
                }
                return GetValue<bool>();
            }
            set
            {
                SetValueWithNotify(value);
                writeCoreConfig("UseRa2olStyle", value.ToString());
            }
        }

        public bool LeftClick
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = bool.Parse(getCoreConfig("LeftClick"));
                    SetValueWithNotify(val);
                }
                return GetValue<bool>();
            }
            set
            {
                SetValueWithNotify(value);
                writeCoreConfig("LeftClick", value.ToString());
            }
        }

        public bool RightClick
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = bool.Parse(getCoreConfig("RightClick"));
                    SetValueWithNotify(val);
                }
                return GetValue<bool>();
            }
            set
            {
                SetValueWithNotify(value);
                writeCoreConfig("RightClick", value.ToString());
            }
        }

        public int HotKeyCode
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = int.Parse(getCoreConfig("HotKeyCode"));
                    SetValueWithNotify(val);
                }
                return GetValue<int>();
            }
            set
            {
                SetValueWithNotify(value);
                writeCoreConfig("HotKeyCode", value.ToString());
            }
        }

        public int ClickInterval
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = int.Parse(getCoreConfig("ClickInterval"));
                    SetValueWithNotify(val);
                }
                return GetValue<int>();
            }
            set
            {
                SetValueWithNotify(value);
                writeCoreConfig("ClickInterval", value.ToString());
            }
        }

        public string TextEditor
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = getCoreConfig("TextEditor");
                    SetValueWithNotify(val);
                }
                return GetValue<string>();
            }
            set
            {
                SetValueWithNotify(value);
                writeCoreConfig("TextEditor", value);
            }
        }

        public bool EnableRa2Mode
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = bool.Parse(getRa2Config("EnableRa2Mode"));
                    SetValueWithNotify(val);
                }
                return GetValue<bool>();
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("EnableRa2Mode", value.ToString());
            }
        }

        public int ConstructionBarWidth
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = int.Parse(getRa2Config("ConstructionBarWidth"));
                    SetValueWithNotify(val);
                }
                return GetValue<int>();
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("ConstructionBarWidth", value.ToString());
            }
        }

        public int ScreenWidth
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = int.Parse(getRa2Config("ScreenWidth"));
                        SetValueWithNotify(val);
                    }
                    return GetValue<int>();
                }
                catch
                {
                    return Screen.PrimaryScreen.WorkingArea.Width;
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("ScreenWidth", value.ToString());
            }
        }

        public bool AutoDetectMode
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = bool.Parse(getRa2Config("AutoDetectMode"));
                    SetValueWithNotify(val);
                }
                return GetValue<bool>();
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("AutoDetectMode", value.ToString());
            }
        }

        public bool AutoDetectAres
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = bool.Parse(getRa2Config("AutoDetectAres"));
                    SetValueWithNotify(val);
                }
                return GetValue<bool>();
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("AutoDetectAres", value.ToString());
            }
        }

        public bool KillProcessOn
        {
            get
            {
                if (!ContainsProperty())
                {
                    var val = bool.Parse(getRa2Config("KillProcessOn"));
                    SetValueWithNotify(val);
                }
                return GetValue<bool>();
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("KillProcessOn", value.ToString());
            }
        }

        public int AutoDetectInterval
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = int.Parse(getRa2Config("AutoDetectInterval"));
                        SetValueWithNotify(val);
                    }
                    return GetValue<int>();
                }
                catch
                {
                    return 5000;
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("AutoDetectInterval", value.ToString());
            }
        }

        public string GameProcessFileName
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = getRa2Config("GameProcessFileName");
                        SetValueWithNotify(val);
                    }
                    return GetValue<string>();
                }
                catch
                {
                    return "game-processes.txt";
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("GameProcessFileName", value);
            }
        }

        public string AresProcessFileName
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = getRa2Config("AresProcessFileName");
                        SetValueWithNotify(val);
                    }
                    return GetValue<string>();
                }
                catch
                {
                    return "ares-processes.txt";
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("AresProcessFileName", value);
            }
        }

        public string GameProcessSeparator
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = getRa2Config("GameProcessSeparator");
                        SetValueWithNotify(val);
                    }
                    return GetValue<string>();
                }
                catch
                {
                    return "|";
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("GameProcessSeparator", value);
            }
        }

        public string AresProcessSeparator
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = getRa2Config("AresProcessSeparator");
                        SetValueWithNotify(val);
                    }
                    return GetValue<string>();
                }
                catch
                {
                    return "|";
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("AresProcessSeparator", value);
            }
        }

        public string GameProcessList
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = getRa2Config("GameProcessList");
                        SetValueWithNotify(val);
                    }
                    return GetValue<string>();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("GameProcessList", value);
            }
        }

        public string AresProcessList
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = getRa2Config("AresProcessList");
                        SetValueWithNotify(val);
                    }
                    return GetValue<string>();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("AresProcessList", value);
            }
        }

        public string KillProcessHotkey
        {
            get
            {
                try
                {
                    if (!ContainsProperty())
                    {
                        var val = getRa2Config("KillProcessHotkey");
                        SetValueWithNotify(val);
                    }
                    return GetValue<string>();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                SetValueWithNotify(value);
                writeRa2Config("KillProcessHotkey", value);
            }
        }

        private bool writeCoreConfig(string key, string value)
        {
            return writeConfig("core", key, value);
        }
        private string getCoreConfig(string key)
        {
            return getConfig("core", key);
        }
        private bool writeRa2Config(string key, string value)
        {
            return writeConfig("ra2", key, value);
        }
        private string getRa2Config(string key)
        {
            return getConfig("ra2", key);
        }

        private bool writeConfig(string section, string key, string value)
        {
            return 0 != WritePrivateProfileString(section, key, value, ConfigFile);
        }

        private string getConfig(string section, string key, int nSize = 1024, string defaultValue = "")
        {
            StringBuilder sb = new StringBuilder(nSize);
            GetPrivateProfileString(section, key, defaultValue, sb, nSize, ConfigFile);
            return sb.ToString();
        }

        #region windows api

        /// <summary>
        /// 为INI文件中指定的节点取得字符串
        /// </summary>
        /// <param name="section">欲在其中查找关键字的节点名称</param>
        /// <param name="key">欲获取的项名</param>
        /// <param name="defaultValue">指定的项没有找到时返回的默认值</param>
        /// <param name="returnedStr">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="nSize">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="fileName">INI文件完整路径</param>
        /// <returns>复制到lpReturnedString缓冲区的字节数量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnedStr, int nSize, string fileName);

        /// <summary>
        /// 修改INI文件中内容
        /// </summary>
        /// <param name="section">欲在其中写入的节点名称</param>
        /// <param name="key">欲设置的项名</param>
        /// <param name="value">要写入的新字符串</param>
        /// <param name="fileName">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string section, string key, string value, string fileName);

        #endregion windows api

        public static Encoding GetFileEncoding(string filename)
        {
            byte[] buffer = File.ReadAllBytes(filename);
            if (buffer[0] >= 0xEF)
            {
                if (buffer[0] == 0xEF && buffer[1] == 0xBB)
                {
                    return Encoding.UTF8;
                }
                else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
                {
                    return Encoding.BigEndianUnicode;
                }
                else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
                {
                    return Encoding.Unicode;
                }
                else
                {
                    return Encoding.Default;
                }
            }
            else
            {
                return Encoding.Default;
            }
        }
    }
}

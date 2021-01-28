﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick
{
    public class Config
    {
        private readonly static string AppRoot = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string configFile = Path.Combine(AppRoot, "config.ini");

        public Config()
        {
            // 转换配置文件编码为 Encoding.Default 否则无法读取配置
            if (GetFileEncoding(configFile) != Encoding.Default)
            {
                string configStr = File.ReadAllText(configFile);
                File.WriteAllText(configFile, configStr, Encoding.Default);
            }
        }

        public int ClickCounts
        {
            get
            {
                return int.Parse(getCoreConfig("ClickCounts"));
            }
            set
            {
                writeCoreConfig("ClickCounts", value.ToString());
            }
        }

        public bool UseRa2olStyle
        {
            get
            {
                return bool.Parse(getCoreConfig("UseRa2olStyle"));
            }
            set
            {
                writeCoreConfig("UseRa2olStyle", value.ToString());
            }
        }

        public int HotKeyCode
        {
            get
            {
                return int.Parse(getCoreConfig("HotKeyCode"));
            }
            set
            {
                writeCoreConfig("HotKeyCode", value.ToString());
            }
        }

        public int ClickInterval
        {
            get
            {
                return int.Parse(getCoreConfig("ClickInterval"));
            }
            set
            {
                writeCoreConfig("ClickInterval", value.ToString());
            }
        }

        public bool EnableRa2Mode
        {
            get
            {
                return bool.Parse(getRa2Config("EnableRa2Mode"));
            }
            set
            {
                writeRa2Config("EnableRa2Mode", value.ToString());
            }
        }

        public int ConstructionBarWidth
        {
            get
            {
                return int.Parse(getRa2Config("ConstructionBarWidth"));
            }
            set
            {
                writeRa2Config("ConstructionBarWidth", value.ToString());
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
            return 0 != WritePrivateProfileString(section, key, value, configFile);
        }

        private string getConfig(string section, string key, int nSize = 1024, string defaultValue = "")
        {
            StringBuilder sb = new StringBuilder(nSize);
            GetPrivateProfileString(section, key, defaultValue, sb, nSize, configFile);
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
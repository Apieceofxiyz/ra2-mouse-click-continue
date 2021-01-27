using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace MouseClick
{
    public static class KeyboardSimulator
    {

        #region Windows API Code

        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;

        [DllImport("user32.dll")]
        static extern void keybd_event(byte key, byte scan, int flags, int extraInfo);

        #endregion

        public static void KeyDown(Keys key)
        {
            keybd_event(ParseKey(key), 0, 0, 0);
        }

        public static void KeyUp(Keys key)
        {
            keybd_event(ParseKey(key), 0, KEYEVENTF_KEYUP, 0);
        }

        public static void KeyPress(Keys key)
        {
            KeyDown(key);
            KeyUp(key);
        }

        static byte ParseKey(Keys key)
        {

            // Alt, Shift, and Control need to be changed for API function to work with them
            switch (key)
            {
                case Keys.Alt:
                    return (byte)18;
                case Keys.Control:
                    return (byte)17;
                case Keys.Shift:
                    return (byte)16;
                default:
                    return (byte)key;
            }

        }
    }

    public static class MouseSimulator
    {

        #region Windows API Code

        [DllImport("user32.dll")]
        static extern int ShowCursor(bool show);

        [DllImport("user32.dll")]
        static extern void mouse_event(int flags, int dX, int dY, int buttons, int extraInfo);

        const int MOUSEEVENTF_MOVE = 0x1;
        const int MOUSEEVENTF_LEFTDOWN = 0x2;
        const int MOUSEEVENTF_LEFTUP = 0x4;
        const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        const int MOUSEEVENTF_RIGHTUP = 0x10;
        const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        const int MOUSEEVENTF_MIDDLEUP = 0x40;
        const int MOUSEEVENTF_WHEEL = 0x800;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        #endregion

        /// <summary>
        /// Press a mouse button down
        /// </summary>
        /// <param name="button"></param>
        private static void MouseDown(MouseButton button)
        {
            mouse_event(((int)button), 0, 0, 0, 0);
        }

        public static void MouseDown(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    MouseDown(MouseButton.Left);
                    break;
                case MouseButtons.Middle:
                    MouseDown(MouseButton.Middle);
                    break;
                case MouseButtons.Right:
                    MouseDown(MouseButton.Right);
                    break;
            }
        }

        /// <summary>
        /// Let a mouse button up
        /// </summary>
        /// <param name="button"></param>
        private static void MouseUp(MouseButton button)
        {
            mouse_event(((int)button) * 2, 0, 0, 0, 0);
        }

        public static void MouseUp(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    MouseUp(MouseButton.Left);
                    break;
                case MouseButtons.Middle:
                    MouseUp(MouseButton.Middle);
                    break;
                case MouseButtons.Right:
                    MouseUp(MouseButton.Right);
                    break;
            }
        }

        /// <summary>
        /// Click a mouse button (down then up)
        /// </summary>
        /// <param name="button"></param>
        private static void Click(MouseButton button)
        {
            MouseDown(button);
            MouseUp(button);
        }

        public static void Click(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    Click(MouseButton.Left);
                    break;
                case MouseButtons.Middle:
                    Click(MouseButton.Middle);
                    break;
                case MouseButtons.Right:
                    Click(MouseButton.Right);
                    break;
            }
        }

        enum MouseButton
        {
            Left = 0x2,
            Right = 0x8,
            Middle = 0x20
        }
    }
}

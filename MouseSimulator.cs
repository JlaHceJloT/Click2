using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX;


namespace Click2
{
    class MouseSimulator
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public SendInputEventType type;
            public MouseKeybdhardwareInputUnion mkhi;
        }
        [StructLayout(LayoutKind.Explicit)]
        struct MouseKeybdhardwareInputUnion
        {
            [FieldOffset(0)]
            public MouseInputData mi;

            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }
        struct MouseInputData
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public MouseEventFlags dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [Flags]
        internal enum MouseEventFlags : uint
        {
            MOUSEEVENTF_MOVE = 0x0001,
            MOUSEEVENTF_LEFTDOWN = 0x0002,
            MOUSEEVENTF_LEFTUP = 0x0004,
            MOUSEEVENTF_RIGHTDOWN = 0x0008,
            MOUSEEVENTF_RIGHTUP = 0x0010,
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,
            MOUSEEVENTF_MIDDLEUP = 0x0040,
            MOUSEEVENTF_XDOWN = 0x0080,
            MOUSEEVENTF_XUP = 0x0100,
            MOUSEEVENTF_WHEEL = 0x0800,
            MOUSEEVENTF_VIRTUALDESK = 0x4000,
            MOUSEEVENTF_ABSOLUTE = 0x8000
        }
        enum SendInputEventType : int
        {
            InputMouse,
            InputKeyboard,
            InputHardware
        }

        enum SendInputWaiting : int 
        {
            MOUSE_EVENT_WAITING_SHORT = 50,
            MOUSE_EVENT_WAITING_DEFAULT = 100,
            MOUSE_EVENT_WAITING_LONG = 200
        }

        static int MOUSE_WAIT = 25;


        public void ClickMouseButton(MouseEventFlags mouseKeyDown, MouseEventFlags mouseKeyUp)
        {
            INPUT mouseDownInput = new INPUT();
            mouseDownInput.type = SendInputEventType.InputMouse;
            mouseDownInput.mkhi.mi.dwFlags = mouseKeyDown;
            System.Threading.Thread.Sleep(MOUSE_WAIT);

            SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));

            mouseDownInput.mkhi.mi.dwFlags = mouseKeyUp;
            System.Threading.Thread.Sleep(MOUSE_WAIT); 
            SendInput(1, ref mouseDownInput, Marshal.SizeOf(new INPUT()));

        }


        public void MoveMouseCursor(int dx, int dy)
        {
            INPUT mouseMoveInput = new INPUT();
            mouseMoveInput.type = SendInputEventType.InputMouse;
            mouseMoveInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_MOVE;
            mouseMoveInput.mkhi.mi.dx = dx;
            mouseMoveInput.mkhi.mi.dy = dy;
            SendInput(1, ref mouseMoveInput, Marshal.SizeOf(new INPUT()));

            System.Threading.Thread.Sleep(MOUSE_WAIT);

        }
    } 

}

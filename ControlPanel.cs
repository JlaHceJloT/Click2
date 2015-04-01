using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Click2
{
    class ControlPanel
    {
        internal enum MovingDirection : uint
        {
            FORWARD = 0x01,
            BACK = 0x02,
            LEFT = 0x03,
            RIGHT = 0x04
        }
        KeyboardSimulator keyboardSimulator = new KeyboardSimulator();
        MouseSimulator mouseSumulator = new MouseSimulator();
        bool[] isMoving = new bool[4];

        public void StartMoving(MovingDirection direction)
        {
            if(isMoving[(int)direction])
            {
                return;
            }
            switch(direction)
            {
                case MovingDirection.FORWARD :
                    keyboardSimulator.PressKey(KeyboardSimulator.ScanCodeShort.KEY_W, KeyboardSimulator.VirtualKeyShort.KEY_W);
                    break;
                case MovingDirection.LEFT :
                    keyboardSimulator.PressKey(KeyboardSimulator.ScanCodeShort.KEY_A, KeyboardSimulator.VirtualKeyShort.KEY_A);
                    break;
                case MovingDirection.BACK:
                    keyboardSimulator.PressKey(KeyboardSimulator.ScanCodeShort.KEY_S, KeyboardSimulator.VirtualKeyShort.KEY_S);
                    break;
                case MovingDirection.RIGHT:
                    keyboardSimulator.PressKey(KeyboardSimulator.ScanCodeShort.KEY_D, KeyboardSimulator.VirtualKeyShort.KEY_D);
                    break;
            }
            isMoving[(int)direction] = true;
        }
        public void StopMoving(MovingDirection direction)
        {
            if (!isMoving[(int)direction])
            {
                return;
            }
            switch (direction)
            {
                case MovingDirection.FORWARD:
                    keyboardSimulator.UnpressKey(KeyboardSimulator.ScanCodeShort.KEY_W, KeyboardSimulator.VirtualKeyShort.KEY_W);
                    break;
                case MovingDirection.LEFT:
                    keyboardSimulator.UnpressKey(KeyboardSimulator.ScanCodeShort.KEY_A, KeyboardSimulator.VirtualKeyShort.KEY_A);
                    break;
                case MovingDirection.BACK:
                    keyboardSimulator.UnpressKey(KeyboardSimulator.ScanCodeShort.KEY_S, KeyboardSimulator.VirtualKeyShort.KEY_S);
                    break;
                case MovingDirection.RIGHT:
                    keyboardSimulator.UnpressKey(KeyboardSimulator.ScanCodeShort.KEY_D, KeyboardSimulator.VirtualKeyShort.KEY_D);
                    break;
            }
            isMoving[(int)direction] = false;
        }
        public bool IsMoving(MovingDirection direction)
        {
            return isMoving[(int)direction];
        }


        public void ClickMouseRightButton()
        {
            mouseSumulator.ClickMouseButton(MouseSimulator.MouseEventFlags.MOUSEEVENTF_RIGHTUP, MouseSimulator.MouseEventFlags.MOUSEEVENTF_RIGHTDOWN);
        }
        public void ClickMouseLeftButton()
        {
            mouseSumulator.ClickMouseButton(MouseSimulator.MouseEventFlags.MOUSEEVENTF_LEFTDOWN, MouseSimulator.MouseEventFlags.MOUSEEVENTF_LEFTUP);
        }

        public void MoveMouseCursor(int dx, int dy)
        {
            mouseSumulator.MoveMouseCursor(dx, dy);
        }


    }
}

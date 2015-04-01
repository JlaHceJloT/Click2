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
    /**
    * Mouse simulator for DirectX windows        
    */
  
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            //Cursor.Position = new Cursor.Position(Point(500, 500));

            IntPtr calculatorHandle = FindWindow(null, "WoT client");
            //IntPtr calculatorHandle = FindWindow(null, "Калькулятор");
            if (calculatorHandle == IntPtr.Zero)
            {
                MessageBox.Show("Calculator is not running");
                return;
            }
            SetForegroundWindow(calculatorHandle);

            // MouseSimulator.MoveMouseCursor(0, 600);
            //for (int i = 0; i < 5; i++ )
            //{
            //    MouseSimulator.MoveMouseCursor(100, 0);
            //    MouseSimulator.ClickLeftMouseButton();
            //    System.Threading.Thread.Sleep(300);
            //}


            KeyboardSimulator.PressKey(KeyboardSimulator.ScanCodeShort.KEY_W, KeyboardSimulator.VirtualKeyShort.KEY_W, 10000);
            KeyboardSimulator.PressKey(KeyboardSimulator.ScanCodeShort.KEY_A, KeyboardSimulator.VirtualKeyShort.KEY_A, 1000);
            MouseSimulator.MoveMouseCursor(100, 0);
            MouseSimulator.ClickLeftMouseButton();
            System.Threading.Thread.Sleep(10000);
            MouseSimulator.MoveMouseCursor(1000, 100);
            MouseSimulator.ClickLeftMouseButton();


            //System.Threading.Thread.Sleep(1000);
            //MouseSimulator.PressKey(MouseSimulator.ScanCodeShort.KEY_A, MouseSimulator.VirtualKeyShort.KEY_A, 0);
            //System.Threading.Thread.Sleep(1000);
            //MouseSimulator.PressKey(MouseSimulator.ScanCodeShort.KEY_W, MouseSimulator.VirtualKeyShort.KEY_W, 0);
            //MouseSimulator.PressKey(MouseSimulator.ScanCodeShort.KEY_A, MouseSimulator.VirtualKeyShort.KEY_A, 0);
            //MouseSimulator.PressKey(MouseSimulator.ScanCodeShort.KEY_W, MouseSimulator.VirtualKeyShort.KEY_W, 0);




            //MouseSimulator.ClickRightMouseButton();


        }

        
    }

   
}

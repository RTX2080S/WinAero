using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
    }
    
    public partial class Form1 : Form
    {
        //The Following Codes are for total AeroGlass

        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {

            if (DwmIsCompositionEnabled())
            {
                MARGINS margins = new MARGINS();
                margins.Right = 0; 
                margins.Left = 0; 
                margins.Top = 20; 
                margins.Bottom = 0;
                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
            }
            base.OnLoad(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (DwmIsCompositionEnabled()) e.Graphics.Clear(Color.Black);
        }

        //The Codes above are for total AeroGlass


        //The following Code is for any-drag

        //[DllImport("user32.dll")] 
        //public static extern bool ReleaseCapture(); 

        //[DllImport("user32.dll")] 
        //public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        //private void Form1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, 0x0112, 0xF012, 0); 
        //}

        //The Codes above are for whole window-drag

    }
}

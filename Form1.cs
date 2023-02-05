using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mashUp
{
    public partial class Form1 : Form
    {
        static Figure f;
        Point ptX, ptY, mouse;
        Bitmap bmpX, bmpY;
        Graphics gX, gY;
        bool IsMouseDownX = false;
        bool IsMouseDownY = false;
        Canvas canvas;
        float deltaX = 0;
        float deltaY = 1;
        Scene scene;
        bool isMouseDown = false;

        const int WM_KEYUP = 0x0101;
        const int WM_KEYDOWN = 0x0100;
        public Form1()
        {
            InitializeComponent();
        }




        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}

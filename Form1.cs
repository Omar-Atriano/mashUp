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
        bool sliderLimit = false;


        private bool play = false;



        const int WM_KEYUP = 0x0101;

        public Form1()
        {
            InitializeComponent();
            Init();
            IsMouseDownX = false;
        }

        private void Init()
        {
            bmpX = new Bitmap(sliderX.Width, sliderX.Height);
            bmpY = new Bitmap(sliderY.Width, sliderY.Height);

            gX = Graphics.FromImage(bmpX);
            gY = Graphics.FromImage(bmpY);

            sliderX.Image = bmpX;
            sliderY.Image = bmpY;

            gX.DrawLine(Pens.DimGray, 0, bmpX.Height / 2, bmpX.Width, bmpX.Height / 2);
            gX.FillEllipse(Brushes.Aquamarine, bmpX.Width / 2, bmpX.Height / 4, bmpX.Height / 2, bmpX.Height / 2);

            gY.DrawLine(Pens.DimGray, bmpY.Width / 2, 0, bmpY.Width / 2, bmpY.Height);
            gY.FillEllipse(Brushes.Aquamarine, bmpY.Width / 4, bmpY.Height / 2, bmpX.Height / 2, bmpX.Height / 2);

            scene = new Scene();
            canvas = new Canvas(PCT_CANVAS);
            //Figure fig = new Figure(trackBar1.Maximum);
            //fig.Add(new PointF(100, 120));
            //fig.Add(new PointF(1400, 120));
            //scene.Figures.Add(fig);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            canvas = new Canvas(PCT_CANVAS);
        }

        //PCT_CANVAS Methods
        private void PCT_CANVAS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                f.UpdateAttributes();
        }

        private void PCT_CANVAS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f != null)
            {
                //canvas.DrawPixel(e.X, e.Y, Color.White);
                f.Add(new PointF(e.X, e.Y));
            }
        }

        private void PCT_CANVAS_MouseDown(object sender, MouseEventArgs e) //This method activates when a mouse button is pressed on the canvas
        {
            mouse = e.Location;
            isMouseDown = true;
        }

        private void PCT_CANVAS_MouseUp(object sender, MouseEventArgs e) //This method activates when a mouse button is released of the canvas
        {
            isMouseDown = false;
            PCT_CANVAS.Select();
        }

        private void PCT_CANVAS_MouseMove(object sender, MouseEventArgs e) //It works when we drag and drop the figure in a certain postion
        {
            if (isMouseDown)
            {
                mouse.X -= e.X;
                mouse.Y -= e.Y;
                f.TranslatePoints(new Point(-mouse.X, -mouse.Y));
                f.UpdateAttributes();
                mouse = e.Location;
            }
        }


        //Transformation Methods 
        //Resize Transformation
        private void sliderY_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDownY = false;
            gY.Clear(Color.Transparent);
            gY.DrawLine(Pens.DimGray, bmpY.Width / 2, 0, bmpY.Width / 2, bmpY.Height);
            gY.FillEllipse(Brushes.Aquamarine, bmpY.Width / 4, bmpY.Height / 2, bmpX.Height / 2, bmpX.Height / 2);

            sliderY.Invalidate();
        }

        private void sliderY_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDownY)
            {
                gY.Clear(Color.Transparent);
                gY.DrawLine(Pens.DimGray, bmpY.Width / 2, 0, bmpY.Width / 2, bmpY.Height);
                gY.FillEllipse(Brushes.Aquamarine, bmpY.Width / 4, e.Y, bmpX.Height / 2, bmpX.Height / 2);

                sliderY.Invalidate();
                deltaY += (float)(ptY.Y - e.Location.Y) / 500;//------------------
                ptY.Y = e.Location.Y;
            }
        }

        private void sliderY_MouseDown(object sender, MouseEventArgs e)
        {
            ptY = e.Location;
            IsMouseDownY = true;
        }

        //Rotation Transformation
        private void sliderX_MouseDown(object sender, MouseEventArgs e)
        {
            ptX = e.Location;
            IsMouseDownX = true;
        }

        private void sliderX_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDownX)
            {
                gX.Clear(Color.Transparent);
                gX.DrawLine(Pens.DimGray, 0, sliderX.Height / 2, sliderX.Width, sliderX.Height / 2);
                gX.FillEllipse(Brushes.Aquamarine, e.X, sliderX.Height / 4, sliderX.Height / 2, sliderX.Height / 2);

                sliderX.Invalidate();
                deltaX += (float)(e.Location.X - ptX.X) / 3;//------------------
                ptX.X = e.Location.X;
            }
        }

        private void sliderX_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDownX = false;
            gX.Clear(Color.Transparent);
            gX.DrawLine(Pens.DimGray, 0, sliderX.Height / 2, sliderX.Width, sliderX.Height / 2);
            gX.FillEllipse(Brushes.Aquamarine, sliderX.Width / 2, sliderX.Height / 4, sliderX.Height / 2, sliderX.Height / 2);

            sliderX.Invalidate();
        }


        //Updates
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (f != null) //&& (IsMouseDownX || IsMouseDownY)
            {
                f.TranslateToOrigin();
                f.Scale(deltaY);
                f.Rotate(deltaX);
                f.TranslatePoints(f.Centroid);
                f.Ascale *= deltaY;
            }
            deltaX = 0;
            deltaY = 1;
            canvas.Render(scene); //This option is in charge of indicating the main points of a created figure

            if (play)
            {
                if (trackBar1.Value < trackBar1.Maximum && !sliderLimit)
                {
                    trackBar1.Value++;
                    RunAnimation();
                }
                else if (trackBar1.Value > 0 && sliderLimit)
                {
                    trackBar1.Value--;
                    RunAnimation();
                }
                else sliderLimit = !sliderLimit;
            }
        }

        private void refresh(Figure figs, float x, float y) //Funciona igual que el tick, pero solo para guardar valores, así no tenemos que esperar a la computadora para guardar valores
        {

            if (figs != null)
            {
                figs.TranslateToOrigin();
                figs.Scale(1 / figs.Ascale); //Cada que avancemos o retrocedamos un frame de la animación, elimina la escala que tenga volviendola 1
                figs.Ascale *= 1 / figs.Ascale;
                figs.Scale(y); //Para despues modificar la escala por el valor que mandamos a pedir
                figs.Rotate(-figs.Arotation + x); //Cada que avancemos o retrocedamos un frame de la animación, elimina la rotación que tenga dejandolo en el angulo 0, y despues le añade la rotación que mandamos
                figs.Arotation = x; //una vez modificado guardamos la nueva rotacion
                figs.Ascale = y; //una vez modificado guardamos la nueva escala
                figs.TranslatePoints(figs.Centroid);
            }
        }

        private void RunAnimation()
        {
            if (checkBox1.Checked) foreach (Figure figure in scene.Figures) FigureAnimation(figure);
            else FigureAnimation(f);
        }

        private void FigureAnimation(Figure figs)
        {
            int firstSavedFrame = -1;
            int finalSavedFrame = -1; 
            float difference; 

            float rotAngle; //Rotation preset on that frame
            float scaleFactor; //How much the size of the figure will increase on that frame

            if (scene.Figures.Count == 0 || figs.frames[trackBar1.Value]) return; //It detects if we have created figures before starting an animation
            else
            {
                for (int i = trackBar1.Value; i >= 0; i--)
                {
                    if (figs.frames[i])
                    {
                        firstSavedFrame = i;
                        break;
                    }
                }
                for (int i = trackBar1.Value; i <= figs.positions.Length - 1; i++)
                {
                    if (figs.frames[i])
                    {
                        finalSavedFrame = i;
                        break;
                    }
                }
            }
            if (firstSavedFrame != -1 && finalSavedFrame != -1) //If there exist an initial and final frame the animation can start
            {

                difference = ((float)trackBar1.Value - firstSavedFrame) / (finalSavedFrame - firstSavedFrame); 

                rotAngle = ((figs.rotations[finalSavedFrame] - figs.rotations[firstSavedFrame]) * difference) + figs.rotations[firstSavedFrame]; //la rotacion guardada en el frame siguiente (guardado), menos la rotacion del frame anterior (guardado) podemos obtener cuantos grados hay entre ellos. Luego obtejemos el valor del punto en el que estamos con el porcentaje. Finalmente le sumamos los grados del inicio para poder obtener la rotacion inicial
                scaleFactor = ((figs.sizes[finalSavedFrame] - figs.sizes[firstSavedFrame]) * difference) + figs.sizes[firstSavedFrame];

                figs.Follow(figs.positions[firstSavedFrame], figs.positions[finalSavedFrame], difference); //This helps to go to the next point.
                refresh(figs, rotAngle, scaleFactor); //Values are updated even before the tick
            }
        }
        //Add figure Method
        private void ADD_Click(object sender, EventArgs e)
        {
            f = new Figure(trackBar1.Maximum);
            scene.Figures.Add(f);
            TreeNode node = new TreeNode("Fig" + (treeView1.Nodes.Count + 1));
            node.Tag = f;
            treeView1.Nodes.Add(node);
        }

        private void PLAY_Click(object sender, EventArgs e)
        {
            play = !play;

            if (play)
                PLAY.Text = "PAUSA";
            else
                PLAY.Text = "PLAY";
        }

        private void RECORD_Click(object sender, EventArgs e)
        {
            f.frames[trackBar1.Value] = true;
            f.positions[trackBar1.Value] = f.Centroid;
            f.rotations[trackBar1.Value] = f.Arotation;
            f.sizes[trackBar1.Value] = f.Ascale;
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            f = (Figure)treeView1.SelectedNode.Tag;
            ADD.Select();
        }

        public static bool IsControlDown()
        {
            return (Control.ModifierKeys & Keys.Control) == Keys.Control;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (f == null)
                return false;

            switch (keyData)
            {
                case Keys.Left:
                    f.Centroid.X -= 3;
                    break;
                case Keys.Right:
                    f.Centroid.X += 3;
                    break;
                case Keys.Up:
                    f.Centroid.Y += -3;
                    break;
                case Keys.Down:
                    f.Centroid.Y += 3;
                    break;
                case Keys.Space:
                    break;
            }
            PCT_CANVAS.Select();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }

        const int WM_KEYDOWN = 0x0100;

        //Animation scroll
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            RunAnimation();
        }
    }
}

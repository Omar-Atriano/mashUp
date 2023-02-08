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
        Canvas canvas;
        float deltaX = 0;
        float deltaY = 1;
        Scene scene;
        bool IsMouseDownX = false;
        bool IsMouseDownY = false;
        bool isMouseDown = false;
        bool sliderLimit = false;
        private bool play = false;
        int speedCounter;

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

            gX.DrawLine(Pens.Gold, 0, bmpX.Height / 2, bmpX.Width, bmpX.Height / 2);
            gX.FillEllipse(Brushes.Purple, bmpX.Width / 2, bmpX.Height / 4, bmpX.Height / 2, bmpX.Height / 2);

            gY.DrawLine(Pens.Gold, bmpY.Width / 2, 0, bmpY.Width / 2, bmpY.Height);
            gY.FillEllipse(Brushes.Purple, bmpY.Width / 4, bmpY.Height / 2, bmpX.Height / 2, bmpX.Height / 2);

            scene = new Scene();
            canvas = new Canvas(PCT_CANVAS);
            framesLabel.Text = "Frame: " + trackBar1.Value + "\nAvailable Frames: " + trackBar1.Maximum;

        }

        //PCT_CANVAS Methods
        private void PCT_CANVAS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (f != null)
            {
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
                deltaY += (float)(ptY.Y - e.Location.Y) / 500;
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
                deltaX += (float)(e.Location.X - ptX.X) / 3;
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
            if (f != null)
            {
                f.TranslateToOrigin();
                f.Scale(deltaY);
                f.Rotate(deltaX);
                f.TranslatePoints(f.Centroid);
                f.Arotation += deltaX;
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

        private void refresh(Figure figs, float x, float y) //Method that helps to save and update more data as size, rotation.
        {

            if (figs != null)
            {
                figs.TranslateToOrigin();
                figs.Scale(1 / figs.Ascale); //Cada que avancemos o retrocedamos un frame de la animación, elimina la escala que tenga volviendola 1
                figs.Ascale *= 1 / figs.Ascale;
                figs.Scale(y);
                figs.Rotate(-figs.Arotation + x); //Each frame it will reset the figure rotation and update it with the most recent. 
                figs.Arotation = x; 
                figs.Ascale = y; 
                figs.TranslatePoints(figs.Centroid);
            }
        }

        private void RunAnimation()
        {
            framesLabel.Text = "Frame: " + trackBar1.Value + "\nAvailable Frames: " + trackBar1.Maximum;

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

                rotAngle = ((figs.rotations[finalSavedFrame] - figs.rotations[firstSavedFrame]) * difference) + figs.rotations[firstSavedFrame]; //This helps to play a possible stated rotation by taking into account the rotation of a point in comparison to another.
                scaleFactor = ((figs.sizes[finalSavedFrame] - figs.sizes[firstSavedFrame]) * difference) + figs.sizes[firstSavedFrame];

                figs.Follow(figs.positions[firstSavedFrame], figs.positions[finalSavedFrame], difference); //This helps to go to the next point.
                refresh(figs, rotAngle, scaleFactor); //Values are updated even before the tick
            }
        }
        //Add figure Button Method
        private void ADD_Click(object sender, EventArgs e)
        {
            f = new Figure(trackBar1.Maximum);
            scene.Figures.Add(f);
            TreeNode node = new TreeNode("Fig" + (treeView1.Nodes.Count + 1));
            node.Tag = f;
            treeView1.Nodes.Add(node);
        }

        //Play Animation Button Method
        private void PLAY_Click(object sender, EventArgs e)
        {
            play = !play;

            if (play)
                PLAY.Text = "PAUSA";
            else
                PLAY.Text = "PLAY";
        }

        //Record frame Button Method
        private void RECORD_Click(object sender, EventArgs e)
        {
            f.frames[trackBar1.Value] = true;
            f.positions[trackBar1.Value] = f.Centroid;
            f.rotations[trackBar1.Value] = f.Arotation;
            f.sizes[trackBar1.Value] = f.Ascale;
        }

        //Increase speed Button Method
        private void BTN_SPEED_Click(object sender, EventArgs e)
        {
            if (play == false) MessageBox.Show("You cannot change the speed of the animation if the animation is not playing. \n\nPlease try again.", "Change Animation Speed Error");
            else
            {
                if (speedCounter == 0)
                {
                    BTN_SPEED.Text = "|>";
                    timer1.Interval = 20;
                    speedCounter++;
                }
                else if (speedCounter == 1)
                {
                    BTN_SPEED.Text = "|>|>";
                    timer1.Interval = 10;
                    speedCounter++;
                }
                else if (speedCounter == 2)
                {
                    BTN_SPEED.Text = "|>|>|>";
                    timer1.Interval = 5;
                    speedCounter++;
                }
                else if (speedCounter == 3)
                {
                    BTN_SPEED.Text = "|>|>|>|>";
                    timer1.Interval = 1;
                    speedCounter++;
                }
                else if (speedCounter == 4)
                {
                    BTN_SPEED.Text = "Change Animation Speed";
                    timer1.Interval = 40;
                    speedCounter = 0;
                }
            }
            
        }

        //Figures list methods
        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            f = (Figure)treeView1.SelectedNode.Tag;
            ADD.Select();
        }

        //Animation scroll
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            RunAnimation();
        }
    }
}

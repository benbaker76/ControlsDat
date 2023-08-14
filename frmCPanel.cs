using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ControlsDat
{
    public partial class frmCPanel : Form
    {
        ColourProcessing m_colourAdjust = new ColourProcessing();

        public delegate void PixelSelectDelegate(Color color);

        public event PixelSelectDelegate PixelSelect = null;

        public frmCPanel()
        {
            InitializeComponent();
        }

        public void LoadPanel(MameXml.GameNode gameNode)
        {
            if(String.IsNullOrEmpty(Settings.Mame.Folders.CPanel))
                return;

            if (picCPanel.Image != null)
            {
                picCPanel.Image.Dispose();
                picCPanel.Image = null;
            }

            Bitmap bmp = null;

            string romFilename = Path.Combine(Settings.Mame.Folders.CPanel, gameNode.Name + ".png");
            string romOfFilename = Path.Combine(Settings.Mame.Folders.CPanel, gameNode.RomOf + ".png");
            string parentFilename = Path.Combine(Settings.Mame.Folders.CPanel, gameNode.GetParentString() + ".png");

            if (!FileIO.TryLoadImage(romFilename, out bmp))
                if (!FileIO.TryLoadImage(romOfFilename, out bmp))
                    FileIO.TryLoadImage(parentFilename, out bmp);

            if(bmp != null)
            {
                ColorMatrix Matrix = new ColorMatrix();

                m_colourAdjust.SaturateMatrix(ref Matrix, (float)120 / 100f);
                m_colourAdjust.TryApplyMatrix(bmp, Matrix);

                picMagnify.Image = new Bitmap(picMagnify.Width, picMagnify.Height);

                picCPanel.Image = bmp;
                picCPanel.Invalidate();
            }
        }

        private void frmCPanel_Load(object sender, EventArgs e)
        {
            ConfigIO.LoadWindowPosition(this);
        }

        private void frmCPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigIO.SaveWindowPosition(this);
            Global.CPanelForm = null;
        }

        private void picCPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (picCPanel.Image == null)
                return;

            Color pixelColor = DrawMagnifier((int)(((float)e.X / (float)picCPanel.Width) * (float)picCPanel.Image.Width), (int)(((float)e.Y / (float)picCPanel.Height) * (float)picCPanel.Image.Height));
        }

        private void picCPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (picCPanel.Image == null)
                return;

            Bitmap bmp = new Bitmap(picCPanel.Image, new Size(picCPanel.Width, picCPanel.Height));
            Color pixelColor = bmp.GetPixel(e.X, e.Y);

            bmp.Dispose();

            if (PixelSelect != null)
            {
                Color colorMatch = GetColorMatch(pixelColor);
                PixelSelect(colorMatch);
            }
        }

        private Color GetColorMatch(Color col)
        {
            Color ColorMatch = Color.Empty;

            int LeastDistance = int.MaxValue;

            int Alpha = col.A;
            int Red = col.R;
            int Green = col.G;
            int Blue = col.B;

            for (int i = 0; i < Global.SwatchArray.Length; i++)
            {
                Color PaletteColor = Global.SwatchArray[i];

                int AlphaDistance = PaletteColor.A - Alpha;
                int RedDistance = PaletteColor.R - Red;
                int GreenDistance = PaletteColor.G - Green;
                int BlueDistance = PaletteColor.B - Blue;

                int Distance = (AlphaDistance * AlphaDistance) +
                    (RedDistance * RedDistance) +
                    (GreenDistance * GreenDistance) +
                    (BlueDistance * BlueDistance);

                if (Distance < LeastDistance)
                {
                    ColorMatch = PaletteColor;
                    LeastDistance = Distance;

                    if (Distance == 0)
                        return PaletteColor;
                }
            }

            return ColorMatch;
        }

        private Color DrawMagnifier(int MouseX, int MouseY)
        {
            Bitmap bmpMagnify = (Bitmap)picMagnify.Image;
            Bitmap bmp = (Bitmap) picCPanel.Image;
            Graphics g = Graphics.FromImage(bmpMagnify);

            int Left = 0, Right = 0;
            int Top = 0, Bottom = 0;

            if (MouseX < picMagnify.Width / 2)
                Left = (picMagnify.Width / 4) - MouseX;
            if (MouseY < picMagnify.Height / 2)
                Top = (picMagnify.Height / 4) - MouseY;
            if (MouseX > bmp.Width - picMagnify.Width / 2)
                Right = (picMagnify.Width / 4) - (bmp.Width - MouseX);
            if (MouseY > bmp.Height - picMagnify.Height / 2)
                Bottom = (picMagnify.Height / 4) - (bmp.Height - MouseY);

            for (int y = 0 + Top; y < (picMagnify.Height / 2) - Bottom; y++)
            {
                for (int x = 0 + Left; x < (picMagnify.Width / 2) - Right; x++)
                {
                    Color pixelColor = bmp.GetPixel(MouseX - (picMagnify.Width / 4) + x, MouseY - (picMagnify.Height / 4) + y);

                    pixelColor = GetColorMatch(pixelColor);

                    g.FillRectangle(new SolidBrush(pixelColor), x * 2, y * 2, 2, 2);
                }
            }

            picMagnify.Invalidate();

            Color colorSelect = bmpMagnify.GetPixel(picMagnify.Width / 2, picMagnify.Height / 2);

            g.DrawLine(new Pen(Color.Black), picMagnify.Width / 2 - 4, picMagnify.Height / 2, picMagnify.Width / 2 + 4, picMagnify.Height / 2);
            g.DrawLine(new Pen(Color.Black), picMagnify.Width / 2, picMagnify.Height / 2 - 4, picMagnify.Width / 2, picMagnify.Height / 2 + 4);

            g.Dispose();

            return colorSelect;
        }
    }
}
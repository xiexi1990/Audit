using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audit
{
    public partial class ImageShower : Form
    {
        public ImageShower(Image image)
        {
            InitializeComponent();
            if (image == null)
                return;
            this.pictureBox1.Image = image;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";

            this.pictureBox1.Size = new Size(pictureBox1.Image.Size.Width, pictureBox1.Image.Size.Height + 100);
                
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.Size = new Size(pictureBox1.Size.Width + 20, pictureBox1.Size.Height);
        }
    }
}

using System;
using System.Windows.Forms;

namespace DragAndDropApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Move);
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            string item = e.Data.GetData(DataFormats.StringFormat).ToString();
            listBox2.Items.Add(item);
            listBox1.Items.Remove(item);
        }
    }
}

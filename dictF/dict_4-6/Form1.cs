using System.Configuration;

namespace dict_4_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetDict getDict = new GetDict();
            string str = getDict.phonetic;
            str = str.Replace("\n", "  ").Trim();

            label1.Text = getDict.word;
            label2.Text = getDict.translate;
            if (string.IsNullOrEmpty(getDict.distortion))
            {
                label3.Text = "нч";
            }
            else
            {
                label3.Text = getDict.distortion;
            }
            label4.Text = str;
            label5.Text = getDict.samples;

        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            GetDict getDict = new GetDict();
            int temp = int.Parse(getDict.id) + 1;
            getDict.SaveLastVisitedWordToStorage(temp.ToString());

            string str = getDict.phonetic;
            str = str.Replace("\n", "  ").Trim();

            label1.Text = getDict.word;
            label2.Text = getDict.translate;
            if (string.IsNullOrEmpty(getDict.distortion))
            {
                label3.Text = "нч";
            }
            else
            {
                label3.Text = getDict.distortion;
            }
            label4.Text = str;
            label5.Text = getDict.samples;
        }
    }

}


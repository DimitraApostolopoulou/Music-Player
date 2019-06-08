using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Player
{
    class lsong
    {
        //gia na fortoso tragoudia sto listview
        Stream myStream = null;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public ListView l(ListView listView1)
        {
            openFileDialog1.Filter = "MP3 Audio File (*.mp3)|*.mp3| Windows Media File (*.wma)|*.wma|WAV Audio File  (*.wav)|*.wav|All FILES (*.*)|*.*";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    //using:gia na anoiksw to arxeio apo to mystream
                    using (myStream)
                    {
                        string[] s_name = openFileDialog1.FileNames;
                        string[] path_song = openFileDialog1.SafeFileNames;

                        for (int i = 0; i < openFileDialog1.SafeFileNames.Count(); i++)
                        {
                            //gia to 1o arxeio pu tha vrw tha ftiaksw enan pseytopinaka pu sthn 1h sthlh vazei to onoma k stn 2h to path
                            string[] a = new string[2]; 
                            a[0] = path_song[i];
                            a[1] = s_name[i];
                            //ena antikeimeno to opoio prosthetei ta nea tragudia multiselect
                            ListViewItem neo_tragudi = new ListViewItem(a);
                            listView1.Items.Add(neo_tragudi);
                        }
                    }
                }
            }
            return listView1;
        }
    }
}

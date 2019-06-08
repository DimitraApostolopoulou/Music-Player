using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Player
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        List<string> random = new List<string>(); //lista pou xrisimopoieitai sthn tyxaia anaparagwgh
        OleDbConnection conn = new OleDbConnection();
        int rand;//metavlhth gia thn tyxaia anaparagwgh gia to kathe tragudi

        //ftiaxno antikeimena ton klaseon prop kai lsong
        prop object_properties = new prop();
        lsong object_load_songs = new lsong();
        public Form1()
        {
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Database1.mdb";
            //ta tragudia ths listas ta vazo sthn lista tis tuxaias anaparagoghs
            random.Add("Imagine Dragons - Believer.mp3");
            random.Add("Kaleo - No Good.mp3");
            random.Add("Kaleo - Way Down We Go.mp3");
            random.Add("Taylor Swift - Look What You Made Me Do.mp3");
            random.Add("twenty one pilots- Stressed Out.mp3");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Top_songs(); //gia na fortosei apo thn arxi ta top 5 tragoudia 
        }
        //sinartisi gia top tragoudia
        private void Top_songs()
        {
            conn.Open();
            string query = "SELECT Song_name from table1 order by Frequency desc";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader rdr = cmd.ExecuteReader();
            string[] t = new string[5]; //string pou periexei tis plirofories gia ta top 5 tragoudia 
            int i = 0; //deiktis
            while (rdr.Read())
            {
                //apo tn sthlh 0 pu exei ta onomata tu tragudiu
                t[i] = rdr.GetString(0);
                //paw stn apo katw sthlh k deixnw ta label me tn seira pu einai
                i = i + 1;
            }
            //vazw sta label to tragudi me tis perissoteres provoles
            label7.Text = t[0];
            label8.Text = t[1];
            label9.Text = t[2];
            label10.Text = t[3];
            label11.Text = t[4];
            conn.Close();
        }
        //sunartisi gia na apothikeuo sthn vash thn suxnothta anaparagoghs tou tragoudiou 
        private void fr(string song_name)
        {
            conn.Open();
            //otan paththei to button play tu kathe tragudiu ayksanw thn syxnothta kata 1
            string query = "UPDATE table1  SET Frequency = Frequency+1  where Song_name ='" + song_name + "'";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader rdr = cmd.ExecuteReader();
            conn.Close();
        }
        //to play tou protou tragoudiou 
        //se kathe play auksanete h suxnothta anaparagoghs kathos kaleitai kai h top songs gia na ananeonete h lista
        //kai to rand apokta thn timh 1 oste na kserei pos na kanei shuffle 
        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "Imagine Dragons - Believer.mp3";
            rand = 1;
            fr("Imagine Dragons - Believer");
            Top_songs();
        }
        //to play tou deuterou tragoudiou
        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "Kaleo - No Good.mp3";
            rand = 1;
            fr("Kaleo - No Good");
            Top_songs();
        }
        //to play tou tritou tragoudiou
        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "Kaleo - Way Down We Go.mp3";
            rand = 1;
            fr("Kaleo - Way Down We Go");
            Top_songs();
        }
        //to play tou tetartou tragoudiou
        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "Taylor Swift - Look What You Made Me Do.mp3";
            rand = 1;
            fr("Taylor Swift - Look What You Made Me Do");
            Top_songs();
        }
        //to play tou pemptou tragoudiou
        private void button9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "twenty one pilots- Stressed Out.mp3";
            rand = 1;
            fr("twenty one pilots- Stressed Out");
            Top_songs();
        }
        private void show_Textbox(Boolean a)
        {
            label12.Visible = a;
            label13.Visible = a;
            label14.Visible = a;
            label15.Visible = a;
            button13.Visible = a;
            button14.Visible = a;
            panel6.Visible = a;
            textBox1.Visible = a;
            textBox2.Visible = a;
            textBox3.Visible = a;
            textBox4.Visible = a;
        }
        //gia na kano edit to proto tragoudi 
        private void button2_Click(object sender, EventArgs e)
        {
            show_Textbox(true);
            fill_textbox("Imagine Dragons - Believer");
        }
        //gia na kano edit to deutero tragoudi 
        private void button4_Click(object sender, EventArgs e)
        {
            show_Textbox(true);
            fill_textbox("Kaleo - No Good");
        }
        //gia na kano edit to trito tragoudi 
        private void button6_Click(object sender, EventArgs e)
        {
            show_Textbox(true);
            fill_textbox("Kaleo - Way Down We Go");
        }
        //gia na kano edit to teterto tragoudi
        private void button8_Click(object sender, EventArgs e)
        {
            show_Textbox(true);
            fill_textbox("Taylor Swift - Look What You Made Me Do");
        }
        //gia na kano edit to pempto tragoudi
        private void button10_Click(object sender, EventArgs e)
        {
            show_Textbox(true);
            fill_textbox("twenty one pilots- Stressed Out");
        }
        string c;
        //gia na paiksei to tragoudi pou exoume anoiksei 
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                //subItems[1]=diadromh tu tragudiou(kolwna 1) ,kai focusedItem einai to epilegmeno tragudi sto listview
                c = listView1.FocusedItem.SubItems[1].Text;
                axWindowsMediaPlayer1.URL = c;
            }
        }
        //gia na diagrapso to tragoudi pou exoume anoiksei
        private void button11_Click(object sender, EventArgs e)
        {
            //kalo to antikeimeno pou eftiaksa sthn arxh pou einai tis prop klashs
            object_properties.delete(listView1);
        }
        //gia na emfanizei sto richtextbox tis plhrofories tou tragoudiou pou paizei 
        private void button12_Click(object sender, EventArgs e)
        {
            string songn = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);
            conn.Open();
            //vriskw se poia grammh apo tn access to onoma tu tragudiu antistoixei sto song name
            string query = "SELECT * from table1 where Song_name ='" + songn + "'";
            //ftiaxnw pada ena antikeimeno!
            OleDbCommand cmd = new OleDbCommand(query, conn);
            //gia na ta diavasw apo tn vash
            OleDbDataReader rdr = cmd.ExecuteReader();

            //oso diavazeis apo tn vash
            while (rdr.Read())
            {
                richTextBox1.Text = "Artist's Name: " + rdr.GetString(1) + Environment.NewLine + "Year: " + rdr.GetInt32(2) + Environment.NewLine + "Genre: " + rdr.GetString(3) + Environment.NewLine + "Language: " + rdr.GetString(4);
            }
            conn.Close();
        }
        Boolean song = false;
        string p;
        //event pu to xrisimopoiw  gia na paizei apeythias(xwris na pathsw play)to epomeno tragudi
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //an ftasei sto telos tu tragudiu
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                if (checkBox1.Checked)
                {
                    //to Next mu vgazei enan tyxaio akeraio
                    int next = r.Next(random.Count);
                    p = random[next];
                    axWindowsMediaPlayer1.URL = p;
                    song = true;
                }
                //h periptwsh opu den exume tyxaia anaparagwgh,kai me ayton ton tropo paizei synexomena to ena tragudi meta to allo
                if (!checkBox1.Checked)
                {
                    if (rand == 1)
                    {
                        axWindowsMediaPlayer1.URL = "Kaleo - No Good.mp3";
                        rand = 2;
                    }
                    else if (rand == 2)
                    {
                        axWindowsMediaPlayer1.URL = "Kaleo - Way Down We Go.mp3";
                        rand = 3;
                    }
                    else if (rand == 3)
                    {
                        axWindowsMediaPlayer1.URL = "Taylor Swift - Look What You Made Me Do.mp3";
                        rand = 4;
                    }
                    else if (rand == 4)
                    {
                        axWindowsMediaPlayer1.URL = "twenty one pilots- Stressed Out.mp3"; ;
                        rand = 4;
                    }
                    else
                    {
                        axWindowsMediaPlayer1.URL = "Imagine Dragons - Believer.mp3";
                        rand= 1;
                    }
                    song = true;
                }
            }
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsReady)
            {
                //an to allo tragudi einai true!diladi einai etoimo na paiksei tote paiksto
                if (song)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    song = false;
                }
            }
        }
        string sname = "a";
        //gia na gemisei automata ta textbox me tis plhrofories tou tragoudiou
        private void fill_textbox(string song_name)
        {
            conn.Open();
            sname = song_name;
            string query = "SELECT * from table1 where Song_name ='" + song_name + "'";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                textBox1.Text = rdr.GetString(1);
                textBox2.Text = rdr.GetInt32(2).ToString();
                textBox3.Text = rdr.GetString(3);
                textBox4.Text = rdr.GetString(4);
            }
            conn.Close();
        }
        //gia na kano update tis plhrofories pou allaksa sthn vash 
        private void button13_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE table1  SET Artists_name = '" + textBox1.Text + "',Etos='" + textBox2.Text + "',Genre='" + textBox3.Text + "',Lang='" + textBox4.Text + "' where Song_name ='" + sname + "'";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader rdr = cmd.ExecuteReader();
            conn.Close();
            MessageBox.Show("The changes you made are saved!");
            show_Textbox(false);
        }
        //gia na kleiso to panel me ta textbox
        private void button14_Click(object sender, EventArgs e)
        {
            show_Textbox(false);
        }
        //gia na fortoso tragoudia sto listview
        private void loadSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1 = object_load_songs.l(listView1); //kalo to antikeimeno pou ftiaksame noritera gia thn klasi lsong
        }

        private void playAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //oi 2 aytes entoles einai gia na prosthesun ta kommatia apo to multiselect pu einai stn listview sto windows media player kai na borun na paizun ta kommatia
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("tragudia");
            WMPLib.IWMPMedia media;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                int k = 1;
                //vazw ta tragudia stn playlist 
                media = axWindowsMediaPlayer1.newMedia(listView1.Items[i].SubItems[k].Text);
                //vazw +1 kommati stn lista kathe fora
                playlist.appendItem(media);
                k++;
                axWindowsMediaPlayer1.currentPlaylist = playlist;
                //patietai apeythias to play gia to epomeno tragudi
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
        //gia na diagrapso tragoudi apo to listview
        private void deleteSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object_properties.delete(listView1); //kalo to antikeimeno pou ftiaksame pio prin gia thn prop klash
        }
        //gia na kleisei h efarmogi
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

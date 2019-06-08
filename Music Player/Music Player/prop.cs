using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Player
{
    class prop
    {
        //gia na diagrapso tragoudi apo to listview
        public void delete(ListView listView1)
        {
            if (MessageBox.Show("Είστε σίγουρος;", "Διαγραφή", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //to selectedIndices pairnei to deikth tu pinaka pu vrisketai to sigkekrimeno tragudi pu thelw na svhsw
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
        }
    }
}

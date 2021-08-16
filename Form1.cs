using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Initiative_Service
{
    public partial class mainWindow : Form
    {
        DataTable characters = new DataTable();
        DataColumn column;
        DataRow row;
        DataView view;

        public mainWindow()
        {
            InitializeComponent();



            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            characters.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "iniBonus";
            characters.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Roll";
            characters.Columns.Add(column);

            row = characters.NewRow();
            row["Name"] = "Bharmir";
            row["iniBonus"] = -1;
            row["Roll"] = 0;
            characters.Rows.Add(row);
            row = characters.NewRow();
            row["Name"] = "Leygolass";
            row["iniBonus"] = 3;
            row["Roll"] = 0;
            characters.Rows.Add(row);
            row = characters.NewRow();
            row["Name"] = "Jennifer";
            row["iniBonus"] = 3;
            row["Roll"] = 0;
            characters.Rows.Add(row);
            row = characters.NewRow();
            row["Name"] = "Caedwyth";
            row["iniBonus"] = 0;
            row["Roll"] = 0;
            characters.Rows.Add(row);
            row = characters.NewRow();
            row["Name"] = "Malon";
            row["iniBonus"] = 0;
            row["Roll"] = 0;
            characters.Rows.Add(row);

            view = new DataView(characters);
            dataGridViewMain.DataSource = view;


        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            Random d20 = new Random();
            int i = 0;
            foreach (DataRow row  in characters.Rows)
            {
               
                int rolled = d20.Next(1, 20);
                int initiative = characters.Rows[i].Field<int>("iniBonus");
                row["Roll"] = (rolled + initiative);
                i++;
            }
        }
    }
}

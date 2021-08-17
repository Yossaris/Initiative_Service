using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Initiative_Service
{
    public partial class mainWindow : Form
    {
        System.Data.DataTable initiativeOrder = new System.Data.DataTable();
        DataColumn column;
        DataRow row;
        DataView view;
        bool ally;
        
        public mainWindow()
        {
            InitializeComponent();

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            initiativeOrder.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "iniBonus";
            initiativeOrder.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Roll";
            initiativeOrder.Columns.Add(column);

            row = initiativeOrder.NewRow();
            row["Name"] = "Bharmir";
            row["iniBonus"] = -1;
            row["Roll"] = 0;
            initiativeOrder.Rows.Add(row);
            row = initiativeOrder.NewRow();
            row["Name"] = "Leygolass";
            row["iniBonus"] = 3;
            row["Roll"] = 0;
            initiativeOrder.Rows.Add(row);
            row = initiativeOrder.NewRow();
            row["Name"] = "Jennifer";
            row["iniBonus"] = 3;
            row["Roll"] = 0;
            initiativeOrder.Rows.Add(row);
            row = initiativeOrder.NewRow();
            row["Name"] = "Caedwyth";
            row["iniBonus"] = 0;
            row["Roll"] = 0;
            initiativeOrder.Rows.Add(row);
            row = initiativeOrder.NewRow();
            row["Name"] = "Malon";
            row["iniBonus"] = 0;
            row["Roll"] = 0;
            initiativeOrder.Rows.Add(row);

            view = new DataView(initiativeOrder);
            dataGridViewMain.DataSource = view;


        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            Random d20 = new Random();
            int i = 0;
            foreach (DataRow row  in initiativeOrder.Rows)
            {
               
                int rolled = d20.Next(1, 20);
                int initiative = initiativeOrder.Rows[i].Field<int>("iniBonus");
                row["Roll"] = (rolled + initiative);
                i++;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            initiativeOrder.Clear();
        }

        private void buttonAlly_Click(object sender, EventArgs e)
        {
            ally = true;
            DataRow Row;
            var addDialog = new AddForm(ally);
            var dialogResult = addDialog.ShowDialog();
            foreach (DataRow row in addDialog.addedToInitiative.Rows)
            {
                Row = initiativeOrder.NewRow();
                Row["Name"] = row["name"];
                Row["iniBonus"] = row["iniBonus"];
                initiativeOrder.Rows.Add(Row);
            }
        }

        private void buttonFoe_Click(object sender, EventArgs e)
        {
            ally = false;
            DataRow Row;
            var addDialog = new AddForm(ally);
            var dialogResult = addDialog.ShowDialog();
            foreach (DataRow row in addDialog.addedToInitiative.Rows)
            {
                Row = initiativeOrder.NewRow();
                Row["Name"] = row["name"];
                Row["iniBonus"] = row["iniBonus"];
                initiativeOrder.Rows.Add(Row);
            }
        }
    }
}

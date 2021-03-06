using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Initiative_Service
{
    public partial class AddForm : Form
    {
        public DataTable addedToInitiative = new DataTable(); 
        DataTable allyList = new DataTable();
        DataColumn column;
        DataRow row;
        DataView view;
        int addCount;
        public AddForm(bool alignment)
        {
            InitializeComponent();
            addCount = 0;
            if (alignment == true)
            {
                
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Name";
                allyList.Columns.Add(column);
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "iniBonus";
                allyList.Columns.Add(column);


                row = allyList.NewRow();
                row["Name"] = "Bharmir";
                row["iniBonus"] = -1;
                allyList.Rows.Add(row);

                row = allyList.NewRow();
                row["Name"] = "Leygolass";
                row["iniBonus"] = 3;
                allyList.Rows.Add(row);

                row = allyList.NewRow();
                row["Name"] = "Jennifer";
                row["iniBonus"] = 3;
                allyList.Rows.Add(row);

                row = allyList.NewRow();
                row["Name"] = "Caedwyth";
                row["iniBonus"] = 0;
                allyList.Rows.Add(row);

                row = allyList.NewRow();
                row["Name"] = "Malon";
                row["iniBonus"] = 0;
                allyList.Rows.Add(row);

                view = new DataView(allyList);

                dataGridViewAdd.DataSource = view;
               
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (addedToInitiative.Columns.Count == 0)
            {
                foreach (DataGridViewColumn column in dataGridViewAdd.Columns)
                    addedToInitiative.Columns.Add(column.Name);
            }

            for (int i = 0; i < dataGridViewAdd.SelectedRows.Count; i++)
            {
                addedToInitiative.Rows.Add();
                for (int j = 0; j < dataGridViewAdd.Columns.Count; j++)
                {
                    addedToInitiative.Rows[i+addCount][j] = dataGridViewAdd.SelectedRows[i].Cells[j].Value;
                    //^^^^^^^^^^^
                }
                
            }
            SendDataTable(addedToInitiative);
            addCount++;
        }

        public DataTable SendDataTable(DataTable dt)
        {
            return addedToInitiative;
        }
    }
}

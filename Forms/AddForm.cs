using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Initiative_Service
{
    public partial class AddForm : Form
    {
        public DataTable addedToInitiative = new DataTable(); 
        DataTable allyList = new DataTable();
        DataTable foeList = new DataTable();
        DataColumn column;
        DataRow row;
        DataView view;
        int addCount;

        public AddForm(bool alignment)
        {
            InitializeComponent();
            addCount = 0;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            allyList.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "iniBonus";
            allyList.Columns.Add(column);
            if (alignment == true)
            {               
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
            else
            {
                foeList = ParseMonsters();
                view = new DataView(foeList);
                dataGridViewAdd.DataSource = view;

            }
        }
        public DataTable ParseMonsters()
        {
            int i = 0;
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"D&D 5e Monster List with Ability Scores.xlsx");
            //var file = @"C:\Users\Chris\Desktop\TestSheet.xls";
            Console.WriteLine(file);

            Excel.Application excel = new Excel.Application();
            Excel.Workbook wkb = excel.Workbooks.Open(file);

            Excel.Worksheet sheet = wkb.Sheets[1] as Excel.Worksheet;

            Excel.Range range1 = sheet.get_Range("A2", Missing.Value);
            Excel.Range range2 = sheet.get_Range("B2", Missing.Value);

            
            foreach (Excel.Range r in range1)
            {
                row = foeList.NewRow();
                row["Name"] = r.Text;
                foeList.Rows.Add(row);

            };
            foreach (Excel.Range r in range2)
            {
                row = foeList.Rows[i];
                row["iniBonus"] = r.Text;
                foeList.Rows.Add(row);
                i++;
            }
            return foeList;
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
            addCount= addCount + dataGridViewAdd.SelectedRows.Count;
        }

        public DataTable SendDataTable(DataTable dt)
        {
            return addedToInitiative;
        }
    }
}

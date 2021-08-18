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
using Syncfusion.XlsIO;

namespace Initiative_Service
{
    public partial class AddForm : Form
    {
        public DataTable addedToInitiative = new DataTable();
        DataTable characterList = new DataTable();
        DataTable allyList = new DataTable();
        DataTable foeList = new DataTable();
        DataView view;
        int addCount;
        string? _oldSearch;
        List<int>? _cells;
        int _searchIndex;

        public AddForm(bool alignment)
        {
            InitializeComponent();
            addCount = 0;

            if (alignment == true)
            {
                ParseAllies();

                //view = new DataView(allyList);

                //dataGridViewAdd.DataSource = view;             
            }
            else
            {
                ParseMonsters();

            }
                view = new DataView(characterList);
                dataGridViewAdd.DataSource = view;
        }
        public void ParseAllies()
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;

            FileStream inputStream = new FileStream("Player Characters.xlsx", FileMode.Open, FileAccess.Read);
            IWorkbook workbook = application.Workbooks.Open(inputStream);
            IWorksheet worksheet = workbook.Worksheets[0];
            characterList = worksheet.ExportDataTable(1, 1, 6, 2, ExcelExportDataTableOptions.ColumnNames);

        }
        public void ParseMonsters()
        {


            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;

            FileStream inputStream = new FileStream("D&D 5e Monster List with Ability Scores.xlsx", FileMode.Open, FileAccess.Read);
            IWorkbook workbook = application.Workbooks.Open(inputStream);
            IWorksheet worksheet = workbook.Worksheets[0];
            characterList = worksheet.ExportDataTable(1, 1, 429, 2, ExcelExportDataTableOptions.ColumnNames);
            foreach (DataRow row in characterList.Rows)
            {
                //var dex = row["iniBonus"];
                //if(row["iniBonus"])

                switch (row["iniBonus"])
                {
                    case "1":
                        row["iniBonus"] = -5;
                        break;
                    case "2":
                    case "3":
                        row["iniBonus"] = -4;
                        break;
                    case "4":
                    case "5":
                        row["iniBonus"] = -3;
                        break;
                    case "6":
                    case "7":
                        row["iniBonus"] = -2;
                        break;
                    case "8":
                    case "9":
                        row["iniBonus"] = -1;
                        break;
                    case "10":
                    case "11":
                        row["iniBonus"] = 0;
                        break;
                    case "12":
                    case "13":
                        row["iniBonus"] = 1;
                        break;
                    case "14":
                    case "15":
                        row["iniBonus"] = 2;
                        break;
                    case "16":
                    case "17":
                        row["iniBonus"] = 3;
                        break;
                    case "18":
                    case "19":
                        row["iniBonus"] = 4;
                        break;
                    case "20":
                    case "21":
                        row["iniBonus"] = 5;
                        break;
                    case "22":
                    case "23":
                        row["iniBonus"] = 6;
                        break;
                    case "24":
                    case "25":
                        row["iniBonus"] = 7;
                        break;
                    case "26":
                    case "27":
                        row["iniBonus"] = 8;
                        break;
                    case "28":
                    case "29":
                        row["iniBonus"] = 9;
                        break;
                    case "30":
                        row["iniBonus"] = 10;
                        break;
                    default:
                        row["iniBonus"] = "no Initiative";
                        break;
                        
                }
                    
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
            addCount= addCount + dataGridViewAdd.SelectedRows.Count;
        }

        public DataTable SendDataTable(DataTable dt)
        {
            return addedToInitiative;
        }
        public List<int> SearchCell(string searchText, DataGridView grid)
        {
            var results = new List<int>();
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().ToLower().Contains(searchText))
                    {
                        results.Add(grid.Rows[row.Index].Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return results;
        }

        public int CycleCell(List<int> data, int index)
        {
            return data[index];
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchValue = searchTextBox.Text.ToLower();
            if (_oldSearch != searchValue)
            {
                _cells = SearchCell(searchValue, dataGridViewAdd);
                if (_cells.Count == 0)
                {
                    MessageBox.Show($"\"{searchValue}\" not found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //searchTextBox.Text = string.Empty;
                    return;
                }
                _searchIndex = 0;
                _oldSearch = searchValue;
                dataGridViewAdd.Rows[CycleCell(_cells, _searchIndex)].Selected = true;
                dataGridViewAdd.CurrentCell = dataGridViewAdd.SelectedRows[0].Cells[0];
                _searchIndex++;
                if (_searchIndex == _cells.Count)
                {
                    _searchIndex = 0;
                }
            }
            else if (_cells != null)
            {
                dataGridViewAdd.Rows[CycleCell(_cells, _searchIndex)].Selected = true;
                dataGridViewAdd.CurrentCell = dataGridViewAdd.SelectedRows[0].Cells[0];
                _searchIndex++;
                if (_searchIndex == _cells.Count)
                {
                    _searchIndex = 0;
                }
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = true;
            if (searchTextBox.Text == string.Empty)
            {
                searchButton.Enabled = false;
            }
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}

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
        private BindingSource characters = new BindingSource();

        private class Character
        {
            private string characterName;
            private int bonus;
            private int d20Roll;


            public Character(string name, int iniBonus, int roll)
            {

                characterName = name;
                bonus = iniBonus;
                d20Roll = roll;

            }

            public string name
            {
                get
                {
                    return characterName;
                }

                set
                {
                    characterName = value;
                }
            }

            public int iniBonus
            {
                get
                {
                    return bonus;
                }
                set
                {
                    bonus = value;
                }
            }

            public int roll
            {
                get
                {
                    return d20Roll;
                }
                set
                {
                    d20Roll = value;
                }
            }


        }

        public mainWindow()
        {
            InitializeComponent();
            characters.Add(new Character("Bharmir", -1, 1));
            characters.Add(new Character("Leygolass", 3, 1));
            characters.Add(new Character("Jennifer", 3, 1));
            characters.Add(new Character("Caedwyth", 0, 1));
            characters.Add(new Character("Malon", 0, 1));

            
            dataGridViewMain.AutoGenerateColumns = false;
            dataGridViewMain.DataSource = characters;


            // Initialize and add a text box column.
            //DataGridViewColumn columnName = new DataGridViewTextBoxColumn();
            //columnName.DataPropertyName = "name";
            //columnName.Name = "Name";
            //dataGridViewMain.Columns.Add(columnName);

            //DataGridViewColumn columnBonus = new DataGridViewTextBoxColumn();
            //columnBonus.DataPropertyName = "iniBonus";
            //columnBonus.Name = "Ini Bonus";
            //dataGridViewMain.Columns.Add(columnBonus);

            //DataGridViewColumn columnRoll = new DataGridViewTextBoxColumn();
            //columnRoll.DataPropertyName = "roll";
            //columnRoll.Name = "Roll";
            //dataGridViewMain.Columns.Add(columnRoll);

        }
 
        
    }
}

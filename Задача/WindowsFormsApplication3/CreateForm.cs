using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class CreateForm : Form
    {
        private Form1 MainForm;
        private bool IsAddForm = false;
        private int EditRowId;
        private TableStorage Storage;

        public CreateForm(Form1 mainForm)
        {
            MainForm = mainForm;
            InitializeComponent();
        }

        public void SetAddForm(TableStorage storage, int rowLastId)
        {
            this.Text = "Добавить";
            this.IsAddForm = true;
            this.Storage = storage;
            this.EditRowId = rowLastId;
            idTextbox.Text = this.EditRowId.ToString();
        }

        public void SetEditForm(TableStorage storage, int rowId)
        {
            this.Text = "Редактировать";
            this.IsAddForm = false;
            this.Storage = storage;
            this.EditRowId = rowId;

            var row = storage.DataTable.Rows[rowId];
            idTextbox.Text = row["id"].ToString();
            nameTextbox.Text = row["doc_name"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsAddForm)
            {
                Storage.DataTable.Rows.Add(Convert.ToInt32(idTextbox.Text), nameTextbox.Text);
                this.Close();
            }
            else
            {
                Storage.DataTable.Rows[EditRowId].SetField("id", Convert.ToInt32(idTextbox.Text));
                Storage.DataTable.Rows[EditRowId].SetField("doc_name", nameTextbox.Text);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
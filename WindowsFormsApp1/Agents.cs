using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Agents : Form
    {
        public Agents()
        {
            InitializeComponent();
            ShowlistView();
        }

        void ShowlistView()
        {
            listView.Items.Clear();

            foreach (AgentsSet agents in Program.RPE.AgentsSet)
            {
                ListViewItem item = new ListViewItem(new string[] { agents.FirstName.ToString(), agents.MiddleName.ToString(), agents.LastName.ToString(), agents.DealShare.ToString() });
                item.Tag = agents;
                listView.Items.Add(item);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxDealShare.Text != "" && textBoxLastName.Text != "" && textBoxMiddleName.Text != "" && textBoxName.Text != "")
            {
                AgentsSet agents = new AgentsSet();

                agents.FirstName = textBoxName.Text;
                agents.MiddleName = textBoxMiddleName.Text;
                agents.LastName = textBoxLastName.Text;
                agents.DealShare = textBoxDealShare.Text;
                Program.RPE.AgentsSet.Add(agents);
                Program.RPE.SaveChanges();

                textBoxDealShare.Text = "";
                textBoxLastName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxName.Text = "";

                ShowlistView();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                AgentsSet agentsSet = listView.SelectedItems[0].Tag as AgentsSet;

                agentsSet.FirstName = textBoxName.Text;
                agentsSet.MiddleName = textBoxMiddleName.Text;
                agentsSet.LastName = textBoxLastName.Text;
                agentsSet.DealShare = textBoxDealShare.Text;

                Program.RPE.SaveChanges();
                ShowlistView();
            }
            else
            {
                textBoxName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxLastName.Text = "";
                textBoxDealShare.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count == 1)
                {
                    AgentsSet agentsSet = listView.SelectedItems[0].Tag as AgentsSet;

                    Program.RPE.AgentsSet.Remove(agentsSet);

                    Program.RPE.SaveChanges();

                    ShowlistView();
                }
                textBoxDealShare.Text = "";
                textBoxLastName.Text = "";
                textBoxMiddleName.Text = "";
                textBoxName.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

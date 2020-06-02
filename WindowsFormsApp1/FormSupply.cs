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
    public partial class FormSupply : Form
    {
        public FormSupply()
        {
            InitializeComponent();
            ShowAgents();
            ShowClients();
            ShowRealEstate();
            ShowSupplySet();
        }

        void ShowAgents()
        {
            comboBoxAgents.Items.Clear();
            foreach (AgentsSet agentsSet in Program.RPE.AgentsSet)
            {
                string[] item = { agentsSet.id.ToString() + ". ", agentsSet.FirstName, agentsSet.MiddleName, agentsSet.LastName };
                comboBoxAgents.Items.Add(string.Join("", item));
            }
        }
        void ShowClients()
        {
            comboBoxClients.Items.Clear();
            foreach (ClientsSet clientsSet in Program.RPE.ClientsSet)
            {
                string[] item = { clientsSet.id.ToString() + ". ", clientsSet.FirstName, clientsSet.MiddleName, clientsSet.LastName };
                comboBoxClients.Items.Add(string.Join(" ", item));
            }
        }
        void ShowRealEstate()
        {
            comboBoxRealEstate.Items.Clear();
            foreach (RealEstateSet realEstateSet in Program.RPE.RealEstateSet)
            {
                string[] item = { realEstateSet.id.ToString() + ". ", realEstateSet.Address_City + ",", realEstateSet.Address_Street + ",", "д. " + realEstateSet.Address_House + ",", "кв. " + realEstateSet.Address_Numder };
                comboBoxRealEstate.Items.Add(string.Join(" ", item));
            }
        }
        void ShowSupplySet()
        {
            listViewSupplySet.Items.Clear();

            foreach (SupplySet supply in Program.RPE.SupplySet)
            {
                ListViewItem item = new ListViewItem(new string[] {
                    supply.idAgent.ToString(),
                    supply.AgentsSet.LastName + " " + supply.AgentsSet.FirstName + " " + supply.AgentsSet.MiddleName,
                    supply.idClient.ToString(),
                    supply.ClientsSet.LastName+" "+ supply.ClientsSet.FirstName+" "+supply.ClientsSet.MiddleName,
                    supply.idRealEstate.ToString(),
                    "г. "+ supply.RealEstateSet.Address_City+", ул. "+supply.RealEstateSet.Address_Street + ", д. "+ supply.RealEstateSet.Address_House+", кв. "+supply.RealEstateSet.Address_Numder,
                    supply.Price.ToString()

                });
                item.Tag = supply;
                listViewSupplySet.Items.Add(item);
                listViewSupplySet.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (comboBoxAgents.SelectedItem != null && comboBoxClients.SelectedItem != null && comboBoxRealEstate != null && textBoxPrice.Text != "")
            {
                SupplySet supply = new SupplySet();

                supply.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                supply.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                supply.idRealEstate = Convert.ToInt32(comboBoxRealEstate.SelectedItem.ToString().Split('.')[0]);
                supply.Price = Convert.ToInt64(textBoxPrice.Text);
                Program.RPE.SupplySet.Add(supply);
                Program.RPE.SaveChanges();
                ShowSupplySet();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewSupplySet.SelectedItems.Count == 1)
            {
                SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;

                supply.idAgent = Convert.ToInt32(comboBoxAgents.SelectedItem.ToString().Split('.')[0]);
                supply.idClient = Convert.ToInt32(comboBoxClients.SelectedItem.ToString().Split('.')[0]);
                supply.idRealEstate = Convert.ToInt32(comboBoxRealEstate.ToString().Split('.')[0]);
                supply.Price = Convert.ToInt64(textBoxPrice.Text);
                Program.RPE.SaveChanges();
                ShowSupplySet();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewSupplySet.SelectedItems.Count == 1)
                {
                    SupplySet supply = listViewSupplySet.SelectedItems[0].Tag as SupplySet;
                    Program.RPE.SupplySet.Remove(supply);
                    Program.RPE.SaveChanges();
                    ShowSupplySet();
                }
                comboBoxAgents.SelectedItem = null;
                comboBoxClients.SelectedItem = null;
                comboBoxRealEstate.SelectedItem = null;
                textBoxPrice.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
    public partial class Сделки : Form
    {
        public Сделки()
        {
            InitializeComponent();
            ShowSupply();
            ShowDemand();
            ShowDealSet();
        }
        void ShowSupply()
        {
            comboBoxSupply.Items.Clear();
            foreach (SupplySet supplySet in Program.RPE.SupplySet)
            {
                string[] item = { supplySet.id.ToString() + ". ", "Риелтор: " + supplySet.AgentsSet.LastName, "Клиент: " + supplySet.ClientsSet.LastName };
                comboBoxSupply.Items.Add(string.Join(" ", item));
            }
        }
        void ShowDemand()
        {
            comboBoxDemand.Items.Clear();
            foreach (DemandSet demandSet in Program.RPE.DemandSet)
            {
                string[] item = { demandSet.id.ToString() + ". ", "Риелтор: " + demandSet.AgentsSet.LastName, "Клиент: " + demandSet.ClientsSet.LastName };
                comboBoxDemand.Items.Add(string.Join(" ", item));
            }
        }
        void Deductions()
        {
            if (comboBoxSupply.SelectedItem != null && comboBoxDemand.SelectedItem != null)
            {
                SupplySet supplySet = Program.RPE.SupplySet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                DemandSet demandSet = Program.RPE.DemandSet.Find(Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]));
                double customerCompanyDeductions = supplySet.Price * 0.03;
                textCustomerCompanyDeductions.Text = customerCompanyDeductions.ToString("0.00");

                if (demandSet.AgentsSet.DealShare != null)
                {
                    double agentCustomerDeductions = customerCompanyDeductions * Convert.ToDouble(demandSet.AgentsSet.DealShare) / 100.00;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDeductions.ToString("0.00");
                }
                else
                {
                    double agentCustomerDeductions = customerCompanyDeductions * 0.45;
                    textBoxAgentCustomerDeductions.Text = agentCustomerDeductions.ToString("0.00");
                }
            }
            else
            {
                textCustomerCompanyDeductions.Text = "";
                textBoxAgentCustomerDeductions.Text = "";
            }
            if(comboBoxSupply.SelectedItem != null)
            {
                SupplySet supplySet = Program.RPE.SupplySet.Find(Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]));
                double sellerCompanyDeductions;
                if(supplySet.RealEstateSet.Type == 0)
                {
                    sellerCompanyDeductions = 36000 + supplySet.Price * 0.01;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                else if(supplySet.RealEstateSet.Type == 1)
                {
                    sellerCompanyDeductions = 30000 + supplySet.Price * 0.01;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }
                else
                {
                    sellerCompanyDeductions = 30000 + supplySet.Price * 0.02;
                    textBoxSellerCompanyDeductions.Text = sellerCompanyDeductions.ToString("0.00");
                }

                if(supplySet.AgentsSet.DealShare != null)
                {
                    double agentSellerDeductions = sellerCompanyDeductions * Convert.ToDouble(supplySet.AgentsSet.DealShare) / 100.00;
                    textBoxAgentSellerDeductions.Text = agentSellerDeductions.ToString("0.00");
                }
                else
                {
                    double agentSellerDeductins = sellerCompanyDeductions * 0.45;
                    textBoxAgentSellerDeductions.Text = agentSellerDeductins.ToString("0.00");
                }
            }
        }

        private void comboBoxSupply_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }

        private void comboBoxDemand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deductions();
        }

        void ShowDealSet()
        {
            listView.Items.Clear();
            foreach(DealSet deal in Program.RPE.DealSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    deal.SupplySet.ClientsSet.LastName,
                    deal.SupplySet.AgentsSet.LastName,
                    deal.DemandSet.ClientsSet.LastName,
                    deal.DemandSet.AgentsSet.LastName,
                    "г. "+deal.SupplySet.RealEstateSet.Address_City+", ул. "+deal.SupplySet.RealEstateSet.Address_Street+", д. "+deal.SupplySet.Price.ToString(),
                    deal.SupplySet.Price.ToString()
                });
                item.Tag = deal;
                listView.Items.Add(item);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxDemand.SelectedItem != null && comboBoxSupply.SelectedItem != null)
            {
                DealSet deal = new DealSet();
                deal.idSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                deal.idDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);
                Program.RPE.DealSet.Add(deal);
                Program.RPE.SaveChanges();
                ShowDealSet();
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                DealSet deal = listView.SelectedItems[0].Tag as DealSet;
                deal.idSupply = Convert.ToInt32(comboBoxSupply.SelectedItem.ToString().Split('.')[0]);
                deal.idDemand = Convert.ToInt32(comboBoxDemand.SelectedItem.ToString().Split('.')[0]);

                Program.RPE.SaveChanges();
                ShowDealSet();
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView.SelectedItems.Count == 1)
            {
                DealSet deal = listView.SelectedItems[0].Tag as DealSet;
                comboBoxSupply.SelectedIndex = comboBoxSupply.FindString(deal.idSupply.ToString());
                comboBoxDemand.SelectedIndex = comboBoxDemand.FindString(deal.idDemand.ToString());
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if(listView.SelectedItems.Count == 1)
                {
                    DealSet deal = listView.SelectedItems[0].Tag as DealSet;
                    Program.RPE.DealSet.Remove(deal);
                    Program.RPE.SaveChanges();
                    ShowDealSet();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

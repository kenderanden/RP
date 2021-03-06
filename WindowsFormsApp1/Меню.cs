﻿using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            if (FormAuthorization.users.type == "agent") buttonOpenAgents.Enabled = false;
            labelHello.Text = "Приветствую тебя, " + FormAuthorization.users.login;
        }

        private void buttonOpenClients_Click(object sender, EventArgs e)
        {
            Form formClient = new Клиент();
            formClient.Show();
        }

        private void buttonOpenAgents_Click(object sender, EventArgs e)
        {
            Form formClient = new Agents();
            formClient.Show();
        }

        private void buttonOpenDemands_Click(object sender, EventArgs e)
        {
            Form formSupply = new FormSupply();
            formSupply.Show();
        }

        private void buttonOpenRealEstate_Click(object sender, EventArgs e)
        {
            Form formClient = new Объекты_недвижимости();
            formClient.Show();
        }

        private void buttonOpenSupplies_Click(object sender, EventArgs e)
        {
            Form formClient = new Потребности();
            formClient.Show();
        }

        private void buttonOpenDeals_Click(object sender, EventArgs e)
        {
            Form formClient = new Сделки();
            formClient.Show();
        }
    }
}

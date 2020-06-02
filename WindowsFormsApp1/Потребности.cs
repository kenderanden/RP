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
    public partial class Потребности : Form
    {
        public Потребности()
        {
            InitializeComponent();
            ShowClient();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DemandSet demandSet = new DemandSet();

            demandSet.idAgent = Convert.ToInt32(textBoxidAgent.Text);
            demandSet.idClient = Convert.ToInt32(textBoxidClient.Text);
            demandSet.Type = textboxType.Text;
            demandSet.MinPrice = Convert.ToInt32(PriceMin.Text);
            demandSet.MaxPrice = Convert.ToInt32(PriceMax.Text);
            demandSet.MinArea = Convert.ToInt32(AreaMin.Text);
            demandSet.MaxArea = Convert.ToInt32(AreaMax.Text);
            demandSet.MinRooms = Convert.ToInt32(RoomsMin.Text);
            demandSet.MaxRooms = Convert.ToInt32(RoomsMax.Text);
            demandSet.MinFloor = Convert.ToInt32(FloorMin.Text);
            demandSet.MaxFloor = Convert.ToInt32(FloorMax.Text);
            demandSet.MinFloors = Convert.ToInt32(FloorsMin.Text);
            demandSet.MaxFloors = Convert.ToInt32(FloorsMax.Text);

            Program.RPE.DemandSet.Add(demandSet);
            Program.RPE.SaveChanges();
            ShowClient();
        }

        void ShowClient()
        {
            listView.Items.Clear();

            foreach (DemandSet demandSet in Program.RPE.DemandSet)
            {
                ListViewItem item = new ListViewItem(new string[] {
                demandSet.idAgent.ToString(),
                demandSet.idClient.ToString(),
                demandSet.Type,
                demandSet.MinPrice.ToString(),
                demandSet.MaxPrice.ToString(),
                demandSet.MinArea.ToString(),
                demandSet.MaxArea.ToString(),
                demandSet.MinRooms.ToString(),
                demandSet.MaxRooms.ToString(),
                demandSet.MinFloor.ToString(),
                demandSet.MaxFloor.ToString(),
                demandSet.MinFloors.ToString(),
                demandSet.MaxFloors.ToString()});

                item.Tag = demandSet;
                listView.Items.Add(item);
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                DemandSet demandSet = listView.SelectedItems[0].Tag as DemandSet;

                demandSet.idAgent = Convert.ToInt32(textBoxidAgent.Text);
                demandSet.idClient = Convert.ToInt32(textBoxidClient.Text);
                demandSet.Type = textboxType.Text;
                demandSet.MinPrice = Convert.ToInt32(PriceMin.Text);
                demandSet.MaxPrice = Convert.ToInt32(PriceMax.Text);
                demandSet.MinArea = Convert.ToInt32(AreaMin.Text);
                demandSet.MaxArea = Convert.ToInt32(AreaMax.Text);
                demandSet.MinRooms = Convert.ToInt32(RoomsMin.Text);
                demandSet.MaxRooms = Convert.ToInt32(RoomsMax.Text);
                demandSet.MinFloor = Convert.ToInt32(FloorMin.Text);
                demandSet.MaxFloor = Convert.ToInt32(FloorMax.Text);
                demandSet.MinFloors = Convert.ToInt32(FloorsMin.Text);
                demandSet.MaxFloors = Convert.ToInt32(FloorsMax.Text);

                Program.RPE.SaveChanges();
                ShowClient();
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                DemandSet clientsSet = listView.SelectedItems[0].Tag as DemandSet;

                textBoxidAgent.Text = clientsSet.idAgent.ToString();
                textBoxidClient.Text = clientsSet.idClient.ToString();
                textboxType.Text = clientsSet.Type;
                PriceMin.Text = clientsSet.MinPrice.ToString();
                PriceMax.Text = clientsSet.MaxPrice.ToString();
                AreaMin.Text = clientsSet.MinArea.ToString();
                AreaMax.Text = clientsSet.MaxArea.ToString();
                RoomsMin.Text = clientsSet.MinRooms.ToString();
                RoomsMax.Text = clientsSet.MaxRooms.ToString();
                FloorMin.Text = clientsSet.MinFloor.ToString();
                FloorMax.Text = clientsSet.MaxFloors.ToString();
                FloorsMin.Text = clientsSet.MinFloors.ToString();
                FloorsMax.Text = clientsSet.MaxFloors.ToString();
            }
            else
            {
                textBoxidAgent.Text = "";
                textBoxidClient.Text = "";
                textboxType.Text = "";
                PriceMin.Text = "";
                PriceMax.Text = "";
                AreaMin.Text = "";
                AreaMax.Text = "";
                RoomsMin.Text = "";
                RoomsMax.Text = "";
                FloorMin.Text = "";
                FloorMax.Text = "";
                FloorsMin.Text = "";
                FloorsMax.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count == 1)
                {
                    DemandSet demandSet = listView.SelectedItems[0].Tag as DemandSet;

                    Program.RPE.DemandSet.Remove(demandSet);

                    Program.RPE.SaveChanges();

                    ShowClient();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

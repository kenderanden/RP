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
    public partial class Объекты_недвижимости : Form
    {
        public Объекты_недвижимости()
        {
            InitializeComponent();
            ShowRealEstateSet();
        }
        private void Квартира_Click(object sender, EventArgs e)
        {
            #region визуал
            listViewRealEstateSet_Apartment.Enabled = true;
            listViewRealEstateSet_Apartment.Visible = true;

            listViewRealEstateSet_Land.Enabled = false;
            listViewRealEstateSet_Land.Visible = false;

            listViewRealEstateSet_House.Enabled = false;
            listViewRealEstateSet_House.Visible = false;



            Квартира.Enabled = false;
            Дом.Enabled = true;
            Земля.Enabled = true;

            textBoxTotalFloors.Enabled = true;
            textBoxFloor.Enabled = true;

            textBoxRooms.Enabled = false;
            textBoxRooms.Text = "";

            #endregion
            ShowRealEstateSet();
        }

        private void Дом_Click(object sender, EventArgs e)
        {
            #region визуал
            listViewRealEstateSet_Apartment.Enabled = false;
            listViewRealEstateSet_Apartment.Visible = false;

            listViewRealEstateSet_Land.Enabled = true;
            listViewRealEstateSet_Land.Visible = true;

            listViewRealEstateSet_House.Enabled = false;
            listViewRealEstateSet_House.Visible = false;


            Квартира.Enabled = true;
            Дом.Enabled = false;
            Земля.Enabled = true;

            textBoxFloor.Enabled = false;
            textBoxFloor.Text = "";
            #endregion
            ShowRealEstateSet();
        }

        private void Земля_Click(object sender, EventArgs e)
        {
            #region визуал
            listViewRealEstateSet_Apartment.Enabled = false;
            listViewRealEstateSet_Apartment.Visible = false;

            listViewRealEstateSet_Land.Enabled = false;
            listViewRealEstateSet_Land.Visible = false;

            listViewRealEstateSet_House.Enabled = true;
            listViewRealEstateSet_House.Visible = true;



            Квартира.Enabled = true;
            Дом.Enabled = true;
            Земля.Enabled = false;

            textBoxTotalFloors.Enabled = true;
            textBoxFloor.Enabled = false;
            textBoxFloor.Text = "";
            #endregion
            ShowRealEstateSet();
        }
       
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            RealEstateSet realEstate = new RealEstateSet();

            realEstate.Address_City = textBoxAddress_City.Text;
            realEstate.Address_Street = textBoxAddress_Street.Text;
            realEstate.Address_House = textBoxAddress_House.Text;
            realEstate.Address_Numder = textBoxAddress_Number.Text;
            realEstate.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
            realEstate.Coordinate_longitude = Convert.ToDouble(textBoxCoordinate_longitude.Text);
            realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);


            if (Квартира.Enabled == false)
            {
                realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);

                Program.RPE.RealEstateSet.Add(realEstate);
                Program.RPE.SaveChanges();
            }
            else if (Дом.Enabled == false)
            {
                Program.RPE.RealEstateSet.Add(realEstate);
                Program.RPE.SaveChanges();
            }
            else
            {
                realEstate.TotalFloors = Convert.ToInt32(textBoxTotalFloors.Text);

                Program.RPE.RealEstateSet.Add(realEstate);
                Program.RPE.SaveChanges();
            }
            ShowRealEstateSet();
            textBoxAddress_City.Text = "";
            textBoxAddress_Street.Text = "";
            textBoxAddress_House.Text = "";
            textBoxAddress_Number.Text = "";
            textBoxCoordinate_latitude.Text = "";
            textBoxCoordinate_longitude.Text = "";
            textBoxTotalArea.Text = "";
            textBoxTotalFloors.Text = "";
            textBoxRooms.Text = "";
            textBoxFloor.Text = "";
        }

        void ShowRealEstateSet()
        {
            if (Квартира.Enabled == false)
            {
                listViewRealEstateSet_Apartment.Items.Clear();
                foreach (RealEstateSet realEstate in Program.RPE.RealEstateSet)
                {
                    ListViewItem item = new ListViewItem(new string[] { realEstate.Address_City, realEstate.Address_Street, realEstate.Address_House, realEstate.Address_Numder, realEstate.Coordinate_latitude.ToString(), realEstate.Coordinate_longitude.ToString(), realEstate.TotalArea.ToString(), realEstate.Floor.ToString(), realEstate.Floor.ToString() });

                    item.Tag = realEstate;
                    listViewRealEstateSet_Apartment.Items.Add(item);
                }
                listViewRealEstateSet_Apartment.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else if (Дом.Enabled == false)
            {
                listViewRealEstateSet_Land.Items.Clear();
                foreach (RealEstateSet realEstate in Program.RPE.RealEstateSet)
                {
                    ListViewItem item = new ListViewItem(new string[] { realEstate.Address_City, realEstate.Address_Street, realEstate.Address_House, realEstate.Address_Numder, realEstate.Coordinate_latitude.ToString(), realEstate.Coordinate_longitude.ToString(), realEstate.TotalArea.ToString() });

                    item.Tag = realEstate;
                    listViewRealEstateSet_Land.Items.Add(item);
                }
                listViewRealEstateSet_Land.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                listViewRealEstateSet_House.Items.Clear();
                foreach (RealEstateSet realEstate in Program.RPE.RealEstateSet)
                {
                    ListViewItem item = new ListViewItem(new string[] { realEstate.Address_City, realEstate.Address_Street, realEstate.Address_House, realEstate.Address_Numder, realEstate.Coordinate_latitude.ToString(), realEstate.Coordinate_longitude.ToString(), realEstate.TotalArea.ToString(), realEstate.TotalFloors.ToString() });

                    item.Tag = realEstate;
                    listViewRealEstateSet_Land.Items.Add(item);
                }
                listViewRealEstateSet_House.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(Квартира.Enabled == false)
            {
                if(listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                {
                    RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;

                    realEstate.Address_City = textBoxAddress_City.Text;
                    realEstate.Address_Street = textBoxAddress_Street.Text;
                    realEstate.Address_House = textBoxAddress_House.Text;
                    realEstate.Address_Numder = textBoxAddress_Number.Text;
                    realEstate.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                    realEstate.Coordinate_longitude = Convert.ToDouble(textBoxCoordinate_longitude.Text);
                    realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                    realEstate.Rooms = Convert.ToInt32(textBoxRooms.Text);
                    realEstate.Floor = Convert.ToInt32(textBoxFloor.Text);

                    Program.RPE.SaveChanges();
                    ShowRealEstateSet();
                }
            }
            else if(Дом.Enabled == false)
            {
                if(listViewRealEstateSet_House.SelectedItems.Count == 1)
                {
                    RealEstateSet realEstate = listViewRealEstateSet_House.SelectedItems[0].Tag as RealEstateSet;

                    realEstate.Address_City = textBoxAddress_City.Text;
                    realEstate.Address_Street = textBoxAddress_Street.Text;
                    realEstate.Address_House = textBoxAddress_House.Text;
                    realEstate.Address_Numder = textBoxAddress_Number.Text;
                    realEstate.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                    realEstate.Coordinate_longitude = Convert.ToDouble(textBoxCoordinate_longitude.Text);
                    realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);

                    Program.RPE.SaveChanges();
                    ShowRealEstateSet();
                }
            }
            else
            {
                if(listViewRealEstateSet_Land.SelectedItems.Count == 1)
                {
                    RealEstateSet realEstate = listViewRealEstateSet_Land.SelectedItems[0].Tag as RealEstateSet;

                    realEstate.Address_City = textBoxAddress_City.Text;
                    realEstate.Address_Street = textBoxAddress_Street.Text;
                    realEstate.Address_House = textBoxAddress_House.Text;
                    realEstate.Address_Numder = textBoxAddress_Number.Text;
                    realEstate.Coordinate_latitude = Convert.ToDouble(textBoxCoordinate_latitude.Text);
                    realEstate.Coordinate_longitude = Convert.ToDouble(textBoxCoordinate_longitude.Text);
                    realEstate.TotalArea = Convert.ToDouble(textBoxTotalArea.Text);
                    realEstate.TotalFloors = Convert.ToInt32(textBoxTotalFloors.Text);

                    Program.RPE.SaveChanges();
                    ShowRealEstateSet();
                }
            }
        }

        private void listViewRealEstateSet_Apartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
            {
                RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;

                textBoxAddress_City.Text = realEstate.Address_City;
                textBoxAddress_Street.Text = realEstate.Address_Street;
                textBoxAddress_House.Text = realEstate.Address_House;
                textBoxAddress_Number.Text = realEstate.Address_Numder;
                textBoxCoordinate_latitude.Text = realEstate.Coordinate_latitude.ToString();
                textBoxCoordinate_longitude.Text = realEstate.Coordinate_longitude.ToString();
                textBoxTotalArea.Text = realEstate.TotalArea.ToString();
                textBoxRooms.Text = realEstate.Rooms.ToString();
                textBoxFloor.Text = realEstate.Floor.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxTotalFloors.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";
            }
        }

        private void listViewRealEstateSet_Land_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewRealEstateSet_Land.SelectedItems.Count == 1)
            {
                RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;

                textBoxAddress_City.Text = realEstate.Address_City;
                textBoxAddress_Street.Text = realEstate.Address_Street;
                textBoxAddress_House.Text = realEstate.Address_House;
                textBoxAddress_Number.Text = realEstate.Address_Numder;
                textBoxCoordinate_latitude.Text = realEstate.Coordinate_latitude.ToString();
                textBoxCoordinate_longitude.Text = realEstate.Coordinate_longitude.ToString();
                textBoxTotalArea.Text = realEstate.Rooms.ToString();
                textBoxTotalFloors.Text = realEstate.Floor.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxTotalFloors.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";
            }
        }

        private void listViewRealEstateSet_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewRealEstateSet_House.SelectedItems.Count == 1)
            {
                RealEstateSet realEstate = listViewRealEstateSet_House.SelectedItems[0].Tag as RealEstateSet;

                textBoxAddress_City.Text = realEstate.Address_City;
                textBoxAddress_Street.Text = realEstate.Address_Street;
                textBoxAddress_House.Text = realEstate.Address_House;
                textBoxAddress_Number.Text = realEstate.Address_Numder;
                textBoxCoordinate_latitude.Text = realEstate.Coordinate_latitude.ToString();
                textBoxCoordinate_longitude.Text = realEstate.Coordinate_longitude.ToString();
                textBoxTotalArea.Text = realEstate.Rooms.ToString();
                textBoxTotalFloors.Text = realEstate.Floor.ToString();
            }
            else
            {
                textBoxAddress_City.Text = "";
                textBoxAddress_Street.Text = "";
                textBoxAddress_House.Text = "";
                textBoxAddress_Number.Text = "";
                textBoxCoordinate_latitude.Text = "";
                textBoxCoordinate_longitude.Text = "";
                textBoxTotalArea.Text = "";
                textBoxTotalFloors.Text = "";
                textBoxRooms.Text = "";
                textBoxFloor.Text = "";
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewRealEstateSet_Apartment.SelectedItems.Count == 1)
                {
                    RealEstateSet realEstate = listViewRealEstateSet_Apartment.SelectedItems[0].Tag as RealEstateSet;

                    Program.RPE.RealEstateSet.Remove(realEstate);

                    Program.RPE.SaveChanges();

                    ShowRealEstateSet();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

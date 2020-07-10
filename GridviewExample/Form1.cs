using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridviewExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dT = new DataTable();

            dT.Columns.Add("Date");
            dT.Columns.Add("Date2");
            dT.Columns.Add("Third");

            dataGridView1.DataSource = dT;
            
        }

        private int getMonthDays(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: return 31;

                case 4:
                case 6:
                case 9:
                case 11: return 30;

                case 2: return year % 4 == 0 ? 29 : 28;
            }
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ============== Not Working =============================================================
            dataGridView1.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy"; 
            dataGridView1.Columns["Date"].ValueType = typeof(double);

            dataGridView1.Columns["Date2"].ValueType = typeof(double);
            dataGridView1.Columns["Date2"].DefaultCellStyle.Format = "MM/dd/yyyy";


            //==========================================================================================

            // ============== Working Fine =============================================================
            dataGridView1.Columns["Date"].DefaultCellStyle.Font = new Font("Arial", 10); //Working Fine
            //==========================================================================================

            int[] arr = { 1, 2, 3 };
            foreach (var a in arr)
            {
                DataTable dataTable = (DataTable)dataGridView1.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                var now = DateTime.Now;
                var yeasInMS = now.Year * 365.25 * 24 * 3600 * 1000;

                var monthDays = 0;
                for(int i=1; i<=now.Month; i++)
                {
                    monthDays += getMonthDays(i, now.Year);
                }
                var monthsInMS = monthDays * 24 * 3600 * 1000;
                var daysInMS = now.Day * 24 * 3600 * 1000;

                var dateInMilliseconds = yeasInMS + monthsInMS + daysInMS;
                drToAdd[0] = DateTime.Now;
                drToAdd[1] = dateInMilliseconds;
                drToAdd[2] = "Nothing";

                dataTable.Rows.Add(drToAdd);
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }
    }
}

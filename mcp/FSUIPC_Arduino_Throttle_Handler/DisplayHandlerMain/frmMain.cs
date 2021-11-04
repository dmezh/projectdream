using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSUIPC;

namespace DisplayHandlerMain
{
    public partial class frmMain : Form
    {

        // =====================================
        // Declared offsets
        // =====================================
        //private Offset<uint> airspeed = new Offset<uint>(0x02BC);
        //private Offset<uint> avionicsMaster = new Offset<uint>(0x2E80);
        private Offset<ushort> APIAS = new Offset<ushort>(0x07E2); //AT Speed IAS, in clean knots
        private Offset<uint> APMACH = new Offset<uint>(0x07E8); //AT Speed Mach, in wretched *65536 format.

        public ConnectedAVR AVR1 = new ConnectedAVR(); //initialize an Arduino

        public frmMain() //setup method, runs on form start
        {
            InitializeComponent(); 
            configureForm(); 
            AVR1.Setup(4); //Set the COM port to 4. //***CRINGE AT HARDCODED PORT
        }

        // The connect/disconnect button
        private void btnToggleConnection_Click(object sender, EventArgs e)
        {
            if (FSUIPCConnection.IsOpen)
            {
                this.timerMain.Stop();
                FSUIPCConnection.Close();
            }
            else
            {
                // Try to open the connection
                try
                {
                    this.lblConnectionStatus.Text = "Looking for a flight simulator...";
                    this.lblConnectionStatus.ForeColor = Color.Goldenrod;
                    FSUIPCConnection.Open();
                    // If there was no problem, start the main timer
                    this.timerMain.Start();
                }
                catch (Exception ex)
                {
                    // An error occured. Tell the user.
                    MessageBox.Show("Connection Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            configureForm();
        }

        // This method runs on a Timer (set on the form to change interval, currently 15ms)
        bool refstat; //bool for the reference type
        int prevAPIASint; bool prevRef; bool firstrun; 
        private void timerMain_Tick(object sender, EventArgs e)
        {
            // Call process() to read/write data to/from FSUIPC
            // We do this in a Try/Catch block in case something goes wrong
            try
            {
                //Get data from FSUIPC
                FSUIPCConnection.Process();

                //take the LVAR status from FSUIPC and compare it to 0 so refstat is set to 0 when in IAS and 1 when in Mach:
                refstat = (FSUIPCConnection.ReadLVar("qw_mach_status") != 0);
                //  Take the Mach value from FSUIPC, cast it to DECIMAL, divide it by 65536, 
                //  round it to two decimal places,
                //  then multiply it by 100 and cast it to an int. Then this represens mach*100. 
                int APMACHint = (int)(100*Math.Round((decimal)APMACH.Value / 65536, 2)); 

                //see if the IAS changed (works even if in Mach mode) or refstat changed, and if either has, send new stuff to the arduino
                if (APIASint != prevAPIASint || refstat != prevRef || firstrun)
                {
                    AVR1.SendSpd(refstat ? APMACHint : APIASint);

                    AVR1.SendRef(refstat);
                }

                prevAPIASint = APIASint;
                prevRef = refstat;
                firstrun = false;

                //update the form
                this.txtATIAS.Text = APIASint.ToString();
                this.txtATMACH.Text = "." + (APMACH.Value).ToString();// + "0";
                this.txtATTYPE.Text = (refstat ? "Mach" : "IAS");

            }
            catch (Exception ex)
            {
                // An error occured. Notify and stop the timer.
                this.timerMain.Stop();
                MessageBox.Show("Communication with FSUIPC Failed\n\n" + ex.Message, "FSUIPC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Update the connection status
                configureForm();
            }
        }
        private void configureForm()
        {
            if (FSUIPCConnection.IsOpen)
            {
                this.btnToggleConnection.Text = "Disconnect";
                this.lblConnectionStatus.Text = "Connected to " + FSUIPCConnection.FlightSimVersionConnected.ToString();
                this.lblConnectionStatus.ForeColor = Color.Green;
            }
            else
            {
                this.btnToggleConnection.Text = "Connect";
                this.lblConnectionStatus.Text = "Disconnected";
                this.lblConnectionStatus.ForeColor = Color.Red;
            }
        }

        // Form is closing so stop the timer and close FSUIPC Connection
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerMain.Stop();
            FSUIPCConnection.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblConnectionStatus_Click(object sender, EventArgs e)
        {

        }
    }
}

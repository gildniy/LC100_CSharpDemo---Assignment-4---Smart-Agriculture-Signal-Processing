using System;
using System.Drawing;
using System.Windows.Forms;

using Thorlabs.LC100;

/*
// macros for operating mode
#define OPMODE_IDLE                    0
#define OPMODE_SW_SINGLE_SHOT          1
#define OPMODE_SW_LOOP                 2
#define OPMODE_HW_SINGLE_SHOT          3
#define OPMODE_HW_LOOP                 4
*/

namespace LC100_CSharpDemo
{
    public partial class Form1 : Form
    {
        private LC100_Drv lc100Driver;
        private Bitmap lc100Diagram;
        private Graphics lc100Graphics;
        private Pen curvePen;
        private Point[] lc100CurvePoints;
        private short[] lc100Data;
        private double[] lc100Dark;
        private double[] lc100Blank;
        private double[] lc100Sample;
        private double[] lc100T;
        private double[] lc100Abs;


        public Form1()
        {
            InitializeComponent();

            curvePen = new Pen(Color.Red, 2.0f);
            lc100CurvePoints = new Point[2048];
            lc100Data = new short[2048];
            lc100Dark = new double[2048];
            lc100Blank = new double[2048];
            lc100Sample = new double[2048];
            lc100T = new double[2048];
            lc100Abs = new double[2048];


            lc100Diagram = new Bitmap(2048, this.pictureBox1.Height);
            lc100Graphics = Graphics.FromImage(lc100Diagram);
            this.pictureBox1.BackgroundImage = lc100Diagram;

            this.comboBox_OperationMode.Items.Clear();
            this.comboBox_OperationMode.Items.Add("SW Trigger Single Shot");
            this.comboBox_OperationMode.Items.Add("SW Trigger Continuous");
            this.comboBox_OperationMode.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // release the device
            if (lc100Driver != null)
                lc100Driver.Dispose();

            // release the drawing resources
            lc100Diagram.Dispose();
            lc100Graphics.Dispose();
            curvePen.Dispose();
        }

        private void button_StartScan_Click(object sender, EventArgs e)
        {
            if (lc100Driver == null)
            {
                if (textBox_SerialNumber.Text.Length == 0)
                {
                    MessageBox.Show("Please insert the 8 numerics of the serial number");
                    return;
                }

                // set the busy cursor
                this.Cursor = Cursors.WaitCursor;

                // connect the ccs device and start the sample application. Read out the instrument resource name from the sample application
                string resourceName = "USB::0x1313::0x80A0::M" + textBox_SerialNumber.Text.ToString() + "::RAW";

                // initialize device with the resource name (be sure the device is still connected)
                lc100Driver = new LC100_Drv(resourceName, false, false);

                // reset the cursor
                this.Cursor = Cursors.Default;

                if (lc100Driver == null)
                    return;
            }

            button_StartScan.Enabled = false;
         
            int status;
            int res = lc100Driver.getDeviceStatus(out status);

            // set opoeration mode
            if (this.comboBox_OperationMode.SelectedIndex == -1)
                this.comboBox_OperationMode.SelectedIndex = 0;
            else
            {
                uint opMode;
                res = lc100Driver.getOperatingMode(out opMode);
                if (res == 0 && opMode != this.comboBox_OperationMode.SelectedIndex + 1)
                    comboBox_OperationMode_SelectedIndexChanged(null, null);
            }

            // set the integration time
            res = lc100Driver.setIntegrationTime((double)numericUpDown_IntegrationTime.Value);
            
            // start the scan
            if (this.comboBox_OperationMode.SelectedIndex == 0)
                res = lc100Driver.startScan();
            else if (this.comboBox_OperationMode.SelectedIndex == 1)
                res = lc100Driver.startScanCont();

            // has the device started?
            res = lc100Driver.getDeviceStatus(out status);

            // wait 3 sec for a new data transfer
            if ((status & 0x00000001) == 0 && (status & 0x00000002) == 0)
            {
                DateTime startTime = DateTime.Now;
                TimeSpan elapsedTime = DateTime.Now - startTime;

                while (elapsedTime.Seconds < 3)
                {
                    elapsedTime = DateTime.Now - startTime;
                }
            }

            // camera has data available for transfer
            if ((status & 0x00000001) > 0 || (status & 0x00000002) > 0)
            {
                res = lc100Driver.getScanData(lc100Data);

                if (res == 0)
                {
                    // get the maximum 
                    int maxVal = 0;
                    foreach (short dataItem in lc100Data)
                    {
                        if (dataItem > maxVal)
                            maxVal = dataItem;
                    }

                    if (maxVal > 0)
                    {
                        for (int data = 0; data < 2048; data++)
                        {
                            lc100CurvePoints[data].X = data;
                            lc100CurvePoints[data].Y = Math.Max(0, lc100Data[data] * this.pictureBox1.Height / maxVal);
                        }
                    }
                    else
                    {
                        for (int data = 0; data < 2048; data++)
                        {
                            lc100CurvePoints[data].X = data;
                            lc100CurvePoints[data].Y = 0;
                        }
                    }

                    // draw the diagram from the data
                    lc100Graphics.Clear(Color.Transparent);
                    lc100Graphics.DrawCurve(curvePen, lc100CurvePoints);
                    this.pictureBox1.Refresh();

                    // color the button green
                    button_StartScan.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    // error color
                    button_StartScan.BackColor = Color.Maroon;
                }
            }
            else
            {
                // color the button to signal that no scan has been finished
                button_StartScan.BackColor = SystemColors.Control;
            }

            // reset the state to idle
            lc100Driver.setOperatingMode(LC100_DrvConstants.OpmodeIdle);

            button_StartScan.Enabled = true;

        }

        private void comboBox_OperationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lc100Driver == null)
                return;
            
            if (this.comboBox_OperationMode.SelectedIndex == 0)
            {
                // SW Trigger Single Shot
                lc100Driver.setOperatingMode(LC100_DrvConstants.OpmodeSwSingleShot);
            }
            else if (this.comboBox_OperationMode.SelectedIndex == 1)
            {
                // SW Trigger Continuous
                lc100Driver.setOperatingMode(LC100_DrvConstants.OpmodeSwLoop);
            }
        }

        private void numericUpDown_IntegrationTime_ValueChanged(object sender, EventArgs e)
        {
            if (lc100Driver == null)
                return;

            // change the integration time
            int res = lc100Driver.setIntegrationTime((double)numericUpDown_IntegrationTime.Value);

            if (res == 0)
            {
                // read the set integration time
                double integrTime;
                res = lc100Driver.getIntegrationTime(0, out integrTime);
                if (res == 0)
                    numericUpDown_IntegrationTime.Value = Convert.ToDecimal(integrTime);
            }
        }

        private void btnDark_Click(object sender, EventArgs e)
        {
            if (lc100Driver == null)
            {
                if (textBox_SerialNumber.Text.Length == 0)
                {
                    MessageBox.Show("Please insert the 8 numerics of the serial number");
                    return;
                }

                // set the busy cursor
                this.Cursor = Cursors.WaitCursor;

                // connect the ccs device and start the sample application. Read out the instrument resource name from the sample application
                string resourceName = "USB::0x1313::0x80A0::M" + textBox_SerialNumber.Text.ToString() + "::RAW";

                // initialize device with the resource name (be sure the device is still connected)
                lc100Driver = new LC100_Drv(resourceName, false, false);

                // reset the cursor
                this.Cursor = Cursors.Default;

                if (lc100Driver == null)
                    return;
            }

            btnDark.Enabled = false;

            int status;
            int res = lc100Driver.getDeviceStatus(out status);

            // set opoeration mode
            if (this.comboBox_OperationMode.SelectedIndex == -1)
                this.comboBox_OperationMode.SelectedIndex = 0;
            else
            {
                uint opMode;
                res = lc100Driver.getOperatingMode(out opMode);
                if (res == 0 && opMode != this.comboBox_OperationMode.SelectedIndex + 1)
                    comboBox_OperationMode_SelectedIndexChanged(null, null);
            }

            // set the integration time
            res = lc100Driver.setIntegrationTime((double)numericUpDown_IntegrationTime.Value);

            // start the scan
            if (this.comboBox_OperationMode.SelectedIndex == 0)
                res = lc100Driver.startScan();
            else if (this.comboBox_OperationMode.SelectedIndex == 1)
                res = lc100Driver.startScanCont();

            // has the device started?
            res = lc100Driver.getDeviceStatus(out status);

            // wait 3 sec for a new data transfer
            if ((status & 0x00000001) == 0 && (status & 0x00000002) == 0)
            {
                DateTime startTime = DateTime.Now;
                TimeSpan elapsedTime = DateTime.Now - startTime;

                while (elapsedTime.Seconds < 3)
                {
                    elapsedTime = DateTime.Now - startTime;
                }
            }

            // camera has data available for transfer
            if ((status & 0x00000001) > 0 || (status & 0x00000002) > 0)
            {
                res = lc100Driver.getScanData(lc100Data);

                if (res == 0)
                {
                    // get the maximum 
                    int maxVal = 0;
                    foreach (short dataItem in lc100Data)
                    {
                        if (dataItem > maxVal)
                            maxVal = dataItem;
                    }

                    if (maxVal > 0)
                    {
                        for (int data = 0; data < 2048; data++)
                        {
                            lc100CurvePoints[data].X = data;
                            lc100CurvePoints[data].Y = Math.Max(0, lc100Data[data] * this.pictureBox1.Height / maxVal);
                        }
                    }
                    else
                    {
                        for (int data = 0; data < 2048; data++)
                        {
                            lc100CurvePoints[data].X = data;
                            lc100CurvePoints[data].Y = 0;
                        }
                    }

                    for (int data = 0; data < 2048; data++)
                    {
                        lc100Dark[data] = lc100Data[data];
                    }

                    // draw the diagram from the data
                    lc100Graphics.Clear(Color.Transparent);
                    lc100Graphics.DrawCurve(curvePen, lc100CurvePoints);
                    this.pictureBox1.Refresh();

                    // color the button green
                    btnDark.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    // error color
                    btnDark.BackColor = Color.Maroon;
                }
            }
            else
            {
                // color the button to signal that no scan has been finished
                btnDark.BackColor = SystemColors.Control;
            }

            // reset the state to idle
            lc100Driver.setOperatingMode(LC100_DrvConstants.OpmodeIdle);

            btnDark.Enabled = true;
        }

        private void btnBlank_Click(object sender, EventArgs e)
        {
            if (lc100Driver == null)
            {
                if (textBox_SerialNumber.Text.Length == 0)
                {
                    MessageBox.Show("Please insert the 8 numerics of the serial number");
                    return;
                }

                // set the busy cursor
                this.Cursor = Cursors.WaitCursor;

                // connect the ccs device and start the sample application. Read out the instrument resource name from the sample application
                string resourceName = "USB::0x1313::0x80A0::M" + textBox_SerialNumber.Text.ToString() + "::RAW";

                // initialize device with the resource name (be sure the device is still connected)
                lc100Driver = new LC100_Drv(resourceName, false, false);

                // reset the cursor
                this.Cursor = Cursors.Default;

                if (lc100Driver == null)
                    return;
            }

            btnBlank.Enabled = false;

            int status;
            int res = lc100Driver.getDeviceStatus(out status);

            // set opoeration mode
            if (this.comboBox_OperationMode.SelectedIndex == -1)
                this.comboBox_OperationMode.SelectedIndex = 0;
            else
            {
                uint opMode;
                res = lc100Driver.getOperatingMode(out opMode);
                if (res == 0 && opMode != this.comboBox_OperationMode.SelectedIndex + 1)
                    comboBox_OperationMode_SelectedIndexChanged(null, null);
            }

            // set the integration time
            res = lc100Driver.setIntegrationTime((double)numericUpDown_IntegrationTime.Value);

            // start the scan
            if (this.comboBox_OperationMode.SelectedIndex == 0)
                res = lc100Driver.startScan();
            else if (this.comboBox_OperationMode.SelectedIndex == 1)
                res = lc100Driver.startScanCont();

            // has the device started?
            res = lc100Driver.getDeviceStatus(out status);

            // wait 3 sec for a new data transfer
            if ((status & 0x00000001) == 0 && (status & 0x00000002) == 0)
            {
                DateTime startTime = DateTime.Now;
                TimeSpan elapsedTime = DateTime.Now - startTime;

                while (elapsedTime.Seconds < 3)
                {
                    elapsedTime = DateTime.Now - startTime;
                }
            }

            // camera has data available for transfer
            if ((status & 0x00000001) > 0 || (status & 0x00000002) > 0)
            {
                res = lc100Driver.getScanData(lc100Data);

                if (res == 0)
                {
                    // get the maximum 
                    int maxVal = 0;
                    foreach (short dataItem in lc100Data)
                    {
                        if (dataItem > maxVal)
                            maxVal = dataItem;
                    }

                    if (maxVal > 0)
                    {
                        for (int data = 0; data < 2048; data++)
                        {
                            lc100CurvePoints[data].X = data;
                            lc100CurvePoints[data].Y = Math.Max(0, lc100Data[data] * this.pictureBox1.Height / maxVal);
                        }
                    }
                    else
                    {
                        for (int data = 0; data < 2048; data++)
                        {
                            lc100CurvePoints[data].X = data;
                            lc100CurvePoints[data].Y = 0;
                        }
                    }

                    for (int data = 0; data < 2048; data++)
                    {
                        lc100Blank[data] = lc100Data[data];

                        if (lc100Blank[data]<=lc100Dark[data]) {
                            lc100Blank[data] = lc100Dark[data] + 1.0;
                        }
                    }

                    // draw the diagram from the data
                    lc100Graphics.Clear(Color.Transparent);
                    lc100Graphics.DrawCurve(curvePen, lc100CurvePoints);
                    this.pictureBox1.Refresh();

                    // color the button green
                    btnBlank.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    // error color
                    btnBlank.BackColor = Color.Maroon;
                }
            }
            else
            {
                // color the button to signal that no scan has been finished
                btnBlank.BackColor = SystemColors.Control;
            }

            // reset the state to idle
            lc100Driver.setOperatingMode(LC100_DrvConstants.OpmodeIdle);

            btnBlank.Enabled = true;
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            if (lc100Driver == null)
            {
                if (textBox_SerialNumber.Text.Length == 0)
                {
                    MessageBox.Show("Please insert the 8 numerics of the serial number");
                    return;
                }

                // set the busy cursor
                this.Cursor = Cursors.WaitCursor;

                // connect the ccs device and start the sample application. Read out the instrument resource name from the sample application
                string resourceName = "USB::0x1313::0x80A0::M" + textBox_SerialNumber.Text.ToString() + "::RAW";

                // initialize device with the resource name (be sure the device is still connected)
                lc100Driver = new LC100_Drv(resourceName, false, false);

                // reset the cursor
                this.Cursor = Cursors.Default;

                if (lc100Driver == null)
                    return;
            }

            btnSample.Enabled = false;

            int status;
            int res = lc100Driver.getDeviceStatus(out status);

            // set opoeration mode
            if (this.comboBox_OperationMode.SelectedIndex == -1)
                this.comboBox_OperationMode.SelectedIndex = 0;
            else
            {
                uint opMode;
                res = lc100Driver.getOperatingMode(out opMode);
                if (res == 0 && opMode != this.comboBox_OperationMode.SelectedIndex + 1)
                    comboBox_OperationMode_SelectedIndexChanged(null, null);
            }

            // set the integration time
            res = lc100Driver.setIntegrationTime((double)numericUpDown_IntegrationTime.Value);

            // start the scan
            if (this.comboBox_OperationMode.SelectedIndex == 0)
                res = lc100Driver.startScan();
            else if (this.comboBox_OperationMode.SelectedIndex == 1)
                res = lc100Driver.startScanCont();

            // has the device started?
            res = lc100Driver.getDeviceStatus(out status);

            // wait 3 sec for a new data transfer
            if ((status & 0x00000001) == 0 && (status & 0x00000002) == 0)
            {
                DateTime startTime = DateTime.Now;
                TimeSpan elapsedTime = DateTime.Now - startTime;

                while (elapsedTime.Seconds < 3)
                {
                    elapsedTime = DateTime.Now - startTime;
                }
            }

            // camera has data available for transfer
            if ((status & 0x00000001) > 0 || (status & 0x00000002) > 0)
            {
                res = lc100Driver.getScanData(lc100Data);

                if (res == 0)
                {
                    // get the maximum 
                    int maxVal = 0;
                    foreach (short dataItem in lc100Data)
                    {
                        if (dataItem > maxVal)
                            maxVal = dataItem;
                    }

                    if (maxVal > 0)
                    {
                        for (int data = 0; data < 2048; data++)
                        {
                            lc100CurvePoints[data].X = data;
                            lc100CurvePoints[data].Y = Math.Max(0, lc100Data[data] * this.pictureBox1.Height / maxVal);
                        }
                    }
                    else
                    {
                        for (int data = 0; data < 2048; data++)
                        {
                            lc100CurvePoints[data].X = data;
                            lc100CurvePoints[data].Y = 0;
                        }
                    }

                    for (int data = 0; data < 2048; data++)
                    {
                        lc100Sample[data] = lc100Data[data];

                        if (lc100Sample[data] <= lc100Dark[data])
                        {
                            lc100Sample[data] = lc100Dark[data] + 1.0;
                        }
                    }

                    for (int data = 0; data < 2048; data++)
                    {
                        lc100T[data] = (lc100Sample[data] - lc100Dark[data]) / (lc100Blank[data] - lc100Dark[data]);
                        lc100Abs[data] = -1.0*Math.Log10(lc100T[data]);                    
                    }



                    // draw the diagram from the data
                    lc100Graphics.Clear(Color.Transparent);
                    lc100Graphics.DrawCurve(curvePen, lc100CurvePoints);
                    this.pictureBox1.Refresh();

                    // color the button green
                    btnSample.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    // error color
                    btnSample.BackColor = Color.Maroon;
                }
            }
            else
            {
                // color the button to signal that no scan has been finished
                btnSample.BackColor = SystemColors.Control;
            }

            // reset the state to idle
            lc100Driver.setOperatingMode(LC100_DrvConstants.OpmodeIdle);

            btnSample.Enabled = true;
        }
    }
}

//
//
// Managed Client Event sample
//
// Respond to Flaps up and down (F5, F6, F7 and F8 keys)
// Respond to Pitot switch (Shift-H)
// integrated COM Port Serial Communications this will be used to trigger events in FSX/P3D/MSFS/Xplane

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//COM port handling
using System.IO.Ports;
using System.IO;
// Add these two statements to all SimConnect clients
using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;

namespace Managed_Client_Event
{
    public partial class Form1 : Form
    {
        //used for storing selected Baudrate and COMport,for displaying purposes 
        string Selected_Port_Baudrate;

        // User-defined win32 event
        const int WM_USER_SIMCONNECT = 0x0402;

        // SimConnect object
        SimConnect simconnect = null;

        enum EVENTS
        {
            PITOT_TOGGLE,
            FLAPS_INC,
            FLAPS_DEC,
            FLAPS_UP,
            FLAPS_DOWN,
        };

        enum NOTIFICATION_GROUPS
        {
            GROUP0,
        }

        public Form1()
        {
            InitializeComponent();
            //from original simulator stuff
            setButtons(true, false);
            //from original end


            //------------------------- all copied from another tutorial --------------------------- https://www.xanthium.in/building-opensource-gui-based-serial-port-communication-program-dot-net-framework-and-arduino
            ComboBox_Available_SerialPorts.Items.AddRange(SerialPort.GetPortNames());

            // Displaying System Information 

            string SystemInformation;//Used for Storing System Information 

            SystemInformation = " Machine Name = " + System.Environment.MachineName;                                         // Get the Machine Name 
            SystemInformation = SystemInformation + Environment.NewLine + " OS Version = " + System.Environment.OSVersion;    // Get the OS version
            SystemInformation = SystemInformation + Environment.NewLine + " Processor Cores = " + Environment.ProcessorCount; // Get the Number of Processors on the System

            TextBox_System_Log.Text = SystemInformation; //Display into the Log Text Box
            //------------------------- all copied from another tutorial end -------------------------
        }

        //------------------------- all copied from another tutorial -------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            //not used
        }

        private void ComboBox_Available_SerialPorts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Selected_Port_Baudrate = ComboBox_Available_SerialPorts.SelectedItem.ToString() + " Selected"; // Store the Selected COM port

            TextBox_System_Log.Text = Selected_Port_Baudrate;  // Display the Selected COM port in the Log Text Box                                  

            ComboBox_Standard_Baudrates.Enabled = true;       // Enable Baudrate Selection after COM port is Selected

        }

        // Will run, when user selects a baudrate using Drop Down Menu after Serialport is selected
        private void ComboBox_Standard_Baudrates_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Selected_Port_Baudrate = Selected_Port_Baudrate + Environment.NewLine;             
            Selected_Port_Baudrate = Selected_Port_Baudrate + ComboBox_Standard_Baudrates.SelectedItem.ToString() + " bps selected";
            TextBox_System_Log.Text = Selected_Port_Baudrate;  // Display the Selected Baudrate in the Log Text Box 
        }

        //Used for Receiving Data from Serial Port
        private void Button_Receive_Data_Click_1(object sender, EventArgs e)
        {
            
            //Local Variables
            string Port_Name = ComboBox_Available_SerialPorts.SelectedItem.ToString();      // PortName
            int Baud_Rate = Convert.ToInt32(ComboBox_Standard_Baudrates.SelectedItem);     // BaudRate
            //string Data = TextBox_System_Log.Text;
            //SerialPort myport = (SerialPort)sender; //this has been copied from another one of my projects using a console but it crashes

            SerialPort serialPort = new SerialPort(Port_Name, Baud_Rate, Parity.None, 8, StopBits.One);
            SerialPort port = serialPort;
            

            //Open the Serial Port 
            try
            {
                port.Open();
            }

            //error handling below in catches
            
            catch (UnauthorizedAccessException SerialException) //exception that is thrown when the operating system denies access 
            {
                MessageBox.Show(SerialException.ToString());
                TextBox_System_Log.Text = Port_Name + Environment.NewLine + Baud_Rate;
                TextBox_System_Log.Text = TextBox_System_Log.Text + Environment.NewLine + SerialException.ToString();
                port.Close();                                  // Close the Port
            }

            catch (System.IO.IOException SerialException)     // An attempt to set the state of the underlying port failed
            {
                MessageBox.Show(SerialException.ToString());
                TextBox_System_Log.Text = Port_Name + Environment.NewLine + Baud_Rate;
                TextBox_System_Log.Text = TextBox_System_Log.Text + Environment.NewLine + SerialException.ToString();
                port.Close();                                  // Close the Port
            }

            catch (InvalidOperationException SerialException) // The specified port on the current instance of the SerialPort is already open
            {
                MessageBox.Show(SerialException.ToString());
                TextBox_System_Log.Text = Port_Name + Environment.NewLine + Baud_Rate;
                TextBox_System_Log.Text = TextBox_System_Log.Text + Environment.NewLine + SerialException.ToString();
                port.Close();                                  // Close the Port
            }

            catch //Any other ERROR
            {
                MessageBox.Show("ERROR in Opening Serial PORT -- UnKnown ERROR");
                port.Close();                                  // Close the Port
            }
            


            //If we are able to open the port 
            if (port.IsOpen == true)
            {
                TextBox_System_Log.Text = "Port Opened";
                TextBox_System_Log.Text = Port_Name + Environment.NewLine + Baud_Rate;

                //trying this out to see if i can get more lines from arduino
                //String ReceivedData = myport.ReadExisting();

                string ReceivedData = port.ReadLine();     // String Containing Received Data
                TextBox_System_Log.Text = ReceivedData;

            }
            else if (port.IsOpen == false)
            {
                TextBox_System_Log.Text = "Unable to interface with COM port";
                port.Close();                                  // Close the Port
            }
        }
        //------------------------- all copied from another tutorial END -------------------------



        //------------------------- BELOW STARTS SIMULATOR INTERFACE -------------------------
        // Simconnect client will send a win32 message when there is 
        // a packet to process. ReceiveMessage must be called to
        // trigger the events. This model keeps simconnect processing on the main thread.

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simconnect != null)
                {
                    simconnect.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void setButtons(bool bConnect, bool bDisconnect)
        {
            buttonConnect.Enabled = bConnect;
            buttonDisconnect.Enabled = bDisconnect;
        }

        private void closeConnection()
        {
            if (simconnect != null)
            {
                // Dispose serves the same purpose as SimConnect_Close()
                simconnect.Dispose();
                simconnect = null;
                displayText("Connection closed");
            }
        }

        // Set up all the SimConnect related event handlers
        private void initClientEvent()
        {
            try
            {
                // listen to connect and quit msgs
                simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(simconnect_OnRecvOpen);
                simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simconnect_OnRecvQuit);

                // listen to exceptions
                simconnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simconnect_OnRecvException);

                // listen to events
                simconnect.OnRecvEvent += new SimConnect.RecvEventEventHandler(simconnect_OnRecvEvent);

                // subscribe to pitot heat switch toggle
                simconnect.MapClientEventToSimEvent(EVENTS.PITOT_TOGGLE, "PITOT_HEAT_TOGGLE");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.PITOT_TOGGLE, false);

                // subscribe to all four flaps controls
                simconnect.MapClientEventToSimEvent(EVENTS.FLAPS_UP, "FLAPS_UP");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.FLAPS_UP, false);
                simconnect.MapClientEventToSimEvent(EVENTS.FLAPS_DOWN, "FLAPS_DOWN");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.FLAPS_DOWN, false);
                simconnect.MapClientEventToSimEvent(EVENTS.FLAPS_INC, "FLAPS_INCR");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.FLAPS_INC, false);
                simconnect.MapClientEventToSimEvent(EVENTS.FLAPS_DEC, "FLAPS_DECR");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.FLAPS_DEC, false);

                // set the group priority
                simconnect.SetNotificationGroupPriority(NOTIFICATION_GROUPS.GROUP0, SimConnect.SIMCONNECT_GROUP_PRIORITY_HIGHEST);

            }
            catch (COMException ex)
            {
                displayText(ex.Message);
            }
        }

        void simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            displayText("Connected to FSX");
        }

        // The case where the user closes FSX
        void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            displayText("FSX has exited");
            closeConnection();
        }

        void simconnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            displayText("Exception received: " + data.dwException);
        }

        void simconnect_OnRecvEvent(SimConnect sender, SIMCONNECT_RECV_EVENT recEvent)
        {
            switch (recEvent.uEventID)
            {
                case (uint)EVENTS.PITOT_TOGGLE:

                    displayText("PITOT switched");
                    break;

                case (uint)EVENTS.FLAPS_UP:

                    displayText("Flaps Up");
                    break;

                case (uint)EVENTS.FLAPS_DOWN:

                    displayText("Flaps Down");
                    break;

                case (uint)EVENTS.FLAPS_INC:

                    displayText("Flaps Inc");
                    break;

                case (uint)EVENTS.FLAPS_DEC:

                    displayText("Flaps Dec");
                    break;
            }
        }

        // The case where the user closes the client
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeConnection();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (simconnect == null)
            {
                try
                {
                    // the constructor is similar to SimConnect_Open in the native API
                    simconnect = new SimConnect("Managed Client Events", this.Handle, WM_USER_SIMCONNECT, null, 0);

                    setButtons(false, true);

                    initClientEvent();

                }
                catch (COMException ex)
                {
                    displayText("Unable to connect to FSX " + ex.Message);
                }
            }
            else
            {
                displayText("Error - try again");
                closeConnection();

                setButtons(true, false);
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            closeConnection();
            setButtons(true, false);
        }

        // Response number
        int response = 1;

        // Output text - display a maximum of 10 lines
        string output = "\n\n\n\n\n\n\n\n\n\n";
        
        void displayText(string s)
        {
            // remove first string from output
            output = output.Substring(output.IndexOf("\n") + 1);

            // add the new string
            output += "\n" + response++ + ": " + s;

            // display it
            richResponse.Text = output;
        }

        private void richResponse_TextChanged(object sender, EventArgs e)
        {

        }



        private void comboPortSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
// End of program

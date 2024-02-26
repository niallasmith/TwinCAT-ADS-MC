// Event handler for handling Form1 events e.g. buttons pressed etc.

using Microsoft.VisualBasic;
using TwinCAT.Ads;

namespace TwinCAT_ADS_MC;

public partial class MCForm1
{
    public PLC myPLC;
    public NCAxis ncAxis;

    
    public string AMSID;
    public int Port;

    public uint axisID = 0;

    public ushort readPosValue;
    public ushort readVelValue;
    
    public SetupForm1 SetupForm;

    private void connectButton_Click(object sender, EventArgs e) // initialise button pressed
    {

        if (localCheckBox.Checked)
        {
            try
            {
                AMSID = Convert.ToString(AmsNetId.Local);
            }
            catch
            {
                return;
            }
            
        } 
        else
        {
            AMSID = userAMSIDText.Text;
        }

        try
        {
            int value = Convert.ToInt32(userPortText.Text);
        }
        catch
        {
            MessageBox.Show("Invalid port");
            return;
        }

        Port = Convert.ToInt32(userPortText.Text);

        myPLC = new PLC(AMSID,Port);

        if (myPLC.IsStateRun())
        {
            plcConnectedLabel.Text = "Connected";
        }
        else
        {
            MessageBox.Show("PLC not in Run state, probably because of an incorrect Port");
            plcConnectedLabel.Text = "Disonnected";
        }
        
    }

    /*
    
    private void newSetPos_Click(object sender, EventArgs e) // new set position button pressed
    {
        
        if (ncAxis is null) // return if ncAxis has not been setup yet
        {
            MessageBox.Show("ncAxis is null, ensure initialistion");
            return;
        }

        try // try convert, if cannot (due to wrong type, not in range), display message and return
        {
            ushort value = Convert.ToUInt16(setPosText.Text);
            ncAxis.WriteValue1(myPLC, value);
        }
        catch
        {
            MessageBox.Show("value out of range");
            return;
        }
        //MessageBox.Show("New position set event handler");
        
    }
    */
    /*

    private void newVelCmd_Click(object sender, EventArgs e) // new velocity value button pressed
    {
        if (ncAxis is null)
        {
            MessageBox.Show("ncAxis is null, ensure initialistion");
            return;
        }

        try
        {
            ushort value = Convert.ToUInt16(setVelText.Text);
            ncAxis.WriteValue2(myPLC, value);
        }
        catch
        {
            MessageBox.Show("value out of range");
            return;
        }

        //MessageBox.Show("Velocity set event handler");
    }
    */

    /*

    private void checkBox_Click(object sender, EventArgs e) // check box clicked
    {
        if (ncAxis is null)
        {
            MessageBox.Show("ncAxis is null, ensure initialistion");
            return;
        }

        if (checkBOX.Checked)
        {
            //MessageBox.Show("checked");
            ncAxis.WriteValue3(myPLC, true);

        } else {
            //MessageBox.Show("unchecked");
            ncAxis.WriteValue3(myPLC, false);
        }
    }
    */

    private void timer1_Tick(object sender, EventArgs e) // timer interval triggered
    {
        if (ncAxis is null)
        {
            return;
        }
        
        //object[] vars = ncAxis.ReadAxisParameters(myPLC);
        readPosText.Text = Convert.ToString(readPosValue);
        readVelText.Text = Convert.ToString(readVelValue);
    }

    private void localCheckBox_Click(object sender, EventArgs e) // check box clicked
    {
        if (localCheckBox.Checked)
        {
            userAMSIDText.ReadOnly = true;

        } else {
            userAMSIDText.ReadOnly = false;
        }
    }

    private void axesSetupButton_Click(object sender, EventArgs e) 
    {
        SetupForm1 SetupForm = new SetupForm1(myPLC,ncAxis,axisID);
        SetupForm.ShowDialog();
    }

    private void moveAbsoluteRadio_Click(object sender, EventArgs e)
    {
        setPosText.ReadOnly = false;
        setVelText.ReadOnly = false;
    } 

    private void moveRelativeRadio_Click(object sender, EventArgs e)
    {
        setPosText.ReadOnly = false;
        setVelText.ReadOnly = false;
    } 

    private void moveHomeRadio_Click(object sender, EventArgs e)
    {
        setPosText.ReadOnly = true;
        setVelText.ReadOnly = false;
    } 

    private void executeButton_Click(object sender, EventArgs e)
    {
        if (ncAxis is null) // return if ncAxis has not been setup yet
        {
            MessageBox.Show("ncAxis is null, ensure initialistion");
            return;
        }

        /*

        if (setPosText.Text!="")
        {
            WritePosition();
        }

        if (setVelText.Text!="")
        {
            WriteVelocity();
        }
        */

        UInt16 loopID = (UInt16)ncAxis.ReadActiveLoop(myPLC,axisID)[0];

        if (moveAbsoluteRadio.Checked)
        {
            ncAxis.MoveAbsolute(myPLC, axisID, loopID, Convert.ToUInt16(setPosText.Text), Convert.ToUInt16(setVelText.Text));
        } 
        else if (moveRelativeRadio.Checked) 
        {
            ncAxis.MoveRelative(myPLC, axisID, loopID, Convert.ToUInt16(setPosText.Text), Convert.ToUInt16(setVelText.Text));
        }
        else
        {
            setPosText.Text = "Error";
            setVelText.Text = "Error";
        }

    }

    /*
    private void WriteExecute()
    {
        ncAxis.WriteExecute(myPLC, true);
    }

    private void WritePosition()
    {
        try
        {
            ushort value = Convert.ToUInt16(setPosText.Text);
            ncAxis.WritePosition(myPLC, value);
        }
        catch
        {
            MessageBox.Show("position value out of range");
            return;
        }
    }

    private void WriteVelocity()
    {
        try
        {
            ushort value = Convert.ToUInt16(setVelText.Text);
            ncAxis.WriteVelocity(myPLC, value);
        }
        catch
        {
            MessageBox.Show("velocity value out of range");
            return;
        }
    }
    private void WriteAcceleration()
    {
        try
        {
            ushort value = Convert.ToUInt16(setAcclText.Text);
            ncAxis.WriteAcceleration(myPLC, value);
        }
        catch
        {
            MessageBox.Show("acceleration value out of range");
            return;
        }
    }
    */

    private void axisConnectButton_Click(object sender, EventArgs e)
    {
        try
        {
            axisID = (uint)Convert.ToUInt16(axesNumText.Text) - 1;
            if(axisID > 3 || axisID < 0)
            {
                MessageBox.Show("Axes num invalid");
                return;
            }
        }
        catch
        {
            MessageBox.Show("Axes num invalid");
            return;
        }

        try
        {
            ncAxis = new NCAxis(myPLC, axisID);
            axisConnectedLabel.Text = "Connected";
        }
        catch
        {
            MessageBox.Show("Axis not connected");
            axisConnectedLabel.Text = "Disconnected";
            axesNumText.Text = "1";
            return;
        }
    }

    private void SetupForm1_Closed(object sender, EventArgs e)
    {
        // push changes to NC axis 
        System.Console.WriteLine("form closed");
    }
}
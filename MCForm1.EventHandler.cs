// Event handler for handling MCForm1 events e.g. buttons pressed etc.

using Microsoft.VisualBasic;
using TwinCAT.Ads;

namespace TwinCAT_ADS_MC;

public partial class MCForm1
{

    // myPLC, ncAxis, AMSID and SetupForm1 set as nullable. is this a mistake? they can all be nullable and there should not be an issue. 
    // got some warning about nullable properties when exiting the MCForm1 constructor. given that MCForm1 is the primary code that runs, when exiting the constructor i dont think
    // we care whether they are null or not, so i set them as nullable
    public PLC? myPLC; 
    public NCAxis? ncAxis; // set as nullable
    public string? AMSID; // set as nullable
    public int Port;
    public uint axisID = 0; // initialise axis ID to 0 (ID 0 = axis 1)
    public ushort readPosValue;
    public ushort readVelValue;
    public SetupForm1? SetupForm; // set as nullable

    private void connectButton_Click(object sender, EventArgs e) // PLC connect button pressed
    {

        if (localCheckBox.Checked) // if user has selected they want to connect to a local PLC
        {
            try
            {
                AMSID = Convert.ToString(AmsNetId.Local); // try convert local AMS net ID to string
            }
            catch
            {
                MessageBox.Show("Invalid local AMS net ID");
                return; // if cannot, return and return early from connect function
            }
            
        } 
        else // if user has NOT selected a local PLC
        {
            AMSID = userAMSIDText.Text; // AMS ID is the text that the user entered
        }

        try
        {
            Port = Convert.ToInt32(userPortText.Text); // try convert the port the user entered to Int32
        }
        catch
        {
            MessageBox.Show("Invalid port"); // if it isn't (or is null) then display message box and return early from connect function
            return;
        }

        if (AMSID is null) // ensure AMSID is not null
        {
            MessageBox.Show("AMS Net ID is null");
            return;
        }

        myPLC = new PLC(AMSID,Port); // create new PLC object named myPLC. see PLC.cs for code

        if (myPLC.IsStateRun()) // if connection was successful, then PLC will be in run state
        {
            plcConnectedLabel.Text = "Connected"; // if so, change text below connect button
        }
        else
        {
            MessageBox.Show("PLC not in Run state or failed to connect"); // if not, display message box
            plcConnectedLabel.Text = "Disonnected";
        }
        
    }

    // legacy code that no longer applied with the new approach to ADS communication
    // keeping it in case in the future it is useful

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
        if (ncAxis is null || myPLC is null) // if ncAxis is null e.g. PLC has not yet been connected
        {
            return; // return early and do not try reading parameters
        }
        
        object[] motionOutputArray = (object[])ncAxis.ReadAxisMotion(myPLC,axisID);
        RefreshMotionData(motionOutputArray);
    }

    private void localCheckBox_Click(object sender, EventArgs e) // check box clicked
    {
        if (localCheckBox.Checked) // if the checkbox is now checked
        {
            userAMSIDText.ReadOnly = true; // make AMS ID box read only

        } else {
            userAMSIDText.ReadOnly = false; // make it un- read only
        }
    }

    private void axesSetupButton_Click(object sender, EventArgs e) // axis setup button clicked
    {
        if (myPLC is null || ncAxis is null)
        {
            MessageBox.Show("PLC or NCAxis is null");
            return;
        }

        SetupForm1 SetupForm = new SetupForm1(myPLC,ncAxis,axisID); // create setup form
        SetupForm.ShowDialog(); // display setup form
    }

    private void moveAbsoluteRadio_Click(object sender, EventArgs e) // move absolute radio button clicked
    {
        positionSetText.ReadOnly = false;
        velocitySetText.ReadOnly = false;
    } 

    private void moveRelativeRadio_Click(object sender, EventArgs e) // move relative radio button clicked
    {
        positionSetText.ReadOnly = false;
        velocitySetText.ReadOnly = false;
    } 

    private void moveHomeRadio_Click(object sender, EventArgs e) // move home radio button clicked
    {
        positionSetText.ReadOnly = true; // obviously position is implied if homing, so make it read only for clarity's sake
        velocitySetText.ReadOnly = false;
    } 

    private void executeButton_Click(object sender, EventArgs e)
    {

        if (myPLC is null || ncAxis is null) // return if ncAxis has not been setup yet
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
            ncAxis.MoveAbsolute(myPLC, axisID, loopID, Convert.ToDouble(positionSetText.Text), Convert.ToDouble(velocitySetText.Text));
        } 
        else if (moveRelativeRadio.Checked) 
        {
            ncAxis.MoveRelative(myPLC, axisID, loopID, Convert.ToDouble(positionSetText.Text), Convert.ToDouble(velocitySetText.Text));
        }
        else
        {
            positionSetText.Text = "Error";
            velocitySetText.Text = "Error";
        }

    }

    // legacy code that no longer applied with the new approach to ADS communication
    // keeping it in case in the future it is useful

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

    private void axisConnectButton_Click(object sender, EventArgs e) // axis connect button pressed
    {
        if (myPLC is null)
        {
            MessageBox.Show("PLC is null");
            return;
        }

        try
        {
            // try convert user inputted data into int
            axisID = (uint)Convert.ToUInt16(axesNumText.Text) - 1; // axis ID in Beckhoff is an array index between 0..3, therefore if user types in axis 1, this is axis ID 0
            if(axisID > 3 || axisID < 0) // if not in correct range 0..3
            {
                MessageBox.Show("Axes num invalid");
                return; // return early, do not try to connect
            }
        }
        catch
        {
            MessageBox.Show("Axes num invalid"); // if user input cannot be converted to int (a char or is null), return error message and return early from function
            return;
        }

        try
        {
            ncAxis = new NCAxis(myPLC, axisID); // if successful, create new ncAxis object related to axis
            axisConnectedLabel.Text = "Connected"; // change label text
        }
        catch
        {
            MessageBox.Show("Axis not connected"); // if error occurs, display message
            axisConnectedLabel.Text = "Disconnected"; // change label text
            axesNumText.Text = "1"; // reset axis num text to a correct value
            return; // return from function
        }
    }

}
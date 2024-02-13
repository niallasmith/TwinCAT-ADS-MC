// Event handler for handling Form1 events e.g. buttons pressed etc.

using TwinCAT.Ads;

namespace TwinCAT_ADS_MC;

public partial class MCForm1
{
    public PLC myPLC;
    public NCAxis ncAxis;
    public ushort readPosValue;
    public string AMSID;
    public int Port;
    public ushort readVelValue;
    public ushort readAcclValue;
    public ushort axesNum = 1;
    //public Program myPlc;
    private void connectButton_Click(object sender, EventArgs e) // initialise button pressed
    {
        //MessageBox.Show("Initialise button event handler");

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

        Port = Convert.ToInt32(userPortText.Text);

        myPLC = new PLC(AMSID,Port);
        //ncAxis = new NCAxis(myPLC, axesNum);
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
            //MessageBox.Show("ncAxis is null, ensure initialistion");
            return;
        }
        
        readPosValue = ncAxis.ReadPosition(myPLC);
        readVelValue = ncAxis.ReadVelocity(myPLC);
        readAcclValue = ncAxis.ReadAcceleration(myPLC);
        RefreshData();
    }

    private void localCheckBox_Click(object sender, EventArgs e) // check box clicked
    {
        if (localCheckBox.Checked)
        {
            //MessageBox.Show("checked");
            userAMSIDText.ReadOnly = true;

        } else {
            //MessageBox.Show("unchecked");
            userAMSIDText.ReadOnly = false;
        }
    }

    private void axesSetupButton_Click(object sender, EventArgs e) // initialise button pressed
    {
        // do something
    }


    private void moveAbsoluteRadio_Click(object sender, EventArgs e)
    {
        setPosText.ReadOnly = false;
        setVelText.ReadOnly = false;
        setAcclText.ReadOnly = false;
    } 

    private void moveRelativeRadio_Click(object sender, EventArgs e)
    {
        setPosText.ReadOnly = false;
        setVelText.ReadOnly = false;
        setAcclText.ReadOnly = false;
    } 

    private void moveHomeRadio_Click(object sender, EventArgs e)
    {
        setPosText.ReadOnly = true;
        setVelText.ReadOnly = false;
        setAcclText.ReadOnly = false;
    } 

    private void executeButton_Click(object sender, EventArgs e)
    {
        if (ncAxis is null) // return if ncAxis has not been setup yet
        {
            MessageBox.Show("ncAxis is null, ensure initialistion");
            return;
        }

        if (setPosText.Text!="")
        {
            WritePosition();
        }

        if (setVelText.Text!="")
        {
            WriteVelocity();
        }

        if (setAcclText.Text!="")
        {
            WriteAcceleration();
        }

        setPosText.Text = "";
        setVelText.Text = "";
        setAcclText.Text = "";
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

    private void axisConnectButton_Click(object sender, EventArgs e)
    {
        try
        {
            axesNum = Convert.ToUInt16(axesNumText.Text);
            ncAxis = new NCAxis(myPLC, axesNum);
        }
        catch
        {
            MessageBox.Show("axes num invalid");
            axesNumText.Text = "1";
            return;
        }
    }
}
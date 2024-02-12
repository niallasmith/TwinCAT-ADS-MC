// Event handler for handling Form1 events e.g. buttons pressed etc.

namespace TwinCAT_ADS_MC;

public partial class MCForm1
{
    public NCAxis ncAxis;
    public ushort readPosValue;
    public ushort readVelValue;
    //public Program myPlc;
    private void initButton_Click(object sender, EventArgs e) // initialise button pressed
    {
        //MessageBox.Show("Initialise button event handler");
        ncAxis = new NCAxis(Program.myPLC);
    }
    
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
            ncAxis.WriteValue1(Program.myPLC, value);
        }
        catch
        {
            MessageBox.Show("value out of range");
            return;
        }
        //MessageBox.Show("New position set event handler");
        
    }

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
            ncAxis.WriteValue2(Program.myPLC, value);
        }
        catch
        {
            MessageBox.Show("value out of range");
            return;
        }

        //MessageBox.Show("Velocity set event handler");
    }

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
            ncAxis.WriteValue3(Program.myPLC, true);

        } else {
            //MessageBox.Show("unchecked");
            ncAxis.WriteValue3(Program.myPLC, false);
        }
    }

    private void timer1_Tick(object sender, EventArgs e) // timer interval triggered
    {
        if (ncAxis is null)
        {
            //MessageBox.Show("ncAxis is null, ensure initialistion");
            return;
        }
        
        readPosValue = ncAxis.ReadValue1(Program.myPLC);
        readVelValue = ncAxis.ReadValue2(Program.myPLC);
        RefreshData();
    }

}
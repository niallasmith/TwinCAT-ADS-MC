// Event handler for handling Form1 events e.g. buttons pressed etc.

using System.Xml.Serialization;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;

namespace TwinCAT_ADS_MC;

partial class SetupForm1
{

    private void setAxisParams_Click(object sender, EventArgs e)
    {
        // to do: ensure values are proper
        uint maxVeloc = Convert.ToUInt16(maxVelocityText.Text);
        uint maxAccel = Convert.ToUInt16(maxAccelerationText.Text);
        uint defaultAccel = Convert.ToUInt16(defaultAccelText.Text);
        uint defaultJerk = Convert.ToUInt16(defaultJerkText.Text);
        uint homingVeloc = Convert.ToUInt16(homingVelocText.Text);
        uint manualVelocFast = Convert.ToUInt16(manualVelocFastText.Text);
        uint manualVelocSlow = Convert.ToUInt16(manualVelocSlowText.Text);
        uint jogIncrement = Convert.ToUInt16(jogIncrementText.Text);

        object[] vars = {axisID,loopID,maxVeloc,maxAccel,defaultAccel,defaultJerk,homingVeloc,manualVelocFast,manualVelocSlow,jogIncrement};
        ncAxis.WriteAxisParameters(myPLC,vars);
    }

    private void timer2_Tick(object sender, EventArgs e) // timer interval triggered
    {
        if (ncAxis is null)
        {
            return;
        }

        object[] vars = new object[8];

        vars = (object[])ncAxis.ReadAxisParameters(myPLC, axisID, loopID);
        RefreshAxisData(vars);
        object[] encoderVars = new object[5];
        encoderVars = (object[])ncAxis.ReadEncoderParams(myPLC, axisID, loopID);
        RefreshEncoderData(encoderVars);
    }

    private void controlLoopRadio_Click(object sender, EventArgs e)
    {
        if(controlLoop1Radio.Checked)
        {
            loopID = 0;
            ncAxis.SetActiveControlLoop(myPLC, axisID, loopID);
        } 
        if(controlLoop2Radio.Checked) 
        {
            loopID = 1;
            ncAxis.SetActiveControlLoop(myPLC, axisID, loopID);
        }
    }

    private void encoderParamsSetButton_Click(object sender, EventArgs e)
    {

        object[] vars = new object[6];
        //vars[0] = Convert.ToInt16(encoderInvertedDirectionCheck.Checked);
        //vars[0] = encoderInvertedDirectionCheck.Checked;
        vars[0] = axisID;
        vars[1] = loopID;
        vars[2] = Convert.ToDouble(encoderScalingNumeratorText.Text);
        vars[3] = Convert.ToDouble(encoderScalingDenominatorText.Text);
        vars[4] = Convert.ToInt16(encoderOffsetText.Text);
        vars[5] = Convert.ToInt32(encoderMaskText.Text);
        ncAxis.SetEncoderParams(myPLC,vars);
    }

    private void getCurrentLoopID()
    {
        UInt16 activeLoopID = (UInt16)ncAxis.ReadActiveLoop(myPLC,axisID)[0];

        if (activeLoopID == 1)
        {
            controlLoop2Radio.Checked = true;
        } else
        {
            controlLoop1Radio.Checked = true;
        }
    }

}
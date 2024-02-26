// Event handler for handling Form1 events e.g. buttons pressed etc.

using System.Xml.Serialization;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;

namespace TwinCAT_ADS_MC;

//partial class MCForm1
//{

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

        //object[] vars = {maxVeloc,maxAccel,defaultAccel,defaultJerk,homingVeloc,manualVelocFast,manualVelocSlow,jogIncrement,loopID};
        object[] vars = {maxVeloc,maxAccel,defaultAccel,defaultJerk,homingVeloc,manualVelocFast,manualVelocSlow,jogIncrement};
        ncAxis.WriteAxisParameters(myPLC,vars);
    }

    private void timer2_Tick(object sender, EventArgs e) // timer interval triggered
    {
        if (ncAxis is null)
        {
            //MessageBox.Show("ncAxis is null, ensure initialistion");
            return;
        }

        object[] vars = new object[8];

        vars = (object[])ncAxis.ReadAxisParameters(myPLC,loopID);
        //vars = (object[])ncAxis.ReadAxisParameters(myPLC,0);

        //System.Console.WriteLine(vars[0]);
        
        //readPosValue = ncAxis.ReadPosition(myPLC);
        //readVelValue = ncAxis.ReadVelocity(myPLC);
        //readAcclValue = ncAxis.ReadAcceleration(myPLC);
        RefreshAxisData(vars);
        object[] encoderVars = new object[5];
        encoderVars = (object[])ncAxis.ReadEncoderParams(myPLC,loopID);
        //encoderVars = (object[])ncAxis.ReadEncoderParams(myPLC,0);
        RefreshEncoderData(encoderVars);
    }

    private void encoderReadButton_Click(object sender, EventArgs e)
    {
        ncAxis.ReadActiveEncoder(myPLC);
    }

    private void encoderSetButton_Click(object sender, EventArgs e)
    {
        try
        {
            ncAxis.SetActiveEncoder(myPLC, Convert.ToUInt16(axisSetText.Text));
        }
        catch
        {
            System.Console.WriteLine("error in SetActiveEncoder or in converting axisSetText");
        }
        
    }

    //private void callMoveAbsoluteButton_Click(object sender, EventArgs e)
    //{
    //    ncAxis.CallMoveAbsolute(myPLC,loopID);
    //}

    private void controlLoopRadio_Click(object sender, EventArgs e)
    {
        if(controlLoop1Radio.Checked)
        {
            loopID = 0;
            ncAxis.SetActiveEncoder(myPLC, loopID);
        } 
        if(controlLoop2Radio.Checked) 
        {
            loopID = 1;
            ncAxis.SetActiveEncoder(myPLC, loopID);
        }
    }

    private void encoderParamsSetButton_Click(object sender, EventArgs e)
    {
        //invertEncoderDirection : BOOL;
	    //scalingFactorNumerator : UINT;
	    //scalingFactorDenominator : UINT;
	    //encoderOffset : UINT;
	    //encoderMask : UINT;
	    //controlLoopID : UINT;
        object[] vars = new object[4];
        //vars[0] = Convert.ToInt16(encoderInvertedDirectionCheck.Checked);
        //vars[0] = encoderInvertedDirectionCheck.Checked;
        vars[0] = Convert.ToDouble(encoderScalingNumeratorText.Text);
        vars[1] = Convert.ToDouble(encoderScalingDenominatorText.Text);
        vars[2] = Convert.ToInt16(encoderOffsetText.Text);
        vars[3] = Convert.ToInt32(encoderMaskText.Text);
        vars[4] = loopID;
        ncAxis.SetEncoderParams(myPLC,vars);
    }

    private void getCurrentLoopID()
    {
        UInt16 activeLoopID = (UInt16)ncAxis.ReadActiveLoop(myPLC)[0];

        if (activeLoopID == 1)
        {
            controlLoop2Radio.Checked = true;
        } else
        {
            controlLoop1Radio.Checked = true;
        }
    }

}
//}
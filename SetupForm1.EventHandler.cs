// Event handler for handling Form1 events e.g. buttons pressed etc.

using System.Xml.Serialization;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;

namespace TwinCAT_ADS_MC;

partial class SetupForm1
{

    private void setAxisParams_Click(object sender, EventArgs e)
    {
        uint maxVeloc;
        uint maxAccel;
        uint defaultAccel;
        uint defaultJerk;
        uint homingVeloc;
        uint manualVelocFast;
        uint manualVelocSlow;
        uint jogIncrement;

        #region value handling

        if (maxVelocityText.Text == "") 
        {
            maxVeloc = Convert.ToUInt16(maxVelocityActualText.Text);
        } 
        else
        {
            try
            {  
                maxVeloc = Convert.ToUInt16(maxVelocityText.Text);
            }
            catch
            {
                return;
            }
        }

        if (maxAccelerationText.Text == "") 
        {
            maxAccel = Convert.ToUInt16(maxAccelerationActualText.Text);
        } 
        else
        {
            try
            {  
                maxAccel = Convert.ToUInt16(maxAccelerationText.Text);
            }
            catch
            {
                return;
            }
        }

        if (defaultAccelText.Text == "") 
        {
            defaultAccel = Convert.ToUInt16(defaultAccelActualText.Text);
        } 
        else
        {
            try
            {  
                defaultAccel = Convert.ToUInt16(defaultAccelText.Text);
            }
            catch
            {
                return;
            }
        }

        if (defaultJerkText.Text == "") 
        {
            defaultJerk = Convert.ToUInt16(defaultJerkActualText.Text);
        } 
        else
        {
            try
            {  
                defaultJerk = Convert.ToUInt16(defaultJerkText.Text);
            }
            catch
            {
                return;
            }
        }

        if (homingVelocText.Text == "") 
        {
            homingVeloc = Convert.ToUInt16(homingVelocActualText.Text);
        } 
        else
        {
            try
            {  
                homingVeloc = Convert.ToUInt16(homingVelocText.Text);
            }
            catch
            {
                return;
            }
        }

        if (manualVelocFastText.Text == "") 
        {
            manualVelocFast = Convert.ToUInt16(manualVelocFastActualText.Text);
        } 
        else
        {
            try
            {  
                manualVelocFast = Convert.ToUInt16(manualVelocFastText.Text);
            }
            catch
            {
                return;
            }
        }

        if (manualVelocSlowText.Text == "") 
        {
            manualVelocSlow = Convert.ToUInt16(manualVelocSlowActualText.Text);
        } 
        else
        {
            try
            {  
                manualVelocSlow = Convert.ToUInt16(manualVelocSlowText.Text);
            }
            catch
            {
                return;
            }
        }

        if (jogIncrementText.Text == "") 
        {
            jogIncrement = Convert.ToUInt16(jogIncrementActualText.Text);
        } 
        else
        {
            try
            {  
                jogIncrement = Convert.ToUInt16(jogIncrementText.Text);
            }
            catch
            {
                return;
            }
        }
        #endregion

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
        double scalingFactorNum;
        double scalingFactorDen;
        uint offset;
        uint mask;

        if (encoderScalingNumeratorText.Text == "") 
        {
            scalingFactorNum = Convert.ToDouble(encoderScalingNumeratorReadText.Text);
        } 
        else
        {
            try
            {  
                scalingFactorNum = Convert.ToDouble(encoderScalingNumeratorText.Text);
            }
            catch
            {
                return;
            }
        }

        if (encoderScalingDenominatorText.Text == "") 
        {
            scalingFactorDen = Convert.ToDouble(encoderScalingDenominatorReadText.Text);
        } 
        else
        {
            try
            {  
                scalingFactorDen = Convert.ToDouble(encoderScalingDenominatorText.Text);
            }
            catch
            {
                return;
            }
        }

        if (encoderOffsetText.Text == "") 
        {
            offset = Convert.ToUInt32(encoderOffsetReadText.Text);
        } 
        else
        {
            try
            {  
                offset = Convert.ToUInt32(encoderOffsetText.Text);
            }
            catch
            {
                return;
            }
        }

        if (encoderMaskText.Text == "") 
        {
            mask = Convert.ToUInt32(encoderMaskReadText.Text);
        } 
        else
        {
            try
            {  
                mask = Convert.ToUInt32(encoderMaskText.Text);
            }
            catch
            {
                return;
            }
        }

        object[] vars = {axisID,loopID,scalingFactorNum,scalingFactorDen,offset,mask};

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
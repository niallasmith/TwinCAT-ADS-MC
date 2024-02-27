// Event handler for handling Form1 events e.g. buttons pressed etc.

using System.Xml.Serialization;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;

namespace TwinCAT_ADS_MC;

partial class SetupForm1
{

    private void setAxisParams_Click(object sender, EventArgs e)
    {
        double maxVeloc;
        double maxAccel;
        double defaultAccel;
        double defaultJerk;
        double homingVeloc;
        double manualVelocFast;
        double manualVelocSlow;
        double jogIncrement;

        #region value handling

        if (maxVelocityText.Text == "") 
        {
            maxVeloc = Convert.ToDouble(maxVelocityActualText.Text);
        } 
        else
        {
            try
            {  
                maxVeloc = Convert.ToDouble(maxVelocityText.Text);
            }
            catch
            {
                return;
            }
        }

        if (maxAccelerationText.Text == "") 
        {
            maxAccel = Convert.ToDouble(maxAccelerationActualText.Text);
        } 
        else
        {
            try
            {  
                maxAccel = Convert.ToDouble(maxAccelerationText.Text);
            }
            catch
            {
                return;
            }
        }

        if (defaultAccelText.Text == "") 
        {
            defaultAccel = Convert.ToDouble(defaultAccelActualText.Text);
        } 
        else
        {
            try
            {  
                defaultAccel = Convert.ToDouble(defaultAccelText.Text);
            }
            catch
            {
                return;
            }
        }

        if (defaultJerkText.Text == "") 
        {
            defaultJerk = Convert.ToDouble(defaultJerkActualText.Text);
        } 
        else
        {
            try
            {  
                defaultJerk = Convert.ToDouble(defaultJerkText.Text);
            }
            catch
            {
                return;
            }
        }

        if (homingVelocText.Text == "") 
        {
            homingVeloc = Convert.ToDouble(homingVelocActualText.Text);
        } 
        else
        {
            try
            {  
                homingVeloc = Convert.ToDouble(homingVelocText.Text);
            }
            catch
            {
                return;
            }
        }

        if (manualVelocFastText.Text == "") 
        {
            manualVelocFast = Convert.ToDouble(manualVelocFastActualText.Text);
        } 
        else
        {
            try
            {  
                manualVelocFast = Convert.ToDouble(manualVelocFastText.Text);
            }
            catch
            {
                return;
            }
        }

        if (manualVelocSlowText.Text == "") 
        {
            manualVelocSlow = Convert.ToDouble(manualVelocSlowActualText.Text);
        } 
        else
        {
            try
            {  
                manualVelocSlow = Convert.ToDouble(manualVelocSlowText.Text);
            }
            catch
            {
                return;
            }
        }

        if (jogIncrementText.Text == "") 
        {
            jogIncrement = Convert.ToDouble(jogIncrementActualText.Text);
        } 
        else
        {
            try
            {  
                jogIncrement = Convert.ToDouble(jogIncrementText.Text);
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

        object[] driveVars = new object[2];
        driveVars = (object[])ncAxis.ReadDriveParameters(myPLC, axisID, loopID);
        RefreshDriveData(driveVars);

        object[] controllerVars = new object[1];
        controllerVars = (object[])ncAxis.ReadControllerParameters(myPLC, axisID, loopID);
        RefreshControllerData(controllerVars);
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
        bool invertDirection;
        double scalingFactorNum;
        double scalingFactorDen;
        double offset;
        uint mask;

        #region value handling

        invertDirection = encoderInvertedDirectionCheck.Checked;

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
            offset = Convert.ToDouble(encoderOffsetReadText.Text);
        } 
        else
        {
            try
            {  
                offset = Convert.ToDouble(encoderOffsetText.Text);
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

        #endregion

        object[] vars = {axisID,loopID,invertDirection,scalingFactorNum,scalingFactorDen,offset,mask};

        ncAxis.WriteEncoderParameters(myPLC,vars);
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

    private void setControllerParamsButton_Click(object sender, EventArgs e)
    {
        double kvparam;

        #region value handling

        if (encoderMaskText.Text == "") 
        {
            kvparam = Convert.ToDouble(controllerKvText.Text);
        } 
        else
        {
            try
            {  
                kvparam = Convert.ToDouble(controllerKvText.Text);
            }
            catch
            {
                return;
            }
        }

        #endregion

        object[] vars = {axisID, loopID,kvparam};
        ncAxis.WriteControllerParameters(myPLC, vars);
    }

    private void setDriveParamsButton_Click(object sender, EventArgs e)
    {
        bool invertPolarity;
        double refvelo;
        
        #region value handling.

        invertPolarity = driveInvertCheck.Checked;

        if (encoderMaskText.Text == "") 
        {
            refvelo = Convert.ToDouble(driveReferenceVeloActualText.Text);
        } 
        else
        {
            try
            {  
                refvelo = Convert.ToDouble(driveReferenceVeloText.Text);
            }
            catch
            {
                return;
            }
        }

        #endregion

        object[] vars = {axisID, loopID, invertPolarity, refvelo};
        ncAxis.WriteDriveParameters(myPLC, vars);
    }

}
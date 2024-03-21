// Event handler for handling setup form events e.g. buttons pressed etc.

using System.Xml.Serialization;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace TwinCAT_ADS_MC;

partial class SetupForm1
{

    private void timer2_Tick(object sender, EventArgs e) // timer interval triggered
    {
        if (ncAxis is null) // if ncaxis is null (has not yet been connected to)
        {
            return; // early return to prevent errors
        }

        // read axis parameters from the PLC and refresh the form data
        object[] axisOutputArray = (object[])ncAxis.ReadAxisParameters(myPLC, axisID, loopID);
        RefreshAxisData(axisOutputArray);

        // read encoder parameters from the PLC and refresh the form data
        object[] encoderOutputArray = (object[])ncAxis.ReadEncoderParams(myPLC, axisID, loopID);
        RefreshEncoderData(encoderOutputArray);

        // read drive parameters from the PLC and refresh the form data
        object[] driveOutputArray = (object[])ncAxis.ReadDriveParameters(myPLC, axisID, loopID);
        RefreshDriveData(driveOutputArray);

        // read controller parameters from the PLC and refresh the form data
        object[] controllerOutputArray = (object[])ncAxis.ReadControllerParameters(myPLC, axisID, loopID);
        RefreshControllerData(controllerOutputArray);
    }

    private void controlLoopRadio_Click(object sender, EventArgs e) // if either of the control loop switching radio buttons are clicked
    {
        if(controlLoop1Radio.Checked) // if radio button 1 pressed
        {
            loopID = 0; // set loop id
            object[] loopInputArray = {axisID, loopID};
            ncAxis.SetActiveControlLoop(myPLC, loopInputArray); // call method on PLC to change control loop to loop ID
        } 

        if(controlLoop2Radio.Checked)// if radio button 2 pressed
        {
            loopID = 1; // set loop id
            object[] loopInputArray = {axisID, loopID};
            ncAxis.SetActiveControlLoop(myPLC, loopInputArray); // call method on PLC to change control loop to loop ID
        }
    }

    private void getCurrentLoopID()
    {
        UInt16 activeLoopID = (UInt16)ncAxis.ReadActiveLoop(myPLC,axisID)[0]; // call read active loop function to get current loop ID from PLC

        if (activeLoopID == 1)
        {
            controlLoop2Radio.Checked = true; // check the radio button if active loop ID is 1
        } else
        {
            controlLoop1Radio.Checked = true;
        }
    }

    private void setAxisParams_Click(object sender, EventArgs e) // set axis parameters button clicked
    {
        // define some temporary local variables
        double maxVeloc;
        double maxAccel;
        double defaultAccel;
        double defaultJerk;
        double homingVeloc;
        double manualVelocFast;
        double manualVelocSlow;
        double jogIncrement;

        #region value handling

        // if user has left entry blank, define that parameter as the actual read value, therefore nothing should change but we are still writing /something/ to the method

        if (maxVelocityText.Text == "") // if entered text is blank
        {
            maxVeloc = Convert.ToDouble(maxVelocityActualText.Text); // write the values read from the PLC to the temporary variable 
        } 
        else // if not blank
        {
            try
            {  
                maxVeloc = Convert.ToDouble(maxVelocityText.Text); // try convert to double. if success, write to temporary variable
            }
            catch
            {
                return; // if not, return early.
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

        object[] axisInputArray = {axisID,loopID,maxVeloc,maxAccel,defaultAccel,defaultJerk,homingVeloc,manualVelocFast,manualVelocSlow,jogIncrement}; // put all handled parameters into an object array
        ncAxis.WriteAxisParameters(myPLC,axisInputArray); // pass object array to write axis parameters function in NCAxis.cs
    }

    private void encoderParamsSetButton_Click(object sender, EventArgs e) // set encoder parameters button clicked
    {
        // define some temporary local variables
        bool invertDirection;
        double scalingFactorNum;
        double scalingFactorDen;
        double offset;
        uint mask;

        #region value handling

        invertDirection = encoderInvertedDirectionCheck.Checked; // no value handling required

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

        object[] encoderInputArray = {axisID,loopID,invertDirection,scalingFactorNum,scalingFactorDen,offset,mask}; // put all handled parameters into an object array

        ncAxis.WriteEncoderParameters(myPLC,encoderInputArray); // call write encoder parameters method on the PLC, pass it the parameter object array
    }

    private void setDriveParamsButton_Click(object sender, EventArgs e) // set drive parameters button clicked
    {
        // define some temporary local variables
        bool invertPolarity;
        double refvelo;
        
        #region value handling

        invertPolarity = driveInvertCheck.Checked; // no value handling required

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

        object[] driveInputArray = {axisID, loopID, invertPolarity, refvelo}; // put all handled parameters into an object array
        ncAxis.WriteDriveParameters(myPLC, driveInputArray); // call write drive parameters method on the PLC, pass it the parameter object array
    }

    private void setControllerParamsButton_Click(object sender, EventArgs e) // set controller parameters button clicked
    {
        // define some temporary local variables
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
                MessageBox.Show("kv parameter user value error");
                return;
            }
        }

        #endregion

        object[] controllerInputArray = {axisID, loopID, kvparam}; // put all handled parameters into an object array
        ncAxis.WriteControllerParameters(myPLC, controllerInputArray); // call write controller parameters method on the PLC, pass it the parameter object array
    }

    private void setActualPosition_Click(object sender, EventArgs e)
    {
        double actualPosition;

        // value handling

        try
        {
            actualPosition = Convert.ToDouble(setActualPositionTextBox.Text);
        } 
        catch 
        {
            MessageBox.Show("set actual position user value error");
            return;
        }

        

        object[] actualPositionArray = {axisID, loopID, actualPosition};
        ncAxis.SetActualPosition(myPLC,actualPositionArray);
    }

    private void loadFromFileButton_Click(object sender, EventArgs e)
    {
        string filepath;
        ushort invertedEncoderDirection;
        ushort invertedDriveDirection;

        // user input value handling TODO
        filepath = loadFilepathTextbox.Text;

        var xmlDoc = XDocument.Load(filepath);

        var localLoopID = Convert.ToUInt16(xmlDoc.Root.Element("encoderSetup")?.Element("activeControlLoop")?.Value);

        #region load axis params

        //var name = xmlDoc.Root.Element("Name")?.Value;
        var maxVelocity = Convert.ToDouble(xmlDoc.Root.Element("axisSetup")?.Element("maxVelocity")?.Value);
        var maxAcceleration = Convert.ToDouble(xmlDoc.Root.Element("axisSetup")?.Element("maxAcceleration")?.Value);
        var defaultAcceleration = Convert.ToDouble(xmlDoc.Root.Element("axisSetup")?.Element("defaultAcceleration")?.Value);
        var defaultJerk = Convert.ToDouble(xmlDoc.Root.Element("axisSetup")?.Element("defaultJerk")?.Value);
        var homingVelocity = Convert.ToDouble(xmlDoc.Root.Element("axisSetup")?.Element("homingVelocity")?.Value);
        var manualVelocityFast = Convert.ToDouble(xmlDoc.Root.Element("axisSetup")?.Element("manualVelocityFast")?.Value);
        var manualVelocitySlow = Convert.ToDouble(xmlDoc.Root.Element("axisSetup")?.Element("manualVelocitySlow")?.Value);
        var jogIncrement = Convert.ToDouble(xmlDoc.Root.Element("axisSetup")?.Element("jogIncrement")?.Value);

        object[] axisInputArray = {axisID,localLoopID,maxVelocity,maxAcceleration,defaultAcceleration,defaultJerk,homingVelocity,manualVelocityFast,manualVelocitySlow,jogIncrement};
        ncAxis.WriteAxisParameters(myPLC,axisInputArray);

        #endregion

        #region load encoder params

        var activeControlLoop = Convert.ToUInt16(xmlDoc.Root.Element("axisSetup")?.Element("activeControlLoop")?.Value);

        object[] loopInputArray = {axisID,activeControlLoop+1};
        ncAxis.SetActiveControlLoop(myPLC,loopInputArray);

        var tempEncoderValue = xmlDoc.Root.Element("encoderSetup")?.Element("invertedDirection")?.Value;

        if (tempEncoderValue == "True")
        {
            invertedEncoderDirection = 1;
        } else 
        {
            invertedEncoderDirection = 0;
        }

        var scalingFactorNumerator = Convert.ToDouble(xmlDoc.Root.Element("encoderSetup")?.Element("scalingFactorNumerator")?.Value);
        var scalingFactorDenominator = Convert.ToDouble(xmlDoc.Root.Element("encoderSetup")?.Element("scalingFactorDenominator")?.Value);
        var encoderOffset = Convert.ToDouble(xmlDoc.Root.Element("encoderSetup")?.Element("encoderOffset")?.Value);
        var encoderMask = Convert.ToDouble(xmlDoc.Root.Element("encoderSetup")?.Element("encoderMask")?.Value);
        object[] encoderInputArray = {axisID,localLoopID,invertedEncoderDirection,scalingFactorNumerator,scalingFactorDenominator,encoderOffset,encoderMask};
        ncAxis.WriteEncoderParameters(myPLC,encoderInputArray);

        #endregion

        #region load drive params

        var tempDriveValue = xmlDoc.Root.Element("driveSetup")?.Element("invertedMotor")?.Value;

        if (tempDriveValue == "True")
        {
            invertedDriveDirection = 1;
        } else 
        {
            invertedDriveDirection = 0;
        }

        var referenceVelocity = Convert.ToDouble(xmlDoc.Root.Element("driveSetup")?.Element("referenceVelocity")?.Value);
        object[] driveInputArray = {axisID,localLoopID,invertedDriveDirection,referenceVelocity};
        ncAxis.WriteDriveParameters(myPLC,driveInputArray);

        #endregion

        #region load controller params

        var kvParam = Convert.ToDouble(xmlDoc.Root.Element("controllerSetup")?.Element("kvParam")?.Value);
        object[] controllerInputArray = {axisID,localLoopID,kvParam};
        ncAxis.WriteControllerParameters(myPLC,controllerInputArray);

        #endregion

        MessageBox.Show("success");

    }

    private void saveToFileButton_Click(object sender, EventArgs e)
    {
        string filepath;

        // user input value handling TODO
        filepath = saveFilepathTextbox.Text;

        using (XmlTextWriter writer = new XmlTextWriter(filepath, null))
        {
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("setupData");

            writer.WriteStartElement("axisSetup");
            writer.WriteElementString("maxVelocity", Convert.ToString(maxVelocityActualText.Text));
            writer.WriteElementString("maxAcceleration", Convert.ToString(maxAccelerationActualText.Text));
            writer.WriteElementString("defaultAcceleration", Convert.ToString(defaultAccelActualText.Text));
            writer.WriteElementString("defaultJerk", Convert.ToString(defaultJerkActualText.Text));
            writer.WriteElementString("homingVelocity", Convert.ToString(homingVelocActualText.Text));
            writer.WriteElementString("manualVelocityFast", Convert.ToString(manualVelocFastActualText.Text));
            writer.WriteElementString("manualVelocitySlow", Convert.ToString(manualVelocSlowActualText.Text));
            writer.WriteElementString("jogIncrement", Convert.ToString(jogIncrementActualText.Text));
            writer.WriteEndElement();

            writer.WriteStartElement("encoderSetup");
            writer.WriteElementString("activeControlLoop", Convert.ToString(loopID));
            writer.WriteElementString("invertedDirection", Convert.ToString(encoderInvertedDirectionCheck.Checked));
            writer.WriteElementString("scalingFactorNumerator", Convert.ToString(encoderScalingNumeratorReadText.Text));
            writer.WriteElementString("scalingFactorDenominator", Convert.ToString(encoderScalingDenominatorReadText.Text));
            writer.WriteElementString("encoderOffset", Convert.ToString(encoderOffsetReadText.Text));
            writer.WriteElementString("encoderMask", Convert.ToString(encoderMaskReadText.Text));
            writer.WriteEndElement();

            writer.WriteStartElement("driveSetup");
            writer.WriteElementString("invertedMotor", Convert.ToString(driveInvertCheck.Checked));
            writer.WriteElementString("referenceVelocity", Convert.ToString(driveReferenceVeloActualText.Text));
            writer.WriteEndElement();

            writer.WriteStartElement("controllerSetup");
            writer.WriteElementString("kvParam", Convert.ToString(loopID));
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        MessageBox.Show("Save file successful");
    }
}
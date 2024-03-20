// partial class of SetupForm1 that contains basic form-related functions, including the constructor

using TwinCAT.PlcOpen;

namespace TwinCAT_ADS_MC;

public partial class SetupForm1 : Form
{
    
    public PLC myPLC;
    public NCAxis ncAxis;
    public uint axisID;
    public uint loopID = 0; // initialise loop ID as 0
    public SetupForm1(PLC myPLCIn, NCAxis ncAxisIn, uint axisIDIn) // constructor for SetupForm1
    {
        // PLC, ncAxis and axis ID have been passed to this form from MCForm1
        myPLC = myPLCIn;
        ncAxis = ncAxisIn;
        axisID = axisIDIn;

        SetupInitializeComponent(); // call function in SetupForm1.Designer
    }

    public void RefreshAxisData(object[] readAxisDataArray) // update textboxes of axis read data from object array
    {
        // object array passed to this function comes from timer 2 tick, reading axis parameters
        maxVelocityActualText.Text = Convert.ToString(readAxisDataArray[0]);
        maxAccelerationActualText.Text = Convert.ToString(readAxisDataArray[1]);
        defaultAccelActualText.Text = Convert.ToString(readAxisDataArray[2]);
        defaultJerkActualText.Text = Convert.ToString(readAxisDataArray[3]);
        homingVelocActualText.Text = Convert.ToString(readAxisDataArray[4]);
        manualVelocFastActualText.Text = Convert.ToString(readAxisDataArray[5]);
        manualVelocSlowActualText.Text = Convert.ToString(readAxisDataArray[6]);
        jogIncrementActualText.Text = Convert.ToString(readAxisDataArray[7]);
    }

    public void RefreshEncoderData(object[] readEncoderDataArray) // update textboxes of encoder read data from object array
    {
        // object array passed to this function comes from timer 2 tick, reading encoder parameters
        encoderInvertedDirectionReadText.Text = Convert.ToString(readEncoderDataArray[0]);
        encoderScalingNumeratorReadText.Text = Convert.ToString(readEncoderDataArray[1]);
        encoderScalingDenominatorReadText.Text = Convert.ToString(readEncoderDataArray[2]);
        encoderOffsetReadText.Text = Convert.ToString(readEncoderDataArray[3]);
        encoderMaskReadText.Text = Convert.ToString(readEncoderDataArray[4]);
    }

    public void RefreshDriveData(object[] readDriveDataArray) // update textboxes of drive read data from object array
    {
        // object array passed to this function comes from timer 2 tick, reading drive parameters
        driveInvertActualText.Text = Convert.ToString(readDriveDataArray[0]);
        driveReferenceVeloActualText.Text = Convert.ToString(readDriveDataArray[1]);
    }

    public void RefreshControllerData(object[] readControllerDataArray) // update textboxes of controller read data from object array
    {
        // object array passed to this function comes from timer 2 tick, reading controller parameters
        controllerKvActualText.Text = Convert.ToString(readControllerDataArray[0]);
    }

}
//}
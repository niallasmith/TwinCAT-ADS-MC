using TwinCAT.PlcOpen;

namespace TwinCAT_ADS_MC;

//partial class MCForm1
//{
public partial class SetupForm1 : Form
{
    
    public PLC myPLC;
    public NCAxis ncAxis;
    
    public uint axisID;
    public uint loopID = 0;
    public SetupForm1(PLC myPLCIn, NCAxis ncAxisIn, uint axisIDIn)
    {
        myPLC = myPLCIn;
        ncAxis = ncAxisIn;
        axisID = axisIDIn;
        SetupInitializeComponent();
    }

    public void RefreshAxisData(object[] vars)
    {
        maxVelocityActualText.Text = Convert.ToString(vars[0]);
        maxAccelerationActualText.Text = Convert.ToString(vars[1]);
        defaultAccelActualText.Text = Convert.ToString(vars[2]);
        defaultJerkActualText.Text = Convert.ToString(vars[3]);
        homingVelocActualText.Text = Convert.ToString(vars[4]);
        manualVelocFastActualText.Text = Convert.ToString(vars[5]);
        manualVelocSlowActualText.Text = Convert.ToString(vars[6]);
        jogIncrementActualText.Text = Convert.ToString(vars[7]);
    }

    public void RefreshEncoderData(object[] vars)
    {
        encoderInvertedDirectionReadText.Text = Convert.ToString(vars[0]);
        encoderScalingNumeratorReadText.Text = Convert.ToString(vars[1]);
        encoderScalingDenominatorReadText.Text = Convert.ToString(vars[2]);
        encoderOffsetReadText.Text = Convert.ToString(vars[3]);
        encoderMaskReadText.Text = Convert.ToString(vars[4]);
    }

}
//}
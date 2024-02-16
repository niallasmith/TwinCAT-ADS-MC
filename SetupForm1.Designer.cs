namespace TwinCAT_ADS_MC;

partial class SetupForm1
{
    private System.ComponentModel.IContainer components = null;
    public TextBox maxVelocityText;
    public TextBox maxAccelerationText;
    public TextBox axisJogIncrementText;
    public TextBox encoderScalingFactorText;
    public TextBox encoderOffsetText;
    public TextBox encoderModeText;
    public TextBox driveModeText;
    public TextBox controllerMode;
    public RadioButton incrementalEncoderRadio;
    public RadioButton absoluteEncoderRadio;
    public RadioButton openLoopControlRadio;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(500, 500);
        this.Text = "TwinCAT-ADS-MC Axis Setup";

        FormDesignSetup();
    }

    private void FormDesignSetup()
    {
        // setup form design
        CenterToScreen();
    }

}
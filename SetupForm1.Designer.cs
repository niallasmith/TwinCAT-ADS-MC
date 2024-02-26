namespace TwinCAT_ADS_MC;

partial class SetupForm1
{
    private System.ComponentModel.IContainer components = null;

    #region axes param definitions
    
    public Label axisParamsLabel;
    public Label axisParamsSetLabel;
    public Label axisParamsActualLabel;
    public TextBox maxVelocityText;
    public TextBox maxVelocityActualText;
    public Label maxVelocityLabel;
    public TextBox maxAccelerationText;
    public TextBox maxAccelerationActualText;
    public Label maxAccelerationLabel;
    public TextBox defaultAccelText;
    public TextBox defaultAccelActualText;
    public Label defaultAccelLabel;
    public TextBox defaultJerkText;
    public TextBox defaultJerkActualText;
    public Label defaultJerkLabel;
    public TextBox homingVelocText;
    public TextBox homingVelocActualText;
    public Label homingVelocLabel;
    public TextBox manualVelocFastText;
    public TextBox manualVelocFastActualText;
    public Label manualVelocFastLabel;
    public TextBox manualVelocSlowText;
    public TextBox manualVelocSlowActualText;
    public Label manualVelocSlowLabel;
    public TextBox jogIncrementText;
    public TextBox jogIncrementActualText;
    public Label jogIncrementLabel;
    public Button setAxisParamsButton;

    #endregion

    #region encoder parameter definitions

    public Label encoderParamsLabel;
    public Label encoderParamsSetLabel;
    public Label encoderParamsReadLabel;
    public RadioButton controlLoop1Radio;
    public RadioButton controlLoop2Radio;
    public Label controlLoop1Label;
    public Label controlLoop2Label;
    public CheckBox encoderInvertedDirectionCheck;
    public TextBox encoderScalingNumeratorText;
    public TextBox encoderScalingDenominatorText;
    public TextBox encoderOffsetText;
    public TextBox encoderMaskText;
    
    public Label encoderInvertedDirectionLabel;
    public Label encoderScalingNumeratorLabel;
    public Label encoderScalingDenominatorLabel;
    public Label encoderOffsetLabel;
    public Label encoderMaskLabel;
    public TextBox encoderInvertedDirectionReadText;
    public TextBox encoderScalingNumeratorReadText;
    public TextBox encoderScalingDenominatorReadText;
    public TextBox encoderOffsetReadText;
    public TextBox encoderMaskReadText;
    public Button encoderParamsSetButton;

    #endregion

    #region drive parameter definitions
    public Label driveParamsLabel;
    public Label driveParamsSetLabel;
    public Label driveParamsReadLabel;

    #endregion

    #region controller parameter definitions

    public Label controllerParamsLabel;
    public Label controllerParamsSetLabel;
    public Label controllerParamsReadLabel;
    public TextBox controllerMode;
    #endregion


    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    private void SetupInitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1200, 500);
        this.Text = "TwinCAT-ADS-MC Axis Setup";

        FormDesignSetup();
    }

    private void FormDesignSetup()
    {
        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer(); // setup new timer for refreshing form data
        timer2.Interval=1000; // 1 second
        timer2.Tick += new EventHandler(timer2_Tick);
        timer2.Start();

        setAxisParamsButton = new Button();
        setAxisParamsButton.Size = new Size(100,40);
        setAxisParamsButton.Location = new Point(140,325);
        setAxisParamsButton.Text = "Set Axis Params";
        this.Controls.Add(setAxisParamsButton);
        setAxisParamsButton.Click += new EventHandler(setAxisParams_Click);

        #region axis parameters

        axisParamsLabel = new Label();
        axisParamsLabel.Size = new Size(200,30);
        axisParamsLabel.Location = new Point(10,20);
        axisParamsLabel.Text = "Axis Parameters";
        axisParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(axisParamsLabel);

        axisParamsSetLabel = new Label();
        axisParamsSetLabel.Size = new Size(50,20);
        axisParamsSetLabel.Location = new Point(140,50);
        axisParamsSetLabel.Text = "Set";
        //axisParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(axisParamsSetLabel);

        axisParamsActualLabel = new Label();
        axisParamsActualLabel.Size = new Size(50,20);
        axisParamsActualLabel.Location = new Point(200,50);
        axisParamsActualLabel.Text = "Actual";
        //axisParamsActualLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(axisParamsActualLabel);

        #region axis set

        #endregion

        #region axis read

        maxVelocityLabel = new Label();
        maxVelocityLabel.Size = new Size(100,20);
        maxVelocityLabel.Location = new Point(10,80);
        maxVelocityLabel.Text = "Max. Velocity";
        this.Controls.Add(maxVelocityLabel);

        maxVelocityText = new TextBox();
        maxVelocityText.Size = new Size(60,30);
        maxVelocityText.Location = new Point(120,75);
        //maxVelocityText.Text = "";
        this.Controls.Add(maxVelocityText);

        maxVelocityActualText = new TextBox();
        maxVelocityActualText.Size = new Size(60,30);
        maxVelocityActualText.Location = new Point(200,75);
        maxVelocityActualText.ReadOnly = true;
        //maxVelocityText.Text = "";
        this.Controls.Add(maxVelocityActualText);

        #endregion

        #region max acceleration

        maxAccelerationLabel = new Label();
        maxAccelerationLabel.Size = new Size(110,20);
        maxAccelerationLabel.Location = new Point(10,110);
        maxAccelerationLabel.Text = "Max. Acceleration";
        this.Controls.Add(maxAccelerationLabel);

        maxAccelerationText = new TextBox();
        maxAccelerationText.Size = new Size(60,30);
        maxAccelerationText.Location = new Point(120,105);
        //maxVelocityText.Text = "";
        this.Controls.Add(maxAccelerationText);

        maxAccelerationActualText = new TextBox();
        maxAccelerationActualText.Size = new Size(60,30);
        maxAccelerationActualText.Location = new Point(200,105);
        maxAccelerationActualText.ReadOnly = true;
        //maxVelocityText.Text = "";
        this.Controls.Add(maxAccelerationActualText);

        #endregion

        #region default acceleration

        defaultAccelLabel = new Label();
        defaultAccelLabel.Size = new Size(100,20);
        defaultAccelLabel.Location = new Point(10,140);
        defaultAccelLabel.Text = "Default Accel.";
        this.Controls.Add(defaultAccelLabel);

        defaultAccelText = new TextBox();
        defaultAccelText.Size = new Size(60,30);
        defaultAccelText.Location = new Point(120,135);
        //maxVelocityText.Text = "";
        this.Controls.Add(defaultAccelText);

        defaultAccelActualText = new TextBox();
        defaultAccelActualText.Size = new Size(60,30);
        defaultAccelActualText.Location = new Point(200,135);
        defaultAccelActualText.ReadOnly = true;
        //maxVelocityText.Text = "";
        this.Controls.Add(defaultAccelActualText);

        #endregion

        #region default jerk

        defaultJerkLabel = new Label();
        defaultJerkLabel.Size = new Size(100,20);
        defaultJerkLabel.Location = new Point(10,170);
        defaultJerkLabel.Text = "Default Jerk";
        this.Controls.Add(defaultJerkLabel);

        defaultJerkText = new TextBox();
        defaultJerkText.Size = new Size(60,30);
        defaultJerkText.Location = new Point(120,165);
        //maxVelocityText.Text = "";
        this.Controls.Add(defaultJerkText);

        defaultJerkActualText = new TextBox();
        defaultJerkActualText.Size = new Size(60,30);
        defaultJerkActualText.Location = new Point(200,165);
        defaultJerkActualText.ReadOnly = true;
        //maxVelocityText.Text = "";
        this.Controls.Add(defaultJerkActualText);

        #endregion

        #region homing velocity

        homingVelocLabel = new Label();
        homingVelocLabel.Size = new Size(100,20);
        homingVelocLabel.Location = new Point(10,200);
        homingVelocLabel.Text = "Homing Vel.";
        this.Controls.Add(homingVelocLabel);

        homingVelocText = new TextBox();
        homingVelocText.Size = new Size(60,30);
        homingVelocText.Location = new Point(120,195);
        //maxVelocityText.Text = "";
        this.Controls.Add(homingVelocText);

        homingVelocActualText = new TextBox();
        homingVelocActualText.Size = new Size(60,30);
        homingVelocActualText.Location = new Point(200,195);
        homingVelocActualText.ReadOnly = true;
        //maxVelocityText.Text = "";
        this.Controls.Add(homingVelocActualText);

        #endregion

        #region manual velocity fast

        manualVelocFastLabel = new Label();
        manualVelocFastLabel.Size = new Size(100,20);
        manualVelocFastLabel.Location = new Point(10,230);
        manualVelocFastLabel.Text = "Man. Vel. Fast";
        this.Controls.Add(manualVelocFastLabel);

        manualVelocFastText = new TextBox();
        manualVelocFastText.Size = new Size(60,30);
        manualVelocFastText.Location = new Point(120,225);
        //maxVelocityText.Text = "";
        this.Controls.Add(manualVelocFastText);

        manualVelocFastActualText = new TextBox();
        manualVelocFastActualText.Size = new Size(60,30);
        manualVelocFastActualText.Location = new Point(200,225);
        manualVelocFastActualText.ReadOnly = true;
        //maxVelocityText.Text = "";
        this.Controls.Add(manualVelocFastActualText);

        #endregion

        #region manual velocity slow

        manualVelocSlowLabel = new Label();
        manualVelocSlowLabel.Size = new Size(100,20);
        manualVelocSlowLabel.Location = new Point(10,260);
        manualVelocSlowLabel.Text = "Man. Vel. Slow";
        this.Controls.Add(manualVelocSlowLabel);

        manualVelocSlowText = new TextBox();
        manualVelocSlowText.Size = new Size(60,30);
        manualVelocSlowText.Location = new Point(120,255);
        //maxVelocityText.Text = "";
        this.Controls.Add(manualVelocSlowText);

        manualVelocSlowActualText = new TextBox();
        manualVelocSlowActualText.Size = new Size(60,225);
        manualVelocSlowActualText.Location = new Point(200,255);
        manualVelocSlowActualText.ReadOnly = true;
        //maxVelocityText.Text = "";
        this.Controls.Add(manualVelocSlowActualText);

        #endregion

        #region jog increment

        jogIncrementLabel = new Label();
        jogIncrementLabel.Size = new Size(100,20);
        jogIncrementLabel.Location = new Point(10,290);
        jogIncrementLabel.Text = "Jog Increment";
        this.Controls.Add(jogIncrementLabel);

        jogIncrementText = new TextBox();
        jogIncrementText.Size = new Size(60,30);
        jogIncrementText.Location = new Point(120,285);
        //maxVelocityText.Text = "";
        this.Controls.Add(jogIncrementText);

        jogIncrementActualText = new TextBox();
        jogIncrementActualText.Size = new Size(60,30);
        jogIncrementActualText.Location = new Point(200,285);
        jogIncrementActualText.ReadOnly = true;
        //maxVelocityText.Text = "";
        this.Controls.Add(jogIncrementActualText);

        #endregion

        #endregion

        #region encoder parameters

        encoderParamsLabel = new Label();
        encoderParamsLabel.Size = new Size(250,30);
        encoderParamsLabel.Location = new Point(300,20);
        encoderParamsLabel.Text = "Encoder Parameters";
        encoderParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(encoderParamsLabel);

        encoderParamsSetLabel = new Label();
        encoderParamsSetLabel.Size = new Size(50,20);
        encoderParamsSetLabel.Location = new Point(440,100);
        encoderParamsSetLabel.Text = "Set";
        this.Controls.Add(encoderParamsSetLabel);

        encoderParamsReadLabel = new Label();
        encoderParamsReadLabel.Size = new Size(50,20);
        encoderParamsReadLabel.Location = new Point(500,100);
        encoderParamsReadLabel.Text = "Actual";
        this.Controls.Add(encoderParamsReadLabel);

        #region encoder selection radio buttons

        controlLoop1Radio = new RadioButton();
        controlLoop1Radio.Size = new Size(20,20);
        controlLoop1Radio.Location = new Point(320,60);
        this.Controls.Add(controlLoop1Radio);
        controlLoop1Radio.Click += new EventHandler(controlLoopRadio_Click);

        controlLoop1Label = new Label();
        controlLoop1Label.Size = new Size(100,20);
        controlLoop1Label.Location = new Point(345,60);
        controlLoop1Label.Text = "Control loop 1";
        this.Controls.Add(controlLoop1Label);

        controlLoop2Radio = new RadioButton();
        controlLoop2Radio.Size = new Size(20,20);
        controlLoop2Radio.Location = new Point(320,80);
        this.Controls.Add(controlLoop2Radio);
        controlLoop2Radio.Click += new EventHandler(controlLoopRadio_Click);

        controlLoop2Label = new Label();
        controlLoop2Label.Size = new Size(100,20);
        controlLoop2Label.Location = new Point(345,80);
        controlLoop2Label.Text = "Control loop 2";
        this.Controls.Add(controlLoop2Label);

        getCurrentLoopID();

        #endregion

        #region encoder set 

        encoderInvertedDirectionLabel = new Label();
        encoderInvertedDirectionLabel.Size = new Size(100,20);
        encoderInvertedDirectionLabel.Location = new Point(300,130);
        encoderInvertedDirectionLabel.Text = "Inverted direction";
        //axisParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(encoderInvertedDirectionLabel);

        encoderInvertedDirectionCheck = new CheckBox();
        encoderInvertedDirectionCheck.Size = new Size(20,20);
        encoderInvertedDirectionCheck.Location = new Point(440,130);
        this.Controls.Add(encoderInvertedDirectionCheck);

        encoderScalingNumeratorLabel = new Label();
        encoderScalingNumeratorLabel.Size = new Size(100,40);
        encoderScalingNumeratorLabel.Location = new Point(300,160);
        encoderScalingNumeratorLabel.Text = "Scaling factor numerator";
        //axisParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(encoderScalingNumeratorLabel);

        encoderScalingNumeratorText = new TextBox();
        encoderScalingNumeratorText.Size = new Size(60,20);
        encoderScalingNumeratorText.Location = new Point(420,160);
        this.Controls.Add(encoderScalingNumeratorText);

        encoderScalingDenominatorLabel = new Label();
        encoderScalingDenominatorLabel.Size = new Size(100,40);
        encoderScalingDenominatorLabel.Location = new Point(300,210);
        encoderScalingDenominatorLabel.Text = "Scaling factor denominator";
        //axisParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(encoderScalingDenominatorLabel);

        encoderScalingDenominatorText = new TextBox();
        encoderScalingDenominatorText.Size = new Size(60,20);
        encoderScalingDenominatorText.Location = new Point(420,210);
        this.Controls.Add(encoderScalingDenominatorText);

        encoderOffsetLabel = new Label();
        encoderOffsetLabel.Size = new Size(100,20);
        encoderOffsetLabel.Location = new Point(300,265);
        encoderOffsetLabel.Text = "Encoder offset";
        //axisParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(encoderOffsetLabel);

        encoderOffsetText = new TextBox();
        encoderOffsetText.Size = new Size(60,20);
        encoderOffsetText.Location = new Point(420,260);
        this.Controls.Add(encoderOffsetText);

        encoderMaskLabel = new Label();
        encoderMaskLabel.Size = new Size(100,20);
        encoderMaskLabel.Location = new Point(300,295);
        encoderMaskLabel.Text = "Encoder mask";
        //axisParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(encoderMaskLabel);

        encoderMaskText = new TextBox();
        encoderMaskText.Size = new Size(60,20);
        encoderMaskText.Location = new Point(420,290);
        this.Controls.Add(encoderMaskText);

        encoderParamsSetButton = new Button();
        encoderParamsSetButton.Size = new Size(100,40);
        encoderParamsSetButton.Location = new Point(440,325);
        encoderParamsSetButton.Text = "Set Encoder Params";
        this.Controls.Add(encoderParamsSetButton);
        encoderParamsSetButton.Click += new EventHandler(encoderParamsSetButton_Click);

        #endregion 

        #region encoder read

        encoderInvertedDirectionReadText = new TextBox();
        encoderInvertedDirectionReadText.Size = new Size(60,20);
        encoderInvertedDirectionReadText.Location = new Point(500,130);
        encoderInvertedDirectionReadText.ReadOnly = true;
        this.Controls.Add(encoderInvertedDirectionReadText);

        encoderScalingNumeratorReadText = new TextBox();
        encoderScalingNumeratorReadText.Size = new Size(60,20);
        encoderScalingNumeratorReadText.Location = new Point(500,160);
        encoderScalingNumeratorReadText.ReadOnly = true;
        this.Controls.Add(encoderScalingNumeratorReadText);

        encoderScalingDenominatorReadText = new TextBox();
        encoderScalingDenominatorReadText.Size = new Size(60,20);
        encoderScalingDenominatorReadText.Location = new Point(500,210);
        encoderScalingDenominatorReadText.ReadOnly = true;
        this.Controls.Add(encoderScalingDenominatorReadText);

        encoderOffsetReadText = new TextBox();
        encoderOffsetReadText.Size = new Size(60,20);
        encoderOffsetReadText.Location = new Point(500,260);
        encoderOffsetReadText.ReadOnly = true;
        this.Controls.Add(encoderOffsetReadText);

        encoderMaskReadText = new TextBox();
        encoderMaskReadText.Size = new Size(60,20);
        encoderMaskReadText.Location = new Point(500,290);
        encoderMaskReadText.ReadOnly = true;
        this.Controls.Add(encoderMaskReadText);

        #endregion

        #endregion

        #region drive parameters

        driveParamsLabel = new Label();
        driveParamsLabel.Size = new Size(250,30);
        driveParamsLabel.Location = new Point(600,20);
        driveParamsLabel.Text = "Drive Parameters";
        driveParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(driveParamsLabel);

        driveParamsSetLabel = new Label();
        driveParamsSetLabel.Size = new Size(50,20);
        driveParamsSetLabel.Location = new Point(740,50);
        driveParamsSetLabel.Text = "Set";
        this.Controls.Add(driveParamsSetLabel);

        driveParamsReadLabel = new Label();
        driveParamsReadLabel.Size = new Size(50,20);
        driveParamsReadLabel.Location = new Point(800,50);
        driveParamsReadLabel.Text = "Actual";
        this.Controls.Add(driveParamsReadLabel);

        #region drive set

        #endregion

        #region drive read

        #endregion

        #endregion

        #region controller parameters

        controllerParamsLabel = new Label();
        controllerParamsLabel.Size = new Size(250,30);
        controllerParamsLabel.Location = new Point(900,20);
        controllerParamsLabel.Text = "Controller Parameters";
        controllerParamsLabel.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        this.Controls.Add(controllerParamsLabel);

        controllerParamsSetLabel = new Label();
        controllerParamsSetLabel.Size = new Size(50,20);
        controllerParamsSetLabel.Location = new Point(1040,50);
        controllerParamsSetLabel.Text = "Set";
        this.Controls.Add(controllerParamsSetLabel);

        controllerParamsReadLabel = new Label();
        controllerParamsReadLabel.Size = new Size(50,20);
        controllerParamsReadLabel.Location = new Point(1100,50);
        controllerParamsReadLabel.Text = "Actual";
        this.Controls.Add(controllerParamsReadLabel);

        #region controller set

        #endregion

        #region controller read

        #endregion

        #endregion
        
        CenterToScreen();
    }

}
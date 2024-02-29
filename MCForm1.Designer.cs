using System.Drawing.Printing;

namespace TwinCAT_ADS_MC;

partial class MCForm1
{

    public Label amsLabel;
    public Label localAMSLabel;
    public Label portLabel;
    public TextBox userAMSIDText;
    public TextBox userPortText;
    public CheckBox localCheckBox;
    public Label plcConnectedLabel;
    public Label axisConnectedLabel;
    public Button connectButton;

    public Label axesNumLabel;
    public TextBox axesNumText;
    public Button axisConnectButton;
    public Button axesSetupButton;

    public RadioButton moveAbsoluteRadio;
    public Label moveAbsoluteLabel;
    public RadioButton moveRelativeRadio;
    public Label moveRelativeLabel;
    public RadioButton moveHomeRadio;
    public Label moveHomeLabel;

    public Label setLabel;
    public Label readLabel;
    public Label positionLabel;
    public TextBox positionSetText;
    public TextBox positionActualText;
    public Label velocityLabel;
    public TextBox velocitySetText;
    public TextBox velocityActualText;
    
    public Button executeButton;

    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        this.Text = "TwinCAT-ADS-MC";

        FormDesignSetup();
    }

    private void FormDesignSetup()
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer(); // setup new timer for refreshing form data
        timer1.Interval=1000; // 1 second
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Start();

        #region AMS Net ID

        userAMSIDText = new TextBox(); // set position text box
        userAMSIDText.Size = new Size(125,20);
        userAMSIDText.Location = new Point(90,25);
        this.Controls.Add(userAMSIDText);

        amsLabel = new Label();
        amsLabel.Size = new Size(100,20);
        amsLabel.Location = new Point(10,30);
        amsLabel.Text = "AMS Net ID:";
        this.Controls.Add(amsLabel);

        # endregion

        #region Local checkbox

        localCheckBox = new CheckBox(); // checkbox
        localCheckBox.Size = new Size(20,20);
        localCheckBox.Location = new Point(150,50);
        this.Controls.Add(localCheckBox);
        localCheckBox.Click += new EventHandler(localCheckBox_Click);

        localAMSLabel = new Label();
        localAMSLabel.Size = new Size(80,20);
        localAMSLabel.Location = new Point(100,52);
        localAMSLabel.Text = "Local?";
        this.Controls.Add(localAMSLabel);

        #endregion

        #region Port

        userPortText = new TextBox(); // set position text box
        userPortText.Size = new Size(75,20);
        userPortText.Location = new Point(275,25);
        this.Controls.Add(userPortText);

        portLabel = new Label();
        portLabel.Size = new Size(50,20);
        portLabel.Location = new Point(225,30);
        portLabel.Text = "Port:";
        this.Controls.Add(portLabel);

        #endregion

        #region Connect button

        connectButton = new Button(); // initiialise button
        connectButton.Size = new Size(75,40);
        connectButton.Location = new Point(375,17);
        connectButton.Text = "Connect";
        this.Controls.Add(connectButton);
        connectButton.Click += new EventHandler(connectButton_Click);

        #endregion

        #region Axes number

        axesNumLabel = new Label();
        axesNumLabel.Size = new Size(60,20);
        axesNumLabel.Location = new Point(70,120);
        axesNumLabel.Text = "Axes No.";
        this.Controls.Add(axesNumLabel);
        
        axesNumText = new TextBox();
        axesNumText.Size = new Size(50,30);
        axesNumText.Location = new Point(150,110);
        axesNumText.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);
        axesNumText.Text = "1";
        this.Controls.Add(axesNumText);

        #endregion

        #region Axes connect button

        axisConnectButton = new Button();
        axisConnectButton.Size = new Size(75,40);
        axisConnectButton.Location = new Point(225,105);
        axisConnectButton.Text = "Connect to Axis";
        this.Controls.Add(axisConnectButton);
        axisConnectButton.Click += new EventHandler(axisConnectButton_Click);

        #endregion

        #region Axes setup button

        axesSetupButton = new Button();
        axesSetupButton.Size = new Size(75,40);
        axesSetupButton.Location = new Point(350,105);
        axesSetupButton.Text = "Axes Setup";
        this.Controls.Add(axesSetupButton);
        axesSetupButton.Click += new EventHandler(axesSetupButton_Click);

        #endregion

        #region Set / Read Labels

        setLabel = new Label();
        setLabel.Size = new Size(100,20);
        setLabel.Location = new Point(175,225);
        setLabel.Text = "Set:";
        this.Controls.Add(setLabel);

        readLabel = new Label();
        readLabel.Size = new Size(100,20);
        readLabel.Location = new Point(325,225);
        readLabel.Text = "Actual:";
        this.Controls.Add(readLabel);

        #endregion

        #region Position

        positionLabel = new Label();
        positionLabel.Size = new Size(60,20);
        positionLabel.Location = new Point(20,250);
        positionLabel.Text = "Position:";
        this.Controls.Add(positionLabel);

        positionSetText = new TextBox(); // set position text box
        positionSetText.Size = new Size(100,50);
        positionSetText.Location = new Point(150,250);
        this.Controls.Add(positionSetText);

        positionActualText = new TextBox(); // actual read set position text box
        positionActualText.Size = new Size(75,50);
        positionActualText.Location = new Point(325,250);
        positionActualText.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Italic);
        positionActualText.ReadOnly = true;
        this.Controls.Add(positionActualText);

        #endregion

        #region Velocity

        velocityLabel = new Label();
        velocityLabel.Size = new Size(60,20);
        velocityLabel.Location = new Point(20,300);
        velocityLabel.Text = "Velocity:";
        this.Controls.Add(velocityLabel);

        velocitySetText = new TextBox(); // set velocity text box
        velocitySetText.Size = new Size(100,50);
        velocitySetText.Location = new Point(150,300);
        this.Controls.Add(velocitySetText);

        velocityActualText = new TextBox(); // actual read velocity text box
        velocityActualText.Size = new Size(75,50);
        velocityActualText.Location = new Point(325,300);
        velocityActualText.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Italic);
        velocityActualText.ReadOnly = true;
        this.Controls.Add(velocityActualText);

        #endregion

        #region Acceleration

        //accelerationLabel = new Label();
        //accelerationLabel.Size = new Size(80,20);
        //accelerationLabel.Location = new Point(20,350);
        //accelerationLabel.Text = "Acceleration:";
        //this.Controls.Add(accelerationLabel);

        //setAcclText = new TextBox(); // set position text box
        //setAcclText.Size = new Size(100,50);
        //setAcclText.Location = new Point(150,350);
        //this.Controls.Add(setAcclText);

        //readAcclText = new TextBox(); // actual read set position text box
        //readAcclText.Size = new Size(75,50);
        //readAcclText.Location = new Point(325,350);
        //readAcclText.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Italic);
        //readAcclText.ReadOnly = true;
        //this.Controls.Add(readAcclText);

        #endregion

        #region Execute button

        executeButton = new Button();
        executeButton.Size = new Size(75,40);
        executeButton.Location = new Point(175,400);
        executeButton.Text = "Execute Move";
        this.Controls.Add(executeButton);
        executeButton.Click += new EventHandler(executeButton_Click);

        #endregion

        #region move command type radio buttons

        moveAbsoluteRadio = new RadioButton();
        moveAbsoluteRadio.Size = new Size(20,20);
        moveAbsoluteRadio.Location = new Point(125,175);
        this.Controls.Add(moveAbsoluteRadio);
        moveAbsoluteRadio.Click += new EventHandler(moveAbsoluteRadio_Click);

        moveAbsoluteLabel = new Label();
        moveAbsoluteLabel.Size = new Size(100,20);
        moveAbsoluteLabel.Location = new Point(35,175);
        moveAbsoluteLabel.Text = "Move Absolute:";
        this.Controls.Add(moveAbsoluteLabel);

        moveRelativeRadio = new RadioButton();
        moveRelativeRadio.Size = new Size(20,20);
        moveRelativeRadio.Location = new Point(275,175);
        this.Controls.Add(moveRelativeRadio);
        moveRelativeRadio.Click += new EventHandler(moveRelativeRadio_Click);

        moveRelativeLabel = new Label();
        moveRelativeLabel.Size = new Size(100,20);
        moveRelativeLabel.Location = new Point(185,175);
        moveRelativeLabel.Text = "Move Relative:";
        this.Controls.Add(moveRelativeLabel);

        moveHomeRadio = new RadioButton();
        moveHomeRadio.Size = new Size(20,20);
        moveHomeRadio.Location = new Point(425,175);
        this.Controls.Add(moveHomeRadio);
        moveHomeRadio.Click += new EventHandler(moveHomeRadio_Click);

        moveHomeLabel = new Label();
        moveHomeLabel.Size = new Size(100,20);
        moveHomeLabel.Location = new Point(335,175);
        moveHomeLabel.Text = "Move Home:";
        this.Controls.Add(moveHomeLabel);

        #endregion

        #region Connected labels
        
        plcConnectedLabel = new Label();
        plcConnectedLabel.Size = new Size(100,20);
        plcConnectedLabel.Location = new Point(375,60);
        plcConnectedLabel.Text = "Disconnected";
        plcConnectedLabel.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Italic);
        this.Controls.Add(plcConnectedLabel);

        axisConnectedLabel = new Label();
        axisConnectedLabel.Size = new Size(100,20);
        axisConnectedLabel.Location = new Point(225,150);
        axisConnectedLabel.Text = "Disconnected";
        axisConnectedLabel.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Italic);
        this.Controls.Add(axisConnectedLabel);   


        #endregion

        CenterToScreen();
    }
}

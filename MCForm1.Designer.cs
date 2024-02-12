namespace TwinCAT_ADS_MC;

partial class MCForm1
{
    public Button newSetPos;
    public Button newVelCmd;
    public TextBox setPosText;
    public TextBox readPosText;
    public TextBox setVelText;
    public TextBox readVelText;
    public CheckBox checkBOX;
    public Button initButton;
    public Label checkBoxText;
    /// <summary>
    ///  Required designer variable.
    /// </summary>
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

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(350, 300);
        this.Text = "TwinCAT-ADS-MC";

        FormDesignSetup();
    }

    private void FormDesignSetup()
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer(); // setup new timer for refreshing form data
        timer1.Interval=1000; // 5 seconds
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Start();

        initButton = new Button(); // initiialise button
        initButton.Size = new Size(150,40);
        initButton.Location = new Point(25,25);
        initButton.Text = "Initialise PLC";
        this.Controls.Add(initButton);
        initButton.Click += new EventHandler(initButton_Click);

        setPosText = new TextBox(); // set position text box
        setPosText.Size = new Size(100,50);
        setPosText.Location = new Point(25,105);
        this.Controls.Add(setPosText);

        readPosText = new TextBox(); // actual read set position text box
        readPosText.Size = new Size(75,50);
        readPosText.Location = new Point(250,105);
        readPosText.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Italic);
        this.Controls.Add(readPosText);

        setVelText = new TextBox(); // set velocity text box
        setVelText.Size = new Size(100,50);
        setVelText.Location = new Point(25,175);
        this.Controls.Add(setVelText);

        readVelText = new TextBox(); // actual read velocity text box
        readVelText.Size = new Size(75,50);
        readVelText.Location = new Point(250,175);
        readVelText.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Italic);
        this.Controls.Add(readVelText);

        newSetPos = new Button(); // new set position button
        newSetPos.Size = new Size(80, 60);
        newSetPos.Location = new Point(150, 85);
        newSetPos.Text = "Set Position";
        this.Controls.Add(newSetPos);
        newSetPos.Click += new EventHandler(newSetPos_Click);

        newVelCmd = new Button(); // new set velocity command button
        newVelCmd.Size = new Size(80, 60);
        newVelCmd.Location = new Point(150, 160);
        newVelCmd.Text = "Set Velocity";
        this.Controls.Add(newVelCmd);
        newVelCmd.Click += new EventHandler(newVelCmd_Click);

        checkBOX = new CheckBox(); // checkbox
        checkBOX.Size = new Size(20,20);
        checkBOX.Location = new Point(180,250);
        this.Controls.Add(checkBOX);
        checkBOX.Click += new EventHandler(checkBox_Click);

        checkBoxText = new Label();
        checkBoxText.Size = new Size(120,60);
        checkBoxText.Location = new Point(25,250);
        checkBoxText.Text = "Checkbox value 3";
        this.Controls.Add(checkBoxText);

        CenterToScreen();
    }

    #endregion
}

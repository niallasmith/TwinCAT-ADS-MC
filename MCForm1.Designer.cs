﻿using System.Drawing.Printing;

namespace TwinCAT_ADS_MC;

partial class MCForm1
{
    public TextBox userAMSIDText;
    public TextBox userPortText;
    public CheckBox localCheckBox;
    public Button connectButton;
    public Label axesNumLabel;
    public TextBox axesNumText;
    public Button axesSetupButton;
    //public Button newSetPos;
    //public Button newVelCmd;
    public TextBox setPosText;
    public TextBox readPosText;
    public TextBox setVelText;
    public TextBox readVelText;
    public TextBox setAcclText;
    public TextBox readAcclText;
    public Label velocityLabel;
    public Label accelerationLabel;
    public Label positionLabel;
    public Label setLabel;
    public Label readLabel;
    public Button executeButton;
    //public CheckBox checkBOX;
    //public Label checkBoxText;
    public Label amsLabel;
    public Label localAMSLabel;
    public Label portLabel;
    public RadioButton moveAbsoluteRadio;
    public Label moveAbsoluteLabel;
    public RadioButton moveRelativeRadio;
    public Label moveRelativeLabel;
    public RadioButton moveHomeRadio;
    public Label moveHomeLabel;
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
        timer1.Interval=1000; // 5 seconds
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
        axesNumText.Leave += new EventHandler(axesNumText_Leave);
        axesNumText.MouseLeave += new EventHandler(axesNumText_Leave);
        axesNumText.Text = "1";
        this.Controls.Add(axesNumText);

        #endregion

        #region Axes setup button

        axesSetupButton = new Button();
        axesSetupButton.Size = new Size(75,40);
        axesSetupButton.Location = new Point(275,105);
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

        setPosText = new TextBox(); // set position text box
        setPosText.Size = new Size(100,50);
        setPosText.Location = new Point(150,250);
        this.Controls.Add(setPosText);

        readPosText = new TextBox(); // actual read set position text box
        readPosText.Size = new Size(75,50);
        readPosText.Location = new Point(325,250);
        readPosText.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Italic);
        this.Controls.Add(readPosText);
        
        /*

        newSetPos = new Button(); // new set position button
        newSetPos.Size = new Size(80, 60);
        newSetPos.Location = new Point(150, 85);
        newSetPos.Text = "Set Position";
        this.Controls.Add(newSetPos);
        newSetPos.Click += new EventHandler(newSetPos_Click);

        */

        #endregion

        #region Velocity

        positionLabel = new Label();
        positionLabel.Size = new Size(60,20);
        positionLabel.Location = new Point(20,300);
        positionLabel.Text = "Velocity:";
        this.Controls.Add(positionLabel);

        setVelText = new TextBox(); // set velocity text box
        setVelText.Size = new Size(100,50);
        setVelText.Location = new Point(150,300);
        this.Controls.Add(setVelText);

        readVelText = new TextBox(); // actual read velocity text box
        readVelText.Size = new Size(75,50);
        readVelText.Location = new Point(325,300);
        readVelText.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Italic);
        this.Controls.Add(readVelText);

        /*

        newVelCmd = new Button(); // new set velocity command button
        newVelCmd.Size = new Size(80, 60);
        newVelCmd.Location = new Point(150, 160);
        newVelCmd.Text = "Set Velocity";
        this.Controls.Add(newVelCmd);
        newVelCmd.Click += new EventHandler(newVelCmd_Click);

        */

        #endregion

        #region Acceleration

        accelerationLabel = new Label();
        accelerationLabel.Size = new Size(80,20);
        accelerationLabel.Location = new Point(20,350);
        accelerationLabel.Text = "Acceleration:";
        this.Controls.Add(accelerationLabel);

        setAcclText = new TextBox(); // set position text box
        setAcclText.Size = new Size(100,50);
        setAcclText.Location = new Point(150,350);
        this.Controls.Add(setAcclText);

        readAcclText = new TextBox(); // actual read set position text box
        readAcclText.Size = new Size(75,50);
        readAcclText.Location = new Point(325,350);
        readAcclText.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Italic);
        this.Controls.Add(readAcclText);

        #endregion

        //checkBOX = new CheckBox(); // checkbox
        //checkBOX.Size = new Size(20,20);
        //checkBOX.Location = new Point(180,250);
        //this.Controls.Add(checkBOX);
        //checkBOX.Click += new EventHandler(checkBox_Click);

        //checkBoxText = new Label();
        //checkBoxText.Size = new Size(120,60);
        //checkBoxText.Location = new Point(25,250);
        //checkBoxText.Text = "Checkbox value 3";
        //this.Controls.Add(checkBoxText);

        #region Execute button

        executeButton = new Button();
        executeButton.Size = new Size(75,40);
        executeButton.Location = new Point(175,400);
        executeButton.Text = "Execute Move";
        this.Controls.Add(executeButton);
        executeButton.Click += new EventHandler(executeButton_Click);

        #endregion

        #region radio buttons

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

        CenterToScreen();
    }
}
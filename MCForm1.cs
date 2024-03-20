// partial class of MCForm1 that contains basic form-related functions, including the constructor

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TwinCAT_ADS_MC;

public partial class MCForm1 : Form
{
    public MCForm1()
    {
        InitializeComponent(); // upon running MCForm1, this is called. InitializeComponent is held within MCForm1.Designer
    }

    public void RefreshMotionData(object[] readMotionArray) // refresh data in form
    {
        // called by timer1_Tick
        positionActualText.Text = Convert.ToString(readMotionArray[0]);
        velocityActualText.Text = Convert.ToString(readMotionArray[1]);
    }
}
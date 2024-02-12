using TwinCAT.PlcOpen;
using TwinCAT.Ads;
using System.Net.Sockets;
using System.DirectoryServices;
using System.Reflection.Metadata.Ecma335;

namespace TwinCAT_ADS_MC;

public class NCAxis
{
    public uint ftestValue1Handle;  // handles for PLC global variables
    public uint ftestValue2Handle;
    public uint btestValue3Handle;

    private uint _axisID;
    public uint AxisID
    {
        get { return _axisID; }
        set { _axisID = value; }
    }

    public NCAxis(PLC plc)  // NCAxis constructor
    {
        UpdateAxisInstance(plc);
    }

    public void UpdateAxisInstance(PLC plc) // create variable handles
    {
        try
        {
            ftestValue1Handle = plc.TcADS.CreateVariableHandle("GVL_Vars.testValue1");
            ftestValue2Handle = plc.TcADS.CreateVariableHandle("GVL_Vars.testValue2");
            btestValue3Handle = plc.TcADS.CreateVariableHandle("GVL_Vars.testValue3");
            System.Console.WriteLine("created variable handles successfully");
        }
        catch
        {
            System.Console.WriteLine("unsuccessful in creating variable handles");
        }

    }

    public void WriteValue1(PLC plc, ushort value) // write value to PLC
    {
        plc.TcADS.WriteAny(ftestValue1Handle,value);
    }

    public void WriteValue2(PLC plc, ushort value)
    {
        plc.TcADS.WriteAny(ftestValue2Handle,value);
    }

    public void WriteValue3(PLC plc, bool value)
    {
        plc.TcADS.WriteAny(btestValue3Handle,value);
    }

    public ushort ReadValue1(PLC plc) // read value from PLC
    {
        try
        {
            ushort resp = plc.TcADS.ReadAny<ushort>(ftestValue1Handle);
            return resp;
        }
        catch
        {
            return 0; // if error, return 0
        }
    }

    public ushort ReadValue2(PLC plc)
    {
        try
        {
            ushort resp = plc.TcADS.ReadAny<ushort>(ftestValue2Handle);
            return resp;
        }
        catch
        {
            return 0; // if error, return 0
        }
    }

}
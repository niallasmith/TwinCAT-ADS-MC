using TwinCAT.PlcOpen;
using TwinCAT.Ads;
using System.Net.Sockets;
using System.DirectoryServices;
using System.Reflection.Metadata.Ecma335;

namespace TwinCAT_ADS_MC;

public class NCAxis
{
    public uint fpositionHandle;  // handles for PLC global variables
    public uint fvelocityHandle;
    public uint faccelerationHandle;
    public uint bexecuteHandle;
    public ushort axisID;

    private uint _axisID;
    public uint AxisID
    {
        get { return _axisID; }
        set { _axisID = value; }
    }

    public NCAxis(PLC plc, ushort axisID)  // NCAxis constructor
    {
        UpdateAxisInstance(plc, axisID);
    }

    public void UpdateAxisInstance(PLC plc, ushort axisID) // create variable handles
    {
        try
        {
            fpositionHandle = plc.TcADS.CreateVariableHandle("GVL_VARS" + axisID + ".position");
            fvelocityHandle = plc.TcADS.CreateVariableHandle("GVL_VARS" + axisID + ".velocity");
            faccelerationHandle = plc.TcADS.CreateVariableHandle("GVL_VARS" + axisID + ".acceleration");
            bexecuteHandle = plc.TcADS.CreateVariableHandle("GVL_VARS" + axisID + ".execute");
            System.Console.WriteLine("created variable handles successfully");
        }
        catch
        {
            System.Console.WriteLine("unsuccessful in creating variable handles");
        }

    }

    public void WritePosition(PLC plc, ushort value) // write value to PLC
    {
        plc.TcADS.WriteAny(fpositionHandle,value);
    }

    public void WriteVelocity(PLC plc, ushort value)
    {
        plc.TcADS.WriteAny(fvelocityHandle,value);
    }

    public void WriteAcceleration(PLC plc, ushort value)
    {
        plc.TcADS.WriteAny(faccelerationHandle,value);
    }

    public ushort ReadPosition(PLC plc) // read value from PLC
    {
        try
        {
            ushort resp = plc.TcADS.ReadAny<ushort>(fpositionHandle);
            return resp;
        }
        catch
        {
            return 0; // if error, return 0
        }
    }

    public ushort ReadVelocity(PLC plc)
    {
        try
        {
            ushort resp = plc.TcADS.ReadAny<ushort>(fvelocityHandle);
            return resp;
        }
        catch
        {
            return 0; // if error, return 0
        }
    }

    public ushort ReadAcceleration(PLC plc)
    {
        try
        {
            ushort resp = plc.TcADS.ReadAny<ushort>(faccelerationHandle);
            return resp;
        }
        catch
        {
            return 0; // if error, return 0
        }
    }

    public void WriteExecute(PLC plc, bool value)
    {
        plc.TcADS.WriteAny(bexecuteHandle,value);
    }

}
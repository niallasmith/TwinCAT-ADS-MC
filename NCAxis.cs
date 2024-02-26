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
    public uint positionMethodHandle;
    public uint returnMethodHandle;

    private uint _axisID;
    public uint AxisID
    {
        get { return _axisID; }
        set { _axisID = value; }
    }

    public NCAxis(PLC plc, uint axisID)  // NCAxis constructor
    {
        UpdateAxisInstance(plc, axisID);
    }

    public void UpdateAxisInstance(PLC plc, uint axisID) // create variable handles
    {
        try
        {
            fpositionHandle = plc.TcADS.CreateVariableHandle("GVL_VARS" + axisID + ".position");
            fvelocityHandle = plc.TcADS.CreateVariableHandle("GVL_VARS" + axisID + ".velocity");
            faccelerationHandle = plc.TcADS.CreateVariableHandle("GVL_VARS" + axisID + ".acceleration");
            bexecuteHandle = plc.TcADS.CreateVariableHandle("GVL_VARS" + axisID + ".execute");
            //positionMethodHandle = plc.TcADS.CreateVariableHandle("MAIN.fbTest#M_MoveAbs.position");
            //returnMethodHandle = plc.TcADS.CreateVariableHandle("MAIN.fbTest#M_MoveAbs.resp");
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

    public void WriteAxisParameters(PLC plc, object[] vars)
    {
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_WriteAxisParameters", vars);
    }

    public object ReadAxisParameters(PLC plc, uint axisID, uint loopID)
    {
        object[] varsin = {axisID,loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadAxisParameters", varsin, out object[] vars);
        //plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadAxisParameters", null, out object[] vars);
        return vars;
    }

    /*
    public uint ReadActiveEncoder(PLC plc)
    {
        object[] varsin = new object[1];
        varsin[0] = 0;
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadActiveEncoder", varsin, out object[] vars);
        uint val = (uint)vars[0];
        System.Console.WriteLine(val);
        return val;
    }
    */
    public void SetActiveEncoder(PLC plc, uint axisID, uint loopID)
    {
        object[] vars = {axisID, loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_SetActiveEncoder", vars);
    }

    public void MoveAbsolute(PLC plc, uint axisID, uint loopID, uint position, uint velocity)
    {
        object[] varsEnable = {axisID,loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_EnableAxis",varsEnable);
        object[] vars = {axisID,loopID,position,velocity};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_MoveAbsolute",vars);
    }

    public void MoveRelative(PLC plc, uint axisID, uint loopID, uint position, uint velocity)
    {
        object[] varsEnable = {axisID,loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_EnableAxis",varsEnable);
        object[] vars = {axisID,loopID,position,velocity};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_MoveRelative",vars);
    }

    public object[] ReadEncoderParams(PLC plc, uint axisID, uint loopID)
    {
        object[] vars = new object[5];
        object[] varsin = {axisID, loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadEncoderParameters", varsin, out vars);
        return vars;
    }

    public void SetEncoderParams(PLC plc,object[] vars)
    {
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_WriteEncoderParameters", vars);
    }

    public object[] ReadActiveLoop(PLC plc, uint axisID)
    {
        object[] vars = new object[1];
        object[] varsin = {axisID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadActiveLoop", varsin, out vars);
        return vars;
    }

}
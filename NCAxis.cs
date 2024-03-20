// code that implements motion commands, and reading/writing data

using TwinCAT.PlcOpen;
using TwinCAT.Ads;
using System.Net.Sockets;
using System.DirectoryServices;
using System.Reflection.Metadata.Ecma335;
using System.Buffers;

namespace TwinCAT_ADS_MC;

public class NCAxis
{
    // variables only used if using variable handle approach, not currently used
    /*
    public uint fpositionHandle;  // handles for PLC global variables
    public uint fvelocityHandle;
    public uint faccelerationHandle;
    public ushort axisID;
    public uint bexecuteHandle;
    public uint positionMethodHandle;
    public uint returnMethodHandle;
    */
    
    // private Axis ID. this is not used
    private uint _axisID;
    public uint AxisID
    {
        get { return _axisID; }
        set { _axisID = value; }
    }

    public NCAxis(PLC plc, uint axisID)  // NCAxis constructor
    {
        //UpdateAxisInstance(plc, axisID);
    }

    // legacy code that no longer applied with the new approach to ADS communication
    // keeping it in case in the future it is useful

    /*

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

    */

    #region write data
    public void WriteAxisParameters(PLC plc, object[] axisInputArray)
    {
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_WriteAxisParameters", axisInputArray); // object variable is passed to method in PLC
        // does not return anything
    }

    public void SetActiveControlLoop(PLC plc, object[] loopInputArray)
    {
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_SetActiveEncoder", loopInputArray); // object variable is passed to method in PLC
        // does not return anything
    }

    public void WriteEncoderParameters(PLC plc, object[] encoderInputArray)
    {
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_WriteEncoderParameters", encoderInputArray); // object variable is passed to method in PLC
        // does not return anything
    }

    public void WriteControllerParameters(PLC plc, object[] controllerInputArray)
    {
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_WriteControllerParameters", controllerInputArray); // object variable is passed to method in PLC
        // does not return anything
    }

    public void WriteDriveParameters(PLC plc, object[] driveInputArray)
    {
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_WriteDriveParameters", driveInputArray); // object variable is passed to method in PLC
        // does not return anything
    }

    #endregion

    #region read data

    public object ReadAxisMotion(PLC plc, uint axisID)
    {
        object[] motionInputArray = {axisID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadAxisMotion", motionInputArray, out object[]? motionOutputArray); // object variable is read from the PLC

        if (motionOutputArray is null){ // if method return object is null, return an empty object
            object[] test = new object[0]; // empty object
            return test;
        }
        return motionOutputArray; // else if not null, return data
    }

    public object ReadAxisParameters(PLC plc, uint axisID, uint loopID)
    {
        object[] axisInputArray = {axisID,loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadAxisParameters", axisInputArray, out object[]? axisOutputArray); // object variable is read from the PLC

        if (axisOutputArray is null){ // if method return object is null, return an empty object
            object[] test = new object[0]; // empty object
            return test;
        }
        return axisOutputArray; // else if not null, return data
    }

    public object[] ReadEncoderParams(PLC plc, uint axisID, uint loopID)
    {
        object[] encoderInputArray = {axisID, loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadEncoderParameters", encoderInputArray, out object[]? encoderOutputArray); // object variable is read from the PLC
        
        if (encoderOutputArray is null){
            object[] emptyObject = new object[0]; // empty object
            return emptyObject;
        }
        return encoderOutputArray;
    }

    public object[] ReadActiveLoop(PLC plc, uint axisID)
    {
        object[] loopInputArray = {axisID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadActiveLoop", loopInputArray, out object[]? loopOutputArray); // object variable is read from the PLC
        
        if (loopOutputArray is null){
            object[] emptyObject = new object[0];
            return emptyObject;
        }
        return loopOutputArray;
    }

    public object[] ReadDriveParameters(PLC plc, uint axisID, uint loopID)
    {
        object[] driveInputArray = {axisID, loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadDriveParameters", driveInputArray, out object[]? driveOutputArray ); // object variable is read from the PLC
        
        if (driveOutputArray is null){
            object[] emptyObject = new object[0];
            return emptyObject;
        }
        return driveOutputArray;
    }

        public object[] ReadControllerParameters(PLC plc, uint axisID, uint loopID)
    {
        object[] controllerInputArray = {axisID, loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_ReadControllerParameters", controllerInputArray, out object[]? controllerOutputArray); // object variable is read from the PLC
        
        if (controllerOutputArray is null){
            object[] emptyObject = new object[0];
            return emptyObject;
        }
        return controllerOutputArray;
    }

    #endregion

    #region motion commands
    public void MoveAbsolute(PLC plc, uint axisID, uint loopID, double position, double velocity) // TODO: make this a object array that is passed to the function
    {
        object[] enableInputArray = {axisID,loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_EnableAxis",enableInputArray); // call enable axis method
        object[] absoluteInputArray = {axisID,loopID,position,velocity};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_MoveAbsolute",absoluteInputArray); // call move absolute method
    }

    public void MoveRelative(PLC plc, uint axisID, uint loopID, double position, double velocity) // TODO: make this a object array that is passed to the function
    {
        object[] enableInputArray = {axisID,loopID};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_EnableAxis",enableInputArray); // call enable axis method
        object[] relativeInputArray = {axisID,loopID,position,velocity};
        plc.TcADS.InvokeRpcMethod("MAIN.FB_Functions","M_MoveRelative",relativeInputArray); // call move relative method 
    }

    // TODO: add move home function

    #endregion
    
}
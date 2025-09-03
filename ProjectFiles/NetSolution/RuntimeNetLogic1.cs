#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.HMIProject;
using FTOptix.NativeUI;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.EventLogger;
using FTOptix.Recipe;
using FTOptix.Core;
using FTOptix.NetLogic;
using FTOptix.Alarm;
using FTOptix.CommunicationDriver;
using FTOptix.Modbus;
using FTOptix.AuditSigning;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void MyMethod()
    {
        var input = Project.Current.GetVariable("Model/Audit Methods/VariableIN");
        var output = Project.Current.GetVariable("Model/Audit Methods/VariableOUT");
        output.Value = input.Value;
    }
}

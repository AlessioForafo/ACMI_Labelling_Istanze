#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.NativeUI;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
using System.Linq;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started

        foreach (ScreenType item in Project.Current.Get("UI/Screens").Children)
        {
            Log.Info(item.BrowseName);
            var myEnable = item.GetVariable("Abilitata");
            var dynamicLinkNode = myEnable.Refs.GetVariable(FTOptix.CoreBase.ReferenceTypes.HasDynamicLink);
            var pointedNode = dynamicLinkNode.Refs.GetNodes(FTOptix.Core.ReferenceTypes.Resolves).First();
            Log.Info(item.GetVariable("Abilitata").Value);
            Log.Info(Log.Node(pointedNode));
        }
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
}

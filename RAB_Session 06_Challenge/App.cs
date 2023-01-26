#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace RAB_Session_06_Challenge
{{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            string assemblyName = Utils.GetAssemblyName();

            // step 1: create ribbon tab (if needed)

            try
            {
                a.CreateRibbonTab("Revit Add-in Bootcamp");
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", "Ribbon tab already exists.");
                Debug.Print(ex.Message);
                return Result.Failed;
            }

            // step 2: create ribbon panel(s)

            RibbonPanel panel1 = a.CreateRibbonPanel("Revit Add-in Bootcamp", "Revit Tools");            

            // step 3: create Tool data instances

            PushButtonData pData1 = new PushButtonData("button1", "Tool 1", assemblyName, "RAB_Session_06_Challenge.cmdTool01");
            PushButtonData pData2 = new PushButtonData("button2", "Tool 2", assemblyName, "RAB_Session_06_Challenge.cmdTool02");
            PushButtonData pData3 = new PushButtonData("button3", "Tool 3", assemblyName, "RAB_Session_06_Challenge.cmdTool03");
            PushButtonData pData4 = new PushButtonData("button4", "Tool 4", assemblyName, "RAB_Session_06_Challenge.cmdTool04");
            PushButtonData pData5 = new PushButtonData("button5", "Tool 5", assemblyName, "RAB_Session_06_Challenge.cmdTool05");
            PushButtonData pData6 = new PushButtonData("button6", "Tool 6", assemblyName, "RAB_Session_06_Challenge.cmdTool06");
            PushButtonData pData7 = new PushButtonData("button3", "Tool 3", assemblyName, "RAB_Session_06_Challenge.cmdTool07");
            PushButtonData pData8 = new PushButtonData("button4", "Tool 4", assemblyName, "RAB_Session_06_Challenge.cmdTool08");
            PushButtonData pData9 = new PushButtonData("button5", "Tool 5", assemblyName, "RAB_Session_06_Challenge.cmdTool09");
            PushButtonData pData10 = new PushButtonData("button6", "Tool 6", assemblyName, "RAB_Session_06_Challenge.cmdTool10");

            PulldownButtonData pullDownData1 = new PulldownButtonData("pulldown1", "Pulldown Button");

            SplitButtonData splitData1 = new SplitButtonData("split1", "Split Button");

            // step 4: add images

            pData1.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_32);
            pData1.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_16);
            pData2.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Red_32);
            pData2.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Red_16);
            pData3.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Yellow_32);
            pData3.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Yellow_16);
            pData4.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Green_32);
            pData4.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Green_16);
            pData5.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_32);
            pData5.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_16);
            pData6.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Red_32);
            pData6.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Red_16);
            pData7.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Yellow_32);
            pData7.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Yellow_16);
            pData8.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Green_32);
            pData8.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Green_16);
            pData9.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_32);
            pData9.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_16);
            pData9.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Red_32);
            pData9.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Red_16);

            pullDownData1.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_32);

            // step 5: add tool tips

            pData1.ToolTip = "Tool 1 tool tip";
            pData2.ToolTip = "Tool 2 tool tip";
            pData3.ToolTip = "Tool 1 tool tip";
            pData4.ToolTip = "Tool 2 tool tip";
            pData5.ToolTip = "Tool 1 tool tip";
            pData6.ToolTip = "Tool 2 tool tip";
            pData7.ToolTip = "Tool 1 tool tip";
            pData8.ToolTip = "Tool 2 tool tip";
            pData9.ToolTip = "Tool 1 tool tip";
            pData10.ToolTip = "Tool 2 tool tip";

            // step 6: create buttons

            panel1.AddItem(pData1);
            panel1.AddItem(pData2);

            SplitTool split1 = panel1.AddItem(splitData1) as SplitButton;
            split1.AddPushButton(pData3);
            split1.AddPushButton(pData4);

            PulldownTool pull1 = panel2.AddItem(pullDownData1) as PulldownButton;
            pull1.AddPushButton(pData5);
            pull1.AddPushButton(pData6);

            panel3.AddStackedItems(pData1, pData2, pData3);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}

#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
#endregion

namespace RAB_Session_06_Challenge
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            string assemblyName = Utils.GetAssemblyName();

            // step 1: create ribbon tab

            try
            {
                app.CreateRibbonTab("Revit Add-in Bootcamp");
            }
            catch (Exception)
            {
                Debug.Print("Tab already exists");
            }

            // step 2: create ribbon panel

            RibbonPanel panel1 = Utils.CreateRibbonPanel(app, "Revit Add-in Bootcamp", "Revit Tools");           

            // step 3: create Tool data instances

            PushButtonData pData1 = new PushButtonData("button1", "Tool 1", assemblyName, "RAB_Session_06_Challenge.cmdTool01");
            PushButtonData pData2 = new PushButtonData("button2", "Tool 2", assemblyName, "RAB_Session_06_Challenge.cmdTool02");
            PushButtonData pData3 = new PushButtonData("button3", "Tool 3", assemblyName, "RAB_Session_06_Challenge.cmdTool03");
            PushButtonData pData4 = new PushButtonData("button4", "Tool 4", assemblyName, "RAB_Session_06_Challenge.cmdTool04");
            PushButtonData pData5 = new PushButtonData("button5", "Tool 5", assemblyName, "RAB_Session_06_Challenge.cmdTool05");
            PushButtonData pData6 = new PushButtonData("button6", "Tool 6", assemblyName, "RAB_Session_06_Challenge.cmdTool06");
            PushButtonData pData7 = new PushButtonData("button3", "Tool 7", assemblyName, "RAB_Session_06_Challenge.cmdTool07");
            PushButtonData pData8 = new PushButtonData("button4", "Tool 8", assemblyName, "RAB_Session_06_Challenge.cmdTool08");
            PushButtonData pData9 = new PushButtonData("button5", "Tool 9", assemblyName, "RAB_Session_06_Challenge.cmdTool09");
            PushButtonData pData10 = new PushButtonData("button6", "Tool 10", assemblyName, "RAB_Session_06_Challenge.cmdTool10");

            PulldownButtonData pullDownData1 = new PulldownButtonData("pulldown1", "More Tools");

            SplitButtonData splitData1 = new SplitButtonData("split1", "Split\rButton");

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
            pData10.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Red_32);
            pData10.Image = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Red_16);

            pullDownData1.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_32);

            // step 5: add tool tips

            pData1.ToolTip = "Deletes Revisions in project";
            pData2.ToolTip = "Deletes Buckup files in selected folder";
            pData3.ToolTip = "Mirrors project along specified axis";
            pData4.ToolTip = "Reverses all door swings";
            pData5.ToolTip = "Renames the side elevations";
            pData6.ToolTip = "Sets up all Levels, Views & Sheets for a new project";
            pData7.ToolTip = "Sets up al Views & Sheets for a new elevation in an existing project";
            pData8.ToolTip = "Renumbers Views on a Sheet";
            pData9.ToolTip = "Batch Sheet Rename";
            pData10.ToolTip = "Batch View Rename";

            // step 6: create buttons

            panel1.AddItem(pData1);
            panel1.AddItem(pData2);

            panel1.AddStackedItems(pData3, pData4, pData5);

            SplitButton split1 = panel1.AddItem(splitData1) as SplitButton;
            split1.AddPushButton(pData6);
            split1.AddPushButton(pData7);

            PulldownButton pull1 = panel1.AddItem(pullDownData1) as PulldownButton;
            pull1.AddPushButton(pData8);
            pull1.AddPushButton(pData9);
            pull1.AddPushButton(pData10);            

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }
    }
}

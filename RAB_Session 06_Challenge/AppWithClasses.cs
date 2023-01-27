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
    internal class AppWithClasses : IExternalApplication
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

            ButtonClass data1 = new ButtonClass("Tool1", "Tool 1", "RAB_Session_06_Challenge.cmdTool01",
                RAB_Session_06_Challenge.Properties.Resources.Blue_32,
                RAB_Session_06_Challenge.Properties.Resources.Blue_16, "Deletes Revisions in Project");
            ButtonClass data2 = new ButtonClass("Tool2", "Tool 2", "RAB_Session_06_Challenge.cmdTool02",
                RAB_Session_06_Challenge.Properties.Resources.Red_32,
                RAB_Session_06_Challenge.Properties.Resources.Red_16, "Deletes Buckup files in selected folder");
            ButtonClass data3 = new ButtonClass("Tool3", "Tool 3", "RAB_Session_06_Challenge.cmdTool03",
                RAB_Session_06_Challenge.Properties.Resources.Yellow_32,
                RAB_Session_06_Challenge.Properties.Resources.Yellow_16, "Mirrors project along specified axis");
            ButtonClass data4 = new ButtonClass("Tool4", "Tool 4", "RAB_Session_06_Challenge.cmdTool04",
                RAB_Session_06_Challenge.Properties.Resources.Green_32,
                RAB_Session_06_Challenge.Properties.Resources.Green_16, "Reverses all door swings");
            ButtonClass data5 = new ButtonClass("Tool5", "Tool 5", "RAB_Session_06_Challenge.cmdTool05",
                RAB_Session_06_Challenge.Properties.Resources.Blue_32,
                RAB_Session_06_Challenge.Properties.Resources.Blue_16, "Renames the side elevations");
            ButtonClass data6 = new ButtonClass("Tool6", "Tool 6", "RAB_Session_06_Challenge.cmdTool06",
                RAB_Session_06_Challenge.Properties.Resources.Red_32,
                RAB_Session_06_Challenge.Properties.Resources.Red_16, "Sets up all Levels, Views & Sheets for a new project");
            ButtonClass data7 = new ButtonClass("Tool7", "Tool 7", "RAB_Session_06_Challenge.cmdTool07",
                RAB_Session_06_Challenge.Properties.Resources.Yellow_32,
                RAB_Session_06_Challenge.Properties.Resources.Yellow_16, "Sets up all Views & Sheets for a new elevation in an existing project");
            ButtonClass data8 = new ButtonClass("Tool8", "Tool 8", "RAB_Session_06_Challenge.cmdTool08",
                RAB_Session_06_Challenge.Properties.Resources.Green_32,
                RAB_Session_06_Challenge.Properties.Resources.Green_16, "Renumbers Views on a Sheet");
            ButtonClass data9 = new ButtonClass("Tool9", "Tool 9", "RAB_Session_06_Challenge.cmdTool09",
                RAB_Session_06_Challenge.Properties.Resources.Blue_32,
                RAB_Session_06_Challenge.Properties.Resources.Blue_16, "Renames a group of sheets");
            ButtonClass data10 = new ButtonClass("Tool10", "Tool 10", "RAB_Session_06_Challenge.cmdTool10",
                RAB_Session_06_Challenge.Properties.Resources.Red_32,
                RAB_Session_06_Challenge.Properties.Resources.Red_16, "Renames a group of views");

            PulldownButtonData pullDownData1 = new PulldownButtonData("pulldown1", "More Tools");

            SplitButtonData splitData1 = new SplitButtonData("split1", "Split\rButton");

            // step 4: add images

            pullDownData1.LargeImage = Utils.BitmapToImageSource(RAB_Session_06_Challenge.Properties.Resources.Blue_32);

            // step 5: add tool tips           

            // step 6: create buttons

            panel1.AddItem(data1.Data);
            panel1.AddItem(data2.Data);

            panel1.AddStackedItems(data3.Data, data4.Data, data5.Data);

            SplitButton split1 = panel1.AddItem(splitData1) as SplitButton;
            split1.AddPushButton(data6.Data);
            split1.AddPushButton(data7.Data);

            PulldownButton pull1 = panel1.AddItem(pullDownData1) as PulldownButton;
            pull1.AddPushButton(data8.Data);
            pull1.AddPushButton(data9.Data);
            pull1.AddPushButton(data10.Data);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }
    }

    public class ButtonClass
    {
        public PushButtonData Data { get; set; }

        public ButtonClass(string name, string text, string className, System.Drawing.Bitmap largeImage,
            System.Drawing.Bitmap smallImage, string toolTip)
        {
            Data = new PushButtonData(name, text, Utils.GetAssemblyName(), className);
            Data.ToolTip = toolTip;
            Data.LargeImage = Utils.BitmapToImageSource(largeImage);
            Data.Image = Utils.BitmapToImageSource(smallImage);
        }
    }


}

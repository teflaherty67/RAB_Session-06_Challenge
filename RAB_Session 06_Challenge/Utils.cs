using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace RAB_Session_06_Challenge
{
    internal static class Utils
    {
        internal static BitmapImage BitmapToImageSource(Bitmap bm)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                bm.Save(mem, System.Drawing.Imaging.ImageFormat.Png);
                mem.Position = 0;
                BitmapImage bmi = new BitmapImage();
                bmi.BeginInit();
                bmi.StreamSource = mem;
                bmi.CacheOption = BitmapCacheOption.OnLoad;
                bmi.EndInit();

                return bmi;
            }
        }

        internal static RibbonPanel CreateRibbonPanel(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel curPanel = GetRibbonPanelByName(app, tabName, panelName);

            if (curPanel == null)
                curPanel = app.CreateRibbonPanel(tabName, panelName);

            return curPanel;
        }

        private static RibbonPanel GetRibbonPanelByName(UIControlledApplication app, string tabName, string panelName)
        {
            foreach (RibbonPanel tempPanel in app.GetRibbonPanels(tabName))
            {
                if (tempPanel.Name == panelName)
                    return tempPanel;
            }

            return null;
        }

        internal static string GetAssemblyName()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;
            return assemblyName;
        }
    }
}
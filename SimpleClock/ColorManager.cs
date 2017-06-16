using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SimpleClock
{
    public sealed class ColorManager
    {
        private static ColorManager instance = null;

        private static Dictionary<int, ColorSchema> Schemas { get; set; }


        public static ColorManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ColorManager();
                }
                return instance;
            }
        }

        public ColorSchema GetColorSchema(int idx)
        {
            if (Schemas.ContainsKey(idx))
            {
                return Schemas[idx];
            }
            else
            {
                return Schemas[-1];
            }
            
        }

        private ColorManager()
        {
            Schemas = new Dictionary<int, ColorSchema>() { { -1, new ColorSchema() { Text = Color.FromArgb(255, 255, 255), Background = Color.FromArgb(0,0,0) }  } };

            var keys = System.Configuration.ConfigurationSettings.AppSettings.AllKeys;
            if (keys.Any())
            {
                foreach (var key in keys)
                {
                    if (key.Contains("FontColor") && keys.Contains(key.Replace("FontColor", "BackgroundColor")))
                    {
                        int idx = int.Parse(key.Replace("FontColor", ""));

                        var textColorArr = System.Configuration.ConfigurationSettings.AppSettings[key].Split(',');
                        var textR = int.Parse(textColorArr[0]);
                        var textG = int.Parse(textColorArr[1]);
                        var textB = int.Parse(textColorArr[2]);

                        var backColorArr = System.Configuration.ConfigurationSettings.AppSettings[key.Replace("FontColor", "BackgroundColor")].Split(',');
                        var backR = int.Parse(backColorArr[0]);
                        var backG = int.Parse(backColorArr[1]);
                        var backB = int.Parse(backColorArr[2]);

                        Schemas.Add(idx, new ColorSchema() { Text = Color.FromArgb(textR, textG, textB), Background = Color.FromArgb(backR, backG, backB) });
                    }
                }
            }
            
            
        }
    }
}

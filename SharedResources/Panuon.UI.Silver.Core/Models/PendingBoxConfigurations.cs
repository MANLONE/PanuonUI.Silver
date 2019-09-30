﻿using Panuon.UI.Silver.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver.Core
{
    public class PendingBoxConfigurations
    {
        public PendingBoxConfigurations()
        {
            switch (Cache.Language)
            {
                case "zh-CN":
                    CancelButton = "取 消";
                    break;
            }
        }

        /// <summary>
        /// Loding style.
        /// </summary>
        public LoadingStyle LoadingStyle { get; set; } = LoadingStyle.Ring2;

        /// <summary>
        /// Theme Brush
        /// </summary>
        public Brush ButtonBrush { get; set; } = "#3E3E3E".ToColor().ToBrush();

        /// <summary>
        /// Loading stroke.
        /// </summary>
        public Brush LoadingBackground { get; set; } = Brushes.Transparent;

        /// <summary>
        /// Loading stroke cover
        /// </summary>
        public Brush LoadingForeground { get; set; } = "#3E3E3E".ToColor().ToBrush();

        /// <summary>
        /// Min height. Default : 250.
        /// </summary>
        public double MinHeight { get; set; } = 150;

        /// <summary>
        /// Min width. Default : 500.
        /// </summary>
        public double MinWidth { get; set; } = 400;

        /// <summary>
        /// Min height. Default : 250.
        /// </summary>
        public double MaxHeight { get; set; } = 150;

        /// <summary>
        /// Min width. Default : 500.
        /// </summary>
        public double MaxWidth { get; set; } = 400;

        /// <summary>
        /// Font size. Default : 16.
        /// </summary>
        public double FontSize { get; set; } = 16;

        /// <summary>
        /// Loading size
        /// </summary>
        public double LoadingSize { get; set; } = 35;

        /// <summary>
        /// Show in taskbar.
        /// </summary>
        public bool ShowInTaskbar { get; set; } = true;

        /// <summary>
        /// Topmost.
        /// </summary>
        public bool Topmost { get; set; } = true;

        /// <summary>
        /// Window startup location.
        /// </summary>
        public WindowStartupLocation WindowStartupLocation { get; set; } = WindowStartupLocation.CenterScreen;

        /// <summary>
        /// Show owner's mask when popuped, and hide it when closed. Only worked with WindowX type owner.
        /// </summary>
        public bool InteractOwnerMask { get; set; } = true;

        /// <summary>
        /// Content of cancel button. 
        /// </summary>
        public string CancelButton { get; set; } = "Cancel";

    }
}

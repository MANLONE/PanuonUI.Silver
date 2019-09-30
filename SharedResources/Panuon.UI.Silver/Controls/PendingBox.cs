﻿using Panuon.UI.Silver.Controls.Internal;
using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver
{
    public static class PendingBox
    {
        #region Identity
        public static IDictionary<string, PendingBoxConfigurations> PendingBoxConfigurations { get; }
        #endregion

        #region Constructor
        static PendingBox()
        {
            PendingBoxConfigurations = new Dictionary<string, PendingBoxConfigurations>();
        }
        #endregion

        #region Show API
        public static IPendingHandler Show(string message, string title = null)
        {
            return CallPendingBox(null, message, title, new PendingBoxConfigurations());
        }

        public static IPendingHandler Show(string message, string title = null, bool cancelable = false)
        {
            return CallPendingBox(null, message, title,  new PendingBoxConfigurations());
        }

        public static IPendingHandler Show(string message, string title = null, bool cancelable = false, Window owner = null)
        {
            return CallPendingBox(owner, message, title, new PendingBoxConfigurations());
        }


        public static IPendingHandler Show(string message, string title = null, bool cancelable = false, Window owner = null, string configKey = null)
        {
            PendingBoxConfigurations pendingBoxConfigurations = null;

            if (configKey.IsNullOrEmpty())
                pendingBoxConfigurations = new PendingBoxConfigurations();
            else
            {
                if (!PendingBoxConfigurations.ContainsKey(configKey))
                    throw new Exception($"Configuration key \"{configKey}\" does not exists.");

                pendingBoxConfigurations = PendingBoxConfigurations[configKey];
            }

            return CallPendingBox(owner, message, title, pendingBoxConfigurations);
        }

        public static IPendingHandler Show(string message, string title = null, bool cancelable = false, Window owner = null, PendingBoxConfigurations configurations = null)
        {
            if (configurations == null)
                configurations = new PendingBoxConfigurations();

            return CallPendingBox(owner, message, title, configurations);
        }
        #endregion

        #region Function
        private static IPendingHandler CallPendingBox(Window owner, string message, string title, PendingBoxConfigurations configurations)
        {
            var msb = new Controls.Internal.PendingBox(owner, message, title, configurations);
            var handler = new PendingHandler(() =>
            {
                msb.ForceClose();
            }, (s)=> 
            {
                msb.UpdateMessage(s);
            });

            WindowX windowX = null;

            if (configurations.InteractOwnerMask && owner != null && owner is WindowX)
                windowX = owner as WindowX;

            if (windowX != null)
                windowX.IsMaskVisible = true;
            msb.Closed += (s, e) =>
            {
                if (windowX != null)
                    windowX.IsMaskVisible = false;
                handler.RaiseCanceledEvent(s, e);
            };
            msb.Canceled += (s, e) =>
            {
                handler.RaiseCanceledEvent(s, e);
            };
            msb.Show();

            return handler;
        }
        #endregion
    }
}

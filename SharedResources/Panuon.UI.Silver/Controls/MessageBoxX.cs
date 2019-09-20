﻿using Panuon.UI.Silver.Controls.Internal;
using Panuon.UI.Silver.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver
{
    public static class MessageBoxX
    {
        #region Identity
        public static Dictionary<string, MessageBoxXConfigurations> MessageBoxXConfigurations { get; }
        #endregion

        #region Constructor
        static MessageBoxX()
        {
            MessageBoxXConfigurations = new Dictionary<string, MessageBoxXConfigurations>();
        }
        #endregion

        #region Show API
        public static MessageBoxResult Show(string message, string title = null)
        {
            return CallMsgBox(null, message, title, MessageBoxButton.OK, new MessageBoxXConfigurations());
        }

        public static MessageBoxResult Show(string message, string title = null, Window owner = null)
        {
            return CallMsgBox(owner, message, title,  MessageBoxButton.OK, new MessageBoxXConfigurations());
        }

        public static MessageBoxResult Show(string message, string title = null, Window owner = null, MessageBoxButton messageBoxButton = MessageBoxButton.OK)
        {
            return CallMsgBox(owner, message, title, messageBoxButton, new MessageBoxXConfigurations());
        }

        public static MessageBoxResult Show(string message, string title = null, Window owner = null, MessageBoxButton messageBoxButton = MessageBoxButton.OK, string configKey = null)
        {
            MessageBoxXConfigurations messageBoxXConfigurations = null;

            if (configKey.IsNullOrEmpty())
                messageBoxXConfigurations = new MessageBoxXConfigurations();
            else
            {
                if (!MessageBoxXConfigurations.ContainsKey(configKey))
                    throw new Exception($"Configuration key \"{configKey}\" does not exists.");

                messageBoxXConfigurations = MessageBoxXConfigurations[configKey];
            }

            return CallMsgBox(owner, message, title, messageBoxButton, messageBoxXConfigurations);
        }

        public static MessageBoxResult Show(string message, string title = null, Window owner = null, MessageBoxButton messageBoxButton = MessageBoxButton.OK, MessageBoxXConfigurations configurations = null)
        {
            if (configurations == null)
                configurations = new MessageBoxXConfigurations();

            return CallMsgBox(owner, message, title, messageBoxButton, configurations);
        }

        public static IWaitingHandler ShowWaiting(string message, string title = null, Window owner = null)
        {
            var window = new Window();
            window.ShowDialog();
            return new WaitingHandler(window);
        }

        public static IWaitingHandler ShowWaiting(string message, string title = null, Window owner = null, Action cancellectionCallback = null)
        {
            var window = new Window();
            window.ShowDialog();
            return new WaitingHandler(window);
        }
        #endregion

        #region Function
        private static MessageBoxResult CallMsgBox(Window owner, string message, string title, MessageBoxButton messageBoxButton, MessageBoxXConfigurations configurations)
        {
            var msb = new MsgBox(owner, message, title, messageBoxButton, configurations);

            WindowX windowX = null;

            if(configurations.InteractOwnerMask && owner != null && owner is WindowX)
                windowX = owner as WindowX;

            if(windowX != null)
                windowX.IsMaskVisible = true;
            msb.ShowDialog();
            if (windowX != null)
                windowX.IsMaskVisible = false;

            return msb.MessageBoxResult;
        }

        private static MessageBoxResult CallWaitingBox(Window owner, string message, string title, MessageBoxButton messageBoxButton, MessageBoxXConfigurations configurations)
        {
            var msb = new MsgBox(owner, message, title, messageBoxButton, configurations);

            WindowX windowX = null;

            if (configurations.InteractOwnerMask && owner != null && owner is WindowX)
                windowX = owner as WindowX;

            if (windowX != null)
                windowX.IsMaskVisible = true;
            msb.ShowDialog();
            if (windowX != null)
                windowX.IsMaskVisible = false;

            return msb.MessageBoxResult;
        }
        #endregion
    }


}

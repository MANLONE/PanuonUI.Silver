﻿using System.Windows;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class ContextMenuHelper
    {
        #region CornerRadius
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ContextMenuHelper));
        #endregion

        #region HoverForeground
        public static Brush GetHoverForeground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverForegroundProperty);
        }

        public static void SetHoverForeground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverForegroundProperty, value);
        }

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.RegisterAttached("HoverForeground", typeof(Brush), typeof(ContextMenuHelper));
        #endregion

        #region HoverBackground
        public static Brush GetHoverBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HoverBackgroundProperty);
        }

        public static void SetHoverBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(HoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.RegisterAttached("HoverBackground", typeof(Brush), typeof(ContextMenuHelper));
        #endregion

        #region CheckedIconBrush
        public static Brush GetCheckedIconBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(CheckedIconBrushProperty);
        }

        public static void SetCheckedIconBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(CheckedIconBrushProperty, value);
        }

        public static readonly DependencyProperty CheckedIconBrushProperty =
            DependencyProperty.RegisterAttached("CheckedIconBrush", typeof(Brush), typeof(ContextMenuHelper));
        #endregion

        #region CheckedIcon
        public static object GetCheckedIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(CheckedIconProperty);
        }

        public static void SetCheckedIcon(DependencyObject obj, object value)
        {
            obj.SetValue(CheckedIconProperty, value);
        }

        public static readonly DependencyProperty CheckedIconProperty =
            DependencyProperty.RegisterAttached("CheckedIcon", typeof(object), typeof(ContextMenuHelper));
        #endregion

        #region ShadowColor
        public static Color? GetShadowColor(DependencyObject obj)
        {
            return (Color?)obj.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(DependencyObject obj, Color? value)
        {
            obj.SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.RegisterAttached("ShadowColor", typeof(Color?), typeof(ContextMenuHelper));
        #endregion

        #region ItemIconWidth
        public static string GetItemIconWidth(DependencyObject obj)
        {
            return (string)obj.GetValue(ItemIconWidthProperty);
        }

        public static void SetItemIconWidth(DependencyObject obj, string value)
        {
            obj.SetValue(ItemIconWidthProperty, value);
        }

        public static readonly DependencyProperty ItemIconWidthProperty =
            DependencyProperty.RegisterAttached("ItemIconWidth", typeof(string), typeof(ContextMenuHelper));
        #endregion

        #region ItemHeight
        public static double GetItemHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(ItemHeightProperty);
        }

        public static void SetItemHeight(DependencyObject obj, double value)
        {
            obj.SetValue(ItemHeightProperty, value);
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.RegisterAttached("ItemHeight", typeof(double), typeof(ContextMenuHelper));
        #endregion

        #region ItemPadding
        public static Thickness GetItemPadding(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(ItemPaddingProperty);
        }

        public static void SetItemPadding(DependencyObject obj, Thickness value)
        {
            obj.SetValue(ItemPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.RegisterAttached("ItemPadding", typeof(Thickness), typeof(ContextMenuHelper));


        #endregion
    }
}

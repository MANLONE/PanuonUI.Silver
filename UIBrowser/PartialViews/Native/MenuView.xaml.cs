﻿using Panuon.UI.Silver;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using UIBrowser.Helpers;

namespace UIBrowser.PartialViews.Native
{
    /// <summary>
    /// MenuView.xaml 的交互逻辑
    /// </summary>
    public partial class MenuView : UserControl
    {
        #region Identity
        private bool _isCodeViewing;

        private LinearGradientBrush _linearGradientBrush;
        #endregion

        public MenuView()
        {
            InitializeComponent();
            Loaded += ButtonView_Loaded;
            UpdateVisualEffect();
            _linearGradientBrush = FindResource("ColorSelectorBrush") as LinearGradientBrush;
        }

        #region Event

        private void ButtonView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTemplate();
            UpdateCode();
        }

        private void SldTheme_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }

        private void SldCornerRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsLoaded)
                return;

            UpdateTemplate();
            UpdateCode();
        }


        private void BtnViewCode_Click(object sender, RoutedEventArgs e)
        {
            if (_isCodeViewing)
            {
                if (Helper.Tier == 2)
                {
                    AnimationHelper.SetEasingFunction(GrpPalette, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GrpPalette, new Thickness(0, 0, 0, 0));
                    AnimationHelper.SetEasingFunction(GrpCode, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GrpCode, new Thickness(0, 0, 0, 0));
                }
                else
                {
                    GrpPalette.Margin = new Thickness(0, 0, 0, 0);
                    GrpCode.Margin = new Thickness(0, 0, 0, 0);
                }
                BtnViewCode.Content = Properties.Resource.ViewCode;
            }
            else
            {
                if (Helper.Tier == 2)
                {
                    AnimationHelper.SetEasingFunction(GrpPalette, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GrpPalette, new Thickness(0, -120, 0, 0));
                    AnimationHelper.SetEasingFunction(GrpCode, new CubicEase() { EasingMode = EasingMode.EaseOut });
                    AnimationHelper.SetMarginTo(GrpCode, new Thickness(0, 0, 0, -120));
                }
                else
                {
                    GrpPalette.Margin = new Thickness(0, -120, 0, 0);
                    GrpCode.Margin = new Thickness(0, 0, 0, -120);
                }
                BtnViewCode.Content = Properties.Resource.CloseCodeViewer;
            }
            _isCodeViewing = !_isCodeViewing;
        }

        private void MenuItem_CopyCode(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(TbCode.Text);
        }

        #endregion

        #region Function
        private void UpdateVisualEffect()
        {
            switch (Helper.Tier)
            {
                case 1:
                case 2:
                    AnimationHelper.SetSlideInFromBottom(GrpPalette, true);
                    RectBackground.Fill = FindResource("GridBrush") as Brush;
                    GroupBoxHelper.SetEffect(GrpPalette, FindResource("DropShadow") as Effect);
                    GroupBoxHelper.SetEffect(GrpCode, FindResource("DropShadow") as Effect);
                    break;
            }
        }
        private void UpdateTemplate()
        {
            var color = Helper.GetColorByOffset(_linearGradientBrush.GradientStops, SldTheme.Value / 7);
            MenuHelper.SetHoverBackground(MenuCustom, color.ToBrush());
        }

        private void UpdateCode()
        {
            //var icon = ComboBoxHelper.GetIcon(CmbCustom);
            //var watermark = ComboBoxHelper.GetWatermark(CmbCustom);
            //var cornerRadius = SldCornerRadius.Value;
            //var searchBoxVisible = ComboBoxHelper.GetIsSearchTextBoxVisible(CmbCustom);

            //TbCode.Text = "<ComboBox  Height=\"30\"" +
            //            $"\nWidth=\"{CmbCustom.Width}\"" +
            //            (watermark == null ? "" : $"\npu:ComboBoxHelper.Watermark=\"{watermark}\"") +
            //            (icon == null ? "" : $"\npu:ComboBoxHelper.Icon=\"{icon}\"") +
            //            $"\npu:ComboBoxHelper.HoverBrush=\"{ComboBoxHelper.GetHoverBrush(CmbCustom).ToColor().ToHexString()}\"" +
            //            $"\npu:ComboBoxHelper.SelectedBrush=\"{ComboBoxHelper.GetSelectedBrush(CmbCustom).ToColor().ToHexString()}\"" +
            //            (cornerRadius == 0 ? "" : $"\npu:ComboBoxHelper.CornerRadius=\"{cornerRadius}\"") +
            //            (searchBoxVisible ? "pu:ComboBoxHelper.IsSearchTextBoxVisible=\"True\"" : "") +
            //            (searchBoxVisible ? "pu:ComboBoxHelper.SearchTextChanged=\"...\"" : "") +
            //            " />";
        }
        #endregion

    }
}

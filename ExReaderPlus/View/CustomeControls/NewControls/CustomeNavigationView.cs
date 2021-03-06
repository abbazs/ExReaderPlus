﻿using ExReaderPlus.View.Commands;
using System.Timers;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ExReaderPlus.View {

    [ContentProperty(Name = "Content")]
    public sealed class CustomeNavigationView : Control {

        #region Properties
        private bool _pointover = false;

        private string _radiogroupname;

        private Timer _transtiontimer;

        private IconViewItem _selecteditem;

        #region PaneBg
        public Brush PaneBackground {
            get { return (Brush)GetValue(PaneBackgroundProperty); }
            set { SetValue(PaneBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PaneBackgroundProperty =
            DependencyProperty.Register("PaneBackground", typeof(Brush),
                typeof(CustomeNavigationView), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 255, 255, 255))));
        #endregion

        #region IsPaneOpen
        /// <summary>
        /// 打开listview
        /// </summary>
        public bool IsPaneOpen {
            get { return (bool)GetValue(IsPaneOpenProperty); }
            set { SetValue(IsPaneOpenProperty, value); }
        }
        public static readonly DependencyProperty IsPaneOpenProperty =
            DependencyProperty.Register("IsPaneOpen", typeof(bool),
                typeof(CustomeNavigationView), new PropertyMetadata(false));
        #endregion

        #region Content
        /// <summary>
        /// 右侧内容区
        /// </summary>
        public UIElement Content {
            get { return (UIElement)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(UIElement),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region FunctionArea
        /// <summary>
        /// 项目菜单区
        /// </summary>
        public Grid FunctionArea {
            get { return (Grid)GetValue(FunctionAreaProperty); }
            set { SetValue(FunctionAreaProperty, value); }
        }
        public static readonly DependencyProperty FunctionAreaProperty =
            DependencyProperty.Register("FunctionArea", typeof(Grid),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region AboutCommand
        public ICommand AboutCommand {
            get { return (ICommand)GetValue(AboutCommandProperty); }
            set { SetValue(AboutCommandProperty, value); }
        }
        public static readonly DependencyProperty AboutCommandProperty =
            DependencyProperty.Register("AboutCommand", typeof(ICommand),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region AboutCommandPara
        public object AboutCommandPara {
            get { return (object)GetValue(AboutCommandParaProperty); }
            set { SetValue(AboutCommandParaProperty, value); }
        }
        public static readonly DependencyProperty AboutCommandParaProperty =
            DependencyProperty.Register("AboutCommandPara", typeof(object),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region SettingCommand
        public ICommand SettingCommand {
            get { return (ICommand)GetValue(SettingCommandProperty); }
            set { SetValue(SettingCommandProperty, value); }
        }
        public static readonly DependencyProperty SettingCommandProperty =
            DependencyProperty.Register("SettingCommand", typeof(ICommand),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region SettingCommandPara
        public object SettingCommandPara {
            get { return (object)GetValue(SettingCommandParaProperty); }
            set { SetValue(SettingCommandParaProperty, value); }
        }
        public static readonly DependencyProperty SettingCommandParaProperty =
            DependencyProperty.Register("SettingCommandPara", typeof(object),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region PanelWidth

        #endregion

        //SizeProperties

        #region ClipOffset
        /// <summary>
        /// 使用Clip位移制作宽度动画
        /// </summary>
        public double ClipOffset {
            get { return (double)GetValue(ClipOffsetProperty); }
            set { SetValue(ClipOffsetProperty, value); }
        }
        public static readonly DependencyProperty ClipOffsetProperty =
            DependencyProperty.Register("ClipOffset", typeof(double),
                typeof(CustomeNavigationView), new PropertyMetadata(0));
        #endregion

        #region PanelClip
        /// <summary>
        /// 裁剪矩形
        /// </summary>
        public Rect PaneClip {
            get { return (Rect)GetValue(PaneClipProperty); }
            private set { SetValue(PaneClipProperty, value); }
        }
        private static readonly DependencyProperty PaneClipProperty =
            DependencyProperty.Register("PaneClip", typeof(Rect),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region OpenWidth
        /// <summary>
        /// 展开宽度
        /// </summary>
        public double OpenWidth {
            get { return (double)GetValue(OpenWidthProperty); }
            set { SetValue(OpenWidthProperty, value); }
        }
        public static readonly DependencyProperty OpenWidthProperty =
            DependencyProperty.Register("OpenWidth", typeof(double),
                typeof(CustomeNavigationView), new PropertyMetadata(240.0));
        #endregion

        #region CollapseWidth
        /// <summary>
        /// 折叠宽度
        /// </summary>
        public double CollapseWidth {
            get { return (double)GetValue(CollapseWidthProperty); }
            set { SetValue(CollapseWidthProperty, value); }
        }
        public static readonly DependencyProperty CollapseWidthProperty =
            DependencyProperty.Register("CollapseWidth", typeof(double),
                typeof(CustomeNavigationView), new PropertyMetadata(48.0));
        #endregion

        #region OpenPaneCommand
        /// <summary>
        /// 打开pane命令
        /// </summary>
        public CommandBase OpenPaneCommand {
            get { return (CommandBase)GetValue(OpenPaneCommandProperty); }
            set { SetValue(OpenPaneCommandProperty, value); }
        }
        public static readonly DependencyProperty OpenPaneCommandProperty =
            DependencyProperty.Register("OpenPaneCommand", typeof(CommandBase),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        //

        #region AboutButton
        public Visibility AboutButton {
            get { return (Visibility)GetValue(AboutButtonProperty); }
            set { SetValue(AboutButtonProperty, value); }
        }
        public static readonly DependencyProperty AboutButtonProperty =
            DependencyProperty.Register("AboutButton", typeof(Visibility),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region SettingButton
        public Visibility SettingButton {
            get { return (Visibility)GetValue(SettingButtonProperty); }
            set { SetValue(SettingButtonProperty, value); }
        }
        public static readonly DependencyProperty SettingButtonProperty =
            DependencyProperty.Register("SettingButton", typeof(Visibility),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region IconStroke
        public Brush IconStroke {
            get { return (Brush)GetValue(IconStrokeProperty); }
            set { SetValue(IconStrokeProperty, value); }
        }
        public static readonly DependencyProperty IconStrokeProperty =
            DependencyProperty.Register("IconStroke", typeof(Brush),
                typeof(CustomeNavigationView), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0))));
        #endregion

        #region SelectedIconfont
        public FontFamily SelectedIconfont {
            get { return (FontFamily)GetValue(SelectedIconfontProperty); }
            set { SetValue(SelectedIconfontProperty, value); }
        }
        public static readonly DependencyProperty SelectedIconfontProperty =
            DependencyProperty.Register("SelectedIconfont", typeof(FontFamily),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region SelectedIcon
        public string SelectedIcon {
            get { return (string)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }
        public static readonly DependencyProperty SelectedIconProperty =
            DependencyProperty.Register("SelectedIcon", typeof(string),
                typeof(CustomeNavigationView), new PropertyMetadata(null));
        #endregion

        #region PointChange

        #endregion

        #endregion


        #region Motheds
        protected override void OnApplyTemplate() {
            base.OnApplyTemplate();
            if (FunctionArea.Children != null && FunctionArea.Children.Count > 0)
                foreach (UIElement uie in FunctionArea.Children)
                {
                    if (uie is IconViewItem)
                    {
                        (uie as IconViewItem).GroupName = _radiogroupname;
                        (uie as IconViewItem).PointerEntered += OverButton;
                        (uie as IconViewItem).Checked += CheckButton; ;
                        (uie as IconViewItem).PointerExited += LeaveButton; ; ;
                    }
                }
            IconViewItem Ab = GetTemplateChild("About") as IconViewItem;
            Ab.GroupName = _radiogroupname;
            Ab.PointerEntered += OverButton;
            Ab.Checked += CheckButton;
            Ab.PointerExited += LeaveButton;

            IconViewItem St = GetTemplateChild("Setting") as IconViewItem;
            St.GroupName = _radiogroupname;
            St.PointerEntered += OverButton;
            St.Checked += CheckButton;
            St.PointerExited += LeaveButton;
        }

        private void LeaveButton(object sender, PointerRoutedEventArgs e) {
            _pointover = false;
        }

        private void CheckButton(object sender, RoutedEventArgs e) {
            _selecteditem = (IconViewItem)sender;
        }

        private void OverButton(object sender, PointerRoutedEventArgs e) {
            var Over = sender as IconViewItem;
            SelectedIcon = Over.Icon;
            SelectedIconfont = Over.IconFont;
            VisualStateManager.GoToState(this, "HeaderIconAreaC", true);
            _pointover = true;
            _transtiontimer.Enabled = true;
        }

        private void InitTimer() {
            _transtiontimer = new Timer { Interval = 500 };
            _transtiontimer.Elapsed += _transtiontimer_Elapsed;
        }

        /// <summary>
        /// 渐变重置
        /// </summary>
        private async void _transtiontimer_Elapsed(object sender, ElapsedEventArgs e) {
            if (_pointover)
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    VisualStateManager.GoToState(this, "HeaderIconAreaN", false);
                    _transtiontimer.Enabled = false;
                });
        }

        private void InitCommands() {
            OpenPaneCommand = new CommandBase(obj =>
            {
                if (IsPaneOpen)
                    ClosePane();
                else
                    OpenPane();
            });
        }

        private void OpenPane() {
            if (_selecteditem != null)
            {
                SelectedIcon = _selecteditem.Icon;
                SelectedIconfont = _selecteditem.IconFont;
            }
            IsPaneOpen = true;
            VisualStateManager.GoToState(this, "CollapseMode_Open", true);
        }

        private void ClosePane() {
            IsPaneOpen = false;
            VisualStateManager.GoToState(this, "CollapseMode_Collapse", true);
        }

        protected override void OnLostFocus(RoutedEventArgs e) {
            base.OnLostFocus(e);
            ClosePane();
        }

        private void CustomeNavigationView_Loaded(object sender, RoutedEventArgs e) {
            ClipOffset = OpenWidth - CollapseWidth;
            VisualStateManager.GoToState(this, "CollapseMode_Collapse", false);
        }

        private void CustomeNavigationView_SizeChanged(object sender, SizeChangedEventArgs e) {
            PaneClip = new Rect(0, 0, OpenWidth, e.NewSize.Height);
        }
        #endregion


        #region Contructors
        public CustomeNavigationView() {
            InitCommands();
            InitTimer();
            _radiogroupname = GetHashCode().ToString();
            Loaded += CustomeNavigationView_Loaded;
            SizeChanged += CustomeNavigationView_SizeChanged;
            DefaultStyleKey = typeof(CustomeNavigationView);
        }
        #endregion
    }
}

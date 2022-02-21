using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SimpleMvvmDemo.Client.UserControls
{
    /// <summary>
    /// UserControl_LeftAndRightScrollViewer.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_LeftAndRightScrollViewer : UserControl
    {
        public UserControl_LeftAndRightScrollViewer()
        {
            InitializeComponent();
        }


        //添加依赖属性，用于绑定传递的ItemsControl控件
        public UIElement MyContentElement
        {
            get { return (UIElement)GetValue(MyContentElementProperty); }
            set { SetValue(MyContentElementProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyContentElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyContentElementProperty =
            DependencyProperty.Register("MyContentElement", typeof(UIElement), typeof(UserControl_LeftAndRightScrollViewer), new PropertyMetadata(null));

        //加载绑定的控件
        //private void LoadMyContentElement(UIElement itemsControl)
        //{
        //    if (itemsControl !=null)
        //    {
        //        ListView listView = itemsControl as ListView;
        //        ListViewAutomationPeer lvap = new ListViewAutomationPeer(listView);
        //        var svap = lvap.GetPattern(PatternInterface.Scroll) as ScrollViewerAutomationPeer ;
        //        ScrollViewer scrollViewer = svap.Owner as ScrollViewer;
        //        scrollViewer.ScrollChanged_+=
        //    }
        //}
     

        private bool IsVerticalScrollBarAtButtom(ScrollViewer scrollViewer)
        {
            throw new NotImplementedException();
        }

        private void Button_left_Click_1(object sender, RoutedEventArgs e)
        {
            if (MyContentElement != null)
            {
                ListView listView = MyContentElement as ListView;
                ListViewAutomationPeer lvap = new ListViewAutomationPeer(listView);
                var svap = lvap.GetPattern(PatternInterface.Scroll) as ScrollViewerAutomationPeer;
                ScrollViewer scrollViewer = svap.Owner as ScrollViewer;
                double offset = scrollViewer.VerticalOffset - listView.ActualHeight + 3;
                scrollViewer.ScrollToVerticalOffset(offset);

                //DoubleAnimation doubleAnimation = new DoubleAnimation();
                //doubleAnimation.From = scrollViewer.VerticalOffset;
                //doubleAnimation.To = scrollViewer.VerticalOffset - listView.ActualHeight - 3;
                //doubleAnimation.Duration = TimeSpan.FromMilliseconds(300);
                //doubleAnimation.FillBehavior = FillBehavior.HoldEnd;
                //doubleAnimation.EasingFunction = new SineEase() { EasingMode = EasingMode.EaseInOut };

                //Storyboard storyboard = new Storyboard();
                //Storyboard.SetTarget(doubleAnimation, scrollViewer);
                //Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(0)", new DependencyProperty[] { ScrollViewerEx.VerticalOffsetProperty }));
                //storyboard.Children.Add(doubleAnimation);
                //storyboard.Begin(); 
            }
        }

        private void Button_Right_Click_1(object sender, RoutedEventArgs e)
        {
            if (MyContentElement != null)
            {
                ListView listView = MyContentElement as ListView;
                ListViewAutomationPeer lvap = new ListViewAutomationPeer(listView);
                var svap = lvap.GetPattern(PatternInterface.Scroll) as ScrollViewerAutomationPeer;
                ScrollViewer scrollViewer = svap.Owner as ScrollViewer;
                double offset= scrollViewer.VerticalOffset + listView.ActualHeight - 3;
                scrollViewer.ScrollToVerticalOffset(offset);
                //DoubleAnimation doubleAnimation = new DoubleAnimation();
                //doubleAnimation.From = scrollViewer.VerticalOffset;
                //doubleAnimation.To = scrollViewer.VerticalOffset + listView.ActualHeight - 3;
                //doubleAnimation.Duration = TimeSpan.FromMilliseconds(300);
                //doubleAnimation.FillBehavior = FillBehavior.HoldEnd;
                //doubleAnimation.EasingFunction = new SineEase() { EasingMode = EasingMode.EaseInOut };

                //Storyboard storyboard = new Storyboard();
                //Storyboard.SetTarget(doubleAnimation, scrollViewer);
                //Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(0)", new DependencyProperty[] { ScrollViewerEx.VerticalOffsetProperty }));
                //storyboard.Children.Add(doubleAnimation);
                //storyboard.Begin();
            }
        }
    }
}

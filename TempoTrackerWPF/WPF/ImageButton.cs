using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TempoTrackerWPF.WPF
{
    public class ImageButton : Button
    {
        readonly Image _image;
        readonly TextBlock _textBlock;

        public ImageButton()
        {
            var panel = new StackPanel
            {
                Orientation = Orientation.Horizontal, 
                Margin = new Thickness(10)
            };

            _image = new Image
            {
                Margin = new Thickness(0, 0, 10, 0)
            };

            _textBlock = new TextBlock();

            panel.Children.Add(_image);
            panel.Children.Add(_textBlock);

            Content = panel;
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string), 
                typeof(ImageButton), 
                new UIPropertyMetadata(""));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(
                "Image",
                typeof(ImageSource),
                typeof(ImageButton),
                new UIPropertyMetadata(null));
    }
}
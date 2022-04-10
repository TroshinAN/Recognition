using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace RecognitionWPF.Models
{
    public class ScrollOnNewItem : Behavior<ItemsControl>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += OnLoaded;
            AssociatedObject.Unloaded += OnUnLoaded;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= OnLoaded;
            AssociatedObject.Unloaded -= OnUnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var items = AssociatedObject.ItemsSource as INotifyCollectionChanged;

            if (items != null)
            {
                items.CollectionChanged += OnCollectionChanged;
            }
        }

        private void OnUnLoaded(object sender, RoutedEventArgs e)
        {
            var items = AssociatedObject.ItemsSource as INotifyCollectionChanged;

            if (items != null)
            {
                items.CollectionChanged -= OnCollectionChanged;
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (AssociatedObject.Items.Count > 0)
                {
                    var border = (Border)VisualTreeHelper.GetChild(AssociatedObject, 0);
                    if (border != null)
                    {
                        var scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                        scrollViewer?.ScrollToBottom();
                    }
                }
            }
        }
    }
}

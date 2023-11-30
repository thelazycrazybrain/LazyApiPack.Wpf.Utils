using System.Windows.Input;
using System.Windows;

namespace LazyApiPack.Wpf.Utils.Geometry
{
    public static class FrameworkElementExtensions
    {
        public static FrameworkElement GetTopmostParent(this FrameworkElement fxe)
        {
            var anchestor = fxe;
            while (true)
            {
                var parent = anchestor.Parent as FrameworkElement;
                if (parent == null) return anchestor;
                anchestor = parent;
            }
        }
        public static TElement? GetParent<TElement>(this FrameworkElement fxe)
        {
            var anchestor = fxe;
            while (true)
            {
                var parent = anchestor.Parent as FrameworkElement;
                if (parent is TElement te)
                {
                    return te;
                }
                if (parent == null) return default;
                anchestor = parent;
            }
        }
        public static LazyApiPack.Utils.Geometry.Size GetActualSize(this FrameworkElement fx)
        {
            var width = double.IsNaN(fx.Width) ? fx.ActualWidth : fx.Width;
            var height = double.IsNaN(fx.Height) ? fx.ActualHeight : fx.Height;
            return new LazyApiPack.Utils.Geometry.Size(width, height);
        }

        public static bool IsOnElement(this FrameworkElement fx, MouseDevice mouse)
        {
            var root = fx.GetTopmostParent() as UIElement;
            if (root == null)
            {
                return false;
            }

            var point = Convert.ToLazyPoint( mouse.GetPosition(root));
            var rect = fx.ToGeometricRectangle(root);
            return LazyApiPack.Utils.Math.GeometryMath.IsPointInRectangle(point, rect);

        }

        public static LazyApiPack.Utils.Geometry.Rect ToGeometricRectangle(this FrameworkElement fx, UIElement? relativeTo = null)
        {
            var size = fx.GetActualSize();

            if (relativeTo == null)
            {
                return new LazyApiPack.Utils.Geometry.Rect(0, 0, size.Width, size.Height);

            }
            else
            {
                var startPoint = fx.TranslatePoint(new Point(0, 0), relativeTo);
                return new LazyApiPack.Utils.Geometry.Rect(startPoint.X, startPoint.Y, size.Width + startPoint.X, size.Height + startPoint.Y);

            }
        }
    }

}

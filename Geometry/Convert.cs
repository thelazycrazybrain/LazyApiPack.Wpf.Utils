using System.Windows;

namespace LazyApiPack.Wpf.Utils.Geometry
{
    public static class Convert
    {
        public static LazyApiPack.Utils.Geometry.Rect ToLazyRect(Rect rect)
        {
            return new LazyApiPack.Utils.Geometry.Rect(rect.X, rect.Y, rect.Width, rect.Height);
        }
        public static LazyApiPack.Utils.Geometry.Point ToLazyPoint(Point point)
        {
            return new LazyApiPack.Utils.Geometry.Point (point.X, point.Y);
        }
    }

}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace LibraryManagementSystem
{
    public static class GraphicsExtensions
    {
        // Method from EnhancedBookCard.cs
        public static void AddRoundedRectangle(this GraphicsPath path, Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            // Upper left arc
            path.AddArc(arcRect, 180, 90);

            // Upper right arc
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // Lower right arc
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // Lower left arc
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
        }

        // Method from EnhancedBookCard.cs
        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle rect, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRoundedRectangle(rect, radius);
                graphics.FillPath(brush, path);
            }
        }

        // Method from EnhancedBookCard.cs
        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle rect, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRoundedRectangle(rect, radius);
                graphics.DrawPath(pen, path);
            }
        }

        // Method from EnhancedBorrowedBookCard.cs
        public static void FillRoundedRectangleCompat(this Graphics graphics, Brush brush, Rectangle rect, int cornerRadius)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                graphics.FillPath(brush, path);
            }
        }

        // Method from EnhancedBorrowedBookCard.cs
        public static void DrawRoundedRectangleCompat(this Graphics graphics, Pen pen, Rectangle rect, int cornerRadius)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        // Method from EnhancedBorrowedBookCard.cs
        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddArc(rect.Right - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddArc(rect.Right - cornerRadius * 2, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}


using System.Drawing;
using System.Windows.Forms;

namespace UCImageCombo
{
    public class ImageCombo : ComboBox
    {
        public ImageCombo()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        public ImageList ImageList { get; set; } = new ImageList();

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index < 0)

            {
                e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor),
                    e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
            }

            else
            {
                if (Items[e.Index].GetType() == typeof(ImageComboItem))
                {
                    var icItem = (ImageComboItem) Items[e.Index];

                    var forecolor = icItem.ForeColor != Color.FromKnownColor(KnownColor.Transparent)
                        ? icItem.ForeColor
                        : e.ForeColor;

                    var font = icItem.Indicate ? new Font(e.Font, FontStyle.Bold) : e.Font;

                    if (icItem.ImageIndex != -1)
                    {
                        ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, icItem.ImageIndex);

                        e.Graphics.DrawString(icItem.ItemText, font, new SolidBrush(forecolor),
                            e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
                    }
                    else

                    {
                        e.Graphics.DrawString(icItem.ItemText, font, new SolidBrush(forecolor),
                            e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
                    }
                }

                else

                {
                    e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor),
                        e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
                }
            }

            base.OnDrawItem(e);
        }
    }
}
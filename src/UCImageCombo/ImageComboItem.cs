using System.Drawing;

namespace UCImageCombo
{
    public class ImageComboItem : object
    {
        public ImageComboItem()
        {
        }

        public ImageComboItem(string Text)
        {
            ItemText = Text;
        }

        public ImageComboItem(string stText, int intImageIndex)

        {
            ItemText = stText;
            ImageIndex = intImageIndex;
        }

        public ImageComboItem(string stText, int intImageIndex, bool blnIndi)
        {
            ItemText = stText;

            ImageIndex = intImageIndex;

            Indicate = blnIndi;
        }

        public ImageComboItem(string stText, int intImageIndex, bool blnIndi, Color clForeColor)

        {
            ItemText = stText;

            ImageIndex = intImageIndex;

            Indicate = blnIndi;

            ForeColor = clForeColor;
        }

        public ImageComboItem(string stText, int intImageIndex, bool blnIndi, Color clForeColor, object oTag)
        {
            ItemText = stText;

            ImageIndex = intImageIndex;

            Indicate = blnIndi;

            ForeColor = clForeColor;

            Tag = oTag;
        }

        public Color ForeColor { get; set; } = Color.FromKnownColor(KnownColor.Transparent);

        public int ImageIndex { get; set; } = -1;

        public bool Indicate { get; set; }

        public object Tag { get; set; }

        public string ItemText { get; set; }

        public override string ToString()
        {
            return ItemText;
        }
    }
}
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UCImageCombo;

/// <summary>
/// A combo box that draws an icon from <see cref="ImageList"/>, a custom colour and an optional bold
/// weight beside each item. Items that are not <see cref="ImageComboItem"/> are drawn as plain text.
/// </summary>
public class ImageCombo : ComboBox
{
    private const int LogicalRowPadding = 4;
    private const int LogicalIconGap = 4;

    private const TextFormatFlags TextFlags =
        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine |
        TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;

    private ImageList? _imageList;

    /// <summary>Creates the control in owner-draw mode.</summary>
    public ImageCombo()
    {
        DrawMode = DrawMode.OwnerDrawFixed;
    }

    /// <summary>
    /// Gets or sets the icons that <see cref="ImageComboItem.ImageIndex"/> points into.
    /// The control does not own the list and never disposes it. Size the images for the target DPI.
    /// </summary>
    [Category("Appearance")]
    [Description("The icons that each item's ImageIndex points into.")]
    [DefaultValue(null)]
    public ImageList? ImageList
    {
        get => _imageList;
        set
        {
            if (ReferenceEquals(_imageList, value))
            {
                return;
            }

            _imageList = value;
            UpdateItemHeight();
            Invalidate();
        }
    }

    /// <inheritdoc />
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateItemHeight();
    }

    /// <inheritdoc />
    protected override void OnFontChanged(EventArgs e)
    {
        base.OnFontChanged(e);
        UpdateItemHeight();
    }

    /// <inheritdoc />
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        e.DrawBackground();

        var selected = (e.State & DrawItemState.Selected) != 0;
        var honorItemColor = Enabled && !selected && !SystemInformation.HighContrast;
        object? item = e.Index < 0 ? Text : e.Index < Items.Count ? Items[e.Index] : null;
        var look = ItemLook.Resolve(item, e.ForeColor, honorItemColor);
        var foreColor = Enabled ? look.ForeColor : SystemColors.GrayText;

        var imageWidth = 0;
        if (_imageList is not null)
        {
            imageWidth = _imageList.ImageSize.Width + LogicalToDeviceUnits(LogicalIconGap);
            if (look.ImageIndex >= 0 && look.ImageIndex < _imageList.Images.Count)
            {
                var top = e.Bounds.Top + ((e.Bounds.Height - _imageList.ImageSize.Height) / 2);
                _imageList.Draw(e.Graphics, e.Bounds.Left, top, look.ImageIndex);
            }
        }

        var textBounds = Rectangle.FromLTRB(
            e.Bounds.Left + imageWidth, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);
        var baseFont = e.Font ?? Font;
        using var boldFont = look.Bold ? new Font(baseFont, FontStyle.Bold) : null;
        TextRenderer.DrawText(e.Graphics, look.Text, boldFont ?? baseFont, textBounds, foreColor, TextFlags);

        e.DrawFocusRectangle();
        base.OnDrawItem(e);
    }

    private void UpdateItemHeight()
    {
        ItemHeight = ItemLook.RowHeight(
            FontHeight,
            _imageList?.ImageSize.Height ?? 0,
            LogicalToDeviceUnits(LogicalRowPadding));
    }
}

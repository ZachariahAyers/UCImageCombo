using System;
using System.Drawing;

namespace UCImageCombo;

/// <summary>
/// What one row looks like, resolved from an item without touching a window.
/// </summary>
internal readonly record struct ItemLook(string Text, int ImageIndex, Color ForeColor, bool Bold)
{
    /// <summary>Works out the look of <paramref name="item"/>.</summary>
    /// <param name="item">An <see cref="ImageComboItem"/>, or any object, which is shown with <c>ToString()</c>.</param>
    /// <param name="defaultForeColor">The colour used when the item sets none or its colour is not honoured.</param>
    /// <param name="honorItemColor">False on a selected row, a disabled control or in high contrast.</param>
    internal static ItemLook Resolve(object? item, Color defaultForeColor, bool honorItemColor)
    {
        if (item is ImageComboItem styled)
        {
            var color = honorItemColor && styled.ForeColor != Color.Transparent
                ? styled.ForeColor
                : defaultForeColor;
            return new ItemLook(styled.Text, styled.ImageIndex, color, styled.Indicate);
        }

        return new ItemLook(item?.ToString() ?? string.Empty, -1, defaultForeColor, false);
    }

    /// <summary>The row height that fits both the text and the icon, plus <paramref name="padding"/>.</summary>
    internal static int RowHeight(int fontHeight, int imageHeight, int padding) =>
        Math.Max(fontHeight, imageHeight) + padding;
}

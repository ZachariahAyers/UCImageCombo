using System;
using System.Drawing;

namespace UCImageCombo;

/// <summary>
/// An entry for <see cref="ImageCombo"/>: text, plus an optional icon, colour and bold weight.
/// </summary>
public class ImageComboItem
{
    /// <summary>Creates an item.</summary>
    /// <param name="text">The text to show.</param>
    /// <param name="imageIndex">Index into <see cref="ImageCombo.ImageList"/>, or -1 for no icon.</param>
    /// <exception cref="ArgumentNullException"><paramref name="text"/> is <see langword="null"/>.</exception>
    public ImageComboItem(string text, int imageIndex = -1)
    {
        ArgumentNullException.ThrowIfNull(text);
        Text = text;
        ImageIndex = imageIndex;
    }

    /// <summary>Gets or sets the text to show.</summary>
    public string Text { get; set; }

    /// <summary>Gets or sets the index into <see cref="ImageCombo.ImageList"/>, or -1 for no icon.</summary>
    public int ImageIndex { get; set; }

    /// <summary>Gets or sets whether the text is drawn bold.</summary>
    public bool Indicate { get; set; }

    /// <summary>
    /// Gets or sets the text colour. <see cref="Color.Transparent"/> (the default) uses the control's own colour.
    /// The colour is ignored on a selected row, on a disabled control and in high contrast mode.
    /// </summary>
    public Color ForeColor { get; set; } = Color.Transparent;

    /// <summary>Gets or sets caller data attached to the item.</summary>
    public object? Tag { get; set; }

    /// <summary>Returns <see cref="Text"/>, which is what a combo box uses for search and accessibility.</summary>
    public override string ToString() => Text;
}

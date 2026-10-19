using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UCImageCombo.Sample;

/// <summary>One <see cref="ImageCombo"/> with three styled items and a label that echoes the choice.</summary>
internal sealed class MainForm : Form
{
    private readonly Container _components = new();

    public MainForm()
    {
        Text = "UCImageCombo sample";
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(360, 100);

        var combo = new ImageCombo
        {
            AccessibleName = "Status",
            DropDownStyle = ComboBoxStyle.DropDownList,
            ImageList = CreateIcons(_components),
            Location = new Point(16, 16),
            Width = 328,
        };
        combo.Items.Add(new ImageComboItem("Online", 0) { Indicate = true, ForeColor = Color.SeaGreen });
        combo.Items.Add(new ImageComboItem("Away", 1) { ForeColor = Color.DarkGoldenrod });
        combo.Items.Add(new ImageComboItem("Offline", 2) { ForeColor = Color.Firebrick });
        combo.Items.Add("A plain string");

        var echo = new Label { AutoSize = true, Location = new Point(16, 56), Text = "Pick an item." };
        combo.SelectedIndexChanged += (_, _) => echo.Text = $"Selected: {combo.SelectedItem}";

        Controls.Add(combo);
        Controls.Add(echo);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _components.Dispose();
        }

        base.Dispose(disposing);
    }

    private static ImageList CreateIcons(IContainer owner)
    {
        var icons = new ImageList(owner) { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(16, 16) };
        foreach (var color in new[] { Color.SeaGreen, Color.DarkGoldenrod, Color.Firebrick })
        {
            using var bitmap = new Bitmap(16, 16);
            using (var graphics = Graphics.FromImage(bitmap))
            using (var brush = new SolidBrush(color))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.FillEllipse(brush, 1, 1, 14, 14);
            }

            icons.Images.Add(bitmap);
        }

        return icons;
    }
}

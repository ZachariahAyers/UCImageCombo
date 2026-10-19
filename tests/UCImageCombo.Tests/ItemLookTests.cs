using System.Drawing;
using Xunit;

namespace UCImageCombo.Tests;

public class ItemLookTests
{
    private static readonly Color Default = Color.Black;

    [Fact]
    public void PlainObjectShowsItsToString()
    {
        var look = ItemLook.Resolve(42, Default, honorItemColor: true);

        Assert.Equal(new ItemLook("42", -1, Default, false), look);
    }

    [Fact]
    public void NullItemIsEmptyText()
    {
        var look = ItemLook.Resolve(null, Default, honorItemColor: true);

        Assert.Equal(string.Empty, look.Text);
        Assert.Equal(-1, look.ImageIndex);
    }

    [Fact]
    public void StyledItemCarriesTextIconColourAndWeight()
    {
        var item = new ImageComboItem("Alert", 3) { Indicate = true, ForeColor = Color.Red };

        var look = ItemLook.Resolve(item, Default, honorItemColor: true);

        Assert.Equal(new ItemLook("Alert", 3, Color.Red, true), look);
    }

    [Fact]
    public void ItemWithoutColourUsesTheDefault()
    {
        var look = ItemLook.Resolve(new ImageComboItem("Plain"), Default, honorItemColor: true);

        Assert.Equal(Default, look.ForeColor);
    }

    [Fact]
    public void ItemColourIsIgnoredWhenNotHonoured()
    {
        var item = new ImageComboItem("Alert") { ForeColor = Color.Red };

        var look = ItemLook.Resolve(item, Color.White, honorItemColor: false);

        Assert.Equal(Color.White, look.ForeColor);
    }

    [Theory]
    [InlineData(15, 0, 4, 19)]
    [InlineData(15, 32, 4, 36)]
    [InlineData(20, 16, 8, 28)]
    public void RowHeightFitsTheTallerOfTextAndIcon(int fontHeight, int imageHeight, int padding, int expected)
    {
        Assert.Equal(expected, ItemLook.RowHeight(fontHeight, imageHeight, padding));
    }
}

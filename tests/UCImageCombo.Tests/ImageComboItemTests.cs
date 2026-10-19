using System;
using System.Drawing;
using Xunit;

namespace UCImageCombo.Tests;

public class ImageComboItemTests
{
    [Fact]
    public void DefaultsMeanNoIconNoColourNotBold()
    {
        var item = new ImageComboItem("Item");

        Assert.Equal(-1, item.ImageIndex);
        Assert.Equal(Color.Transparent, item.ForeColor);
        Assert.False(item.Indicate);
        Assert.Null(item.Tag);
    }

    [Fact]
    public void ToStringReturnsTheText()
    {
        Assert.Equal("Item", new ImageComboItem("Item").ToString());
    }

    [Fact]
    public void NullTextIsRejected()
    {
        Assert.Throws<ArgumentNullException>(() => new ImageComboItem(null!));
    }
}

# Changelog

## 2.0.0

Rebuilt on .NET 10 with the same purpose: a combo box that draws an icon, colour and bold weight per item.

- SDK-style `net10.0-windows` library with nullable types, analyzers, warnings as errors and central package management.
- Text is drawn with `TextRenderer`, vertically centred and ellipsised; GDI brushes and fonts are no longer leaked.
- Row height follows font, icon size and monitor DPI.
- High contrast, selected rows and the disabled state use system colours instead of the item colour.
- Fixed: the focus rectangle was painted under the text; an out-of-range `ImageIndex` threw.
- Breaking: `ImageComboItem.ItemText` is now `Text`; the five constructors are one `ImageComboItem(string text, int imageIndex = -1)` with `Indicate`, `ForeColor` and `Tag` as properties; `ImageCombo.ImageList` is `null` until set.
- Added xUnit tests, a sample app, a CI workflow and a NuGet package definition.

## 1.0.0

The original 2019 .NET Framework 4.7.2 control. Tagged `v1`.

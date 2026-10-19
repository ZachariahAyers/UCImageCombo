# Changelog

## v2.0.0 - 2026-10-19

A Windows Forms combo box for .NET 10 that draws an icon, a colour and an optional bold weight beside each item.

- SDK-style `net10.0-windows` library with nullable types, analyzers, warnings as errors and central package management.
- Text is drawn with `TextRenderer`, vertically centred and ellipsised, and every GDI brush and font is disposed.
- Row height follows font, icon size and monitor DPI.
- High contrast, selected rows and the disabled state use system colours.
- The focus rectangle is painted over the text.
- `ImageComboItem(string text, int imageIndex = -1)` with `Text`, `Indicate`, `ForeColor` and `Tag` properties; `ImageCombo.ImageList` is `null` until set.
- xUnit tests, a sample app, a CI workflow and a NuGet package definition.

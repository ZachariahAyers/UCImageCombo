# Architecture

`ImageCombo` is a `ComboBox` in `OwnerDrawFixed` mode. WinForms calls `OnDrawItem` for each visible row, including the closed box, and the control paints the row itself.

## Pieces

| Type | Job |
| --- | --- |
| `ImageCombo` | Owns the `ImageList` reference, sets the row height, paints rows. |
| `ImageComboItem` | Text, icon index, bold flag, optional colour, tag. |
| `ItemLook` | Turns any item into text, icon index, colour and weight. Also computes the row height. Pure, so it is unit-tested without a window. |

## Drawing a row

1. `DrawBackground` paints the system selection or window background.
2. `ItemLook.Resolve` decides what to show. A plain object is shown with `ToString()`. An index of -1 (nothing selected) shows the control's `Text`.
3. The icon is centred vertically in the row. An index outside the list draws no icon.
4. Text is drawn with `TextRenderer` (GDI), vertically centred, trimmed with an ellipsis. When an icon list is set, every row is indented by the icon width so plain rows line up with icon rows.
5. `DrawFocusRectangle` runs last so the text does not paint over it, then the base class raises `DrawItem`.

## Colour rules

An item's own colour is used only when the control is enabled, the row is not selected, and Windows is not in high contrast. Otherwise the system colour passed in by WinForms is used. A disabled control draws in `SystemColors.GrayText`.

## DPI

The row height is `max(font height, icon height) + padding`, recomputed on font and handle changes. Padding and gaps go through `LogicalToDeviceUnits`, so they follow the monitor DPI. Icon bitmaps are not rescaled: supply an `ImageList` sized for the DPI you target. Apps opt in to per-monitor DPI with `ApplicationHighDpiMode` in the project file, as the sample does.

## Limits

Right-to-left layout is not mirrored. Row height is the same for all items.

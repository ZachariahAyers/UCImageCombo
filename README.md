# UCImageCombo

[![CI](https://github.com/ZachariahAyers/UCImageCombo/actions/workflows/ci.yml/badge.svg)](https://github.com/ZachariahAyers/UCImageCombo/actions/workflows/ci.yml)

A Windows Forms combo box that shows an icon, a colour and an optional bold weight beside each item.

## Features

- An icon per item, taken from a standard `ImageList`
- Per-item text colour and bold emphasis
- Plain strings and other objects still work as ordinary items
- Follows system colours, high contrast and the disabled state
- Scales its row height with the monitor DPI

## Tech stack

C#, .NET 10, Windows Forms, xUnit, GitHub Actions.

## Getting started

Requires Windows and the .NET 10 SDK.

```bash
git clone https://github.com/ZachariahAyers/UCImageCombo.git
cd UCImageCombo
dotnet run --project samples/UCImageCombo.Sample
```

Use it in your own form:

```csharp
var combo = new ImageCombo { ImageList = icons, DropDownStyle = ComboBoxStyle.DropDownList };
combo.Items.Add(new ImageComboItem("Online", imageIndex: 0) { Indicate = true, ForeColor = Color.SeaGreen });
```

## Development

```bash
dotnet format UCImageCombo.slnx --verify-no-changes
dotnet build UCImageCombo.slnx -c Release
dotnet test UCImageCombo.slnx -c Release
dotnet pack src/UCImageCombo/UCImageCombo.csproj -c Release -o artifacts
```

How it is put together: [docs/ARCHITECTURE.md](docs/ARCHITECTURE.md).

## License

GNU GPL v3. See [LICENSE](LICENSE).

---

Built by [Zachariah Ayers](https://ayers.repair).

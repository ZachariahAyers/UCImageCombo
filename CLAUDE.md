# UCImageCombo

A Windows Forms combo box (`ImageCombo`) that draws an icon, a custom colour and an optional bold weight beside each item. NuGet library on net10.0-windows, with xUnit tests and a sample app.

## Commands

Windows only for the UI projects. Run from the repo root.

```bash
dotnet restore UCImageCombo.slnx
dotnet format UCImageCombo.slnx --verify-no-changes   # fix with: dotnet format UCImageCombo.slnx
dotnet build UCImageCombo.slnx -c Release
dotnet test UCImageCombo.slnx -c Release
dotnet pack src/UCImageCombo/UCImageCombo.csproj -c Release -o artifacts
dotnet run --project samples/UCImageCombo.Sample
```

## Map

- `src/UCImageCombo/` the library: `ImageCombo` (the control), `ImageComboItem` (item model), `ItemLook` (drawing decisions, no window needed)
- `tests/UCImageCombo.Tests/` xUnit tests; internals are visible to it
- `samples/UCImageCombo.Sample/` demo app
- `docs/ARCHITECTURE.md` how drawing works

## Conventions

- Warnings are errors; nullable is on; implicit usings are off. Keep every public member XML-documented.
- Package versions live only in `Directory.Packages.props`.
- Decide in `ItemLook` (testable), draw in `ImageCombo.OnDrawItem`. Do not put logic that needs a window under test.
- Draw text with `TextRenderer`, scale pixel values with `LogicalToDeviceUnits`, and dispose every GDI object you create.
- Honour high contrast and the disabled state; never hard-code colours over system colours.
- Conventional commits, lower-case subject, no AI attribution.

## Definition of done

Format check, Release build and tests all pass with no warnings. New behaviour has a test in `ItemLookTests` or `ImageComboItemTests`. Public API changes are noted in `CHANGELOG.md`.

# IntToOrdinal

Provides an extension method for `Int`/`UInt` to convert a number (0-99) to an ordinal string value.
- Currently only supports English ordinals.

## Usage

```c#
ToOrdinal(this int number, string language = "en", FormatStyle formatStyle = FormatStyle.Short)
ToOrdinal(this uint number, string language = "en", FormatStyle formatStyle = FormatStyle.Short)
```

## FormatStyle
- `Short` (e.g. `1st`)
- `Full` (e.g. `first`)
- `FullHyphenated` (e.g. `twenty-first`)
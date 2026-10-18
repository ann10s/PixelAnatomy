namespace PixelAnatomy.Models;

/// <summary>
/// Параметры палитры. ColorsCount – количество цветов (2..2^24).
/// </summary>
public sealed class PaletteParameters
{
    public const int MinColors = 2;
    public const int MaxColors = 16_777_216; // 2^24 – практический предел

    public int ColorsCount { get; set; } = 16;

    public bool IsValid => ColorsCount >= MinColors && ColorsCount <= MaxColors;
}
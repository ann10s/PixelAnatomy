namespace PixelAnatomy.Models;

/// <summary>
/// Размеры изображения (в пикселях) и глубина цвета (бит на пиксель).
/// </summary>
public sealed class ImageParameters
{
    public const int MinSide = 1;
    public const int MaxSide = 100_000;

    public int Width { get; set; } = 16;
    public int Height { get; set; } = 16;

    /// <summary>Бит на пиксель (глубина цвета).</summary>
    public int BitsPerPixel { get; set; } = 4;

    public bool IsValid =>
        Width >= MinSide && Width <= MaxSide &&
        Height >= MinSide && Height <= MaxSide &&
        BitsPerPixel >= 1 && BitsPerPixel <= 48;

    public long PixelCount => (long)Width * Height;
    public long TotalBits => PixelCount * BitsPerPixel;
}
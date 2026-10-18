namespace PixelAnatomy.Models;

/// <summary>
/// Результат задачи «объём изображения».
/// VolumeBytes – точное значение (может быть нецелым, если BitsPerPixel не кратно 8 – но мы считаем биты).
/// </summary>
public sealed record VolumeResult(
    long Width,
    long Height,
    int BitsPerPixel,
    long PixelCount,
    long TotalBits,
    double TotalBytes,
    double TotalKib,
    double TotalMib,
    string Formula,
    string Substitution
);
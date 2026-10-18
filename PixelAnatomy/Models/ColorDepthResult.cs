namespace PixelAnatomy.Models;

/// <summary>
/// Результат задачи «определить глубину цвета по размеру палитры».
/// </summary>
public sealed record ColorDepthResult(
    int ColorsCount,
    int BitsPerPixel,
    string Formula,
    string Substitution,
    string Explanation
);
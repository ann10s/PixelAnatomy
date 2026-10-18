using PixelAnatomy.Models;

namespace PixelAnatomy.Services;

public sealed class ImageMathService : IImageMathService
{
    public ColorDepthResult ComputeColorDepth(int colorsCount)
    {
        if (colorsCount < PaletteParameters.MinColors || colorsCount > PaletteParameters.MaxColors)
            throw new ArgumentOutOfRangeException(nameof(colorsCount),
                $"Число цветов должно быть в диапазоне {PaletteParameters.MinColors}..{PaletteParameters.MaxColors}.");

        // Глубина цвета = ceil(log2(K)). Для точных степеней двойки это ровно log2(K).
        // Для не-степеней (например, 100) получаем минимальное число бит, вмещающее 100 цветов => 7.
        int bits = 0;
        long capacity = 1;
        while (capacity < colorsCount)
        {
            capacity <<= 1;
            bits++;
        }

        string formula = "i = ⌈log₂ N⌉";
        string substitution = $"i = ⌈log₂({colorsCount})⌉ = {bits} бит";
        string explanation = IsPowerOfTwo(colorsCount)
            ? $"{colorsCount} = 2^{bits}, значит i = {bits} бит."
            : $"{colorsCount} не является степенью двойки, округляем вверх: i = {bits} бит (вмещает до {capacity} цветов).";

        return new ColorDepthResult(colorsCount, bits, formula, substitution, explanation);
    }

    public VolumeResult ComputeVolume(int width, int height, int bitsPerPixel)
    {
        if (width <= 0 || height <= 0 || bitsPerPixel <= 0)
            throw new ArgumentOutOfRangeException(nameof(width), "Размеры и глубина цвета должны быть положительными.");

        long pixels = (long)width * height;
        long bits = pixels * bitsPerPixel;
        double bytes = bits / 8.0;
        double kib = bytes / 1024.0;
        double mib = kib / 1024.0;

        string formula = "V = W · H · i";
        string substitution =
            $"V = {width} · {height} · {bitsPerPixel} = {bits} бит " +
            $"= {bytes:0.##} байт = {kib:0.###} КБ = {mib:0.######} МБ";

        return new VolumeResult(width, height, bitsPerPixel, pixels, bits, bytes, kib, mib, formula, substitution);
    }

    private static bool IsPowerOfTwo(long value) => value > 0 && (value & (value - 1)) == 0;
}
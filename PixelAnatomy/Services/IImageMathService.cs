using PixelAnatomy.Models;

namespace PixelAnatomy.Services;

public interface IImageMathService
{
    /// <summary>Глубина цвета: N = log2(K). Бросает ArgumentOutOfRangeException при некорректных данных.</summary>
    ColorDepthResult ComputeColorDepth(int colorsCount);

    /// <summary>Объём изображения: V = W*H*b, в битах, байтах, КиБ, МиБ.</summary>
    VolumeResult ComputeVolume(int width, int height, int bitsPerPixel);
}
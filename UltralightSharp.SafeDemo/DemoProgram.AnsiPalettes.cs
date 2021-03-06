using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing.Processors.Dithering;
using SixLabors.ImageSharp.Processing.Processors.Quantization;

namespace Supine.UltralightSharp.Demo {

  public static partial class DemoProgram {

    public enum AnsiColors {

      Palette16 = 0,

      Palette256,

      TrueColor,

    }

    public static readonly IDither[] Dithers = {
      OrderedDither.Bayer2x2,
      OrderedDither.Bayer4x4,
      OrderedDither.Bayer8x8,
      OrderedDither.Ordered3x3,
      ErrorDither.Atkinson,
      ErrorDither.Burkes,
      ErrorDither.FloydSteinberg,
      ErrorDither.JarvisJudiceNinke,
      ErrorDither.Sierra2,
      ErrorDither.Sierra3,
      ErrorDither.SierraLite,
      ErrorDither.StevensonArce,
      ErrorDither.Stucki,
    };

    public static readonly PaletteQuantizer AnsiPalette16
      = new PaletteQuantizer(new[] {
        // 16 default VGA colors
        new Color(new Rgb24(0, 0, 0)),
        new Color(new Rgb24(128, 0, 0)),
        new Color(new Rgb24(0, 128, 0)),
        new Color(new Rgb24(128, 128, 0)),
        new Color(new Rgb24(0, 0, 128)),
        new Color(new Rgb24(128, 0, 128)),
        new Color(new Rgb24(0, 128, 128)),
        new Color(new Rgb24(192, 192, 192)),
        new Color(new Rgb24(128, 128, 128)),
        new Color(new Rgb24(255, 0, 0)),
        new Color(new Rgb24(0, 255, 0)),
        new Color(new Rgb24(255, 255, 0)),
        new Color(new Rgb24(0, 0, 255)),
        new Color(new Rgb24(255, 0, 255)),
        new Color(new Rgb24(0, 255, 255)),
        new Color(new Rgb24(255, 255, 255)),
      }, new QuantizerOptions {
        Dither = OrderedDither.Bayer2x2,
        DitherScale = 1f,
        MaxColors = 16
      });

    public static readonly PaletteQuantizer AnsiPalette256
      = new PaletteQuantizer(new[] {
        // 16 default VGA colors
        new Color(new Rgb24(0, 0, 0)),
        new Color(new Rgb24(128, 0, 0)),
        new Color(new Rgb24(0, 128, 0)),
        new Color(new Rgb24(128, 128, 0)),
        new Color(new Rgb24(0, 0, 128)),
        new Color(new Rgb24(128, 0, 128)),
        new Color(new Rgb24(0, 128, 128)),
        new Color(new Rgb24(192, 192, 192)),
        new Color(new Rgb24(128, 128, 128)),
        new Color(new Rgb24(255, 0, 0)),
        new Color(new Rgb24(0, 255, 0)),
        new Color(new Rgb24(255, 255, 0)),
        new Color(new Rgb24(0, 0, 255)),
        new Color(new Rgb24(255, 0, 255)),
        new Color(new Rgb24(0, 255, 255)),
        new Color(new Rgb24(255, 255, 255)),
        // 216 palette colors
        new Color(new Rgb24(0, 0, 0)),
        new Color(new Rgb24(0, 0, 95)),
        new Color(new Rgb24(0, 0, 135)),
        new Color(new Rgb24(0, 0, 175)),
        new Color(new Rgb24(0, 0, 215)),
        new Color(new Rgb24(0, 0, 255)),
        new Color(new Rgb24(0, 95, 0)),
        new Color(new Rgb24(0, 95, 95)),
        new Color(new Rgb24(0, 95, 135)),
        new Color(new Rgb24(0, 95, 175)),
        new Color(new Rgb24(0, 95, 215)),
        new Color(new Rgb24(0, 95, 255)),
        new Color(new Rgb24(0, 135, 0)),
        new Color(new Rgb24(0, 135, 95)),
        new Color(new Rgb24(0, 135, 135)),
        new Color(new Rgb24(0, 135, 175)),
        new Color(new Rgb24(0, 135, 215)),
        new Color(new Rgb24(0, 135, 255)),
        new Color(new Rgb24(0, 175, 0)),
        new Color(new Rgb24(0, 175, 95)),
        new Color(new Rgb24(0, 175, 135)),
        new Color(new Rgb24(0, 175, 175)),
        new Color(new Rgb24(0, 175, 215)),
        new Color(new Rgb24(0, 175, 255)),
        new Color(new Rgb24(0, 215, 0)),
        new Color(new Rgb24(0, 215, 95)),
        new Color(new Rgb24(0, 215, 135)),
        new Color(new Rgb24(0, 215, 175)),
        new Color(new Rgb24(0, 215, 215)),
        new Color(new Rgb24(0, 215, 255)),
        new Color(new Rgb24(0, 255, 0)),
        new Color(new Rgb24(0, 255, 95)),
        new Color(new Rgb24(0, 255, 135)),
        new Color(new Rgb24(0, 255, 175)),
        new Color(new Rgb24(0, 255, 215)),
        new Color(new Rgb24(0, 255, 255)),
        new Color(new Rgb24(95, 0, 0)),
        new Color(new Rgb24(95, 0, 95)),
        new Color(new Rgb24(95, 0, 135)),
        new Color(new Rgb24(95, 0, 175)),
        new Color(new Rgb24(95, 0, 215)),
        new Color(new Rgb24(95, 0, 255)),
        new Color(new Rgb24(95, 95, 0)),
        new Color(new Rgb24(95, 95, 95)),
        new Color(new Rgb24(95, 95, 135)),
        new Color(new Rgb24(95, 95, 175)),
        new Color(new Rgb24(95, 95, 215)),
        new Color(new Rgb24(95, 95, 255)),
        new Color(new Rgb24(95, 135, 0)),
        new Color(new Rgb24(95, 135, 95)),
        new Color(new Rgb24(95, 135, 135)),
        new Color(new Rgb24(95, 135, 175)),
        new Color(new Rgb24(95, 135, 215)),
        new Color(new Rgb24(95, 135, 255)),
        new Color(new Rgb24(95, 175, 0)),
        new Color(new Rgb24(95, 175, 95)),
        new Color(new Rgb24(95, 175, 135)),
        new Color(new Rgb24(95, 175, 175)),
        new Color(new Rgb24(95, 175, 215)),
        new Color(new Rgb24(95, 175, 255)),
        new Color(new Rgb24(95, 215, 0)),
        new Color(new Rgb24(95, 215, 95)),
        new Color(new Rgb24(95, 215, 135)),
        new Color(new Rgb24(95, 215, 175)),
        new Color(new Rgb24(95, 215, 215)),
        new Color(new Rgb24(95, 215, 255)),
        new Color(new Rgb24(95, 255, 0)),
        new Color(new Rgb24(95, 255, 95)),
        new Color(new Rgb24(95, 255, 135)),
        new Color(new Rgb24(95, 255, 175)),
        new Color(new Rgb24(95, 255, 215)),
        new Color(new Rgb24(95, 255, 255)),
        new Color(new Rgb24(135, 0, 0)),
        new Color(new Rgb24(135, 0, 95)),
        new Color(new Rgb24(135, 0, 135)),
        new Color(new Rgb24(135, 0, 175)),
        new Color(new Rgb24(135, 0, 215)),
        new Color(new Rgb24(135, 0, 255)),
        new Color(new Rgb24(135, 95, 0)),
        new Color(new Rgb24(135, 95, 95)),
        new Color(new Rgb24(135, 95, 135)),
        new Color(new Rgb24(135, 95, 175)),
        new Color(new Rgb24(135, 95, 215)),
        new Color(new Rgb24(135, 95, 255)),
        new Color(new Rgb24(135, 135, 0)),
        new Color(new Rgb24(135, 135, 95)),
        new Color(new Rgb24(135, 135, 135)),
        new Color(new Rgb24(135, 135, 175)),
        new Color(new Rgb24(135, 135, 215)),
        new Color(new Rgb24(135, 135, 255)),
        new Color(new Rgb24(135, 175, 0)),
        new Color(new Rgb24(135, 175, 95)),
        new Color(new Rgb24(135, 175, 135)),
        new Color(new Rgb24(135, 175, 175)),
        new Color(new Rgb24(135, 175, 215)),
        new Color(new Rgb24(135, 175, 255)),
        new Color(new Rgb24(135, 215, 0)),
        new Color(new Rgb24(135, 215, 95)),
        new Color(new Rgb24(135, 215, 135)),
        new Color(new Rgb24(135, 215, 175)),
        new Color(new Rgb24(135, 215, 215)),
        new Color(new Rgb24(135, 215, 255)),
        new Color(new Rgb24(135, 255, 0)),
        new Color(new Rgb24(135, 255, 95)),
        new Color(new Rgb24(135, 255, 135)),
        new Color(new Rgb24(135, 255, 175)),
        new Color(new Rgb24(135, 255, 215)),
        new Color(new Rgb24(135, 255, 255)),
        new Color(new Rgb24(175, 0, 0)),
        new Color(new Rgb24(175, 0, 95)),
        new Color(new Rgb24(175, 0, 135)),
        new Color(new Rgb24(175, 0, 175)),
        new Color(new Rgb24(175, 0, 215)),
        new Color(new Rgb24(175, 0, 255)),
        new Color(new Rgb24(175, 95, 0)),
        new Color(new Rgb24(175, 95, 95)),
        new Color(new Rgb24(175, 95, 135)),
        new Color(new Rgb24(175, 95, 175)),
        new Color(new Rgb24(175, 95, 215)),
        new Color(new Rgb24(175, 95, 255)),
        new Color(new Rgb24(175, 135, 0)),
        new Color(new Rgb24(175, 135, 95)),
        new Color(new Rgb24(175, 135, 135)),
        new Color(new Rgb24(175, 135, 175)),
        new Color(new Rgb24(175, 135, 215)),
        new Color(new Rgb24(175, 135, 255)),
        new Color(new Rgb24(175, 175, 0)),
        new Color(new Rgb24(175, 175, 95)),
        new Color(new Rgb24(175, 175, 135)),
        new Color(new Rgb24(175, 175, 175)),
        new Color(new Rgb24(175, 175, 215)),
        new Color(new Rgb24(175, 175, 255)),
        new Color(new Rgb24(175, 215, 0)),
        new Color(new Rgb24(175, 215, 95)),
        new Color(new Rgb24(175, 215, 135)),
        new Color(new Rgb24(175, 215, 175)),
        new Color(new Rgb24(175, 215, 215)),
        new Color(new Rgb24(175, 215, 255)),
        new Color(new Rgb24(175, 255, 0)),
        new Color(new Rgb24(175, 255, 95)),
        new Color(new Rgb24(175, 255, 135)),
        new Color(new Rgb24(175, 255, 175)),
        new Color(new Rgb24(175, 255, 215)),
        new Color(new Rgb24(175, 255, 255)),
        new Color(new Rgb24(215, 0, 0)),
        new Color(new Rgb24(215, 0, 95)),
        new Color(new Rgb24(215, 0, 135)),
        new Color(new Rgb24(215, 0, 175)),
        new Color(new Rgb24(215, 0, 215)),
        new Color(new Rgb24(215, 0, 255)),
        new Color(new Rgb24(215, 95, 0)),
        new Color(new Rgb24(215, 95, 95)),
        new Color(new Rgb24(215, 95, 135)),
        new Color(new Rgb24(215, 95, 175)),
        new Color(new Rgb24(215, 95, 215)),
        new Color(new Rgb24(215, 95, 255)),
        new Color(new Rgb24(215, 135, 0)),
        new Color(new Rgb24(215, 135, 95)),
        new Color(new Rgb24(215, 135, 135)),
        new Color(new Rgb24(215, 135, 175)),
        new Color(new Rgb24(215, 135, 215)),
        new Color(new Rgb24(215, 135, 255)),
        new Color(new Rgb24(215, 175, 0)),
        new Color(new Rgb24(215, 175, 95)),
        new Color(new Rgb24(215, 175, 135)),
        new Color(new Rgb24(215, 175, 175)),
        new Color(new Rgb24(215, 175, 215)),
        new Color(new Rgb24(215, 175, 255)),
        new Color(new Rgb24(215, 215, 0)),
        new Color(new Rgb24(215, 215, 95)),
        new Color(new Rgb24(215, 215, 135)),
        new Color(new Rgb24(215, 215, 175)),
        new Color(new Rgb24(215, 215, 215)),
        new Color(new Rgb24(215, 215, 255)),
        new Color(new Rgb24(215, 255, 0)),
        new Color(new Rgb24(215, 255, 95)),
        new Color(new Rgb24(215, 255, 135)),
        new Color(new Rgb24(215, 255, 175)),
        new Color(new Rgb24(215, 255, 215)),
        new Color(new Rgb24(215, 255, 255)),
        new Color(new Rgb24(255, 0, 0)),
        new Color(new Rgb24(255, 0, 95)),
        new Color(new Rgb24(255, 0, 135)),
        new Color(new Rgb24(255, 0, 175)),
        new Color(new Rgb24(255, 0, 215)),
        new Color(new Rgb24(255, 0, 255)),
        new Color(new Rgb24(255, 95, 0)),
        new Color(new Rgb24(255, 95, 95)),
        new Color(new Rgb24(255, 95, 135)),
        new Color(new Rgb24(255, 95, 175)),
        new Color(new Rgb24(255, 95, 215)),
        new Color(new Rgb24(255, 95, 255)),
        new Color(new Rgb24(255, 135, 0)),
        new Color(new Rgb24(255, 135, 95)),
        new Color(new Rgb24(255, 135, 135)),
        new Color(new Rgb24(255, 135, 175)),
        new Color(new Rgb24(255, 135, 215)),
        new Color(new Rgb24(255, 135, 255)),
        new Color(new Rgb24(255, 175, 0)),
        new Color(new Rgb24(255, 175, 95)),
        new Color(new Rgb24(255, 175, 135)),
        new Color(new Rgb24(255, 175, 175)),
        new Color(new Rgb24(255, 175, 215)),
        new Color(new Rgb24(255, 175, 255)),
        new Color(new Rgb24(255, 215, 0)),
        new Color(new Rgb24(255, 215, 95)),
        new Color(new Rgb24(255, 215, 135)),
        new Color(new Rgb24(255, 215, 175)),
        new Color(new Rgb24(255, 215, 215)),
        new Color(new Rgb24(255, 215, 255)),
        new Color(new Rgb24(255, 255, 0)),
        new Color(new Rgb24(255, 255, 95)),
        new Color(new Rgb24(255, 255, 135)),
        new Color(new Rgb24(255, 255, 175)),
        new Color(new Rgb24(255, 255, 215)),
        new Color(new Rgb24(255, 255, 255)),
        // 24 grayscale colors
        new Color(new Rgb24(8, 8, 8)),
        new Color(new Rgb24(18, 18, 18)),
        new Color(new Rgb24(28, 28, 28)),
        new Color(new Rgb24(38, 38, 38)),
        new Color(new Rgb24(48, 48, 48)),
        new Color(new Rgb24(58, 58, 58)),
        new Color(new Rgb24(68, 68, 68)),
        new Color(new Rgb24(78, 78, 78)),
        new Color(new Rgb24(88, 88, 88)),
        new Color(new Rgb24(98, 98, 98)),
        new Color(new Rgb24(108, 108, 108)),
        new Color(new Rgb24(118, 118, 118)),
        new Color(new Rgb24(128, 128, 128)),
        new Color(new Rgb24(138, 138, 138)),
        new Color(new Rgb24(148, 148, 148)),
        new Color(new Rgb24(158, 158, 158)),
        new Color(new Rgb24(168, 168, 168)),
        new Color(new Rgb24(178, 178, 178)),
        new Color(new Rgb24(188, 188, 188)),
        new Color(new Rgb24(198, 198, 198)),
        new Color(new Rgb24(208, 208, 208)),
        new Color(new Rgb24(218, 218, 218)),
        new Color(new Rgb24(228, 228, 228)),
        new Color(new Rgb24(238, 238, 238))
      }, new QuantizerOptions {
        Dither = OrderedDither.Bayer8x8, // ErrorDither.FloydSteinberg, 
        DitherScale = 1f, //.15f,
        MaxColors = 256
      });

  }

}
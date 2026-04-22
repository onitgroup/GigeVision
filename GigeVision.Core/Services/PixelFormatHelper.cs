using System;

namespace GigeVision.Core.Services
{
    internal static class PixelFormatHelper
    {
        public static int GetBytesPerPixelRoundedUp(uint pixelFormat)
        {
            return DivideRoundUp(GetEffectiveBitsPerPixel(pixelFormat), 8);
        }

        public static int GetFrameSize(int width, int height, uint pixelFormat)
        {
            if (width <= 0 || height <= 0)
            {
                return 0;
            }

            long totalBits = (long)width * height * GetEffectiveBitsPerPixel(pixelFormat);
            return (int)DivideRoundUp(totalBits, 8);
        }

        public static int GetLineSize(int width, uint pixelFormat)
        {
            if (width <= 0)
            {
                return 0;
            }

            long totalBits = (long)width * GetEffectiveBitsPerPixel(pixelFormat);
            return (int)DivideRoundUp(totalBits, 8);
        }

        private static int GetEffectiveBitsPerPixel(uint pixelFormat)
        {
            int effectiveBits = (int)((pixelFormat >> 16) & 0xFF);
            return effectiveBits > 0 ? effectiveBits : 8;
        }

        private static int DivideRoundUp(long value, int divisor)
        {
            return (int)((value + divisor - 1) / divisor);
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    internal class Convolution : BaseImageProcesser
    {
        public Convolution(Bitmap sourceImage) : base(sourceImage)
        {
            ConvolutionMatrix = new ConvolutionMatrix();
            CloneFromSourceAndCreateBitmapDataFromClone(sourceImage);
        }

        private void CloneFromSourceAndCreateBitmapDataFromClone(Bitmap sourceImage)
        {
            BitmapClone = (Bitmap)sourceImage.Clone();
            BitmapDataFromClone = BitmapClone.LockBits(
                new Rectangle(0, 0, ImageWidth, ImageHeight),
                ImageLockMode.ReadWrite,
                (IsImageGrayscale ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb)
            );
        }

        public Bitmap BitmapClone { get; internal set; }

        public BitmapData BitmapDataFromClone { get; internal set; }

        public ConvolutionMatrix ConvolutionMatrix { get; internal set; }

        /// <summary>
        /// Gets the stride(scan) width of the Bitmap object.        
        /// </summary>
        public int ImageStrideFromClone { get; private set; }

        /// <summary>
        /// Gets the address of the first pixel data in the bitmap
        /// </summary>
        public IntPtr Scan0IntPtrFromClone { get; private set; }

        protected void ConvolutionOverTheImage()
        {
            ImageStrideFromClone = ImageStride * 2;        
            Scan0IntPtrFromClone = BitmapDataFromClone.Scan0;

            unsafe
            {
                byte* sourcePixel = (byte*)(void*)Scan0IntPtr;
                byte* clonePixel = (byte*)(void*)Scan0IntPtrFromClone;
                int nOffset = ImageStride - ImageWidth * 3;
                int nWidth = ImageWidth - 2;
                int nHeight = ImageHeight - 2;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        var newPixel = ((((clonePixel[2] * ConvolutionMatrix.TopLeft) +
                                          (clonePixel[5] * ConvolutionMatrix.TopMid) +
                                          (clonePixel[8] * ConvolutionMatrix.TopRight) +
                                          (clonePixel[2 + ImageStride] * ConvolutionMatrix.MidLeft) +
                                          (clonePixel[5 + ImageStride] * ConvolutionMatrix.Pixel) +
                                          (clonePixel[8 + ImageStride] * ConvolutionMatrix.MidRight) +
                                          (clonePixel[2 + ImageStrideFromClone] * ConvolutionMatrix.BottomLeft) +
                                          (clonePixel[5 + ImageStrideFromClone] * ConvolutionMatrix.BottomMid) +
                                          (clonePixel[8 + ImageStrideFromClone] * ConvolutionMatrix.BottomRight))
                                         / ConvolutionMatrix.Factor) + ConvolutionMatrix.Offset);

                        if (newPixel < 0) newPixel = 0;
                        if (newPixel > 255) newPixel = 255;
                        sourcePixel[5 + ImageStride] = (byte)newPixel;

                        newPixel = ((((clonePixel[1] * ConvolutionMatrix.TopLeft) +
                            (clonePixel[4] * ConvolutionMatrix.TopMid) +
                            (clonePixel[7] * ConvolutionMatrix.TopRight) +
                            (clonePixel[1 + ImageStride] * ConvolutionMatrix.MidLeft) +
                            (clonePixel[4 + ImageStride] * ConvolutionMatrix.Pixel) +
                            (clonePixel[7 + ImageStride] * ConvolutionMatrix.MidRight) +
                            (clonePixel[1 + ImageStrideFromClone] * ConvolutionMatrix.BottomLeft) +
                            (clonePixel[4 + ImageStrideFromClone] * ConvolutionMatrix.BottomMid) +
                            (clonePixel[7 + ImageStrideFromClone] * ConvolutionMatrix.BottomRight))
                            / ConvolutionMatrix.Factor) + ConvolutionMatrix.Offset);

                        if (newPixel < 0) newPixel = 0;
                        if (newPixel > 255) newPixel = 255;
                        sourcePixel[4 + ImageStride] = (byte)newPixel;

                        newPixel = ((((clonePixel[0] * ConvolutionMatrix.TopLeft) +
                                       (clonePixel[3] * ConvolutionMatrix.TopMid) +
                                       (clonePixel[6] * ConvolutionMatrix.TopRight) +
                                       (clonePixel[0 + ImageStride] * ConvolutionMatrix.MidLeft) +
                                       (clonePixel[3 + ImageStride] * ConvolutionMatrix.Pixel) +
                                       (clonePixel[6 + ImageStride] * ConvolutionMatrix.MidRight) +
                                       (clonePixel[0 + ImageStrideFromClone] * ConvolutionMatrix.BottomLeft) +
                                       (clonePixel[3 + ImageStrideFromClone] * ConvolutionMatrix.BottomMid) +
                                       (clonePixel[6 + ImageStrideFromClone] * ConvolutionMatrix.BottomRight))
                            / ConvolutionMatrix.Factor) + ConvolutionMatrix.Offset);

                        if (newPixel < 0) newPixel = 0;
                        if (newPixel > 255) newPixel = 255;
                        sourcePixel[3 + ImageStride] = (byte)newPixel;

                        sourcePixel += 3;
                        clonePixel += 3;
                    }

                    sourcePixel += nOffset;
                    clonePixel += nOffset;
                }
            }
            BitmapClone.UnlockBits(BitmapDataFromClone);
        }
    }
}

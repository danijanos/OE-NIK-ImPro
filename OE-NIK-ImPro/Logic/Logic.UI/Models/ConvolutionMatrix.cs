namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <summary>
    /// Class which describe a 3×3 matrix with integer values
    /// </summary>
    public class ConvolutionMatrix
    {
        /// <summary>
        /// Abstarction of a matrix 3×3 matrix parts
        /// </summary>
        public int TopLeft, TopMid, TopRight;
        public int MidLeft, Pixel, MidRight;
        public int BottomLeft, BottomMid, BottomRight;

        public int Factor = 1;
        public int Offset = 0;

        /// <summary>
        /// Initialize an instance of the <see cref="ConvolutionMatrix"/> class
        /// </summary>
        public ConvolutionMatrix()
        {
            Pixel = 1;
            //TopLeft = TopMid = TopRight =
            //    MidLeft = MidRight =
            //        BottomLeft = BottomMid = BottomRight = 0;
        }

        /// <summary>
        /// Sets the matrix values with the given parameter
        /// </summary>
        /// <param name="value">Value for matrix values</param>
        public void SetAllValues(int value)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight =
                BottomLeft = BottomMid = BottomRight = value;
        }
    }
}

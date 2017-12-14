namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <summary>
    /// Class which describe a convoluton matrix for image processing
    /// </summary>
    public class ConvolutionMatrix
    {
        /// <summary>
        /// Abstarction of an identity matrix
        /// </summary>
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;

        public int Factor = 1;
        public int Offset = 0;

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

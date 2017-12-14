namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <summary>
    /// Class which describe a convoluton matrix for image processing
    /// </summary>
    public class ConvolutionMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;

        public int Factor = 1;
        public int Offset = 0;

        public void SetWithValue(int value)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight =
                BottomLeft = BottomMid = BottomRight = value;
        }
    }
}

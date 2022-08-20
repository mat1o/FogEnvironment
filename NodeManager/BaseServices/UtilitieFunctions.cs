using FogEnvironment.Domain.DTO;
using System.Drawing;

namespace FogEnvironment.NodeManager
{
    public class UtilitieFunctions
    {
        public static KnapSackDTO KnapSackResolver(int W, int[] wt, int[] val)
        {
            var knapSackDtio = new KnapSackDTO();
            int n = val.Length;
            int i, w;
            int[,] K = new int[n + 1, W + 1];

            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] +
                                K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            var res = K[n, W];
            knapSackDtio.MaxValue = res;
            w = W;
            for (i = n; i > 0 && res > 0; i--)
            {
                if (res == K[i - 1, w])
                    continue;
                else
                {
                    knapSackDtio.NominatedRows.Add(i - 1);
                    res = res - val[i - 1];
                    w = w - wt[i - 1];
                }
            }

            return knapSackDtio;
        }

        public static Bitmap ConvertByteArrayToBitmap(byte[] image) 
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(image))
            {
                bmp = new Bitmap(ms);
            }

            return bmp;
        }
    }
}

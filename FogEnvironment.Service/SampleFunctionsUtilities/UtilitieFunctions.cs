using FogEnvironment.Domain.DTO;

namespace FogEnvironment.Service.SampleFunctionsUtilities
{
    public class UtilitieFunctions
    {
        public static KnapSackDTO PrintknapSack(int W, int[] wt, int[] val, int n)
        {
            var knapSackDtio = new KnapSackDTO();

            int i, w;
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom up manner
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

            // stores the result of Knapsack
            var res = K[n, W];
            knapSackDtio.MaxValue = res;
            w = W;
            for (i = n; i > 0 && res > 0; i--)
            {

                // either the result comes from the top
                // (K[i-1][w]) or from (val[i-1] + K[i-1]
                // [w-wt[i-1]]) as in Knapsack table. If
                // it comes from the latter one/ it means
                // the item is included.
                if (res == K[i - 1, w])
                    continue;
                else
                {
                    // This item is included.
                    knapSackDtio.NominatedRows.Add(wt[i - 1]);
                    // Since this weight is included its
                    // value is deducted
                    res = res - val[i - 1];
                    w = w - wt[i - 1];
                }
            }

            return knapSackDtio;
        }
    }
}

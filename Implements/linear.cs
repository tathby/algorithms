using AlgoPortfolio.Implements;

namespace AlgoPortfolio.Implements;

public class Linear
{
    public static int NumEvenInList(IList<int> list)
    {
        int ans = 0;
        foreach (var element in list)
        {
            if (Constant.CheckForEven(element))
            {
                ans++;
            }
        }
        return ans;
    } //checks for evens through all elements in the list, increasing linearly by each extra element in the list
}

string showNumPairs(IList<int> elements)
{
    StringBuilder sb = new StringBuilder("");
    for (var outer = 0; outer < elements.Count; outer++)
    {
        for (var inner = 0; inner < elements.Count; inner++)
        {
            sb.Append($"{outer}, {inner}/n");
        }
    } //for each iteration of the outer loop the inner also runs n times for a total of n^2 operations
    return sb.ToString();
}

// See https://aka.ms/new-console-template for more information
namespace SortIntegerNumber;
public static class SortInteger
{
    static void Main(string[] args)
    {
        var list = new List<int>() { 1, -1, 4, 5, 6, 7, 8, 9, 10, -2, -6, 9, 8, 7, 0 };
        Console.WriteLine(string.Join("\t", list));
        var sortList = (SortFirstLastMaxItem(list, 5, 5).ConfigureAwait(false)).GetAwaiter().GetResult();
        Console.WriteLine(string.Join("\t", sortList));
        Console.ReadLine();

    }
    public static async Task<List<int>> SortFirstLastMaxItem(this List<int> list, int rangeOfMaxNumberFirstOrder = 5, int rangeOfMaxNumberSecondOrder = 5)
    {
        if (list == null || !list.Any())
            return new List<int>();
        try
        {
            int count = 0;
            // filter list max value with range
            Tuple<List<int>, List<int>, int?, int?> maxValuesInRangeList = await GetRangeMaximumNumber(list, rangeOfMaxNumberFirstOrder, rangeOfMaxNumberSecondOrder);

            // get minimum number in list max value with range
            var minValueInRange = maxValuesInRangeList?.Item3;
            // remove items max value is being existed in initial list
            foreach (var number in list?.ToList() ?? new List<int>())
            {
                if (number >= minValueInRange && count < maxValuesInRangeList?.Item4)
                {
                    list.Remove(number);
                    count++;
                }
            }

            // append listMaximumNumberSecond to first order in list 

            if (maxValuesInRangeList?.Item1 != null && maxValuesInRangeList.Item1.Any())
            {
                maxValuesInRangeList.Item1.AddRange(list);
                list = maxValuesInRangeList.Item1;
            }

            // append listMaximumNumberSecond to first order in list 
            if (maxValuesInRangeList?.Item2 != null && maxValuesInRangeList.Item2.Any())
            {
                list.AddRange(maxValuesInRangeList.Item2);
            }
        }

        catch (Exception ex)
        {
            return new List<int>();
        }
        return list;
    }

    /// <summary>
    /// GetRangeMaximumNumber
    /// </summary>
    /// <param name="list">List integer numbers</param>
    /// <param name="rangeOfMaxNumberFirstOrder">Range of first maximum integer numbers</param>
    /// <param name="rangeOfMaxNumberSecondOrder">Range of second maximum integer numbers</param>
    public static async Task<Tuple<List<int>, List<int>, int?, int?>> GetRangeMaximumNumber(List<int> list, int rangeOfMaxNumberFirstOrder = 5, int rangeOfMaxNumberSecondOrder = 5)
    {
        if (list == null || !list.Any())
            return new Tuple<List<int>, List<int>, int?, int?>(null, null, null, null);
        try
        {
            int count = 0;
            int rangeOfMaxValue = rangeOfMaxNumberFirstOrder + rangeOfMaxNumberSecondOrder;
            List<int> listMaxValues = list?.OrderBy(x => x).Skip(list.Count - rangeOfMaxValue).Take(rangeOfMaxValue).ToList() ?? new List<int>();
            List<int> listMaximumNumberFirst = listMaxValues?.Skip(0).Take(rangeOfMaxNumberFirstOrder).ToList() ?? new List<int>();
            List<int> listMaximumNumberSecond = listMaxValues?.Skip(rangeOfMaxNumberFirstOrder - 1).Take(rangeOfMaxNumberSecondOrder).ToList() ?? new List<int>();

            return new Tuple<List<int>, List<int>, int?, int?>(listMaximumNumberFirst, listMaximumNumberSecond, listMaxValues?.Min(), ((listMaximumNumberFirst?.Count ?? 0) + (listMaximumNumberSecond?.Count ?? 0)));
        }
        catch (Exception ex)
        {
            return new Tuple<List<int>, List<int>, int?, int?>(null, null, null, null);
        }
    }
}



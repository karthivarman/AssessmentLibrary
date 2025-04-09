using System.Collections.Concurrent;

namespace AssessmentLibrary.Assessment1;

public class Assessment1
{
    public IEnumerable<string> ConvertBytes(IEnumerable<byte> input)
    {
        // Using provided IntegerConverter.Convert(int value)
        // return equivalent collection of string values for each given input.
        foreach (var item in input)
        {
            yield return IntegerConverter.Convert(item);
        }
    }

    public IEnumerable<string> FilterAndConvertIntegers(IEnumerable<int> input)
    {
        // Using provided IntegerConverter.Convert(int value)
        // return equivalent collection of string values for each given input.
        // Where input value cannot be converted, remove the offending value.

        var validInputs = input.Where(item => item >= byte.MinValue && item <= byte.MaxValue);
        foreach (var item in validInputs)
        {
            yield return IntegerConverter.Convert(item);
        }
    }

    public Dictionary<string, int> CountOccurrences(IEnumerable<byte> input)
    {
        // Using provided IntegerConverter.Convert(int value)
        // return a summary of values and the occurrence count.
        var convertedItems = new List<string>();
        var cache = new Dictionary<byte, string>();
        foreach (var item in input)
        {
            if (cache.TryGetValue(item, out var cached))
            {
                convertedItems.Add(cached);
                continue;
            }

            var result = IntegerConverter.Convert(item);
            convertedItems.Add(result);
            cache.Add(item, result);
        }

        return convertedItems.GroupBy(i => i).ToDictionary(k => k.Key, v => v.Count());
    }

    public Dictionary<string, int> ExtractMostCommonBytes(IEnumerable<byte> input)
    {
        // Using provided IntegerConverter.Convert(int value)
        // return top 10 most commonly occurring values and the occurrence count ideally in less than 2seconds.

        var uniqueInput = input.Distinct();
        var cache = new ConcurrentDictionary<int, string>();
        Parallel.ForEach(uniqueInput, item =>
        {
            if (!cache.ContainsKey(item))
            {
                var result = IntegerConverter.Convert(item);
                cache.TryAdd(item, result);
            }
        });

        var convertedItems = new List<string>();
        foreach (var item in input)
        {
            if (cache.TryGetValue(item, out var cached))
            {
                convertedItems.Add(cached);
            }
        };

        return convertedItems.GroupBy(i => i).OrderByDescending(g => g.Count()).Take(10).ToDictionary(k => k.Key, v => v.Count());
    }
}
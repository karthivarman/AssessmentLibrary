namespace AssessmentLibrary.Assessment2;

public class Assessment2
{
    public static Dictionary<int, List<int>> PartitionList(IEnumerable<int> source, int segmentLength)
    {
        // Partition the source into smaller lists - each containing no more than segmentLength items.
        // Return a dictionary of these smaller lists indexed by segment number (starting at 1 not 0) of the source stream.

        var result = new Dictionary<int, List<int>>();
        var input = source.ToList();
        var index = 1;
        for (int i = 0; i < input.Count; i = i + segmentLength)
        {
            var length = Math.Min(segmentLength, input.Count - i);
            result.Add(index, input.GetRange(i, length));
            index++;
        }

        return result;
    }
}
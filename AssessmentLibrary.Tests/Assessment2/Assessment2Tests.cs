namespace AssessmentLibrary.Tests.Assessment2;

[TestClass]
public class Assessment2Tests
{
    [TestMethod]
    public void PartitionList_Returns_EntireSourceListAcrossSegments()
    {
        var input = Enumerable.Range(0, 12345).ToList();

        var output = AssessmentLibrary.Assessment2.Assessment2.PartitionList(input, 1000);
        var recombinedList = output.OrderBy(s => s.Key).SelectMany(s => s.Value).ToList();

        CollectionAssert.AreEqual(input, recombinedList);
    }

    [TestMethod]
    public void PartitionList_Returns_EmptyDictionaryWhenSourceIsEmpty()
    {
        var input = new List<int>();

        var output = AssessmentLibrary.Assessment2.Assessment2.PartitionList(input, 1000);

        Assert.IsNotNull(output);
        Assert.AreEqual(0, output.Count);
    }

    [DataTestMethod]
    [DataRow(1, 10, 1)]
    [DataRow(9, 10, 1)]
    [DataRow(10, 10, 1)]
    [DataRow(12, 10, 2)]
    [DataRow(20, 10, 2)]
    public void PartitionList_Returns_CorrectNumberOFSegments(int sourceListSize, int segmentLength, int expectedSegmentCount)
    {
        var input = Enumerable.Range(0, sourceListSize).ToList();

        var output = AssessmentLibrary.Assessment2.Assessment2.PartitionList(input, segmentLength);

        Assert.AreEqual(expectedSegmentCount, output.Count);
    }

    [DataTestMethod]
    [DataRow(1, 10)]
    [DataRow(10, 10)]
    [DataRow(15, 10)]
    [DataRow(1500, 100)]
    public void PartitionList_Returns_ExpectedNumberOfValues(int sourceListSize, int segmentLength)
    {
        var input = Enumerable.Range(0, sourceListSize).ToList();

        var output = AssessmentLibrary.Assessment2.Assessment2.PartitionList(input, segmentLength);

        Assert.AreEqual(sourceListSize, output.Sum(s => s.Value.Count));
    }

    [DataTestMethod]
    [DataRow(1, 0, 9)]
    [DataRow(2, 10, 19)]
    [DataRow(3, 20, 24)]
    public void PartitionList_Returns_ExpectedSegments(int segment, int segmentStart, int segmentEnd)
    {
        var input = Enumerable.Range(0, 25).ToList();

        var output = AssessmentLibrary.Assessment2.Assessment2.PartitionList(input, 10);

        Assert.AreEqual(segmentStart, output[segment].First());
        Assert.AreEqual(segmentEnd, output[segment].Last());
    }
}
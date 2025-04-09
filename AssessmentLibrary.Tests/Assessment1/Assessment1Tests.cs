using System.Diagnostics;

namespace AssessmentLibrary.Tests.Assessment1;

[TestClass]
public class Assessment1Tests
{
    [TestMethod]
    public void ConvertBytes_Returns_ExpectedOutput()
    {
        var input = Enumerable.Range(byte.MinValue, byte.MaxValue + 1)
            .Select(Convert.ToByte)
            .ToArray();
        var expected = ("ǈ;ǉ;Ǌ;ǋ;ǌ;Ǎ;ǎ;Ǐ;ǐ;Ǒ;ǒ;Ǔ;ǔ;Ǖ;ǖ;Ǘ;ǘ;Ǚ;ǚ;Ǜ;ǜ;ǝ;Ǟ;ǟ;Ǡ;ǡ;Ǣ;ǣ;Ǥ;ǥ;Ǧ;ǧ;Ǩ;ǩ;Ǫ;ǫ;Ǭ;ǭ;Ǯ;ǯ;" + 
                       "ǰ;Ǳ;ǲ;ǳ;Ǵ;ǵ;Ƕ;Ƿ;Ǹ;ǹ;Ǻ;ǻ;Ǽ;ǽ;Ǿ;ǿ;Ȁ;ȁ;Ȃ;ȃ;Ȅ;ȅ;Ȇ;ȇ;Ȉ;ȉ;Ȋ;ȋ;Ȍ;ȍ;Ȏ;ȏ;Ȑ;ȑ;Ȓ;ȓ;Ȕ;ȕ;Ȗ;ȗ;" + 
                       "Ș;ș;Ț;ț;Ȝ;ȝ;Ȟ;ȟ;Ƞ;ȡ;Ȣ;ȣ;Ȥ;ȥ;Ȧ;ȧ;Ȩ;ȩ;Ȫ;ȫ;Ȭ;ȭ;Ȯ;ȯ;Ȱ;ȱ;Ȳ;ȳ;ȴ;ȵ;ȶ;ȷ;ȸ;ȹ;Ⱥ;Ȼ;ȼ;Ƚ;Ⱦ;ȿ;" + 
                       "ɀ;Ɂ;ɂ;Ƀ;Ʉ;Ʌ;Ɇ;ɇ;Ɉ;ɉ;Ɋ;ɋ;Ɍ;ɍ;Ɏ;ɏ;ɐ;ɑ;ɒ;ɓ;ɔ;ɕ;ɖ;ɗ;ɘ;ə;ɚ;ɛ;ɜ;ɝ;ɞ;ɟ;ɠ;ɡ;ɢ;ɣ;ɤ;ɥ;ɦ;ɧ;" + 
                       "ɨ;ɩ;ɪ;ɫ;ɬ;ɭ;ɮ;ɯ;ɰ;ɱ;ɲ;ɳ;ɴ;ɵ;ɶ;ɷ;ɸ;ɹ;ɺ;ɻ;ɼ;ɽ;ɾ;ɿ;ʀ;ʁ;ʂ;ʃ;ʄ;ʅ;ʆ;ʇ;ʈ;ʉ;ʊ;ʋ;ʌ;ʍ;ʎ;ʏ;" +
                       "ʐ;ʑ;ʒ;ʓ;ʔ;ʕ;ʖ;ʗ;ʘ;ʙ;ʚ;ʛ;ʜ;ʝ;ʞ;ʟ;ʠ;ʡ;ʢ;ʣ;ʤ;ʥ;ʦ;ʧ;ʨ;ʩ;ʪ;ʫ;ʬ;ʭ;ʮ;ʯ;ʰ;ʱ;ʲ;ʳ;ʴ;ʵ;ʶ;ʷ;" + 
                       "ʸ;ʹ;ʺ;ʻ;ʼ;ʽ;ʾ;ʿ;ˀ;ˁ;\u02c2;\u02c3;\u02c4;\u02c5;ˆ;ˇ").Split(';').ToList();
        var instance = new AssessmentLibrary.Assessment1.Assessment1();

        var output = instance.ConvertBytes(input).ToList();

        CollectionAssert.AreEqual(expected, output);
    }

    [TestMethod]
    public void FilterAndConvertIntegers_Returns_ExpectedOutput()
    {
        var generator = new Random(65536); // Force generation of a same sequence.
        var input = Enumerable.Range(0,200).Select(i => generator.Next(0,350)).ToArray();
        var expected = ("ɑ;Ȱ;ʩ;ȹ;ʰ;ɉ;ɜ;Ⱦ;ʥ;ɼ;Ȧ;Ȅ;ʡ;ș;ʚ;Ȃ;ɳ;ȶ;ɢ;Ǵ;ʠ;Ǥ;Ǎ;ɘ;ˇ;Ǧ;ɹ;ɷ;ȗ;Ȇ;ȹ;ʖ;ɘ;Ǥ;Ǹ;ʚ;ǡ;ȿ;ɔ;ɤ;ǿ;ɒ;" +
                        "ǽ;ʜ;ɠ;ɐ;Ǵ;ʓ;ɮ;ɖ;ɹ;ɋ;ɝ;ȣ;ɢ;ȶ;Ȋ;ǥ;Ƀ;ˁ;Ɉ;ʶ;ʏ;ȡ;ʎ;ʰ;ʑ;ɪ;Ȥ;ʳ;ʤ;ȗ;Ȅ;ǝ;Ǹ;ǉ;ȟ;Ǥ;ɾ;ɰ;\u02c4;Ǐ;" +
                        "Ȼ;ɽ;ȟ;ǚ;ɳ;ʘ;Ǿ;ʬ;ȼ;ʭ;ȟ;ɗ;\u02c4;ɲ;Ȍ;ʅ;ʎ;Ǌ;ɲ;Ɍ;Ȉ;Ǡ;ʟ;Ƕ;ɇ;ɛ;ɍ;ɚ;ǲ;ɜ;ȍ;ʅ;Ƀ;Ș;Ȳ;ˁ;Ǯ;Ț;ǧ;ʘ;" + 
                        "Ʉ;ʇ;Ȧ;ȝ;ȸ;Ȁ;ɽ;ɱ;ɘ;ǥ;\u02c2;\u02c3;Ȯ;ʑ;ȿ;ǟ;Ǣ;ɥ;ʃ;ǈ;Ǹ;Ȓ;ǧ").Split(';').ToList();
        var instance = new AssessmentLibrary.Assessment1.Assessment1();

        var output = instance.FilterAndConvertIntegers(input).ToList();

        CollectionAssert.AreEqual(expected, output);
    }

    [TestMethod]
    public void CountOccurrences_Returns_ExpectedOutput()
    {
        var generator = new Random(65536); // Force generation of a same sequence.
        var input = Enumerable.Range(0, 1000)
            .Select(i => Convert.ToByte(generator.Next(0, 20)))
            .ToList();
        var expected = new Dictionary<string, int>
        {
            { "Ǐ", 48 }, { "Ǎ", 48 }, { "ǔ", 58 }, { "Ǘ", 48 }, { "ǎ", 47 },
            { "ǖ", 58 }, { "ǘ", 37 }, { "Ǚ", 47 }, { "Ǖ", 45 }, { "ǐ", 51 },
            { "ǚ", 54 }, { "ǒ", 54 }, { "ǋ", 58 }, { "ǌ", 63 }, { "Ǒ", 49 },
            { "Ǌ", 49 }, { "ǉ", 56 }, { "ǈ", 36 }, { "Ǜ", 44 }, { "Ǔ", 50 },
        };

        var instance = new AssessmentLibrary.Assessment1.Assessment1();

        var output = instance.CountOccurrences(input).ToList();

        CollectionAssert.AreEqual(expected, output);
    }

    [TestMethod]
    public void ExtractMostCommonIntegers_Returns_ExpectedOutput()
    {
        var generator = new Random(65536); // Force generation of a same sequence.
        var input = Enumerable.Range(0, 1000000)
            .Select(i => Convert.ToByte(generator.Next(0, 256)))
            .ToList();
        var expected = new Dictionary<string, int>
        {
            { "ɧ", 4082 }, { "ɥ", 4042 }, { "Ƿ", 4033 }, { "ȗ", 4030 }, { "ǥ", 4025 },
            { "ɖ", 4023 }, { "Ⱥ", 4022 }, { "Ȕ", 4021 }, { "Ǵ", 4021 }, { "ɒ", 4019 },
        };

        var instance = new AssessmentLibrary.Assessment1.Assessment1();
        var timer = new Stopwatch();
        timer.Start();
        var output = instance.ExtractMostCommonBytes(input).ToList();
        timer.Stop();

        Assert.IsTrue(timer.ElapsedMilliseconds <= 2000);
        CollectionAssert.AreEqual(expected, output);
    }
}
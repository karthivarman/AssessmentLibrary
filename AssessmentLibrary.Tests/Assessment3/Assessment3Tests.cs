namespace AssessmentLibrary.Tests.Assessment3;

[TestClass]
public class Assessment3Tests
{
    [DataTestMethod]
    [DataRow(1000, 20)]
    [DataRow(2000, 25)]
    public void CalculateGrossAmount_Returns_CorrectValue(int amount, int taxPercentage)
    {
        // Act
        var gross = AssessmentLibrary.Assessment3.Assessment3.CalculateGrossAmount(amount, taxPercentage);
        
        // Assert by calculating and removing tax
        var nett = CalculateNett(gross, taxPercentage);

        Assert.AreEqual(amount, nett);
    }

    [DataTestMethod]
    [DataRow(200, 125, 20, 50)]
    [DataRow(1000, 1500, 20, 25)]
    [DataRow(2000, 1250, 20, 40)]
    public void CalculateGrossAmount_Returns_CorrectTieredValue(int amount, int level1Threshold, int level1Tax1Perc,
        int level2TaxPerc)
    {
        // Act
        var gross = AssessmentLibrary.Assessment3.Assessment3.CalculateGrossAmount(amount, level1Threshold,
            level1Tax1Perc, level2TaxPerc);

        // Assert by calculating and removing tax
        var nett = CalculateNett(level1Threshold, level1Tax1Perc);
        if (gross <= level1Threshold)
        {
            nett = CalculateNett(gross, level1Tax1Perc);
        }
        else
        {
            var level2Balance = gross - level1Threshold;
            nett += CalculateNett(level2Balance, level2TaxPerc);
        }

        Assert.AreEqual(amount, nett);
    }

    private decimal CalculateNett(decimal gross, decimal taxPercentage)
    {
        var taxAmount = gross * (taxPercentage / 100m);
        return gross - taxAmount;
    }
}
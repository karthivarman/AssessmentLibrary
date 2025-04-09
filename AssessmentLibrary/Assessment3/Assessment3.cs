namespace AssessmentLibrary.Assessment3;
public class Assessment3
{
    public static decimal CalculateGrossAmount(decimal amount, decimal taxPercentage)
    {
        // Given a specified Nett amount, calculate the gross amount before tax deduction.

        var tax = taxPercentage / 100m;
        return amount / (1 - tax);
    }

    public static decimal CalculateGrossAmount(decimal amount, decimal level1Threshold, decimal level1TaxPercentage,
        decimal level2TaxPercentage)
    {
        // Given a specified Nett amount, calculate the gross amount before tax deduction
        // Where the first level1Treshold gross amount is taxed at level1TaxPercentage 
        // and the balance is taxed at level2TaxPercentage.
        //
        // Eg: Gross of £325 is taxed as follows:
        //     First £125 taxed @ 20%
        //     Balance taxed @ 50%
        //
        // 20% of 125 = 25. 
        // 325 - 125 = 200.
        // 50% of 200 = 100.
        // Total Tax: 25 + 100 = 125
        // Nett (Gross - Tax): 325 - 125 = 200

        var level1Net = level1Threshold - (level1Threshold * (level1TaxPercentage / 100));
        var totalNet = Math.Min(level1Net, amount);
        var level1Gross = CalculateGrossAmount(totalNet, level1TaxPercentage);

        var level2Gross = 0M;
        if (amount > totalNet)
        {
            level2Gross = CalculateGrossAmount(amount - totalNet, level2TaxPercentage);
        }
        
        return level1Gross + level2Gross;
    }
}
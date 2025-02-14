using System;

namespace DNTCaptcha.Core;

/// <summary>
///     SumOfTwoNumbersToWords Provider
/// </summary>
public class SumOfTwoNumbersToWordsProvider : ICaptchaTextProvider
{
    private readonly HumanReadableIntegerProvider _humanReadableIntegerProvider;
    private readonly int _randomNumber;

    /// <summary>
    ///     SumOfTwoNumbersToWords Provider
    /// </summary>
    public SumOfTwoNumbersToWordsProvider(
        IRandomNumberProvider randomNumberProvider,
        HumanReadableIntegerProvider humanReadableIntegerProvider)
    {
        if (randomNumberProvider == null)
        {
            throw new ArgumentNullException(nameof(randomNumberProvider));
        }

        _randomNumber = randomNumberProvider.NextNumber(1, 7);
        _humanReadableIntegerProvider = humanReadableIntegerProvider;
    }

    /// <summary>
    ///     display a numeric value using the equivalent text
    /// </summary>
    /// <param name="number">input number</param>
    /// <param name="language">local language</param>
    /// <returns>the equivalent text</returns>
    public string GetText(long number, Language language) =>
        number > _randomNumber
            ? $"{_humanReadableIntegerProvider.NumberToText(number - _randomNumber, language)} + {_humanReadableIntegerProvider.NumberToText(_randomNumber, language)}"
            : $"{_humanReadableIntegerProvider.NumberToText(0, language)} + {_humanReadableIntegerProvider.NumberToText(number, language)}";
}
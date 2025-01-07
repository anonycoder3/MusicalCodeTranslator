﻿using System.Text.RegularExpressions;

namespace MusicalCodeTranslator.Translation.TextToMusicalString.FormatChecker;

public class MusicalStringFormatChecker : IFormatChecker
{
    public bool IsMusicallyEncodedString(string text)
    {
        // Remove punctuation and spaces.
        var stringWithNoSpacesNorPunctation = string.Join("", text.Where(char.IsLetterOrDigit));

        // Check that Length is even number. If not, return false. Check that each pair is a musicalLetter and digit. This Regex catches inputs like !!!HIJ!!! or !!!123!!!, which should both be false.
        if (!(stringWithNoSpacesNorPunctation.Length % 2 == 0) || !Regex.IsMatch(stringWithNoSpacesNorPunctation, "^([A-Ga-g][0-3])*$"))
            return false;

        // Below is still needed to catch inputs like A!!!1 which should be false.
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]) && !char.IsDigit(text[i + 1]))
            {
                // If the current character is a letter and it is not immediately followed by a digit, return false.
                return false;
            }

            if (char.IsDigit(text[i]) && !char.IsLetter(text[i - 1]))
            {
                // If the current character is a digit and it is not immediately preceeded by a letter, return false.
                return false;
            }
        }

        return true;
    }

    public bool IsMusicallyEncodedCharacterPair(char leftCharacter, char rightCharacter)
    {
        return char.IsLetter(leftCharacter) &&
               (char.IsLower(leftCharacter) ? AlphabetHelpers.LowercaseEnglishAlphabet.Take(7).Contains(leftCharacter)
                                            : AlphabetHelpers.UppercaseEnglishAlphabet.Take(7).Contains(leftCharacter)) &&
               char.IsDigit(rightCharacter) &&
               rightCharacter >= '0' && rightCharacter <= '3';
    }
}
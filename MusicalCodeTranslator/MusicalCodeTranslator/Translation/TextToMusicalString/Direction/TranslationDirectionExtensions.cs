﻿namespace MusicalCodeTranslator.Translation.TextToMusicalString.Direction;

public static class TranslationDirectionExtensions
{
    public static string AsText(this TranslationDirection direction)
    {
        if (direction == TranslationDirection.Encode)
        {
            return "encode";
        }
        else if (direction == TranslationDirection.Decode)
        {
            return "decode";
        }

        return null;
    }
}
﻿using MusicalCodeTranslator.App;
using MusicalCodeTranslator.UserInteraction;
using MusicalCodeTranslator.Translation.TextToMusicalString;
using MusicalCodeTranslator.Translation.TextToMusicalString.FormatChecker;
using MusicalCodeTranslator.Translation.MusicalStringToMusicalWord;
using MusicalCodeTranslator.Translation.MusicalStringToMusicalWord.FrequencyRangeGeneration;
using MusicalCodeTranslator.NotePlayback;

var translatorConsolUserInteraction = new TranslatorConsoleUserInteraction();
var musicalStringFormatChecker = new MusicalStringFormatChecker();

var musicalCodeTranslatorApp = new MusicalCodeTranslatorApp(
    translatorConsolUserInteraction,
    new TextToMusicalStringEncoder(musicalStringFormatChecker),
    musicalStringFormatChecker,
    new MusicalStringToMusicalWordTranslator(new FrequencyRangeGenerator()),
    new WindowsConsoleMusicNotePlayer(translatorConsolUserInteraction));

musicalCodeTranslatorApp.Run();
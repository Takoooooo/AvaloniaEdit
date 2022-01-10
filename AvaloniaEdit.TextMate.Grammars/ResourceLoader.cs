﻿using AvaloniaEdit.TextMate.Grammars.Enums;
using System;
using System.IO;
using System.Reflection;

namespace AvaloniaEdit.TextMate.Grammars
{
    public static class ResourceLoader
    {
        private const string GrammarPrefix = "AvaloniaEdit.TextMate.Grammars.Resources.Grammars.";

        private const string ThemesPrefix = "AvaloniaEdit.TextMate.Grammars.Resources.Themes.";

        public static Tuple<string, string> LoadGrammarByNameToStream(GrammarName name)
        {
            var stream = typeof(ResourceLoader).GetTypeInfo().Assembly.GetManifestResourceStream(
                GrammarPrefix + name.ToString().ToLower() + "." + "package.json");
            using var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return new Tuple<string, string>(text, name.ToString().ToLower() + "." + "package.json");
        }

        public static string LoadGrammarByNameToStream2(GrammarName name, string fileName)
        {
            var stream = typeof(ResourceLoader).GetTypeInfo().Assembly.GetManifestResourceStream(
                GrammarPrefix + name.ToString().ToLower() + "." + fileName);
            using var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return text;
        }

        public static Tuple<string, string> LoadThemeByNameToStream(ThemeName name)
        {
            var stream = typeof(ResourceLoader).GetTypeInfo().Assembly.GetManifestResourceStream(
                ThemesPrefix + GetThemeFileName(name));
            using var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return new Tuple<string, string>(text, GetThemeFileName(name));
        }

        private static string GetThemeFileName(ThemeName name)
        {
            return name switch
            {
                ThemeName.Abbys => "abyss-color-theme.json",
                ThemeName.Dark => "dark_vs.json",
                ThemeName.DarkPlus => "dark_plus.json",
                ThemeName.DimmedMonokai => "dimmed-monokai-color-theme.json",
                ThemeName.KimbieDark => "kimbie-dark-color-theme.json",
                ThemeName.Light => "light_vs.json",
                ThemeName.LightPlus => "light_plus.json",
                ThemeName.Monokai => "monokai-color-theme.json",
                ThemeName.QuietLight => "quietlight-color-theme.json",
                ThemeName.Red => "Red-color-theme.json",
                ThemeName.SolarizedDark => "solarized-dark-color-theme.json",
                ThemeName.SolarizedLight => "solarized-light-color-theme.json",
                ThemeName.TomorrowNightBlue => "tomorrow-night-blue-color-theme.json",
                _ => null,
            };
        }
    }
}
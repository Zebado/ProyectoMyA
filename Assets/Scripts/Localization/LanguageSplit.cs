using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LanguageSplit
{
    public static Dictionary<Language, Dictionary<string, string>> LoadCSV(string sheet, string source)
    {
        var codex = new Dictionary<Language, Dictionary<string, string>>();

        var langColumn = new Dictionary<int, Language>();
        int idColumn = 0;

        var lines = sheet.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        bool firstLine = true;
        
        foreach (var line in lines)
        {
            var cells = line.Split(',');

            if (firstLine)
            {
                firstLine = false;
                for (int i = 0; i < cells.Length; i++)
                {
                    if (!cells[i].Contains("ID"))
                    {
                        try
                        {
                            langColumn[i] = (Language)Enum.Parse(typeof(Language), cells[i]);
                        }
                        catch(Exception e)
                        {
                            Debug.Log($"{e.ToString()} - source: {source}");
                            continue;
                        }

                        if (!codex.ContainsKey(langColumn[i]))
                        {
                            codex[langColumn[i]] = new Dictionary<string, string>();
                        }
                    }
                    else
                    {
                        idColumn = i;
                    }
                }
                continue;
            }

            for (int i = 0; i < cells.Length; i++)
            {
                if (i == idColumn) continue;

                var lang = langColumn[i];
                var id = cells[idColumn];
                var textValue = cells[i];

                codex[lang][id] = textValue;
            }
        }
        return codex;
    }
}

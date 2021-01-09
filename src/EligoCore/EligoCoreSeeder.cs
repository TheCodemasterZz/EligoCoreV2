using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EligoCore
{
    public class EligoCoreSeeder
    {
        public static IEnumerable<string[]> Parse(string path, string delimiters = "|",
           bool hasFieldsEnclosedInQuotes = true, bool hasHeader = false)
        {
            using (var parser = new TextFieldParser(new StringReader(path)))
            {
                parser.SetDelimiters(delimiters);
                parser.HasFieldsEnclosedInQuotes = hasFieldsEnclosedInQuotes;
                if (hasHeader) parser.ReadLine();
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    if (fields != null)
                        yield return fields;
                }
            }
        }
    }
}

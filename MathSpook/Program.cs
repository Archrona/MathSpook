using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathSpook
{
    public static class Program
    {
        public static Dictionary<string, List<Command>> COMMANDS;

        public static void loadCommands() {
            COMMANDS = new Dictionary<string, List<Command>>();

            using (TextFieldParser parser = new TextFieldParser(@"../../../commands.csv")) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                
                // Discard header
                parser.ReadFields();

                while (!parser.EndOfData) {
                    string[] fields = parser.ReadFields();

                    var c = new Command();
                    c.words = fields[0].Split(' ');
                    c.math = (fields[1].Trim() == "1");
                    c.arguments = int.Parse(fields[2]);
                    c.onlyInMath = (fields[3].Trim() == "1");
                    c.glueLeft = (fields[4].Trim() == "1");
                    c.glueRight = (fields[5].Trim() == "1");

                    if (fields[6].Length > 0) {
                        c.latex = c.html = fields[6];
                    } else {
                        c.latex = fields[7];
                        c.html = fields[8];
                    }

                    if (!COMMANDS.ContainsKey(c.words[0]))
                        COMMANDS[c.words[0]] = new List<Command>();

                    COMMANDS[c.words[0]].Add(c);
                }
            }

            foreach (var kvp in COMMANDS) {
                kvp.Value.Sort((Command a, Command b) =>
                    b.words.Length.CompareTo(a.words.Length)
                );
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            loadCommands();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MathSpook());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathSpook
{
    public enum Mode
    {
        Latex,
        HTML
    }

    public class Command
    {
        public string[] words;

        public int arguments;
        public bool math;
        public bool onlyInMath;
        public bool glueLeft;
        public bool glueRight;

        public string latex;
        public string html;
    }

    public class Word
    {
        public string text;
        public bool literal;
        public bool glueLeft;
        public bool glueRight;
        public bool math;

        public Word(string text, bool glueLeft = true, bool glueRight = true, bool math = false) {
            this.text = text;
            
            if (this.text.Length >= 2 && this.text[0] == '#') {
                this.literal = true;
                this.text = this.text.Substring(1, this.text.Length - 1);
            } else {
                this.literal = false;
            }

            this.glueLeft = glueLeft;
            this.glueRight = glueRight;
            this.math = math;
        }
    }

    public class Convert
    {
        public List<List<Word>> pars;
        public List<string> executedLatex;
        public List<string> executedHTML;

        private int idx;
        private string raw;
        private List<Word> accum;
        private bool whiteBefore;

        public Convert(string raw) {
            this.raw = raw;

            pass1_tokenize();
            pass2_parse();
        }

        private void pass1_tokenize() {
            idx = 0;
            whiteBefore = false;

            pars = new List<List<Word>>();
            accum = new List<Word>();

            while (idx < raw.Length) {
                parse();
            }

            if (accum.Count > 0) {
                pars.Add(accum);
            }
            accum = null;
        }

        private bool isIdent(char c) {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == '#';
        }

        private bool isNumeric(char c) {
            return (c >= '0' && c <= '9');
        }

        private void parse() {
            if (raw[idx] == '\r' || raw[idx] == '\n') {
                parseEOL();
            }
            else if (raw[idx] <= ' ') {
                parseWhite();
            }
            else if (isIdent(raw[idx])) {
                parseIdentifier();
            }
            else if (isNumeric(raw[idx])) {
                parseNumber();
            }
            else {
                parseChar();
            }
        }

        private void parseEOL() {
            int eols = 0;

            while (idx < raw.Length) {
                if (raw[idx] == '\r' && idx + 1 < raw.Length && raw[idx + 1] == '\n') {
                    idx += 2;
                    eols++;
                }
                else if (raw[idx] == '\r') {
                    idx += 1;
                    eols++;
                }
                else if (raw[idx] == '\n') {
                    idx += 1;
                    eols++;
                } 
                else {
                    break;
                }
            }

            if (eols <= 1) {
                if (accum.Count > 0)
                     accum[accum.Count - 1].glueRight = false;
                whiteBefore = true;
            } else {
                if (accum.Count > 0) {
                    pars.Add(accum);
                    accum = new List<Word>();
                    whiteBefore = false;
                }
            }
        }

        private void parseWhite() {
            while (idx < raw.Length && raw[idx] <= ' ' && raw[idx] != '\r' && raw[idx] != '\n') {
                idx++;
            }

            if (accum.Count > 0) {
                accum[accum.Count - 1].glueRight = false;
            }

            whiteBefore = true;
        }

        private void parseIdentifier() {
            int last = idx + 1;

            while (last < raw.Length && isIdent(raw[last])) {
                last++;
            }

            accum.Add(new Word(raw.Substring(idx, last - idx), !whiteBefore));
            idx = last;
            whiteBefore = false;
        }

        private void parseNumber() {
            int last = idx + 1;

            while (last < raw.Length && isNumeric(raw[last])) {
                last++;
            }

            accum.Add(new Word(raw.Substring(idx, last - idx), !whiteBefore, true, true));
            idx = last;
            whiteBefore = false;
        }

        private void parseChar() {
            accum.Add(new Word(raw.Substring(idx, 1), !whiteBefore));
            idx++;
            whiteBefore = false;
        }



        private void pass2_parse() {
            var latex = new List<Word>();
            var html = new List<Word>();

            foreach (var par in pars) {
                latex.Add(execPar(par, 0, false, Mode.Latex).Item1);
                html.Add(execPar(par, 0, false, Mode.HTML).Item1);
            }

            executedLatex = latex.Select(w => w.text).ToList();
            executedHTML = html.Select(w => w.text).ToList();
        }

        private string execStartMath(Mode mode, bool display) {
            if (mode == Mode.HTML) return display ? "<script type=\"text/kdmath\">" : "<script type=\"text/kmath\">";
            else if (mode == Mode.Latex) return display ? "\\[" : "$";
            else return "";
        }

        private string execEndMath(Mode mode, bool display) {
            if (mode == Mode.HTML) return "</script>";
            else if (mode == Mode.Latex) return display ? "\\]" : "$";
            else return "";
        }

        private Word execJoin(List<Word> wds, bool inMath, Mode mode) {
            StringBuilder sb = new StringBuilder();
            bool allMath = wds.TrueForAll(wd => wd.math);
            bool doDelimiters = !inMath && !allMath;

            if (allMath && !inMath) {
                sb.Append(execStartMath(mode, true));
            }

            for (int i = 0; i < wds.Count; i++) {
                if (doDelimiters && wds[i].math && (i == 0 || (i > 0 && !wds[i - 1].math))) {
                    sb.Append(execStartMath(mode, false));
                } 

                sb.Append(wds[i].text);

                if (doDelimiters && wds[i].math && (i == wds.Count - 1 || (i < wds.Count - 1 && !wds[i + 1].math))) {
                    sb.Append(execEndMath(mode, false));
                }

                if (i + 1 < wds.Count && (
                    (!wds[i].glueRight && !wds[i + 1].glueLeft)
                    || (!wds[i].math && wds[i + 1].math && !wds[i].glueRight)
                    || (wds[i].math && !wds[i + 1].math && !wds[i + 1].glueLeft)
                )) {
                    sb.Append(" ");
                }
            }

            if (allMath && !inMath) {
                sb.Append(execEndMath(mode, true));
            }

            return new Word(
                sb.ToString(),
                wds.Count > 0 ? wds[0].glueLeft : true,
                wds.Count > 0 ? wds[wds.Count - 1].glueRight : true
            );
        }

        private Command execCommandMatch(List<Word> par, int i, bool math) {
            string low = par[i].text.ToLower();

            if (par[i].literal) return null;

            if (Program.COMMANDS.ContainsKey(low)) {
                foreach (Command c in Program.COMMANDS[low]) {
                    if (c.onlyInMath && !math) continue;
                    
                    bool match = true;
                    for (int offset = 1; offset < c.words.Length; offset++) {
                        if (i + offset >= par.Count || par[i + offset].text.ToLower() != c.words[offset] || par[i + offset].literal) {
                            match = false;
                            break;
                        }
                    }

                    if (match) {
                        return c;
                    }
                }
            }

            return null;
        }

        // i points to the first token of the first argument
        private (Word, int) execCommand(Command c, List<Word> par, int i, bool math, Mode mode) {
            var repl = (mode == Mode.Latex ? c.latex : c.html);

            if (c.arguments == 0) 
                return (new Word(repl, c.glueLeft, c.glueRight, c.math), i);

            var args = new List<Word>(c.arguments);

            for (int a = 0; a < c.arguments; a++) {
                var (sub, nextIdx) = execPar(par, i, c.math, mode, true);
                i = nextIdx;
                args.Add(sub);
            }

            StringBuilder sb = new StringBuilder();
            int ch = 0;
            while (ch < repl.Length) {
                if (repl[ch] == '$' && ch + 1 < repl.Length) {
                    if (repl[ch + 1] >= '1' && repl[ch + 1] <= '9') {
                        int argIdx = (int)(repl[ch + 1] - '1');
                        if (argIdx < args.Count) {
                            sb.Append(args[argIdx].text);
                        }
                    } else {
                        sb.Append(repl[ch + 1]);
                    }
                    ch += 2;
                } else {
                    sb.Append(repl[ch]);
                    ch += 1;
                }
            }

            return (new Word(sb.ToString(), c.glueLeft, c.glueRight, c.math), i);
        }

        private (Word, int) execPar(List<Word> par, int startIdx, bool inMath, Mode mode, bool justOne = false) {
            List<Word> words = new List<Word>();
            int i = startIdx;
            Command c;

            while (i < par.Count) { 
                if (par[i].text == ")") {
                    i++;
                    break;
                }
                else if (par[i].text == "(") {
                    var (sub, nextIdx) = execPar(par, i + 1, inMath, mode, false);
                    i = nextIdx;
                    words.Add(sub);
                }
                else if ((c = execCommandMatch(par, i, inMath)) != null) {
                    var (sub, nextIdx) = execCommand(c, par, i + c.words.Length, inMath, mode);
                    i = nextIdx;
                    words.Add(sub);
                }
                else {
                    words.Add(par[i]);
                    if (inMath) words[words.Count - 1].math = inMath;  // patch to inherit math status
                    i++;
                }

                if (justOne) return (words[0], i); // no join if just one - so no math wrapping
            }

            if (words.Count == 0) {
                if (inMath) return (new Word("\\square", false, false, true), i);
                else return (new Word("□", false, false, false), i);
            }
            else {
                return (execJoin(words, inMath, mode), i);
            }
        }

        public string toJSON() {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                executedHTML,
                Newtonsoft.Json.Formatting.Indented
            );
        }

        public string toLatex() {
            return String.Join("\r\n\r\n", executedLatex);
        }

        public string toHTML() {
            return executedHTML.Select(line => "<p>" + line + "</p>\r\n").Aggregate("", (s, t) => s + t);
        }
    }
}

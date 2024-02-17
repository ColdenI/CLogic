using c = System.Console;
using System;

namespace CLogic;

public static class EnterData
{
    public static bool isConsoleCommand = true;
    public static string SyntaxErrorMessage = "Syntax error!\n";
    public static string PauseMessage = "Press any key...";
    public static string SyntaxErrorRangeMessage = "Syntax error (Range)!\n";

    public static void Pause()
    {
        c.WriteLine(PauseMessage);
        c.ReadKey();
    }

    public static string GetString(string text = "Enter text", string text_about = "")
    {
        c.Write(text + (string.IsNullOrEmpty(text_about) ? ": " : $" ({text_about}): "));
        string? _res = c.ReadLine();
        if (isConsoleCommand)
        {
            if (_res == "clear") c.Clear();
        }
        return _res??"";
    }

    public static int GetInt(string text = "Enter value", string text_about = "", in int[]? range = null, in int? isEnterExitValue = null)
    {
        while (true)
        {
            if (range != null)
                if (range.Length != 2 || range[0] >= range[1])
                    throw new Exception("The syntax of the 'range' argument is broken, the argument must contain 2 elements (minimum and maximum value)");

            string _data = GetString(text, range != null ? text_about + $" ({range[0]}-{range[1]})" : text_about);
            if (isEnterExitValue != null && string.IsNullOrEmpty(_data)) return (int)isEnterExitValue;

            if (!Int32.TryParse(_data, out int output))
            {
                c.WriteLine(SyntaxErrorMessage);
                continue;
            }
            if (range != null)
                if (!(output >= range[0] && output < range[1]))
                {
                    c.WriteLine(SyntaxErrorRangeMessage);
                    continue;
                }
            return output;
        }
    }

    public static long GetLong(string text = "Enter value", string text_about = "", in long[]? range = null, in long? isEnterExitValue = null)
    {
        while (true)
        {
            if (range != null)
                if (range.Length != 2 || range[0] >= range[1])
                    throw new Exception("The syntax of the 'range' argument is broken, the argument must contain 2 elements (minimum and maximum value)");

            string _data = GetString(text, range != null ? text_about + $" ({range[0]}-{range[1]})" : text_about);
            if (isEnterExitValue != null && string.IsNullOrEmpty(_data)) return (long)isEnterExitValue;

            if (!Int64.TryParse(_data, out long output))
            {
                c.WriteLine(SyntaxErrorMessage);
                continue;
            }
            if (range != null)
                if (!(output >= range[0] && output < range[1]))
                {
                    c.WriteLine(SyntaxErrorRangeMessage);
                    continue;
                }
            return output;
        }
    }

    public static float GetFloat(string text = "Enter value", string text_about = "", in float[]? range = null, in float? isEnterExitValue = null)
    {
        while (true)
        {
            if (range != null)
                if (range.Length != 2 || range[0] >= range[1])
                    throw new Exception("The syntax of the 'range' argument is broken, the argument must contain 2 elements (minimum and maximum value)");

            string _data = GetString(text, range != null ? text_about + $" ({range[0]}-{range[1]})" : text_about);
            if (isEnterExitValue != null && string.IsNullOrEmpty(_data)) return (float)isEnterExitValue;

            if (!Single.TryParse(_data, out float output))
            {
                c.WriteLine(SyntaxErrorMessage);
                continue;
            }
            if (range != null)
                if (!(output >= range[0] && output < range[1]))
                {
                    c.WriteLine(SyntaxErrorRangeMessage);
                    continue;
                }
            return output;
        }
    }

    public static double GetDouble(string text = "Enter value", string text_about = "", in double[]? range = null, in double? isEnterExitValue = null)
    {
        while (true)
        {
            if (range != null)
                if (range.Length != 2 || range[0] >= range[1])
                    throw new Exception("The syntax of the 'range' argument is broken, the argument must contain 2 elements (minimum and maximum value)");

            string _data = GetString(text, text_about = $" ({range[0]}-{range[1]})");
            if (isEnterExitValue != null && string.IsNullOrEmpty(_data)) return (double)isEnterExitValue;

            if (!Double.TryParse(_data, out double output))
            {
                c.WriteLine(SyntaxErrorMessage);
                continue;
            }
            if (range != null)
                if (!(output >= range[0] && output < range[1]))
                {
                    c.WriteLine(SyntaxErrorRangeMessage);
                    continue;
                }
            return output;
        }
    }

    public static void WriteInMatrix(ref CMatrixInt m, string matrixName = "Matrix")
    {
        for (int i = 0; i < m.Size[0]; i++)
            for (int j = 0; j < m.Size[1]; j++)
            {
                m[i, j] = EnterData.GetInt($"{matrixName}[{i},{j}]");
            }
    }
    public static void WriteInMatrix(ref CMatrixDouble m, string matrixName = "Matrix")
    {
        for (int i = 0; i < m.Size[0]; i++)
            for (int j = 0; j < m.Size[1]; j++)
            {
                m[i, j] = EnterData.GetDouble($"{matrixName}[{i},{j}]");
            }
    }

}
namespace CLogic;

public static class CMath
{
    #region Map
    public static int map(int x, int in_min, int in_max, int out_min, int out_max) => (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    public static long map(long x, long in_min, long in_max, long out_min, long out_max) => (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    public static float map(float x, float in_min, float in_max, float out_min, float out_max) => (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    public static double map(double x, double in_min, double in_max, double out_min, double out_max) => (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    public static decimal map(decimal x, decimal in_min, decimal in_max, decimal out_min, decimal out_max) => (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    #endregion

    #region Sum
    public static int Sum(params int[] arr)
    {
        int res = 0;
        foreach (var i in arr) res += i;
        return res;
    }
    public static long Sum(params long[] arr)
    {
        long res = 0;
        foreach (var i in arr) res += i;
        return res;
    }
    public static float Sum(params float[] arr)
    {
        float res = 0;
        foreach (var i in arr) res += i;
        return res;
    }
    public static double Sum(params double[] arr)
    {
        double res = 0;
        foreach (var i in arr) res += i;
        return res;
    }
    public static decimal Sum(params decimal[] arr)
    {
        decimal res = 0;
        foreach (var i in arr) res += i;
        return res;
    }
    /// <summary>
    /// The sum of all the elements of the matrix.
    /// </summary>
    public static int Sum(in CMatrixInt m) => m.Sum;
    /// <summary>
    /// The sum of all the elements of the matrix.
    /// </summary>
    public static double Sum(in CMatrixDouble m) => m.Sum;
    #endregion

    #region Min
    public static int Min(params int[] arr)
    {
        int buf = int.MaxValue;
        foreach (var i in arr)
            if (buf > i) buf = i;
        return buf;
    }
    public static long Min(params long[] arr)
    {
        long buf = long.MaxValue;
        foreach (var i in arr)
            if (buf > i) buf = i;
        return buf;
    }
    public static float Min(params float[] arr)
    {
        float buf = float.MaxValue;
        foreach (var i in arr)
            if (buf > i) buf = i;
        return buf;
    }
    public static double Min(params double[] arr)
    {
        double buf = double.MaxValue;
        foreach (var i in arr)
            if (buf > i) buf = i;
        return buf;
    }
    public static decimal Min(params decimal[] arr)
    {
        decimal buf = decimal.MaxValue;
        foreach (var i in arr)
            if (buf > i) buf = i;
        return buf;
    }
    /// <summary>
    /// The value of the minimum element of the matrix.
    /// </summary>
    public static int Min(CMatrixInt m) => m.Min;
    /// <summary>
    /// The value of the minimum element of the matrix.
    /// </summary>
    public static double Min(CMatrixDouble m) => m.Min;
    #endregion

    #region Max
    public static int Max(params int[] arr)
    {
        int buf = int.MinValue;
        foreach (var i in arr)
            if (buf < i) buf = i;
        return buf;
    }
    public static long Max(params long[] arr)
    {
        long buf = long.MinValue;
        foreach (var i in arr)
            if (buf < i) buf = i;
        return buf;
    }
    public static float Max(params float[] arr)
    {
        float buf = float.MinValue;
        foreach (var i in arr)
            if (buf < i) buf = i;
        return buf;
    }
    public static double Max(params double[] arr)
    {
        double buf = double.MinValue;
        foreach (var i in arr)
            if (buf < i) buf = i;
        return buf;
    }
    public static decimal Max(params decimal[] arr)
    {
        decimal buf = decimal.MinValue;
        foreach (var i in arr)
            if (buf < i) buf = i;
        return buf;
    }
    /// <summary>
    /// The value of the maximum element of the matrix.
    /// </summary>
    public static int Max(CMatrixInt m) => m.Max;
    /// <summary>
    /// The value of the maximum element of the matrix.
    /// </summary>
    public static double Max(CMatrixDouble m) => m.Max;
    #endregion

}

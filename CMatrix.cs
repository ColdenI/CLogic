namespace CLogic;

public abstract class CMatrix
{
    protected bool isTransposed = false;
    public bool IsTransposed { get => isTransposed; }

    /// <summary>
    /// Outputs the matrix values to the console.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="cMatrix"></param>
    /// <param name="matrixName"></param>
    static public void ConsoleDraw<T>(in CMatrix<T> cMatrix, string matrixName = "Matrix")
    {
        Console.WriteLine("\n" + matrixName);
        for (int i = 0; i < cMatrix.Size[0]; i++)
        {
            for (int j = 0; j < cMatrix.Size[1]; j++)
            {
                Console.Write(cMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

/// <summary>
/// A matrix class of indeterminate type
/// </summary>
/// <typeparam name="T"></typeparam>
public class CMatrix<T> : CMatrix
{
    protected T[,] _matrix;

    /// <summary>
    /// The size of the matrix. [rows, columns]
    /// </summary>
    public int[] Size
    {
        get => isTransposed ?
            new int[] { _matrix.GetLength(1), _matrix.GetLength(0) } :
            new int[] { _matrix.GetLength(0), _matrix.GetLength(1) };
    }

    public int Rows
    {
        get => isTransposed ?
             _matrix.GetLength(1) :
             _matrix.GetLength(0);
    }
    public int Columns
    {
        get => isTransposed ?
             _matrix.GetLength(0) :
             _matrix.GetLength(1);
    }

    public CMatrix(T[,] mat) => _matrix = mat;
    public CMatrix(int m, int n) => _matrix = new T[m, n];
    public CMatrix(int m) : this(m, m) { }
    public CMatrix(int[] size) : this(size[0], size[1]) { }

    public T this[int i, int j]
    {
        get { return isTransposed ? _matrix[j, i] : _matrix[i, j]; }
        set { if (isTransposed) _matrix[j, i] = value; else _matrix[i, j] = value; }
    }

    public T Get(int i, int j) => this[i, j];
    public T Get(int[] index) => Get(index[0], index[1]);

    /// <summary>
    /// Transposes and returns the transposed matrix.
    /// </summary>
    /// <returns></returns>
    public virtual CMatrix<T> Transpose()
    {
        isTransposed = !isTransposed;
        return this;
    }
    /// <summary>
    /// Returns a copy of the matrix.
    /// </summary>
    /// <returns></returns>
    public virtual CMatrix<T> Copy() => new CMatrix<T>(_matrix);
    /// <summary>
    /// Returns the transposed copy of the matrix.
    /// </summary>
    /// <returns></returns>
    public virtual CMatrix<T> GetTranspose() => this.Copy().Transpose();    

    public static bool operator ==(in CMatrix<T> a, in CMatrix<T> b) => Equals(a, b);
    public static bool operator !=(in CMatrix<T> a, in CMatrix<T> b) => !(a == b);

    /// <summary>
    /// Outputs the matrix values to the console.
    /// </summary>
    /// <param name="matrixName"></param>
    public void ConsoleDraw(string nameMatrix = "Matrix") => ConsoleDraw(this, nameMatrix);

    /// <summary>
    /// Returns the index of the first found passed element in the matrix, otherwise null.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int[]? IndexOf(T obj)
    {
        for (int i = 0; i < this.Size[0]; i++)
            for (int j = 0; j < this.Size[1]; j++)
                if (Equals(this[i, j], obj)) return new int[] { i, j };
        return null;
    }
    /// <summary>
    /// Returns a two-dimensional array of indexes of all corresponding to the passed object from the elements of the matrix. ( { {0, 0}, {0, 1}, {1, 0}...} )
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int[,]? IndexesOf(T obj)
    {
        List<int[]> indexes = new List<int[]>();
        for (int i = 0; i < this.Size[0]; i++)
            for (int j = 0; j < this.Size[1]; j++)
                if (Equals(this[i, j], obj)) indexes.Add(new int[] { i, j });
        if (indexes.Count == 0) return null;
        int[,] arr = new int[indexes.Count, 2];
        for (int i = 0; i < indexes.Count; i++)
        {
            arr[i, 0] = indexes[i][0];
            arr[i, 1] = indexes[i][1];
        }
        return arr;
    }

    protected static CMatrixInt ConvertToCMatrixInt(CMatrix<T> v)
    {
        CMatrixInt res = new CMatrixInt(v.Size);
        for (int i = 0; i < v.Size[0]; i++)
            for (int j = 0; j < v.Size[1]; j++)
                res[i, j] = Convert.ToInt32(v[i, j]);

        return res;
    }
    protected static CMatrixDouble ConvertToCMatrixDouble(CMatrix<T> v)
    {
        CMatrixDouble res = new CMatrixDouble(v.Size);
        for (int i = 0; i < v.Size[0]; i++)
            for (int j = 0; j < v.Size[1]; j++)
                res[i, j] = Convert.ToDouble(v[i, j]);

        return res;
    }
}

/// <summary>
/// The class of an integer type matrix
/// </summary>
public class CMatrixInt : CMatrix<int>
{
    public CMatrixInt(int m, int n) : base(m, n) { }
    public CMatrixInt(int[,] mat) : base(mat) { }
    public CMatrixInt(int m) : base(m, m) { }
    public CMatrixInt(int[] size) : base(size[0], size[1]) { }

    /// <summary>
    /// The sum of all the elements of the matrix.
    /// </summary>
    public int Sum
    {
        get
        {
            int res = 0;
            for (int i = 0; i < this.Size[0]; i++) for (int j = 0; j < this.Size[1]; j++) res += this[i, j];
            return res;
        }
    }
    /// <summary>
    /// The value of the minimum element of the matrix.
    /// </summary>
    public int Min
    {
        get
        {
            int buf = int.MaxValue;
            for (int i = 0; i < this.Size[0]; i++)
                for (int j = 0; j < this.Size[1]; j++)
                    if (buf > this[i, j]) buf = this[i, j];
            return buf;
        }
    }
    /// <summary>
    /// The value of the maximum element of the matrix.
    /// </summary>
    public int Max
    {
        get
        {
            int buf = int.MinValue;
            for (int i = 0; i < this.Size[0]; i++)
                for (int j = 0; j < this.Size[1]; j++)
                    if (buf < this[i, j]) buf = this[i, j];
            return buf;
        }
    }
    /// <summary>
    /// Returns a row of the matrix by index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public int[] GetRow(int index)
    {
        if (index >= this.Size[0]) throw new ArgumentOutOfRangeException("index");
        int[] res = new int[this.Size[1]];
        for (int i = 0; i < this.Size[1]; i++)
            res[i] = this[index, i];
        return res;
    }
    /// <summary>
    /// Returns the column of the matrix by index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public int[] GetСolumn(int index)
    {
        if (index >= this.Size[1]) throw new ArgumentOutOfRangeException("index");
        int[] res = new int[this.Size[0]];
        for (int i = 0; i < this.Size[0]; i++)
            res[i] = this[i, index];
        return res;
    }

    public override CMatrixInt GetTranspose() => CMatrix<int>.ConvertToCMatrixInt(base.GetTranspose());
    public override CMatrixInt Copy() => CMatrix<int>.ConvertToCMatrixInt(base.Copy());
    public override CMatrixInt Transpose() => CMatrix<int>.ConvertToCMatrixInt(base.Transpose());


    #region operators
    // сложение, вычитание, инверсия
    public static CMatrixInt operator +(in CMatrixInt a, in CMatrixInt b)
    {
        if (a.Size[0] != b.Size[0] || a.Size[1] != b.Size[1]) throw CMatrixException.CMatrixException_addition;
        CMatrixInt resMatrix = new CMatrixInt(a.Size);
        for (int i = 0; i < resMatrix.Size[0]; i++) for (int j = 0; j < resMatrix.Size[1]; j++) resMatrix[i, j] = a[i, j] + b[i, j];
        return resMatrix;
    }
    public static CMatrixInt operator -(in CMatrixInt a, in CMatrixInt b)
    {
        if (a.Size[0] != b.Size[0] || a.Size[1] != b.Size[1]) throw CMatrixException.CMatrixException_addition;
        CMatrixInt resMatrix = new CMatrixInt(a.Size);
        for (int i = 0; i < resMatrix.Size[0]; i++) for (int j = 0; j < resMatrix.Size[1]; j++) resMatrix[i, j] = a[i, j] - b[i, j];
        return resMatrix;
    }
    public static CMatrixInt operator -(in CMatrixInt a) => a * -1;

    public static CMatrixInt operator +(in CMatrixInt a, in int b)
    {
        CMatrixInt res = new CMatrixInt(a.Size);
        for (int i = 0; i < a.Size[0]; i++) for (int j = 0; j < a.Size[1]; j++) res[i, j] = a[i, j] + b;
        return res;
    }
    //public static CMatrixInt operator +(in int a, in CMatrixInt b) => b + a;
    //public static CMatrixInt operator -(in int a, in CMatrixInt b) => b + -a;
    public static CMatrixInt operator -(in CMatrixInt a, in int b) => a + -b;
    // умножение на число
    public static CMatrixInt operator *(in CMatrixInt a, in int b)
    {
        CMatrixInt res = new CMatrixInt(a.Size);
        for (int i = 0; i < a.Size[0]; i++) for (int j = 0; j < a.Size[1]; j++) res[i, j] = a[i, j] * b;
        return res;
    }
    public static CMatrixInt operator *(in int b, in CMatrixInt a) => a * b;
    // умножение на матрицу
    public static CMatrixInt operator *(in CMatrixInt a, in CMatrixInt b)
    {
        if (a.Size[1] != b.Size[0]) throw CMatrixException.CMatrixException_multiplication;
        CMatrixInt r = new CMatrixInt(a.Size[0], b.Size[1]);
        for (int i = 0; i < a.Size[0]; i++)
        {
            for (int j = 0; j < b.Size[1]; j++)
            {
                for (int k = 0; k < b.Size[0]; k++)
                {
                    r[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return r;
    }
    // приведение от типа double
    public static explicit operator CMatrixInt(CMatrixDouble v)
    {
        CMatrixInt res = new CMatrixInt(v.Size);
        for (int i = 0; i < v.Size[0]; i++)
            for (int j = 0; j < v.Size[1]; j++)
                res[i, j] = (int)v[i, j];

        return res;
    }

    // сравнение
    public static bool operator ==(in CMatrixInt a, in CMatrixInt b)
    {
        if (a.Size[0] != b.Size[0] || a.Size[1] != b.Size[1]) return false;
        for (int i = 0; i < a.Size[0]; i++)
            for (int j = 0; j < a.Size[1]; j++)
                if (a[i, j] != b[i, j]) return false;
        return true;
    }
    public static bool operator !=(in CMatrixInt a, in CMatrixInt b) => !(a == b);
    #endregion
}

/// <summary>
/// The class of a double type matrix
/// </summary>
public class CMatrixDouble : CMatrix<double>
{
    public CMatrixDouble(int m, int n) : base(m, n) { }
    public CMatrixDouble(int m) : base(m, m) { }
    public CMatrixDouble(double[,] mat) : base(mat) { }
    public CMatrixDouble(int[] size) : base(size[0], size[1]) { }

    /// <summary>
    /// The sum of all the elements of the matrix.
    /// </summary>
    public double Sum
    {
        get
        {
            double res = 0;
            for (int i = 0; i < this.Size[0]; i++)
                for (int j = 0; j < this.Size[1]; j++) res += this[i, j];
            return res;
        }
    }
    /// <summary>
    /// The value of the maximum element of the matrix.
    /// </summary>
    public double Max
    {
        get
        {
            double buf = double.MinValue;
            for (int i = 0; i < this.Size[0]; i++) for (int j = 0; j < this.Size[1]; j++)
                    if (buf < this[i, j]) buf = this[i, j];
            return buf;
        }
    }
    /// <summary>
    /// The value of the minimum element of the matrix.
    /// </summary>
    public double Min
    {
        get
        {
            double buf = double.MaxValue;
            for (int i = 0; i < this.Size[0]; i++) for (int j = 0; j < this.Size[1]; j++)
                    if (buf > this[i, j]) buf = this[i, j];
            return buf;
        }
    }
    /// <summary>
    /// Returns a row of the matrix by index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public double[] GetRow(int index)
    {
        if (index >= this.Size[0]) throw new ArgumentOutOfRangeException("index");
        double[] res = new double[this.Size[1]];
        for (int i = 0; i < this.Size[1]; i++)
            res[i] = this[index, i];
        return res;
    }
    /// <summary>
    /// Returns the column of the matrix by index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public double[] GetСolumn(int index)
    {
        if (index >= this.Size[1]) throw new ArgumentOutOfRangeException("index");
        double[] res = new double[this.Size[0]];
        for (int i = 0; i < this.Size[0]; i++)
            res[i] = this[i, index];
        return res;
    }

    public override CMatrixDouble GetTranspose() => CMatrix<double>.ConvertToCMatrixDouble(base.GetTranspose());
    public override CMatrixDouble Copy() => CMatrix<double>.ConvertToCMatrixDouble(base.Copy());
    public override CMatrixDouble Transpose() => CMatrix<double>.ConvertToCMatrixDouble(base.Transpose());

    #region operators
    // сложение, вычитание, инверсия
    public static CMatrixDouble operator +(in CMatrixDouble a, in CMatrixDouble b)
    {
        if (a.Size[0] != b.Size[0] || a.Size[1] != b.Size[1]) throw CMatrixException.CMatrixException_addition;
        CMatrixDouble resMatrix = new CMatrixDouble(a.Size);
        for (int i = 0; i < resMatrix.Size[0]; i++) for (int j = 0; j < resMatrix.Size[1]; j++) resMatrix[i, j] = a[i, j] + b[i, j];
        return resMatrix;
    }
    public static CMatrixDouble operator -(in CMatrixDouble a, in CMatrixDouble b)
    {
        if (a.Size[0] != b.Size[0] || a.Size[1] != b.Size[1]) throw CMatrixException.CMatrixException_addition;
        CMatrixDouble resMatrix = new CMatrixDouble(a.Size);
        for (int i = 0; i < resMatrix.Size[0]; i++) for (int j = 0; j < resMatrix.Size[1]; j++) resMatrix[i, j] = a[i, j] - b[i, j];
        return resMatrix;
    }
    public static CMatrixDouble operator -(in CMatrixDouble a) => a * -1;

    public static CMatrixDouble operator +(in CMatrixDouble a, in double b)
    {
        CMatrixDouble res = new CMatrixDouble(a.Size);
        for (int i = 0; i < a.Size[0]; i++) for (int j = 0; j < a.Size[1]; j++) res[i, j] = a[i, j] + b;
        return res;
    }
    public static CMatrixDouble operator -(in CMatrixDouble a, in double b) => a + -b;
    // умножение на число
    public static CMatrixDouble operator *(in CMatrixDouble a, in double b)
    {
        CMatrixDouble res = new CMatrixDouble(a.Size);
        for (int i = 0; i < a.Size[0]; i++) for (int j = 0; j < a.Size[1]; j++) res[i, j] = a[i, j] * b;
        return res;
    }
    public static CMatrixDouble operator *(in double b, in CMatrixDouble a) => a * b;
    // умножение на матрицу
    public static CMatrixDouble operator *(in CMatrixDouble a, in CMatrixDouble b)
    {
        if (a.Size[1] != b.Size[0]) throw CMatrixException.CMatrixException_multiplication;
        CMatrixDouble r = new CMatrixDouble(a.Size[0], b.Size[1]);
        for (int i = 0; i < a.Size[0]; i++)
            for (int j = 0; j < b.Size[1]; j++)
                for (int k = 0; k < b.Size[0]; k++)
                    r[i, j] += a[i, k] * b[k, j];

        return r;
    }
    // приведение от типа int
    public static explicit operator CMatrixDouble(CMatrixInt v)
    {
        CMatrixDouble res = new CMatrixDouble(v.Size);
        for (int i = 0; i < v.Size[0]; i++)
            for (int j = 0; j < v.Size[1]; j++)
                res[i, j] = (double)v[i, j];

        return res;
    }
    // сравнение
    public static bool operator ==(in CMatrixDouble a, in CMatrixDouble b)
    {
        if (a.Size[0] != b.Size[0] || a.Size[1] != b.Size[1]) return false;
        for (int i = 0; i < a.Size[0]; i++)
            for (int j = 0; j < a.Size[1]; j++)
                if (a[i, j] != b[i, j]) return false;
        return true;
    }
    public static bool operator !=(in CMatrixDouble a, in CMatrixDouble b) => !(a == b);
    #endregion

    #region operators CMatrixInt CMatrixDouble
    // умножение на матрицу типа int
    public static CMatrixDouble operator *(in CMatrixDouble a, in CMatrixInt b) => a * (CMatrixDouble)b;
    public static CMatrixDouble operator *(in CMatrixInt a, in CMatrixDouble b) => (CMatrixDouble)a * b;
    // сравнение с типом int
    public static bool operator ==(in CMatrixDouble a, in CMatrixInt b) => a == (CMatrixDouble)b;
    public static bool operator !=(in CMatrixDouble a, in CMatrixInt b) => !(a == (CMatrixDouble)b);
    public static bool operator ==(in CMatrixInt a, in CMatrixDouble b) => (CMatrixDouble)a == b;
    public static bool operator !=(in CMatrixInt a, in CMatrixDouble b) => !((CMatrixDouble)a == b);
    #endregion
}

public class CMatrixException : Exception
{
    internal static CMatrixException CMatrixException_multiplication = new CMatrixException("Matrix multiplication error!");
    internal static CMatrixException CMatrixException_addition = new CMatrixException("Matrix addition error!");

    protected CMatrixException(string message) : base(message) { }
}
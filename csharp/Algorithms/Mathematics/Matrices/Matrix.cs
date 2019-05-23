using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Matrices
{
    public class Matrix : IEquatable<Matrix>, IEnumerable
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Matrix() { }

        /// <summary>
        /// Construct the matrix from the given 2d array
        /// </summary>
        public Matrix(double[,] arr) => _backing = arr;

        public void Add(params double[] row)
        {
            if (row == null)
                throw new ArgumentException("Cant add null rows");

            if (_backing == null)
            {
                _backing = new double[1,row.Length];
                Buffer.BlockCopy(row,0,_backing,0,Buffer.ByteLength(row));
            }
            else
            {
                var tmp = _backing;
                _backing = new double[tmp.GetLength(0)+1,tmp.GetLength(1)];
                Buffer.BlockCopy(tmp,0,_backing,0,Buffer.ByteLength(tmp));
                Buffer.BlockCopy(row,0,_backing,Buffer.ByteLength(tmp),Buffer.ByteLength(row));
            }
        }

        public Matrix(double[] arr, bool isRow = true)
        {

            if (isRow)
            {
                _backing = new double[1, arr.Length];
                Buffer.BlockCopy(arr, 0, _backing, 0, Buffer.ByteLength(arr));
            }
            else
            {
                _backing = new double[arr.Length, 1];
                Buffer.BlockCopy(arr, 0, _backing, 0, Buffer.ByteLength(arr));
            }
        }

        /// <summary>
        /// The number of rows in this Matrix
        /// </summary>
        public int RowCount => _backing.GetLength(0);

        /// <summary>
        /// The number of columns in this Matrix
        /// </summary>
        public int ColCount => _backing.GetLength(1);

        /// <summary>
        /// A clone of this Matrix values. Maintain immutability
        /// </summary>
        public double[,] Values => (double[,]) _backing.Clone();

        /// <summary>
        /// Index into the Matrix
        /// </summary>

        public double this[int rowId, int colIdx] => _backing[rowId, colIdx];

        /// <summary>
        /// Compare to Matrices for value equality
        /// </summary>
        public bool Equals(Matrix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.RowCount != RowCount) return false;
            if (other.ColCount != ColCount) return false;

            return _backing.OfType<double>().SequenceEqual(other._backing.OfType<double>());
        }

        /// <summary>
        /// Create the transpose of this matrix
        /// </summary>
        public Matrix Transpose()
        {
            double[,] t = new double[ColCount,RowCount];
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    t[j, i] = _backing[i, j];
                }
            }

            return new Matrix(t);
        }

        /// <summary>
        /// Value equality
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is Matrix)) return false;
            return Equals((Matrix) obj);
        }

        // Hashcode
        public override int GetHashCode()
        {
            return (_backing != null ? _backing.GetHashCode() : 0);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return ToString(2);
        }

        /// <summary>
        /// Create String representation of this matrix
        /// </summary>
        /// <param name="padding">The padding around elements</param>
        /// <returns></returns>
        public string ToString(int padding)
        {
            var buffer = new StringBuilder();

            for (int rowIdxIndex = 0; rowIdxIndex < _backing.GetLength(0); rowIdxIndex++)
            {
                buffer.Append("| ");

                for (int colIndex = 0; colIndex < _backing.GetLength(1); colIndex++)
                    buffer.Append($" {_backing[rowIdxIndex, colIndex].ToString().PadLeft(padding)} ");

                buffer.Append(" |").AppendLine();
            }

            return buffer.ToString();
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a == null)
                throw new ArgumentException("Matrix A is null");

            if (b == null)
                throw new ArgumentException("Matrix B is null");

            if (a.ColCount != b.RowCount)
                throw new ArgumentException(
                    "Matrix multiplication requires that the number of columns in matrix a match the number of rows in matrix b");

            double[,] c = new double[a.RowCount, b.ColCount];

            for (int rowInA = 0; rowInA < a.RowCount; rowInA++)
            {
                for (int colInB = 0; colInB < b.ColCount; colInB++)
                {
                    double result = 0.0;
                    for (int i = 0; i < a.ColCount; i++)
                        result += a._backing[rowInA, i] * b._backing[i, colInB];

                    c[rowInA, colInB] = result;
                }
            }

            return new Matrix(c);
        }

        private double[,] _backing;
    }
}

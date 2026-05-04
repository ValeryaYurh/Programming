using System;

namespace LR7
{
    public class Matrix
    {
        private int[,] data;

        // Индексатор для доступа к элементам матрицы
        public int this[int row, int col]
        {
            get
            {
                if (row < 0 || row > 1 || col < 0 || col > 1)
                    throw new IndexOutOfRangeException("Индексы должны быть в диапазоне 0-1");
                return data[row, col];
            }
            set
            {
                if (row < 0 || row > 1 || col < 0 || col > 1)
                    throw new IndexOutOfRangeException("Индексы должны быть в диапазоне 0-1");
                data[row, col] = value;
            }
        }

        // Конструктор по умолчанию
        public Matrix()
        {
            data = new int[2, 2];
            Console.WriteLine("  Создана нулевая матрица");
        }

        // Конструктор с параметрами
        public Matrix(int a00, int a01, int a10, int a11)
        {
            data = new int[2, 2];
            data[0, 0] = a00;
            data[0, 1] = a01;
            data[1, 0] = a10;
            data[1, 1] = a11;
            Console.WriteLine($"  Создана матрица: [{a00}, {a01}, {a10}, {a11}]");
        }

        // Свойство для получения определителя
        public int Determinant
        {
            get { return data[0, 0] * data[1, 1] - data[0, 1] * data[1, 0]; }
        }

        // Перегрузка оператора +
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            return new Matrix(
                m1[0, 0] + m2[0, 0],
                m1[0, 1] + m2[0, 1],
                m1[1, 0] + m2[1, 0],
                m1[1, 1] + m2[1, 1]
            );
        }

        // Перегрузка оператора -
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            return new Matrix(
                m1[0, 0] - m2[0, 0],
                m1[0, 1] - m2[0, 1],
                m1[1, 0] - m2[1, 0],
                m1[1, 1] - m2[1, 1]
            );
        }

        // Перегрузка оператора ++
        public static Matrix operator ++(Matrix m)
        {
            if (m == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            m[0, 0]++;
            m[0, 1]++;
            m[1, 0]++;
            m[1, 1]++;
            return m;
        }

        // Перегрузка оператора --
        public static Matrix operator --(Matrix m)
        {
            if (m == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            m[0, 0]--;
            m[0, 1]--;
            m[1, 0]--;
            m[1, 1]--;
            return m;
        }

        // Перегрузка оператора * (умножение матриц)
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1 == null || m2 == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            return new Matrix(
                m1[0, 0] * m2[0, 0] + m1[0, 1] * m2[1, 0],
                m1[0, 0] * m2[0, 1] + m1[0, 1] * m2[1, 1],
                m1[1, 0] * m2[0, 0] + m1[1, 1] * m2[1, 0],
                m1[1, 0] * m2[0, 1] + m1[1, 1] * m2[1, 1]
            );
        }

        // Перегрузка оператора * (умножение на число)
        public static Matrix operator *(Matrix m, int number)
        {
            if (m == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            return new Matrix(
                m[0, 0] * number,
                m[0, 1] * number,
                m[1, 0] * number,
                m[1, 1] * number
            );
        }

        // Перегрузка оператора * (умножение числа на матрицу)
        public static Matrix operator *(int scalar, Matrix m)
        {
            return m * scalar;
        }

        // Перегрузка оператора / (деление на число)
        public static Matrix operator /(Matrix m, int scalar)
        {
            if (m == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            if (scalar == 0)
                throw new DivideByZeroException("Деление на ноль невозможно");
            
            return new Matrix(
                m[0, 0] / scalar,
                m[0, 1] / scalar,
                m[1, 0] / scalar,
                m[1, 1] / scalar
            );
        }

        // Перегрузка оператора ==
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (ReferenceEquals(m1, m2))
                return true;
            
            if (m1 is null || m2 is null)
                return false;
            
            return m1[0, 0] == m2[0, 0] &&
                   m1[0, 1] == m2[0, 1] &&
                   m1[1, 0] == m2[1, 0] &&
                   m1[1, 1] == m2[1, 1];
        }

        // Перегрузка оператора !=
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2);
        }

        // Перегрузка оператора true
        public static bool operator true(Matrix m)
        {
            if (m == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            return m.Determinant != 0;
        }

        // Перегрузка оператора false
        public static bool operator false(Matrix m)
        {
            if (m == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            return m.Determinant == 0;
        }

        // Явное преобразование матрицы в число (определитель)
        public static explicit operator int(Matrix m)
        {
            if (m == null)
                throw new ArgumentNullException("Матрица не может быть null");
            
            return m.Determinant;
        }

        // Явное преобразование числа в матрицу (a,0,0,a)
        public static explicit operator Matrix(int value)
        {
            return new Matrix(value, 0, 0, value);
        }

        // Переопределение ToString()
        public override string ToString()
        {
            return $"[{data[0, 0]}, {data[0, 1]}]\n[{data[1, 0]}, {data[1, 1]}]";
        }

        // Переопределение Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            Matrix other = (Matrix)obj;
            return this == other;
        }

        // Переопределение GetHashCode
        public override int GetHashCode()
        {
            return data[0, 0].GetHashCode() ^ data[0, 1].GetHashCode() ^
                   data[1, 0].GetHashCode() ^ data[1, 1].GetHashCode();
        }
    }
}
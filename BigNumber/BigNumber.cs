using System;
using System.Text.RegularExpressions;

namespace BigNumber
{
    public class BigNumber
    {
        private readonly byte[] _digits;
        private readonly Regex _regExpOnlyNumbers = new Regex(@"^[0-9]+$");

        public BigNumber(string x)
        {
            if (string.IsNullOrWhiteSpace(x))
            {
                throw new ArgumentNullException("Исходная строка является пустой!");
            }

            if (!_regExpOnlyNumbers.IsMatch(x))
            {
                throw new ArgumentException("В исходной строке содержатся нечисловые элементы!");
            }

            int offset = 0;

            for (var i = 0; i < x.Length; i++)
            {
                if ((byte)(x[i] - '0') != 0)
                    break;

                offset++;
            }

            if (x.Length - offset == 0)
            {
                _digits = new byte[] { 0 };
                return;
            }

            _digits = new byte[x.Length - offset];

            for (int i = _digits.Length - 1; i >= 0; i--)
            {
                _digits[_digits.Length - i - 1] = (byte)(x[i + offset] - '0');
            }

        }
        private BigNumber(byte[] x)
        {
            int offset = 0;

            for (var i = x.Length - 1; i >= 0; i--)
            {
                if (x[i] != 0)
                    break;

                offset++;
            }

            if (x.Length - offset == 0)
            {
                _digits = new byte[] { 0 };
                return;
            }

            _digits = new byte[x.Length - offset];

            for (var i = _digits.Length - 1; i >= 0; i--)
            {
                _digits[_digits.Length - 1 - i] = x[i];
            }

        }

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            var result = new byte[a._digits.Length + b._digits.Length];

            var carry = 0;

            for (var i = 0; i < a._digits.Length + b._digits.Length; i++)
            {
                var n1 = a[i];
                var n2 = b[i];

                var value = carry + n1 + n2;

                carry = value / 10;

                result[i] = (byte)(value % 10);

            }
            return new BigNumber(result);

        }

        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            var result = new byte[a._digits.Length + b._digits.Length];

            for (var j = 0; j < b._digits.Length; j++)
            {
                var carry = 0;
                var n2 = b._digits[j];

                for (var i = 0; i < a._digits.Length; i++)
                {
                    var n1 = a[i];

                    var multiply = n1 * n2 + result[i + j] + carry;
                    result[i + j] = (byte)(multiply % 10);
                    carry = multiply / 10;

                }

                result[a._digits.Length + j] += (byte)carry;
            }
            return new BigNumber(result);
        }

        public static BigNumber operator /(BigNumber a, BigNumber b)
        {
            throw new NotImplementedException();
        }

        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            throw new NotImplementedException();
        }

        private byte this[int index]
        {
            get
            {
                return index <= _digits.Length - 1 ? _digits[index] : (byte)0;
            }
        }

        public override string ToString()
        {
            return string.Concat(_digits);
        }
    }
}
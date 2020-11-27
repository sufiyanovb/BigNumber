using System;
using System.Text.RegularExpressions;

namespace BigNumber
{
    public class BigNumber
    {
        private readonly byte[] _digits;
        private readonly Regex _regExpOnlyNumbers = new Regex(@"^[0-9]+$");
        private const string _regExRemoveLeadingZeros = @"^0+(?=\d+$)";

        public BigNumber(string x)
        {
            if (string.IsNullOrWhiteSpace(x))
                throw new ArgumentNullException(nameof(x), "Исходная строка является пустой!");

            if (!_regExpOnlyNumbers.IsMatch(x))
                throw new ArgumentException("В исходной строке содержатся нечисловые элементы!", nameof(x));

            x = Regex.Replace(x, _regExRemoveLeadingZeros, "");//0000 превращается в 0

            var arraySize = x.Length;

            _digits = new byte[arraySize];

            arraySize -= 1;

            for (var i = arraySize; i >= 0; i--)
                _digits[arraySize - i] = (byte)(x[i] - '0');

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
                _digits[_digits.Length - 1 - i] = x[i];

        }
        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            var result = new byte[a._digits.Length + b._digits.Length];

            var carry = 0;

            for (var i = 0; i < a._digits.Length + b._digits.Length; i++)
            {
                var n1 = GetValue(a._digits, i);
                var n2 = GetValue(b._digits, i);

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
                var n2 = GetValue(b._digits, j);

                for (var i = 0; i < a._digits.Length; i++)
                {
                    var n1 = GetValue(a._digits, i);

                    var multiply = n1 * n2 + result[i + j] + carry;
                    result[i + j] = (byte)(multiply % 10);
                    carry = multiply / 10;

                }

                result[a._digits.Length + j] += (byte)carry;
            }
            return new BigNumber(result);
        }
        private static int GetValue(byte[] obj, int index)
        {
            return index <= obj.Length - 1
                             ? obj[index]
                             : 0;
        }
        public override string ToString()
        {
            return string.Concat(_digits);
        }
    }
}
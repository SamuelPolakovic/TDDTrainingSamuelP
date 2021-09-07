/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2021. All rights reserved
   ------------------------------------------------------------------------------------------------- */

#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.VisualBasic;
using static System.Int32;
using static System.String;

namespace TDDTraining
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            ChangeToLowestPossibleDenominator();
        }

        private void ChangeToLowestPossibleDenominator()
        {
            if(Numerator % Denominator == 0)
            {
                Numerator = Numerator / Denominator;
                Denominator = 1;
            }
            else
            {
                var divider = GreatestCommonDivisor(Math.Abs(Numerator), Math.Abs(Denominator));
                Denominator = (int)(Denominator / divider);
                Numerator = (int)(Numerator / divider);
            }
        }

        private static long GreatestCommonDivisor(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        public (int, int) FractionValues => (Numerator, Denominator);

        public Fraction(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public Fraction(string fraction)
        {
            var substrings = fraction.Split("/");
            if (substrings.Length == 1)
            {
                Numerator = Parse(substrings[0]);
                Denominator = 1;
            }
            else if (IsNullOrEmpty(substrings[0]))
            {
                Numerator = 0;
                Denominator = Parse(substrings[1]);
            }
            else if (substrings.Length > 2)
            {
                throw new InvalidDataException();
            }
            else
            {
                Numerator = Parse(substrings[0]);
                Denominator = Parse(substrings[1]);
            }

        }

        public static Fraction Add(Fraction fractionOne, Fraction fractionTwo)
        {
            var denominator = fractionOne.Denominator * fractionTwo.Denominator;
            var numeratorOne = fractionOne.Numerator * fractionTwo.Denominator;
            var numeratorTwo = fractionTwo.Numerator * fractionOne.Denominator;
            return new Fraction(numeratorOne + numeratorTwo, denominator);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Fraction fraction)
            {
                ChangeToLowestPossibleDenominator();
                fraction.ChangeToLowestPossibleDenominator();
                return FractionValues == fraction.FractionValues;
            }

            return false;
        }

        public override string ToString()
        {
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }

            return $"{Numerator}/{Denominator}";
        }

    }
}

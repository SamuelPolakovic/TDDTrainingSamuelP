/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2021. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.VisualBasic;

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
            if (Numerator == 1 || Numerator == 0)
            {
                return;
            }
            if (Denominator % Numerator == 0)
            {
                var divider = Numerator;
                Denominator = Denominator / divider;
                Numerator = Numerator / divider;
            }
            else if(Numerator % Denominator == 0)
            {
                Numerator = Numerator / Denominator;
                Denominator = 1;
            }
        }

        public Fraction(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public double Value { get; set; }

        public static Fraction Add(Fraction fractionOne, Fraction fractionTwo)
        {
            if (fractionOne.Denominator == fractionTwo.Denominator)
            {
                return new Fraction(fractionOne.Numerator + fractionTwo.Numerator,fractionOne.Denominator);
            }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }
            return base.ToString();
        }

    }
}

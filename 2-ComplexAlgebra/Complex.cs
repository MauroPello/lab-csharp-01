using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    public class Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public double Modulus => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        // per evitare il NaN che ci sarebbe usando Math.Atan(Imaginary / Real)
        public double Phase => Math.Atan2(Imaginary, Real);

        public override string ToString()
        {
            string real = this.Real == 0 ? "" : this.Real.ToString();
            string sign = this.Imaginary > 0 ? "+ i" : "- i";
            string imaginary = Math.Abs(this.Imaginary).ToString();

            if (this.Real != 0)
            {
                sign = this.Imaginary > 0 ? " + i" : " - i";
            }
            else
            {
                sign = this.Imaginary > 0 ? "i" : "-i";
            }

            if (Math.Abs(this.Imaginary) == 1 || this.Imaginary == 0)
            {
                imaginary = "";
                if (this.Imaginary == 0)
                {
                    sign = "";
                    if (this.Real == 0)
                    {
                        real = "0";
                    }
                }
            }

            return real + sign + imaginary;
        }

        protected bool Equals(Complex complex) => Real.Equals(complex.Real) && Imaginary.Equals(complex.Imaginary);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Complex)obj);
        }

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex complex) => new Complex(Real + complex.Real, Imaginary + complex.Imaginary);

        public Complex Minus(Complex complex) => new Complex(Real - complex.Real, Imaginary - complex.Imaginary);
    }
}
using laboratoriaProg.Controllers;
using Microsoft.VisualBasic.CompilerServices;

    public class Calculator
    {
        // Właściwości odpowiadające polom formularza
        public Operator2? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        // Operator jako symbol matematyczny do wyświetlenia w widoku
        public string OperatorSymbol
        {
            get
            {
                switch (Operator)
                {
                    case Operator2.Add:
                        return "+";
                    case Operator2.Sub:
                        return "-";
                    case Operator2.Mul:
                        return "*";
                    case Operator2.Div:
                        return "/";
                    default:
                        return "";
                }
            }
        }

        // Sprawdzanie, czy dane są poprawne
        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        // Metoda obliczająca wynik
        public double Calculate()
        {
            switch (Operator)
            {
                case Operator2.Add:
                    return (double)(X + Y);
                case Operator2.Sub:
                    return (double)(X - Y);
                case Operator2.Mul:
                    return (double)(X * Y);
                case Operator2.Div:
                    if (Y == 0)
                    {
                        throw new DivideByZeroException("Nie można dzielić przez zero.");
                    }
                    return (double)(X / Y);
                default:
                    throw new InvalidOperationException("Nieznany operator.");
            }
        }
    }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
   public enum Operation { Add, Div, Sub, Mul, plusandminus }

   public delegate void CalculatorDidUpdateOutput(Calculator sender, double value, int precision);

    public class Calculator
    {

        double? left = null;
        double? right = null;
        Operation? currentOp = null;
        bool decimalPoint = false;
        int precision = 0;

        public  event CalculatorDidUpdateOutput DidUpdateValue;
        public event EventHandler<string> InputError;
        public event EventHandler<string> CalculationError;

        public void AddDigit(int digit)
        {
                if (left.HasValue && left.Value > 99999999 || precision > 8)
                {
                    return;
                }
                if (precision > 8)
                {
                    InputError?.Invoke(this, "Input overflow");
                    return;
                }
                if (!decimalPoint)
                {
                    left = (left ?? 0) * 10 + digit;
                }
                else
                {
                    precision += 1;
                    left = Convert.ToInt32(left + (Math.Pow(0.1, precision) * digit));
                }
                DidUpdateValue?.Invoke(this, left.Value, precision);
          
        }

        public void AddDecimalPoint()
        {
            if (!left.HasValue)
            {
                left = right;
            }
            decimalPoint = true;
        }

        public void AddOperation(Operation op)
        {
            if (left.HasValue && currentOp.HasValue)
            {
                Compute();
            }
            if (!right.HasValue && !(op == Operation.plusandminus))
            {
                right = left;
                left = null;
                precision = 0;
                decimalPoint = false;
                DidUpdateValue.Invoke(this, right.Value, precision);
                currentOp = op;
            }
            if (left.HasValue  && op == Operation.plusandminus)
            {
                currentOp = op;
                ComputeUnar();
                currentOp = null;
            }

        }
        
        public void ComputeUnar()
        {
            switch (currentOp)
            {
                case Operation.plusandminus:
                    right = left*(-1);
                    break;
            }
            left = right;
            DidUpdateValue?.Invoke(this, right.Value, precision);
            right = null;
        }

        public void Compute()
        {
            switch (currentOp)
            {
                case Operation.Add:
                    right = left + right;
                    left = null;
                    break;

                case Operation.Sub:
                    right = right - left;
                    left = null;
                    break;

                case Operation.Mul:
                    right = left * right;
                    left = null;
                    break;

                case Operation.Div:
                    if (left == 0)
                    {
                        CalculationError?.Invoke(this, "«NOT ÷ 0»");
                        return;
                    }
                    
                    right = right / left;
                    int right1 = Convert.ToInt32(right);
                    double x = Convert.ToDouble(right - right1);
                    if (x > 0.4)
                    {
                        right = right1+ 1;
                    }
                    else { right = right1; }
                    left = null;
                    break;
            }

            if (right.HasValue && right.Value <= 999999999 || precision > 10)
            {
                DidUpdateValue?.Invoke(this, right.Value, precision);
                left = right;
                right = null;
                currentOp = null;
            }
            else
            {
                CalculationError?.Invoke(this, "EXCEEDED");
                right = left;
                left = 0;
                currentOp = null;
            }
        }

        public void Clear()
        {
            right = null;
            left = 0;
            DidUpdateValue?.Invoke(this, left.Value, precision);
        }
        public void ClearSimbol()
        {
            if (left.HasValue && left.Value <= 9999999999 || precision > 10)
            {
                left = left * (-1);
            }
            DidUpdateValue?.Invoke(this, left.Value, precision);
        }
    }
}
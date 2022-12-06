using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';

        // in order to set char to null
        private char? _operation = null;
        public Complex Value { get; set; }
        private Complex lastValue = null;

        public char? Operation
        {
            get => this._operation;
            set 
            {
                if(this.lastValue != null) 
                {
                    this.ComputeResult();
                }
                this._operation = value;
                this.lastValue = this.Value;
                this.Value = null;
            }
        }

        public void ComputeResult()
        {
            switch (_operation)
            {
                case OperationPlus:
                    this.Value = this.lastValue.Plus(Value);
                    break;
                case OperationMinus:
                    this.Value = this.lastValue.Minus(Value);
                    break;
                case null:
                default:
                    break;
            }
            _operation = null;
            this.lastValue = null;
        }

        public void Reset() 
        {
            this.lastValue = null;
            this._operation = null;
            this.Value = null;
        }

        public override string ToString() => $"Operation: {_operation}. Value: {Value}. LastValue: {lastValue}.";
    }
}
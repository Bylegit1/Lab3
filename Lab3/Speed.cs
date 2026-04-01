using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public enum MeasureType { mps, kph, kn, max }
    public class Speed
    {
        private double value;
        private MeasureType type;

        public Speed(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }

        public string Verbose()
        {
            var typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.mps:
                    typeVerbose = "м/с";
                    break;
                case MeasureType.kph:
                    typeVerbose = "км/ч";
                    break;
                case MeasureType.kn:
                    typeVerbose = "уз";
                    break;
                case MeasureType.max:
                    typeVerbose = "мах";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }

        public static Speed operator +(Speed instance, double number)
        {
            return new Speed(instance.value + number, instance.type);
        }

        public static Speed operator +(double number, Speed instance)
        {
            return instance + number;
        }

        public static Speed operator -(Speed instance, double number)
        {
            return new Speed(instance.value - number, instance.type);
        }

        public static Speed operator -(double number, Speed instance)
        {
            return new Speed(number - instance.value, instance.type);
        }

        public static Speed operator *(Speed instance, double number)
        {
            return new Speed(instance.value * number, instance.type);
        }

        public static Speed operator *(double number, Speed instance)
        {
            return instance * number;
        }

        public static bool operator ==(Speed left, Speed right)
        {
            var leftMps = left.To(MeasureType.mps).value;
            var rightMps = right.To(MeasureType.mps).value;
            var result = Math.Abs(leftMps - rightMps) < 0.00000001;
            return result;
        }

        public static bool operator !=(Speed left, Speed right)
        {
            return !(left == right);
        }

        public static bool operator >(Speed left, Speed right)
        {
            var leftMps = left.To(MeasureType.mps).value;
            var rightMps = right.To(MeasureType.mps).value;
            var result = leftMps > rightMps;
            return result;
        }

        public static bool operator <(Speed left, Speed right)
        {
            var leftMps = left.To(MeasureType.mps).value;
            var rightMps = right.To(MeasureType.mps).value;
            var result = leftMps < rightMps;
            return result;
        }

        public Speed To(MeasureType newType)
        {
            var newValue = this.value;
            if (this.type == MeasureType.mps)
            {
                switch (newType)
                {
                    case MeasureType.mps:
                        newValue = this.value;
                        break;
                    case MeasureType.kph:
                        newValue = this.value / 0.27;
                        break;
                    case MeasureType.kn:
                        newValue = this.value / 0.514;
                        break;
                    case MeasureType.max:
                        newValue = this.value / 331.46;
                        break;
                }
            }
            else if (newType == MeasureType.mps)
            {
                switch (this.type)
                {
                    case MeasureType.mps:
                        newValue = this.value;
                        break;
                    case MeasureType.kph:
                        newValue = this.value * 3.6;
                        break;
                    case MeasureType.kn:
                        newValue = this.value * 1.94384;
                        break;
                    case MeasureType.max:
                        newValue = this.value * 331.46;
                        break;
                }
            }
            else
            {
                newValue = this.To(MeasureType.mps).To(newType).value;
            }
            return new Speed(newValue, newType);
        }

        public static Speed operator+(Speed speed1, Speed speed2)
        {
            return speed1 + speed2.To(speed1.type).value;
        }

        public static Speed operator -(Speed speed1, Speed speed2)
        {
            return speed1 - speed2.To(speed1.type).value;
        }

        public static Speed operator *(Speed speed1, Speed speed2)
        {
            return speed1 * speed2.To(speed1.type).value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimChistka
{
        public class Flower
    {
        private string name;
        private Colour color;
        private float state;
        private float decayRateInWater;
        private float decayRateOutOfWater;
        private bool inWater;
        private int price;
        private string v1;
        private int v2;
        private int v;

        public Flower(string name = "Rostok", Colour color = Colour.Green, float state = 1.0f, float decayRateInWater = 0.1f, float decayRateOutOfWater = 0.6f, bool inWater = true, int price = 1000)
        {
            SetFlowerData(name, color, state, decayRateInWater, decayRateOutOfWater, inWater, price);
        }

        public Flower(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Flower(string v1, int v2, int v) : this(v1, v2)
        {
            this.v = v;
        }

        public string Name //название цветка
        {
            get { return name; }
            set { name = value; }
        }

        public Colour Color //цвет цветка
        {
            get { return color; }
            set { color = value; }
        }

        public float State //статус цветка 
        {
            get { return state; }
            set
            {
                if (value < 0.0f || value > 1.0f)
                    throw new ArgumentOutOfRangeException("Некорректное значение для состояния цветка.");
                state = value;
            }
        }

        public float DecayRateInWater //скорость увядания в воде
        {
            get { return decayRateInWater; }
            set
            {
                if (value < 0.0f || value > 0.5f)
                    throw new ArgumentOutOfRangeException("Некорректное значение для скорости увядания в воде.");
                decayRateInWater = value;
            }
        }

        public float DecayRateOutOfWater //скорость увядания без воды
        {
            get { return decayRateOutOfWater; }
            set
            {
                if (value < 0.0f || value > 1.0f)
                    throw new ArgumentOutOfRangeException("Некорректное значение для скорости увядания не в воде.");
                decayRateOutOfWater = value;
            }
        }

        public bool InWater //местонахождение цветка (в воде или нет)
        {
            get { return inWater; }
            set { inWater = value; }
        }

        public int Price //начальная цена цветка
        {
            get { return price; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Некорректное значение для стоимости цветка."); //исключение
                price = value;
            }
        }

        public float RealPrice //реальная цена цветка
        {
            get { return (Price * State) > 0 ? Price * State : 0; }
        }

        public void SkipTime(int hours) //пропуск времени 
        {
            if (hours < 0)
                throw new ArgumentOutOfRangeException("Отрицательное значение для hours."); //исключение 

            if (InWater)
                State -= State * DecayRateInWater * hours;
            else
                State -= State * DecayRateOutOfWater * hours;
        }

        public void UpdateState(float newState) //обновление статуса воды
        {
            if (newState < 0.0f || newState > 1.0f)
                throw new ArgumentOutOfRangeException("Некорректное значение для newState."); //исключение

            State = newState;
        }

        public void SetFlowerData(string name, Colour color, float state, float decayRateInWater, float decayRateOutOfWater, bool inWater, int price) //дает информацию о цветке
        {
            Name = name;
            Color = color;
            State = state;
            DecayRateInWater = decayRateInWater;
            DecayRateOutOfWater = decayRateOutOfWater;
            InWater = inWater;
            Price = price;
        }
    }

}

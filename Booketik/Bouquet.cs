using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimChistka
{
    public class Bouquet
    {
        private List<Flower> flowers;
        private bool inWater;

        public Bouquet()
        {
            flowers = new List<Flower>();
            inWater = false;
        }

        public List<Flower> Flowers
        {
            get { return flowers; }
        }

        public bool InWater
        {
            get { return inWater; }
            set { inWater = value; }
        }

        public void AddFlower(Flower flower) //добавление цветка в букет 
        {
            flowers.Add(flower);
        }

        public void RemoveFlower(int index) //удаление цветка из букета
        {
            if (index >= 0 && index < flowers.Count)
                flowers.RemoveAt(index);
        }

        public void PutInWater() //установка букета в воду
        {
            InWater = true;
        }

        public void RemoveFromWater() //удаление букета из воды
        {
            InWater = false;
        }

        public int BasePrice //начальная цена букета
        {
            get { return flowers.Sum(flower => flower.Price); }
        }

        public int RealPrice //настоящая цена букета
        {
            get { return flowers.Sum(flower => (int)(flower.RealPrice)); }
        }

        public string State //статус букета
        {
            get
            {
                foreach (var flower in flowers)
                {
                    if (flower.State <= 0)
                        return "Завял";
                }
                return "Свежий";
            }
        }

        public int FlowerCount //подсчет цветов в букете
        {
            get { return flowers.Count; }
        }

        public int WitheredFlowerCount  //подсчет высохших цветов в букете
        {
            get { return flowers.Count(flower => flower.State <= 0); }
        }

        public void ShiftFlowerClocks(float t) //пропуск времени 
        {
            foreach (var flower in flowers)
            {
                flower.SkipTime((int)t);
            }
        }
    }

}

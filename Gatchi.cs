using System;
namespace dojoGatchi
{
    public class Gatchi {
        Random rand = new Random();
        public int happiness{ get; set; }
        public int fullness{ get; set; }
        public int energy{ get; set; }
        public int meals{ get; set; }

        public Gatchi() {
            this.happiness = 20;
            this.fullness = 20;
            this.energy = 50;
            this.meals = 3;
        }

        public string Feed() {
            if (this.meals > 0) {
                this.meals--;
                int ranFull = rand.Next(5);
                this.fullness += ranFull;
                int amount = ranFull;
                return $"You're Gatchi liked that meal! You gained {amount} Fullness!";
            } else {
                return "You don't have any meals remaining";
            }
        }

        public string Play() {
            int r = rand.Next(4,11);
            int chance = rand.Next(100);
            this.energy -= 5;
            if (chance > 75) {
                return $"Your gatchi doesn't like playing at the moment:(";
            } else {
                this.happiness += r;
                return $"Your Gatchi gained {this.happiness} happiness!";
            }
        }

        public string Work() {
            this.energy -= 5;
            int r = rand.Next(0,4);
            this.meals += r;
            return $"Your Gatchi is now working but gained {this.meals} meal/meals!";
        }

        public string Sleep() {
            this.energy += 15;
            this.fullness -= 5;
            this.happiness -= 5;
            return $"Due to a good nap, you have gained {this.energy} energy!. However, both your fullness and happiness went down by 5:(";
        }

        public string WinOrLose() {
            if (this.energy > 100 && this.fullness > 100 && this.happiness > 100) {
                return "Conragtulations you have won!!!";
            }
            if (this.fullness <= 0 || this.happiness <= 0) {
                return "You have lost:(";
            }
            return "To win or to lose?";
        }
    }
}
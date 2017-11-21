using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmilyTimerUWP.Model
{
    public class Animation
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Animation(string animationName)
        {
            this.Name = animationName;
        }

    }

    public class AnimationFactory
    {
        public static void GetAnimations(ObservableCollection<Animation> Animations)
        {
            var allanimations = GetAllAnimations();
            Animations.Clear();
            allanimations.ForEach(a => Animations.Add(a));

        }

        public static List<Animation> GetAllAnimations()
        {
            var animations = new List<Animation>
            {
                new Animation("Candle"),
                new Animation("Turtle"),
                new Animation("AngryMan")
            };

            return animations;
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Objects.Items
{
    [Serializable]
    public abstract class BaseItem : IItemObservable
    {
        protected abstract int GoalPoints { get; set; }
        protected ItemObserver observer;
        protected double currentPoints;
        [NonSerialized] private Sprite sprite;

        public BaseItem()
        {
            currentPoints = 0;
            observer = ItemObserver.GetInstance();
            observer.AddObservable(this);
        }
        public double GetCurrentPoints()
        {
            return currentPoints;
        }

        public abstract string GetName();

        public int GetPointsToComplete()
        {
            return GoalPoints;
        }
        public abstract string[] GetSprites();
        public virtual void Increment(double points)
        {
            currentPoints += points;
            Text progressBar = GameObject.Find("Progress number").GetComponent<Text>();
            int percentage = (int)(currentPoints * 1f / GoalPoints * 100);
            if (percentage >= 100)
            {
                percentage = 100;
                ParticleSystem system = GameObject.Find("Screen").transform.Find("ItemEmittor").GetComponent<ParticleSystem>();
               
                if (sprite != null && sprite.name == SaveFile.GetInstance().CoreConfig.currentItem.GetUniversalSprite().Split('/')[2])
                {
                    system.textureSheetAnimation.SetSprite(0, sprite);
                }
                else
                {
                    RefreshCurrentSprite();
                    system.textureSheetAnimation.SetSprite(0, sprite);

                }
                system.Emit(1);
                observer.IsComplete(this);
            }
            S_Rendering.Instance.ChangeSprite(percentage);
            progressBar.text = percentage.ToString() + "%";
        }

        private void RefreshCurrentSprite()
        {
            sprite = Resources.Load<Sprite>(SaveFile.GetInstance().CoreConfig.currentItem.GetUniversalSprite());
        }

        public void Reset()
        {
            currentPoints -= GoalPoints;
        }
        public abstract string GetUniversalSprite();
    }
}

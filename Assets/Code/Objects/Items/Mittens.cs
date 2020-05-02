using Assets.Code.Objects.Items;
using System;


// Cannot inherit classes with no default constructor due to how these objects are instanciated in SaveManager.cs
[Serializable]
public class Mittens : BaseItem
{
    public string[] phases;


    protected override int GoalPoints { get; set; }

    public Mittens(ItemObserver observer)
    {
        this.observer = observer;

    }

    public Mittens() : base()
    {
        GoalPoints = 120;
    }

    public override string GetName()
    {
        return "Mittens";
    }

    public override string[] GetSprites()
    {
        if (phases == null)
        {
            phases = new string[6];
            for (int i = 0; i < phases.Length; i++)
            {
                phases[i] = $"Animations/MittenProgress/mitten{i + 1}";
            }
        }
        return phases;
    }

    public override string GetUniversalSprite()
    {
        return "Sprites/Mittens/Mittens_universal";
    }
}

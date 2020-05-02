using Assets.Code.Objects.Items;
using System;

// Cannot inherit classes with no default constructor due to how these objects are instanciated in SaveManager.cs
[Serializable]
public class Scarf : BaseItem
{
    public string[] phases;


    protected override int GoalPoints { get; set; }

    public Scarf(ItemObserver observer)
    {
        this.observer = observer;

    }

    public Scarf() : base()
    {
        GoalPoints = 40;
    }

    public override string GetName()
    {
        return "Scarf";
    }

    public override string[] GetSprites()
    {
        if (phases == null)
        {
            phases = new string[6];
            for (int i = 0; i < phases.Length; i++)
            {
                phases[i] = $"Animations/ScarfProgress/scarf{i + 1}";
            }
        }
        return phases;
    }

    public override string GetUniversalSprite()
    {
        return "Sprites/Scarf/scarf_universal";
    }
}

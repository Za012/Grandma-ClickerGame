using Assets.Code.Objects.Items;
using System;

// Cannot inherit classes with no default constructor due to how these objects are instanciated in SaveManager.cs
[Serializable]
public class Mask : BaseItem
{
    public string[] phases;


    protected override int GoalPoints { get; set; }

    public Mask(ItemObserver observer)
    {
        this.observer = observer;

    }

    public Mask() : base()
    {
        GoalPoints = 1000;
    }

    public override string GetName()
    {
        return "Mask";
    }

    public override string[] GetSprites()
    {
        if (phases == null)
        {
            phases = new string[6];
            for (int i = 0; i < phases.Length; i++)
            {
                phases[i] = $"Animations/MaskProgress/mask{i + 1}";
            }
        }
        return phases;
    }
    public override string GetUniversalSprite()
    {
        return "Sprites/Weird/Weird2_universal";
    }
}

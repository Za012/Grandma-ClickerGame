using Assets.Code.Objects.Items;
using System;

// Cannot inherit classes with no default constructor due to how these objects are instanciated in SaveManager.cs
[Serializable]
public class Socks : BaseItem
{
    public string[] phases;


    protected override int GoalPoints { get; set; }

    public Socks(ItemObserver observer)
    {
        this.observer = observer;

    }

    public Socks() : base()
    {
        GoalPoints = 200;
    }

    public override string GetName()
    {
        return "Socks";
    }

    public override string[] GetSprites()
    {
        if (phases == null)
        {
            phases = new string[6];
            for (int i = 0; i < phases.Length; i++)
            {
                phases[i] = $"Animations/SockProgress/sock{i + 1}";
            }
        }
        return phases;
    }
    public override string GetUniversalSprite()
    {
        return "Sprites/Socks/Socks_universal";
    }
}

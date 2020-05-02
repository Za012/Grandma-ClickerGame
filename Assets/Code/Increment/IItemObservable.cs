using UnityEngine;

public interface IItemObservable
{
    void Reset();
    void Increment(double points);
    int GetPointsToComplete();
    string GetName();
    double GetCurrentPoints();
    string[] GetSprites();
    string GetUniversalSprite();

}

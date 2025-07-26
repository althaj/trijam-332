using UnityEngine;

public class Huntress : Character
{
    public override void Hunt()
    {
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return;
        }

        resourceManager.ChangeFood(Random.Range(2, 3));

        CurrentActivity = Activity.Hunting;
    }
}

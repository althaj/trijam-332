public class Lumberjack : Character
{
    public override void CollectWood()
    {
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();
        if (resourceManager == null)
        {
            return;
        }

        resourceManager.ChangeResources(2);

        CurrentActivity = Activity.CollectingWood;
    }
}

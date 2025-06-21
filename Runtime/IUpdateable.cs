namespace Boomerang.Updateable
{
    public interface IUpdateable
    {
        void OnUpdate(float a_DeltaTime);
        bool CanUpdate { get; }
    }
}

namespace Boomerang.Updateable
{
    public interface ILateUpdateable
    {
        void OnLateUpdate();
        bool CanLateUpdate { get; }
    }
}

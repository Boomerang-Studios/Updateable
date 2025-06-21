namespace Boomerang.Updateable
{
    public interface IFixedUpdateable
    {
        void OnFixedUpdate();
        bool CanFixedUpdate { get; }
    }
}

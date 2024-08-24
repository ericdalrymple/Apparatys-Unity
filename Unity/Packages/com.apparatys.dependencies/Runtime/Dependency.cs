namespace Apparatys.Dependencies
{
    public struct Dependency<T>
        where T : IDependable
    {
        public T Value
        {
            get { return DependencyManager.GetDependable<T>(); }
        }

        public static implicit operator T(Dependency<T> dependency) => dependency.Value;
    }
}



namespace DomainSharedLib.ProtoType
{
    public static class EntityProtoType
    {
        public static T CopyProperties<T>(T source) where T : new()
        {
            T copy = new T();
            foreach (var prop in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                prop.SetValue(copy, prop.GetValue(source, null), null);
            }
            return copy;
        }
    }

}

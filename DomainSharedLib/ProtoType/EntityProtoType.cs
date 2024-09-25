using System.Collections;

namespace DomainSharedLib.ProtoType
{
    public static class EntityProtoType
    {
        public static T CopyProperties<T>(T source) where T : new()
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            T copy = new T();
            foreach (var prop in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                var value = prop.GetValue(source, null);

                if (value is IEnumerable<object> enumerable && !(value is string))
                {
                    // Criar uma nova lista para o IEnumerable, copiando os itens de forma profunda
                    var listType = typeof(List<>).MakeGenericType(prop.PropertyType.GetGenericArguments()[0]);
                    var copyList = (IList)Activator.CreateInstance(listType);

                    foreach (var item in enumerable)
                    {
                        // Fazer cópia profunda de cada item na lista
                        var deepCopyItem = CopyProperties(item);
                        copyList.Add(deepCopyItem);
                    }

                    prop.SetValue(copy, copyList, null);
                }
                else if (value != null && !value.GetType().IsValueType && value.GetType() != typeof(string))
                {
                    // Se a propriedade for um objeto complexo, realizar a cópia profunda recursivamente
                    var deepCopy = CopyProperties(value);
                    prop.SetValue(copy, deepCopy, null);
                }
                else
                {
                    // Para tipos de valor e strings, apenas copie diretamente
                    prop.SetValue(copy, value, null);
                }
            }
            return copy;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateSetting.Model
{
    public static class CloningUitility
    {
        public static T Clone<T>(T source)
        {
            Type sourceDataType = source.GetType();

            object clonedData = Activator.CreateInstance(sourceDataType);
            PropertyInfo[] propArray = sourceDataType.GetProperties();

            foreach (PropertyInfo prop in propArray)
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    object value = prop.GetValue(source, null);
                    prop.SetValue(clonedData, value, null);
                }
            }
            return (T)clonedData;
        }

        public static object Clone(object source)
        {
            Type sourceDataType = source.GetType();

            object clonedData = Activator.CreateInstance(sourceDataType);
            PropertyInfo[] propArray = sourceDataType.GetProperties();

            foreach (PropertyInfo prop in propArray)
            {
                if (prop.CanRead && prop.CanWrite)
                {
                    object value = prop.GetValue(source, null);
                    prop.SetValue(clonedData, value, null);
                }
            }
            return clonedData;
        }

        public static void CopyValues(object source, object destination)
        {
            CopyValues(source, destination, null);
        }

        public static void CopyValues(object source, object destination, params string[] exception)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            if (!sourceType.Equals(destinationType))
            {
                throw new Exception("Invalide data Type: Not same");
            }

            List<string> exceptProperties = new List<string>();
            if (exception != null && exception.Length > 0)
            {
                exceptProperties.AddRange(exception);
            }
            PropertyInfo[] propArray = source.GetType().GetProperties()
                .Where(prop => prop.CanRead && prop.CanWrite).ToArray();
            foreach (PropertyInfo prop in propArray)
            {
                if (!exceptProperties.Contains(prop.Name))
                {
                    object value = prop.GetValue(source, null);
                    prop.SetValue(destination, value, null);
                }
            }
        }

        /// <summary>
        /// Copy and convert data type of the same property name from source to destination 
        /// </summary>
        /// <param name="source">source object</param>
        /// <param name="dest">destination object</param>
        public static void CopyProperties(object source, object dest)
        {
            Type t1 = source.GetType();
            Type t2 = dest.GetType();

            PropertyInfo[] srouceProperties = t1.GetProperties().Where(x => x.CanRead).ToArray();
            PropertyInfo[] destProperties = t2.GetProperties().Where(x => x.CanWrite).ToArray();

            foreach (PropertyInfo sourceProp in srouceProperties)
            {
                //check exists
                if (destProperties.Any(x => x.Name == sourceProp.Name))
                {
                    //get first
                    PropertyInfo destProp = destProperties.First(x => x.Name == sourceProp.Name);

                    object val = sourceProp.GetValue(source, null);

                    //https://stackoverflow.com/questions/13270183/type-conversion-issue-when-setting-property-through-reflection
                    Type destPropType = destProp.PropertyType;

                    if (val != null && destPropType.IsGenericType &&
                        destPropType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        val = Convert.ChangeType(val, Nullable.GetUnderlyingType(destPropType));
                    }

                    destProp.SetValue(dest, val, null);
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi.Func
{
    public static class  Copy
    {
        public static void CopyTo(this object source, object target, Func<KeyValuePair<string, object>, object> fallback = null)
        {
            if (source == null || target == null)
            {
                return;
            }
            PropertyInfo[] properties = source.GetType().GetProperties();
            Type type = target.GetType();
            foreach (PropertyInfo info in properties)
            {
                PropertyInfo property = type.GetProperty(info.Name);
                if (property != null && property.CanWrite)
                {
                    try
                    {
                        if (property.PropertyType == info.PropertyType)
                        {
                            var obj2 = info.GetValue(source, null);
                            property.SetValue(target, obj2, null);
                        }
                        else if ((property.PropertyType.IsGenericType && (property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            && (Nullable.GetUnderlyingType(property.PropertyType) == info.PropertyType))
                        {
                            var obj2 = info.GetValue(source, null);
                            property.SetValue(target, obj2, null);
                        }
                        else if ((info.PropertyType.IsGenericType && (info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))) && (Nullable.GetUnderlyingType(info.PropertyType) == property.PropertyType))
                        {
                            var obj2 = info.GetValue(source, null);
                            if (obj2 != null)
                            {
                                property.SetValue(target, obj2, null);
                            }
                        }
                        else
                        {
                            var obj2 = info.GetValue(source, null);
                            if (fallback != null)
                            {
                                object obj3 = fallback(new KeyValuePair<string, object>(property.Name, obj2));
                                if (obj3 != null)
                                {
                                    property.SetValue(target, obj3, null);
                                }
                            }
                            else if (obj2 != null)
                            {
                                TypeConverter converter = TypeDescriptor.GetConverter(obj2);
                                if ((converter != null) && converter.CanConvertTo(property.PropertyType))
                                {
                                    object obj4 = converter.ConvertTo(obj2, property.PropertyType);
                                    property.SetValue(target, obj4, null);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                     
                    }
                }
            }
        }
        public static T Clone<T>(this object source,
           Func<KeyValuePair<string, object>, object> fallback = null) where T : class, new()
        {
            if (source == null)
            {
                return null;
            }
            T target = Activator.CreateInstance<T>();
            source.CopyTo(target, fallback);
            return target;
        }
        public static T CopyAs<T>(
    this object source,
    Expression<Func<T, object>> e = null,
    Func<KeyValuePair<string, object>, object> fallback = null
) where T : class, new()
    {
        if (e == null)
        {
            return Clone<T>(source, fallback);
        }
        var target = Activator.CreateInstance<T>();
        var fields = GetFields(e.Body).Split('+');
        var type = target.GetType();
        // thực hiện quá trình trích xuất dữ liệu
        var properties = source.GetType().GetProperties();
        foreach (var field in fields)
        {
            var sourceInfo = properties.First(x => x.Name == field);
            var targetInfo = type.GetProperty(field);
            if (sourceInfo != null && targetInfo != null && targetInfo.CanWrite)
            {
                object obj2;
                try
                {
                    obj2 = sourceInfo.GetValue(source, null);
                }
                catch (Exception)
                {
                    
                    continue;
                }
                if (targetInfo.PropertyType == sourceInfo.PropertyType)
                {
                    targetInfo.SetValue(target, obj2, null);
                }
                else if ((targetInfo.PropertyType.IsGenericType && (targetInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                    && (Nullable.GetUnderlyingType(targetInfo.PropertyType) == sourceInfo.PropertyType))
                {
                    targetInfo.SetValue(target, obj2, null);
                }
                else if ((sourceInfo.PropertyType.IsGenericType && (sourceInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))) && (Nullable.GetUnderlyingType(sourceInfo.PropertyType) == targetInfo.PropertyType))
                {
                    if (obj2 != null)
                    {
                        targetInfo.SetValue(target, obj2, null);
                    }
                }
                else
                {
                    try
                    {
                        if (fallback != null)
                        {
                            object obj3 = fallback(new KeyValuePair<string, object>(targetInfo.Name, obj2));
                            if (obj3 != null)
                            {
                                targetInfo.SetValue(target, obj3, null);
                            }
                        }
                        else if (obj2 != null)
                        {
                            TypeConverter converter = TypeDescriptor.GetConverter(obj2);
                            if ((converter != null) && converter.CanConvertTo(targetInfo.PropertyType))
                            {
                                object obj4 = converter.ConvertTo(obj2, targetInfo.PropertyType);
                                targetInfo.SetValue(target, obj4, null);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
        }
        return target;
    }

        public static string GetFields(Expression ex)
        {
            if (ex is MemberExpression)
            {
                return (ex as MemberExpression).Member.Name;
            }
            else if (ex is UnaryExpression)
            {
                return GetFields((ex as UnaryExpression).Operand);
            }
            else if (ex is BinaryExpression)
            {
                var right = GetFields((ex as BinaryExpression).Right);
                var left = GetFields((ex as BinaryExpression).Left);
                return right + '+' + left;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

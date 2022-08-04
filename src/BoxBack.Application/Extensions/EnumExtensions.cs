using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class EnumExtensions<T>
    where T : struct, Enum // This constraint requires C# 7.3 or later.
{
    public static IList<T> GetValues(Enum value)
    {
        var enumValues = new List<T>();

        foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            enumValues.Add((T)Enum.Parse(value.GetType(), fi.Name, false));
        }
        return enumValues;
    }
    public static IList<T> GetValues(List<string> values)
    {
        var enumValues = new List<T>();
        foreach (var value in values)
        {
            var tmp = (T)Enum.Parse(typeof(T), value, true);
            enumValues.Add(tmp);
        }
        return enumValues;
    }
    
    public static T Parse(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static IList<string> GetNamesByValue(Enum value)
    {
        return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
    }

    public static string GetNameByValue(Enum value)
    {
        return Enum.GetName(typeof(T), value);
    }

    public static IList<string> GetNames()
    {
        return Enum.GetNames(typeof(T)).ToList();
    }

    public static IList<string> GetNamesWithRemove(string valueForRemove)
    {
        var enums = Enum.GetNames(typeof(T)).ToList();
        
        foreach (var item in enums.ToList())
        {
            if (item.Equals(valueForRemove))
                enums.Remove(item);
        }

        return enums;
    }

    public static IList<string> GetDisplayValues()
    {
        return GetNames().Select(obj => GetDisplayValue(Parse(obj)).ToUpper()).ToList();
    }

    private static string lookupResource(Type resourceManagerProvider, string resourceKey)
    {
        var resourceKeyProperty = resourceManagerProvider.GetProperty(resourceKey,
            BindingFlags.Static | BindingFlags.Public, null, typeof(string),
            new Type[0], null);
        if (resourceKeyProperty != null)
        {
            return (string)resourceKeyProperty.GetMethod.Invoke(null, null);
        }

        return resourceKey; // Fallback with the key name
    }

    public static string GetDisplayValue(T value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        var descriptionAttributes = fieldInfo.GetCustomAttributes(
            typeof(DisplayAttribute), false) as DisplayAttribute[];

        if (descriptionAttributes[0].ResourceType != null)
            return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

        if (descriptionAttributes == null) return string.Empty;
        return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
    }

    public static int GetNumberByStringName(string name)
    {
        return (int)Enum.Parse(typeof(T), name);
    }

    public static List<int> GetNumbers(List<string> names)
    {
        var enumValues = new List<int>();
        foreach (var name in names)
        {
            var tmp = GetNumberByStringName(name);
            enumValues.Add(tmp);
        }
        return enumValues;
    }
}
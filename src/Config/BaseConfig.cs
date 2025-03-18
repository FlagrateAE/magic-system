using UnityEngine;
using System.Reflection;

public class BaseConfig : ScriptableObject
{
    private protected T GetValue<T>(string fieldName)
    {
        FieldInfo[] fields = GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(T) && field.Name.Contains(fieldName))
            {
                return (T)field.GetValue(this);
            }
        }

        Debug.LogError($"No field of type {typeof(T)} found containing name: {fieldName}");
        return default;
    }
}
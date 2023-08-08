using UnityEngine;

// How to keep variable type modularity without using unnecessary memory ? serialization ?
[CreateAssetMenu(menuName = "Variable_SO")]
public class VariableSO : ScriptableObject
{
    // To have a specific type is also usefull as a form of communication between code and logics.Typed PURPOSES.
    public enum valueType
    {
        BOOL,
        INT,
        FLOAT,
        DOUBLE,
        STRING
    }
    [SerializeField] private valueType type;

    // We need to be able to manipulate the value from outside the class .. object types can't use math for example
    // Maybe this is why we need strictly types variables, so code knows how to handle the type at compilation
    public object Value
    {
        get
        {
            return
                type == valueType.BOOL ? GetBool() :
                type == valueType.INT ? GetInt() :
                type == valueType.FLOAT ? GetFloat() :
                type == valueType.DOUBLE ? GetDouble() :
                type == valueType.STRING ? GetString() :
                null;
        }
        set
        {
            // We need to limit setting the new value accordingly to type
            jsonValue = JsonUtility.ToJson(value);
        }
    }
    private string jsonValue;

    //
    private bool GetBool()
    { return JsonUtility.FromJson<bool>(jsonValue); }
    private int GetInt()
    { return JsonUtility.FromJson<int>(jsonValue); }
    private float GetFloat()
    { return JsonUtility.FromJson<float>(jsonValue); }
    private double GetDouble()
    { return JsonUtility.FromJson<double>(jsonValue); }
    private string GetString()
    { return jsonValue; }
}

using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextListener<T> : VariableListener<T>
{
    private TextMeshProUGUI textField;

    protected override void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
        base.Awake();
    }

    protected override void OnVariableValueChange(T value)
    {
        base.OnVariableValueChange(value);
        UpdateText(value);
    }

    private void UpdateText(T value)
    {
        textField.text = $"{value}";
    }
}

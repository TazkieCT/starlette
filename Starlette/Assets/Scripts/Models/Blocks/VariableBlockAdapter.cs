using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;



public class VariableBlockAdapter : VariableBlock
{
    [SerializeField] private TMP_InputField variableNameText;
    [SerializeField] private TMP_Dropdown dropdown;
    public void TextFieldChanged()
    {
        string newText = variableNameText.text;
        // Validate the new text as a variable name
        if (IsValidVariableName(newText))
        {
            Debug.Log($"Valid variable name: {newText}");
            VariableName = newText;
        }
        else
        {
            // open error panel
            // For demonstration purposes, we will log a warning.
            Debug.LogWarning($"Invalid variable name: {newText}. Please use a valid C# identifier.");
        }
    }

    public void DropdownOptionChanged()
    {
        // Get the selected option's text from the dropdown
        string selectedType = dropdown.options[dropdown.value].text;
        DataType type;
        if (selectedType == "Integer")
        {
            type = DataType.CreateDataType<int>();
        }
        else if (selectedType == "Float")
        {
            type = DataType.CreateDataType<float>();
        }
        else if (selectedType == "Boolean")
        {
            type = DataType.CreateDataType<bool>();
        }
        else
        {
            Debug.LogError("No Valid Option");
            return;
        }
        Value.SetValue(type);
        Debug.Log($"Variable type changed to: {selectedType}");
    }



    private static readonly string[] ReservedKeywords =
    {
        "auto", "break", "case", "char", "const",
        "continue", "default", "do", "double", "else",
        "enum", "extern", "float", "for", "goto",
        "if", "inline", "int", "long", "register",
        "restrict", "return", "short", "signed", "sizeof",
        "static", "struct", "switch", "typedef", "union",
        "unsigned", "void", "volatile", "while", "_Alignas",
        "_Alignof", "_Atomic", "_Bool", "_Complex", "_Generic",
        "_Imaginary", "_Noreturn", "_Static_assert", "_Thread_local"
    };  

    public static bool IsValidVariableName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return false;

        // Check if it's a reserved keyword
        foreach (var keyword in ReservedKeywords)
        {
            if (name == keyword)
                return false;
        }

        // Regular expression to match valid C# variable names
        // ^[a-zA-Z_][a-zA-Z0-9_]*$
        return Regex.IsMatch(name, @"^[a-zA-Z_][a-zA-Z0-9_]*$");
    }
}
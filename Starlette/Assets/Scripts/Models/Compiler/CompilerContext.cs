using System;
using System.Collections.Generic;

public class CompilerContext
{
    private Dictionary<string, VariableBlock> Variables = new();

    public void AssignVariable(string name, VariableBlock value)
    {

        // validasi kalau ada variable dengan nama yang sama
        if (!Variables.ContainsKey(name))
        {
            // add new entries to variables
            Variables.Add(name, value);

        }
        // validasi tipe data yang di assign,
        if (Variables[name].GetDataType() != value.GetDataType())
        {
            throw new Exception($"Variable {name}: data type mismatch.");
        }


        Variables[name] = value;
    }


    public VariableBlock GetVariable(string name)
    {
        if (!Variables.ContainsKey(name))
        {
            throw new Exception($"Variable {name} not declared.");
        }
        return Variables[name];
    }
}

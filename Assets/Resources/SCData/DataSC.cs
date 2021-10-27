using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace ControlData
{
    public class DataSC
    {
        public void Create(string className, int countFields, List<string> nameFields, string[] typeFieldText, bool isMonobehaviourClass)
        {
            string classDefinition = String.Empty;
            string monobehaviourDefinition = isMonobehaviourClass ? " : MonoBehaviour" : "";

            classDefinition += "using System;" + Environment.NewLine;
            classDefinition += "using System.IO;" + Environment.NewLine;
            classDefinition += "using UnityEngine;" + Environment.NewLine;
        
            classDefinition += Environment.NewLine;
        
            classDefinition += "[System.Serializable]" + Environment.NewLine;
            classDefinition += "public class " + className + monobehaviourDefinition + Environment.NewLine;
            classDefinition += "{" + Environment.NewLine;
            
            classDefinition += "    private string _jsonData;" + Environment.NewLine;

            for (int i = 0; i < countFields; i++)
                classDefinition += "    public " + typeFieldText[i] + " "  + nameFields[i] + ";" + Environment.NewLine;

            classDefinition += Environment.NewLine;

            classDefinition += "    public void SaveData()" + Environment.NewLine;
            classDefinition += "    {";

            classDefinition += Environment.NewLine;

            classDefinition +=
                "        File.WriteAllText(Application.persistentDataPath + \"/\" + GetType().Name, JsonUtility.ToJson(this));" + Environment.NewLine;
            classDefinition += "    }";

            classDefinition += Environment.NewLine;
            classDefinition += Environment.NewLine;
        
            classDefinition += "    public void LoadData()" + Environment.NewLine;
            classDefinition += "    {" + Environment.NewLine;
            classDefinition += "        _jsonData = File.ReadAllText(Application.persistentDataPath + \"/\" + GetType().Name);" + Environment.NewLine;
            classDefinition += "        JsonUtility.FromJsonOverwrite(_jsonData, this);" + Environment.NewLine;
            classDefinition += "    }" + Environment.NewLine;
            
            classDefinition += "}";
            File.WriteAllText("Assets/Resources/" + className + ".cs", classDefinition);

            EditorUtility.RevealInFinder("Assets/Resources");
        }
    }
}

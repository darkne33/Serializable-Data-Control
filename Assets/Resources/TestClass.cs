using System;
using System.IO;
using UnityEngine;

[System.Serializable]
public class TestClass
{
    private string _jsonData;
    public int NameField_1;
    public float NameField_2;
    public Vector3 NameField_3;
    public Quaternion NameField_4;

    public void SaveData()
    {
        File.WriteAllText(Application.persistentDataPath + "/" + GetType().Name, JsonUtility.ToJson(this));
    }

    public void LoadData()
    {
        _jsonData = File.ReadAllText(Application.persistentDataPath + "/" + GetType().Name);
        JsonUtility.FromJsonOverwrite(_jsonData, this);
    }
}
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ControlData
{
    public class ControlWindow : EditorWindow
    {
        private DataSC _dataSC;

        private bool _isMonobehaviourClass;
        private string _className;
        private int _countFields;

        private readonly List<string> _nameFields = new List<string>();
        
        private int[] _typeFields = new int[99];
        private string[] _typeFieldsText = new string[99];
        
        private int _selectedField;
        private string[] _typeFieldOptions = {"int", "float", "string", "Vector3", "Quaternion", "Vector2"};


        public ControlWindow()
        {
            _dataSC = new DataSC();
        }

        [MenuItem("Serializable Data/Create Data")]
        private static void Initialize() 
            => GetWindow(typeof(ControlWindow), true, "Create Data");


        private void OnGUI()
        {
            _isMonobehaviourClass = EditorGUILayout.Toggle("Monobehaviour class", _isMonobehaviourClass);
            
            
            InitClassName();
            
            InitFields();

            ResetFieldsButton();
            CreateSCButton();
        }
        
        
        private void InitClassName()
            =>_className = EditorGUILayout.TextField("SC name", _className);


        private void InitFields()
        {
            GUILabelFields();
            
            _countFields = EditorGUILayout.IntField("Count fields in data", _countFields);
            
            for (int i = 0; i < _countFields; i++)
            {
                _nameFields.Add("NameField");
                _nameFields[i] = EditorGUILayout.TextField("Name field", _nameFields[i]);
                _typeFields[i] = EditorGUILayout.Popup("TypeField", _typeFields[i], _typeFieldOptions);
                switch (_typeFields[i])
                {
                    case 0:
                        _typeFieldsText[i] = "int";
                        break;
                    case 1:
                        _typeFieldsText[i] = "float";
                        break;
                    case 2:
                        _typeFieldsText[i] = "string";
                        break;
                    case 3:
                        _typeFieldsText[i] = "Vector3";
                        break;
                    case 4:
                        _typeFieldsText[i] = "Quaternion";
                        break;
                    case 5:
                        _typeFieldsText[i] = "Vector2";
                        break;
                }
            }
        }
        

        private void GUILabelFields()
        {
            GUIStyle guiStyle = new GUIStyle();
            guiStyle.alignment = TextAnchor.MiddleCenter;
            guiStyle.normal.textColor = Color.white;
            EditorGUILayout.LabelField("Fields",guiStyle);
        }
        

        private void ResetFieldsButton()
        {
            if (GUILayout.Button("Reset fields"))
                _nameFields.Clear();
        }

        private void CreateSCButton()
        {
            if (GUILayout.Button("Create SC script"))
                _dataSC.Create(_className, _countFields, _nameFields, _typeFieldsText, _isMonobehaviourClass);
        }
    }
}

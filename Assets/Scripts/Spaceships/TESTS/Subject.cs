using UnityEngine;
using System.Collections;
using UnityEditor;

namespace std
{
    [System.Serializable]
    public class Subject : MonoBehaviour
    {
        [SerializeField]
        public bool b = true;
        [SerializeField]
        public string str = "work";      
    }

    [CustomEditor(typeof(Subject))]
    public class SubjectEditor : Editor
    {
        SerializedProperty SerializedProperty_str;
        SerializedProperty SerializedProperty_b;
        Subject s;
        public override void OnInspectorGUI()
        {            
          
                serializedObject.Update();
               
            EditorGUILayout.PropertyField(SerializedProperty_b);
            if (s.b)
            EditorGUILayout.PropertyField(SerializedProperty_str);

            serializedObject.ApplyModifiedProperties();
       

        }
        public void OnEnable()
        {
            SerializedProperty_str =  serializedObject.FindProperty("str");
            SerializedProperty_b = serializedObject.FindProperty("b");
            s = target as Subject;
        }
    }
}
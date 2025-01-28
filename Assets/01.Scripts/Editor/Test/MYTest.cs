using BGD.Tests;
using UnityEditor;
using UnityEngine;

namespace BGD.CustomEditors
{
    [CustomEditor(typeof(Test))]
    public class MyScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // ��ũ��Ʈ ����
            Test myScript = (Test)target;

            // �⺻ �ʵ� ǥ��
            myScript.basicInfo = EditorGUILayout.TextField("Basic Info", myScript.basicInfo);

            // ���� üũ�ڽ� ǥ��
            myScript.showDetails = EditorGUILayout.Toggle("Show Details", myScript.showDetails);

            // ���ǿ� ���� �ʵ� ǥ��
            if (myScript.showDetails)
            {
                myScript.detailedInfo = EditorGUILayout.TextField("Detailed Info", myScript.detailedInfo);
            }

            // ���� ����Ǿ��� ��� ����
            if (GUI.changed)
            {
                EditorUtility.SetDirty(myScript);
            }
        }
    }
}

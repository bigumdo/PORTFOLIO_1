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
            // 스크립트 참조
            Test myScript = (Test)target;

            // 기본 필드 표시
            myScript.basicInfo = EditorGUILayout.TextField("Basic Info", myScript.basicInfo);

            // 조건 체크박스 표시
            myScript.showDetails = EditorGUILayout.Toggle("Show Details", myScript.showDetails);

            // 조건에 따라 필드 표시
            if (myScript.showDetails)
            {
                myScript.detailedInfo = EditorGUILayout.TextField("Detailed Info", myScript.detailedInfo);
            }

            // 값이 변경되었을 경우 저장
            if (GUI.changed)
            {
                EditorUtility.SetDirty(myScript);
            }
        }
    }
}

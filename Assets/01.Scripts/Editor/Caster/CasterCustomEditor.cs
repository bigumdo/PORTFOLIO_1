using BGD.Combat;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

namespace BGD.CustomEditors
{
    //추상클래스 BaseCaster를 CustomEditor로 제작
    //true를 적용하여 자식 클래스도 CustomEditor 적용
    [CustomEditor(typeof(BaseCaster),true)]
    public class CasterCustomEditor : Editor
    {
        private void OnEnable()
        {
            
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update(); // 변경 감지 시작

            //base.OnInspectorGUI();
            EditorGUILayout.TextField("Setting", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            //모든 직렬화된 변수를 가르킴
            SerializedProperty iterator = serializedObject.GetIterator();

            //iterator가 가르키는 직렬화된 변수를 Inspecter에 표시함
            //true를 추가하여 자식 오브젝트에 포함해서 자동으로 표시
            EditorGUILayout.PropertyField(iterator, true);
            serializedObject.ApplyModifiedProperties();
        }
    }
}

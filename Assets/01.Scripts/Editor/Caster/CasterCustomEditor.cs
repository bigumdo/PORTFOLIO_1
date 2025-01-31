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
            BaseCaster myTarget = (BaseCaster)target;
            //현재 값 가져오기
            serializedObject.Update(); // 변경 감지 시작

            //base.OnInspectorGUI();
            EditorGUILayout.TextField("Setting", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            //모든 직렬화된 변수를 가르킴
            SerializedProperty iterator = serializedObject.GetIterator();
            bool enterChildren = true;
            //inspector에 표시할 수 있는 다음 속성으로 이동하는 함수
            while (iterator.NextVisible(enterChildren))
            {
                //해당 클래스의 변수를 표시 true일 경우 변수의 자식 값도 표시
                //iterator가 가르키는 직렬화된 변수를 Inspecter에 표시함
                //true를 추가하여 자식 오브젝트에 포함해서 자동으로 표시
                if(iterator.name != "castRange" && iterator.name != "castSize")
                    EditorGUILayout.PropertyField(iterator, true);

                if (myTarget.castMethodType == CastMethodType.Circle && iterator.name == "castRange")
                {
                    SerializedProperty castRangeProp = serializedObject.FindProperty("castRange");
                    EditorGUILayout.PropertyField(castRangeProp);
                }
                else if(myTarget.castMethodType == CastMethodType.Box && iterator.name == "castSize")
                {
                    SerializedProperty castRangeProp = serializedObject.FindProperty("castSize");
                    EditorGUILayout.PropertyField(castRangeProp);
                }

                enterChildren = false;
            }

            //변경된 값 반영(Undo/Redo)지원
            serializedObject.ApplyModifiedProperties();
        }
    }
}

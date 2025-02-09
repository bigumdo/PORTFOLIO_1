using BGD.Casters;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UIElements;

namespace BGD.CustomEditors
{
    //�߻�Ŭ���� BaseCaster�� CustomEditor�� ����
    //true�� �����Ͽ� �ڽ� Ŭ������ CustomEditor ����
    [CustomEditor(typeof(BaseCaster),true)]
    public class CasterCustomEditor : Editor
    {
        private void OnEnable()
        {
            
        }

        public override void OnInspectorGUI()
        {
            BaseCaster myTarget = (BaseCaster)target;
            //���� �� ��������
            serializedObject.Update(); // ���� ���� ����

            //base.OnInspectorGUI();
            EditorGUILayout.TextField("DefaultSetting", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            //��� ����ȭ�� ������ ����Ŵ
            SerializedProperty iterator = serializedObject.GetIterator();
            bool enterChildren = true;
            //inspector�� ǥ���� �� �ִ� ���� �Ӽ����� �̵��ϴ� �Լ�
            while (iterator.NextVisible(enterChildren))
            {
                //�ش� Ŭ������ ������ ǥ�� true�� ��� ������ �ڽ� ���� ǥ��
                //iterator�� ����Ű�� ����ȭ�� ������ Inspecter�� ǥ����
                //true�� �߰��Ͽ� �ڽ� ������Ʈ�� �����ؼ� �ڵ����� ǥ��
                if(iterator.name != "castRange" && iterator.name != "castSize" && iterator.name != "rayDirection"
                    && iterator.name != "rayDistance")
                    EditorGUILayout.PropertyField(iterator, true);


                if (myTarget.castMethodType == CastMethodType.Circle && iterator.name == "castRange")
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.TextField("CastSetting", EditorStyles.boldLabel);
                    SerializedProperty castRangeProp = serializedObject.FindProperty("castRange");
                    EditorGUILayout.PropertyField(castRangeProp);
                    EditorGUILayout.Space();
                }
                else if(myTarget.castMethodType == CastMethodType.Box && iterator.name == "castSize")
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.TextField("CastSetting", EditorStyles.boldLabel);
                    SerializedProperty castSizeProp = serializedObject.FindProperty("castSize");
                    EditorGUILayout.PropertyField(castSizeProp);
                    EditorGUILayout.Space();
                }
                else if (myTarget.castMethodType == CastMethodType.Ray && iterator.name == "rayDirection")
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.TextField("CastSetting", EditorStyles.boldLabel);
                    SerializedProperty rayDirectionProp = serializedObject.FindProperty("rayDirection");
                    EditorGUILayout.PropertyField(rayDirectionProp);

                    SerializedProperty rayDistanceProp = serializedObject.FindProperty("rayDistance");
                    EditorGUILayout.PropertyField(rayDistanceProp);
                    EditorGUILayout.Space();
                }

                enterChildren = false;
            }
            //����� �� �ݿ�(Undo/Redo)����
            serializedObject.ApplyModifiedProperties();
        }
    }
}

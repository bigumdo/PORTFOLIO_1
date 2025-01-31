using BGD.Combat;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

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
            EditorGUILayout.TextField("Setting", EditorStyles.boldLabel);
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

            //����� �� �ݿ�(Undo/Redo)����
            serializedObject.ApplyModifiedProperties();
        }
    }
}

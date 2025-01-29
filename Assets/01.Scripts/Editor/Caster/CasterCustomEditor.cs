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
            serializedObject.Update(); // ���� ���� ����

            //base.OnInspectorGUI();
            EditorGUILayout.TextField("Setting", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            //��� ����ȭ�� ������ ����Ŵ
            SerializedProperty iterator = serializedObject.GetIterator();

            //iterator�� ����Ű�� ����ȭ�� ������ Inspecter�� ǥ����
            //true�� �߰��Ͽ� �ڽ� ������Ʈ�� �����ؼ� �ڵ����� ǥ��
            EditorGUILayout.PropertyField(iterator, true);
            serializedObject.ApplyModifiedProperties();
        }
    }
}

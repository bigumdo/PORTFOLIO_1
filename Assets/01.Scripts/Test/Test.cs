using UnityEngine;

namespace BGD.Tests
{
    public abstract class TestAbstract : MonoBehaviour
    {
        public bool showDetails; // ������ �Ǵ� ����
        public string basicInfo; // �׻� ǥ��
        public string detailedInfo; // ���ǿ� ���� ǥ��
    }

    public class Test : TestAbstract
    {
        public bool test;

        [ContextMenu("TestMethod")]
        public void TestMethod()
        {
            Debug.Log(showDetails);
            Debug.Log(basicInfo);
            Debug.Log(detailedInfo);
        }
    }
}

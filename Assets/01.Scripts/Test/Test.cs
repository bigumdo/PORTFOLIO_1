using System;
using UnityEngine;

namespace BGD.Tests
{
    [Serializable]
    public struct TestDataClass
    {
        public int test1;
        public int test2;
        public int test3;
    }


    public abstract class TestAbstract : MonoBehaviour
    {
        public bool showDetails; // ������ �Ǵ� ����
        public string basicInfo; // �׻� ǥ��
        public Transform detailedInfo; // ���ǿ� ���� ǥ��
    }

    public class Test : TestAbstract
    {
        public TestDataClass test;

        [ContextMenu("TestMethod")]
        public void TestMethod()
        {
            Debug.Log(showDetails);
            Debug.Log(basicInfo);
            Debug.Log(detailedInfo);
        }
    }
}

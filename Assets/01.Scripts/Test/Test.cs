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
        public bool showDetails; // 조건이 되는 변수
        public string basicInfo; // 항상 표시
        public Transform detailedInfo; // 조건에 따라 표시
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

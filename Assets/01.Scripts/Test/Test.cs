using UnityEngine;

namespace BGD.Tests
{
    public abstract class TestAbstract : MonoBehaviour
    {
        public bool showDetails; // 조건이 되는 변수
        public string basicInfo; // 항상 표시
        public string detailedInfo; // 조건에 따라 표시
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

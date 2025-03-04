using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace BGD.UIs
{
    public class InventoryUI : MonoBehaviour
    {
        private UIDocument _uiDocument;
        private VisualElement _root, _menu;
        private Button _menuBotton;

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;
            _menuBotton = _root.Q<Button>("Button");
            _menu = _root.Q("Menu");


            _menuBotton.clicked += HandleOpenBtnClick;
        }

        private void HandleOpenBtnClick()
        {
            _menu.ToggleInClassList("on");
        }
    }
}

using Mirror;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Wizzard
{
    public class TeacherController : NetworkManager
    {
        private int _currentSheet;
        private static TeacherController _instance;

        [SerializeField] private TMP_Dropdown[] dropdownElements;
        [SerializeField] private TMP_Dropdown sheetSelection;
        [SerializeField] private GameObject sheet1, sheet2, sheet3;

        void Awake()
        {
            TeacherController._instance = this;
            base.Awake();
        }

        /// <summary>
        /// assigning dropdown events to functions
        /// </summary>
        void Start()
        {
            _currentSheet = 1;
            sheet1.SetActive(true);
            sheet2.SetActive(false);
            sheet3.SetActive(false);
            sheetSelection.onValueChanged.AddListener(delegate { SheetDropdownItemSelected(sheetSelection); });
            foreach(TMP_Dropdown valueDropdown in dropdownElements)
                valueDropdown.onValueChanged.AddListener(delegate { SendNotification(); });

        }

        /// <summary>
        /// activates the selected sheetelement
        /// </summary>
        /// <param name="sheetSelection"></param>
        private void SheetDropdownItemSelected(TMP_Dropdown sheetSelection)
        {
            int _value = sheetSelection.value;
            switch (_value)
            {
                case 0:
                    sheet1.SetActive(true);
                    sheet2.SetActive(false);
                    sheet3.SetActive(false);
                    _currentSheet = 1;
                    break;
                case 1:
                    sheet1.SetActive(false);
                    sheet2.SetActive(true);
                    sheet3.SetActive(false);
                    _currentSheet = 2;
                    break;
                default:
                    sheet1.SetActive(false);
                    sheet2.SetActive(false);
                    sheet3.SetActive(true);
                    _currentSheet = 3;
                    break;
            }
        }

        /// <summary>
        /// creates a new solutionpackage and sends it to the netowrkmanager
        /// </summary>
        private void SendNotification()
        {
            int[] _newSolutions = new int[dropdownElements.Length];
            for (int i = 0; i < dropdownElements.Length; i++)
                _newSolutions[i] = dropdownElements[i].value;

            NetworkServer.SendToReady(new Notification {sheet = _currentSheet, solutions = _newSolutions });
        }

        /// <summary>
        /// get the instance of active teachercontroller
        /// </summary>
        /// <returns></returns>
        public TeacherController GetInstance()
        {
            return _instance;
        }

    }
}

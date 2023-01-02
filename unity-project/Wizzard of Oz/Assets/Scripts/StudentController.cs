using UnityEngine;
using UnityEngine.UI;


namespace Wizzard
{

    public class StudentController : MonoBehaviour
    {
        private static StudentController _instance;
        private Color _default, _right, _wrong;

        [SerializeField] private GameObject[] imageTargets;

        private void Awake()
        {
            StudentController._instance = this;
            _right = new Color(0f, 255f, 0f, 0.30f);        //green
            _wrong = new Color(255f, 0f, 0f, 0.30f);        //red
            _default = new Color(255f, 255f, 255f, 1.0f);   //grey
        }

        /// <summary>
        /// displays the solutions of the given sheet onto the UI canvas
        /// </summary>
        /// <param name="results"></param>
        public void DisplayResults(Notification notification)
        {
            //err handling
            if(notification.sheet < 1 
               || notification.sheet > 3
               || notification.solutions.Length < 1) { return; };


            //iterate over fields and change color codes
            Image[] fields = imageTargets[notification.sheet-1].GetComponentsInChildren<Image>();
            for (int i = 0; i < fields.Length; i++)
            {
                switch (notification.solutions[i])
                {
                    case 0:
                        fields[i].color = _default;
                        break;
                    case 1:
                        fields[i].color = _right;
                        break;
                    case 2:
                        fields[i].color = _wrong;
                        break;
                    default:
                        Debug.LogError("Wrong fieldvalue");
                        break;
                }
            }
        }

        /// <summary>
        /// get the instance of active studentcontroller
        /// </summary>
        /// <returns></returns>
        public static StudentController GetInstance()
        {
            return StudentController._instance;
        }
    }
}

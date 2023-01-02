using UnityEngine;
using Mirror;
using System;
using System.Collections;

namespace Wizzard
{
    /// <summary>
    /// network reciever for the student
    /// </summary>
    public partial class StudentNetworkReciever : NetworkManager
    {
        private void Start()
        {
            StartCoroutine(WaitForNetworkConnection());
        }

        /// <summary>
        /// awaiting network connection to register notification-handler
        /// </summary>
        IEnumerator WaitForNetworkConnection()
        {
            while (!NetworkClient.active)
                yield return new WaitForEndOfFrame();

            NetworkClient.RegisterHandler<Notification>(OnNotification);
        }

        /// <summary>
        /// passes the notification-object to the studentcontroller
        /// </summary>
        /// <param name="obj"></param>
        private void OnNotification(Notification obj)
        {
            StudentController.GetInstance().DisplayResults(obj);
        }
    }
}


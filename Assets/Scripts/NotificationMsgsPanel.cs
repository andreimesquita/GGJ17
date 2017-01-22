using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class NotificationMsgsPanel : MonoBehaviour
{
    public Text Message;

    public void ShowMessage(string msg)
    {
        Message.text = msg;
        this.gameObject.SetActive(true);

        DOVirtual.DelayedCall(3f, HideMessage);
    }

    private void HideMessage()
    {
        this.gameObject.SetActive(false); 
    }
}

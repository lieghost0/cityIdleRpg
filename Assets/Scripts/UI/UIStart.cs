using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    public GameObject gamePanel;
    public void OnClickContinue()
    {

    }
    public void OnClickNewGame()
    {
        this.gameObject.SetActive(false);
        this.gamePanel.SetActive(true);
    }
    public void OnClickLoad()
    {

    }
    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}

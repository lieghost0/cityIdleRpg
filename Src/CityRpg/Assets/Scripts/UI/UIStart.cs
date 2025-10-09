using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers;
using Entities;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    public UIMainGame uiMainGame;

    private void Start()
    {
        
    }
    public void OnClickContinue()
    {

    }
    public void OnClickNewGame()
    {
        InputBox.Show("起一个名字", "请输入您的姓名").OnSubmit += OnNameSubmit;
    }

    private bool OnNameSubmit(string input, out string tips)
    {
        tips = "";
        if (string.IsNullOrEmpty(input))
        {
            tips = "姓名不能为空";
            return false;
        }
        Player player = new Player(1, input, 1, 10, new List<BagItem>());
        User.Instance.currentPlayer = player;

        this.gameObject.SetActive(false);
        this.uiMainGame.GameEnter();
        this.uiMainGame.gameObject.SetActive(true);
        return true;
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

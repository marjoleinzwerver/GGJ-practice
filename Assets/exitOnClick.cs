using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitOnClick : MonoBehaviour
{
    public void ExitGame()
    {
        print("Exit");
        Application.Quit();
    }
}

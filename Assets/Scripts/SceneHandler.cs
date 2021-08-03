using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void setScene1()
    {
        SceneManager.LoadScene("shopTab1");
    }
    public void setScene2()
    {
        SceneManager.LoadScene("shopTab2");
    }
    public void setScene3()
    {
        SceneManager.LoadScene("shopTab3");
    }
    public void setScene4()
    {
        SceneManager.LoadScene("shopTab4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

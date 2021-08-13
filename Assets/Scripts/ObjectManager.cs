using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // singleton
    private static ObjectManager m_Instance = null;
    public static ObjectManager Get()
    {
        if (m_Instance == null)
            m_Instance = (ObjectManager)FindObjectOfType(typeof(ObjectManager));
        return m_Instance;
    }
    // class 
    public GameObject goldDisplay;
    public GameObject autoIncDisplay;

    public GameObject comboDisplay;
    public GameObject comboBar;
    public GameObject comboBox;

    public GameObject rareSpawn;
    public Transform mainClick;

    public GameObject bonusObjClick;
}

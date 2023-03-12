using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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
    public Sprite AscDwarfSprite;
    public RuntimeAnimatorController AscDwarfAnim;

    // class 
    public GameObject Dwarf;

    public Transform mainClick;
    public GameObject goldDisplay;
    public GameObject autoIncDisplay;

    public GameObject goldPopup;
    public GameObject goldPopupContainer;
    public GameObject goldChunk;
    public GameObject goldChunkContainer;

    public GameObject shopWindow;

    public GameObject comboDisplay;
    public GameObject comboBar;
    public GameObject comboBox;

    public GameObject rareSpawn;

    public GameObject buffClicking;
    public GameObject buffAutoInc;
    public GameObject buffGoldReward;

    public Transform buffDisplay;
}

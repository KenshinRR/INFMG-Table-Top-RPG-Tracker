using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> menuList;

    public void toggleMenu(int index)
    { 
        for (int i = 0; i < menuList.Count; i++)
        {
            if (i == index)
            {
                menuList[i].SetActive(true);
            }
            else
            {
                menuList[i].SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

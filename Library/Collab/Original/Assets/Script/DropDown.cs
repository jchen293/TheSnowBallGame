using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour {


    public Dropdown dropdown;
	

    public void ModeSelection(){

        if(dropdown.value ==1){
            GameManager.Instance.startPage.SetActive(true);
        }
    }
}

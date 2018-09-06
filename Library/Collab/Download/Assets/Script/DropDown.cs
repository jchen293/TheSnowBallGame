
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    //Create a List of new Dropdown options
    List<string> m_DropOptions = new List<string> {"     ","Train Mode", "Hard Mode" };
    //My dropdown menu
    Dropdown m_Dropdown;

    void Start()
    {
        //Fetch the Dropdown GameObject 
        m_Dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown stuff
        m_Dropdown.ClearOptions();
        //Add the new options created above
        m_Dropdown.AddOptions(m_DropOptions);
    }
}
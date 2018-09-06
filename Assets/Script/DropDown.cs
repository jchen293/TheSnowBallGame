using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DropDown : MonoBehaviour
{
    //Create a List of new Dropdown options
    //My dropdown menu
    public Dropdown m_Dropdown;
    List<string> names = new List<string> { "     ", "Train Mode", "Hard Mode" };

  

    void Start()
    {
        PopulateList();

        //Fetch the Dropdown GameObject 
        m_Dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown stuff
        m_Dropdown.ClearOptions();
        //Add the new options created above
    }

    public void PopulateList(){
        m_Dropdown.AddOptions(names);

    }

    public void DropDownSelection(int index)
    {

        if (names[index] =="Train Mode")
        {
        }else if(names[index]=="Hard Mode"){
            SceneManager.LoadScene("4LineRocks");

        }
    }
}
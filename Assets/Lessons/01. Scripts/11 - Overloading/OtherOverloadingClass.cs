
using UnityEngine;

public class OtherOverloadingClass : MonoBehaviour
{

    public GameObject gameObjectSelect ;

    // Start is called before the first frame update
    void Start()
    {
        //OverloadingClass myClass = new OverloadingClass();
        //You are trying to create a MonoBehaviour using the 'new' keyword.  This is not allowed.  MonoBehaviours can only be added using AddComponent(). Alternatively your script can inherit from ScriptableObject or no base class at all

        /* 
         * unity will give you a warning so you should use the code below to attach the script to the gameObject
        */

        //GameObject gameObjectSelect = new GameObject();
        OverloadingClass myClass = gameObjectSelect.AddComponent<OverloadingClass>();

        //Output int
        int additionInt;
        additionInt = myClass.Add(1, 2);
        additionInt = myClass.Add(additionInt, 2);
        Debug.Log(additionInt);

        //Output string
        string additionStr;
        additionStr = myClass.Add("Hello", " ");
        additionStr = myClass.Add(additionStr, "World");
        Debug.Log(additionStr);
    }

    
}

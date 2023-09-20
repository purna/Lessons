
using UnityEngine;

public class gui : MonoBehaviour
{
    private Texture2D bwGreen;

    private void OnEnable()
    {
           bwGreen = MakeTex(2, 2, new Color(0.11372f, 0.73333f, 0.6941176f));
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public Texture[] alphaButtons;

    void OnGUI()
    {
        GUILayout.Space(20);

        GUIStyle buttonStyle = new GUIStyle();
        buttonStyle = GUI.skin.button;
        buttonStyle.hover.background = bwGreen;
        buttonStyle.fontSize = 14;

        GUI.skin.settings.selectionColor = Color.cyan;

        string str = "This is a string with\ntwo lines of text";
        str = GUILayout.TextArea(str);


        if (GUI.Button(new Rect(100f, 100f, 150, 100), "I am a button"))
        {
            print("You clicked the button!");
        }

        if (GUI.Button(new Rect(100f, 100f, 150, 100), "I am a button"))
        {
            print("You clicked the button!");
        }

        GUILayout.BeginHorizontal();
        GUILayout.Button("I'm the first button");

        // Insert 20 pixels of space between the 2 buttons.
        GUILayout.Space(20);

        GUILayout.Button("I'm the second button");
        GUILayout.EndHorizontal();

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

}

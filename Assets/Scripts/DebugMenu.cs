using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    enum CurrentTab : int
    {
        Visuals = 0,
        Entities = 1,
        Map = 2
    }

    #region menu
    public bool menu_enable = false;
    float width = Screen.width / 2f;
    float height = Screen.height / 2f;
    static float x = 0;
    static float y = 0;
    #endregion


    bool toogleExample1 = false;
    bool toogleExample2 = false;
    bool toogleExample3 = false;
    bool toogleExample4 = false;
    bool toogleExample5 = false;
    bool toogleExample6 = false;

    Rect windowRect;
    private CurrentTab current_tab = CurrentTab.Visuals;

    public Texture2D MakeTex(int width, int height, Color col)
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

    void Start()
    {
        windowRect = new Rect(x + 10, y + 10, 400, 400);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            menu_enable = !menu_enable;
        }
    }

    private void OnGUI()
    {
        GUI.backgroundColor = Color.white;

        GUI.skin.button.normal.background = MakeTex(2, 2, Color.black);
        GUI.skin.toggle.onNormal.textColor = Color.white;

        GUI.skin.button.hover.background = MakeTex(2, 2, Color.white);
        GUI.skin.button.hover.textColor = Color.black;

        GUI.skin.toggle.onNormal.textColor = Color.cyan;

        if (menu_enable)
        {
            windowRect = GUI.Window(0, windowRect, (GUI.WindowFunction)Tabs, "Jadis0x's Debug Menu");
        }
    }

    public void Tabs(int windowID)
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("TAB 1") || Input.GetKeyDown(KeyCode.F1))
        {
            current_tab = CurrentTab.Visuals;
        }

        if (GUILayout.Button("TAB 2") || Input.GetKeyDown(KeyCode.F2))
        {
            current_tab = CurrentTab.Entities;
        }

        if (GUILayout.Button("TAB 3") || Input.GetKeyDown(KeyCode.F3))
        {
            current_tab = CurrentTab.Map;
        }

        GUILayout.EndHorizontal();

        switch (current_tab)
        {
            case CurrentTab.Visuals:
                Tab1();
                break;
            case CurrentTab.Entities:
                Tab2();
                break;
            case CurrentTab.Map:
                Tab3();
                break;
        }

        GUI.DragWindow();
    }

    void Tab1()
    {
        toogleExample1 = GUI.Toggle(new Rect(x + 10, y + 50, 120, 30), toogleExample1, "Toggle 1");
        toogleExample2 = GUI.Toggle(new Rect(x + 10, y + 80, 120, 30), toogleExample2, "Toggle 2");

        if (GUI.Button(new Rect(x + 10, y + 110, 130, 30), "Button 1"))
        {
            //
        }
    }

    void Tab2()
    {
        toogleExample3 = GUI.Toggle(new Rect(x + 10, y + 50, 120, 30), toogleExample3, "Toggle 3");
        toogleExample4 = GUI.Toggle(new Rect(x + 10, y + 80, 120, 30), toogleExample4, "Toggle 4");
    }

    void Tab3()
    {
        toogleExample5 = GUI.Toggle(new Rect(x + 10, y + 50, 120, 30), toogleExample5, "Toggle 5");
        toogleExample6 = GUI.Toggle(new Rect(x + 10, y + 80, 120, 30), toogleExample6, "Toggle 6");
    }
}

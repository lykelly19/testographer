using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public Camera mainCamera;
    public Font labelFont;
    System.Action<string, Vector2> isDroppedCallback;
    System.Action<Timer> onEndGame;
    System.Action<bool> onUpdateScore;

    BoxList boxes;
    RegionList rList;
    Region[] sidebarList;

    Timer timer;

    public System.Action<Timer> OnEndGame
    {
        set
        {
            onEndGame = value;
        }
    }

    public System.Action<bool> OnUpdateScore
    {
        set
        {
            onUpdateScore = value;
        }
    }

    public void updateIsDroppedCallback()
    {
        isDroppedCallback = (string id, Vector2 location) =>
        {
            string match = boxes.findBoxMatch(location);

            if (match == id)
            {
                // update score
                onUpdateScore(true);

                // update box label
                boxes.updateBoxLabel(id);

                // replace with unmatched region
                int index = -1;
                for (int i = 0; i < sidebarList.Length; i++)
                {
                    if (sidebarList[i].Id == id)
                    {
                        index = i;
                    }
                }
                rList.getReplacementId(sidebarList, id);

                // check if game is over & end it if so:
                if (rList.allMatched())
                {
                    onEndGame(timer);
                }
            }
            else if (match != null)
            {
                onUpdateScore(false);
            }
        };

        foreach (Region r in sidebarList)
            r.IsDroppedCallback = isDroppedCallback;
    }


    // Start is called before the first frame update
    void Start()
    {
        Timer[] timers = FindObjectsOfType<Timer>();
        timer = timers[0];

        boxes = new BoxList(1);
        rList = new RegionList();



        // randomly generate 10 state names
        List<string> sidebarListNames = rList.generateSidebarList(10);

        float[] yPosArr = new float[] { 3.16f, 2.38f, 1.57f, 0.73f, -0.06f, -0.87f, -1.69f, -2.51f, -3.35f, -4.14f };

        // create the first 10 label objects
        for(int i=0; i<10; i++) {
            createRegionLabelObject(i.ToString(), sidebarListNames[i], -7.27f, yPosArr[i]);
        }


        // Get Regions in sidebar
        sidebarList = FindObjectsOfType<Region>();  // after defining IsDroppedCallback, add each Region in regions to rList
    }




    void createRegionLabelObject(string gameObjectName, string displayText, float xPos, float yPos) {

        // GameObject
        GameObject go1 = new GameObject(gameObjectName); 
        go1.AddComponent<BoxCollider2D>();

        Region region = go1.AddComponent<Region>();  // add the Region script to the Region Label GameObject
        region.Id = displayText;  // set the region Id

        SpriteRenderer renderer = go1.AddComponent<SpriteRenderer>();
        renderer.sprite = Resources.Load<Sprite>("Images/Square");
        renderer.sortingOrder = 3;

        // Set Color
        renderer.material.color = new Color(0.0f, 0.42f, 0.54f, 1);

        // set position
        go1.transform.position = new Vector2(xPos, yPos);
        go1.transform.localScale = new Vector3(1.98f, 0.37f, 0.59f);

        // Canvas
        Canvas myCanvas; 
        GameObject myGO;

        myGO = new GameObject();
        myGO.name = "myCanvas";
        myGO.AddComponent<Canvas>();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.WorldSpace;
        myCanvas.sortingOrder = 4;

        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();

        myCanvas.worldCamera = mainCamera;
        myCanvas.transform.parent = go1.transform;
        myCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 10);
        


        // Text
        GameObject myText;
        Text text;

        myText = new GameObject();
        myText.transform.parent = myGO.transform;
        myText.name = gameObjectName;
        myText.transform.position = new Vector2(xPos, yPos-0.32f);

        text = myText.AddComponent<Text>();
        text.text = displayText;
        text.fontSize = 20;
        text.verticalOverflow = VerticalWrapMode.Overflow;
        text.font = labelFont;

        myText.GetComponent<RectTransform>().localScale = new Vector3(0.01f, 0.01f, 0.01f);

    }

    // Update is called once per frame
    void Update()
    {
    }
}


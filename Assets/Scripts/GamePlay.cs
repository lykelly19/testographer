using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// incorporate this code to GameManager?

public class GamePlay : MonoBehaviour
{
    public Camera mainCamera;
    public Font labelFont;

    public int highScore = 0;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);

        float[] yPosArr = new float[] { 3.16f, 2.38f, 1.57f, 0.73f, -0.06f, -0.87f, -1.69f, -2.51f, -3.35f, -4.14f };
        string[] yPosArr2 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        
        // temporary backend - instead we would randomly generate 10 different states & mark which have been selected in a list
        string[] allText = new string[] { "Massachusetts", "a", "b", "c", "d", "e", "f", "g", "h", "i" };

        // create the first 10 label objects
        for(int i=0; i<10; i++) {
            createRegionLabelObject(yPosArr2[i], allText[i], -7.27f, yPosArr[i]);
        }


        Timer[] timer = FindObjectsOfType<Timer>();
        // Timer t1 = timer[0];
        // Debug.Log(timer.name);
        // Score score = FindObjectsOfType<Score>()[0];
        // Debug.Log(score.name);

        BoxList b = new BoxList(1);

        RegionList rList = new RegionList();
        Region[] regions = FindObjectsOfType<Region>();   // add to RegionList?
    
        foreach(Region r in regions)
            rList.addRegion(r);
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

        go1.AddComponent<DragAndDrop>();  // add the DragAndDrop script to the Region Label GameObject

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


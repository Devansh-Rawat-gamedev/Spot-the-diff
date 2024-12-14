using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandeler : MonoBehaviour
{
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] GameObject differencePrefab;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] int oneDiffrenceValue=1;
    private List<Differences> differences = new List<Differences>();
    private int score = 0;
    private bool isTimerRunning=true;
    private float elapsedTime=0f;
    private Vector2 previousSize;

    void Start()
    {
        LoadGameData("LevelData");
    }
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime; // Time.deltaTime adds the time that passed since the last frame
            DisplayTimer(); // Update the UI with the elapsed time
        }


        Vector2 currentSize = image1.rectTransform.rect.size;
        if (currentSize != previousSize)
        {
            previousSize = currentSize;
            RecalculateDifferences(); // Recalculate positions on resize
        }
    }

    void LoadGameData(string fileName)
    {

        string json = Resources.Load<TextAsset>(fileName).text;
        Debug.Log(json);

        GameData gameData = JsonUtility.FromJson<GameData>(json);

        image1.sprite = Resources.Load<Sprite>(gameData.images.image1);
        image2.sprite = Resources.Load<Sprite>(gameData.images.image2);

        if (image1.sprite == null || image2.sprite == null)
        {
            Debug.LogError($"Failed to load sprites from paths: {gameData.images.image1} and {gameData.images.image2}");
            return;
        }

        differences = gameData.differences;
        DisplayDifferences();
    }

    void DisplayDifferences()
    {
        RectTransform imageRectTransform = image1.GetComponent<RectTransform>();
        float imageWidth = imageRectTransform.rect.width;
        float imageHeight = imageRectTransform.rect.height;

        float originalImageWidth = image1.sprite.rect.width; 
        float originalImageHeight = image1.sprite.rect.height;

        float scaleX = imageWidth / originalImageWidth;
        float scaleY = imageHeight / originalImageHeight;

        foreach (Differences diff in differences)
        {
            
            float mappedX = diff.x * scaleX;
            float mappedY = diff.y * scaleY;
            float mappedWidth = diff.width * scaleX;
            float mappedHeight = diff.height * scaleY;

            float anchoredX = mappedX - (imageWidth * 0.5f); 
            float anchoredY = mappedY - (imageHeight * 0.5f);


            
            GameObject clickableArea = Instantiate(differencePrefab, image1.transform);
            GameObject clickableArea2 = Instantiate(differencePrefab, image2.transform);


            RectTransform rectTransform = clickableArea.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(mappedWidth, mappedHeight);
            rectTransform.anchoredPosition = new Vector2(anchoredX, anchoredY);

            RectTransform rectTransform2 = clickableArea2.GetComponent<RectTransform>();
            rectTransform2.sizeDelta = new Vector2(mappedWidth, mappedHeight);
            rectTransform2.anchoredPosition = new Vector2(anchoredX, anchoredY);

            Button button = clickableArea.GetComponent<Button>();
            Button button2 = clickableArea2.GetComponent<Button>();


            GameObject[] clickableAreas= { clickableArea,clickableArea2 };

            button.onClick.AddListener(() => OnDifferenceClicked(clickableAreas));
            button2.onClick.AddListener(() => OnDifferenceClicked(clickableAreas));



        }
    }


    void ClearDifferences()
    {
        // Destroy all existing difference markers
        foreach (Transform child in image1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in image2.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void OnDifferenceClicked(GameObject[] clickableArea)
    {
        foreach (var item in clickableArea)
        {
            item.GetComponent<Button>().enabled=false;
            item.GetComponent<Image>().enabled = true;

        }
        score += oneDiffrenceValue;
        if (score/ oneDiffrenceValue >= differences.Count)
        {
            //stop timer and display you win text
            CompleteLevel();




        }
        UpdateScore();
        return;
            
        
    }

   

    void UpdateScore()
    {
        ;
        scoreText.text = "Score: " + score;
        
    }

    
    void DisplayTimer()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }
    void CompleteLevel()
    {

        isTimerRunning = false;
        winText.gameObject.SetActive(true);
    }


    void RecalculateDifferences()
    {
        ClearDifferences();
        DisplayDifferences(); 
    }
}

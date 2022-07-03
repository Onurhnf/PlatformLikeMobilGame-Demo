using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    bool unlocked;
    public Image unlcokImage;
    public GameObject[] stars;

    public Sprite starSprite;

    private void Awake()
    {
        if (this.gameObject.name == "1")
        {
            unlocked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevel();
        UpdateLevelStatus();
    }


    private void UpdateLevelStatus()
    {
        //PlayerPrefs.DeleteAll();
        int previousLevelStars = int.Parse(gameObject.name)-1;
        if (PlayerPrefs.GetInt("Lv"+previousLevelStars)>0)
        {
            unlocked = true;
        }
        for (int i = 0; i < PlayerPrefs.GetInt("Lv"+gameObject.name); i++)
        {
            stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
        }

    }

    private void UpdateLevel()
    {
        if (!unlocked)
        {
            unlcokImage.gameObject.SetActive(true);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else
        {
            unlcokImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }
        }
    }

    public void LevelPressed()
    {

        if (Application.CanStreamedLevelBeLoaded(this.gameObject.name) && unlocked)
        {

            SceneManager.LoadScene(this.gameObject.name);



        }


    }

}

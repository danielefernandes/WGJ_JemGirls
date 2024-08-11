using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public Button buttonStart;
    [SerializeField]
    public Button buttonExit;
    // Start is called before the first frame update
    void Start()
    {
        Button buttonS = buttonStart.GetComponent<Button>();
        buttonS.onClick.AddListener(StartLevel1); 

        Button buttonE = buttonExit.GetComponent<Button>();
        buttonE.onClick.AddListener(EndGame);
    }

    private void StartLevel1(){
		SceneManager.LoadScene("Rooms");
	}

    // Update is called once per frame
    private void EndGame()
    {
        Application.Quit();
    }
}

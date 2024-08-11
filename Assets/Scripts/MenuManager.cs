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
    [SerializeField]
    public Animator transition;
    [SerializeField]
    public GameObject transitionEffect;

    private float transitionTime = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Button buttonS = buttonStart.GetComponent<Button>();
        buttonS.onClick.AddListener(StartLevel); 

        Button buttonE = buttonExit.GetComponent<Button>();
        buttonE.onClick.AddListener(EndGame);
    }

    private void StartLevel(){
		StartCoroutine(LoadLevel("CutScene"));
	}

    private IEnumerator LoadLevel(string levelName)
    {
        //transition.SetTrigger("Start");
        if (transitionEffect != null)
        {
            transitionEffect.SetActive(true);
        }
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
        
    }

    // Update is called once per frame
    private void EndGame()
    {
        Application.Quit();
    }

    
}

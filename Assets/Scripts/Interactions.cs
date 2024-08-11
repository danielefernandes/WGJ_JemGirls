using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{

    [SerializeField]
    public List<Button> interactionButtons;
    [SerializeField]
    public List<GameObject> roomScenes;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button button in interactionButtons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                // Torna o botão invisível ajustando a opacidade
                Color color = buttonImage.color;
                color.a = 0f; // Define a opacidade como 0 (totalmente invisível)
                buttonImage.color = color;
            }
        }
        
        activateRoom("Scene1");
    }

    private void OnButtonClick(Button clickedButton)
    {
        if(clickedButton.name == "Room1Desk"){
            activateRoom("Scene2");
        }
        if(clickedButton.name == "Room2Exit"){
            activateRoom("Scene1");
        }
        
    }

    private void activateRoom(string roomName){
        
        foreach (GameObject room in roomScenes)
        {
            if(room.name == roomName)
                room.SetActive(true);
            else
                room.SetActive(false);
        }

        

    }

    void Update()
    {
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameController : MonoBehaviour
{
    private string completeString = "Esto es una prueba de texto.";
    private string[] allInputs;
    private string[] specialChar = new string[]{"?", "¿", ".", ",", "!", "¡", ":", ";", "(", ")", "/"};
    private string currentChar;
    private int index = 0;
    private KeyCode k;

    public GameObject uiAllLetters;
    public GameObject textPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GetInputsFromString(completeString);
        SetAllLetters();
        GetNextInput();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)){
                return;
            }
            if(!Input.GetKeyDown(k)){
                Debug.Log("Tecla incorrecta pulsada");
            }
            if(Input.GetKeyDown(k)){
                
                Debug.Log("Tecla correcta pulsada:" + k.ToString());
                index++;
                GetNextInput();
            }
            
        }
    }

    private void GetInputsFromString(string complete){
        complete.Trim();
        complete.ToUpper();
        allInputs = complete.Select(x => new string(x, 1)).ToArray();
    }

    private void GetNextInput(){
        if(index == allInputs.Length){
             Debug.Log("Has ganado!");
            return;
        }
        currentChar = allInputs[index];
        k = (KeyCode)System.Enum.Parse(typeof(KeyCode), currentChar);
        uiAllLetters.transform.position += new Vector3 (-150, 0 ,0); 
    }

    private void SetAllLetters(){
        var i = 0;
        while(allInputs[i]){
            if(!specialChar.Contains(allInputs[i])){
                GameObject t = Instantiate(textPrefab, uiAllLetters.transform);
                t.transform.localPosition = new Vector3 (i * 150,  0,  0);
                t.GetComponent<Text>().text = allInputs[i];
            }
            i++;
        }
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResultController : MonoBehaviour {
    [SerializeField] private List<GameObject> _players = new List<GameObject>();
    [SerializeField] private List<Sprite> _winner = new List<Sprite>();
    [SerializeField] private Image _winImage;
    [SerializeField] private GameObject _winBack;
    [SerializeField] private GameObject[] _buttons;
    private int _winNum;
    private int _winChar;
    private string _winName;
    void Start () {
        _winNum = PlayerPrefs.GetInt("winNum",5) - 1;
        _winName = PlayerPrefs.GetString("winName", "Draw");
		_winChar = PlayerPrefs.GetInt(_winName, 6);
        StartCoroutine(ResultView());
    }
	
	IEnumerator ResultView(){
        if(_winChar != 6)
            _players[_winChar].SetActive(true);
        _winImage.sprite = _winner[_winNum];
        _winBack.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        foreach(var button in _buttons)
            button.SetActive(true);
        _buttons[1].GetComponent<Button>().Select();
        yield break;
    }

	public void BackTItle()
	{
		SceneChange.ChangeScene("Title");
	}

	public void BackSelect()
	{
		SceneChange.ChangeScene("Select");
	}
}

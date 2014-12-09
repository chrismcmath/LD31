using System.Collections;

using UnityEngine;
using UnityEngine.UI;

namespace LD31.Controllers {
    public class ArrowPromptController : MonoBehaviour {
        public string TextValue = "";

        public Text ArrowText = null;
        public Image Background = null;

        public void Start() {
            Setup();
        }

        public void Setup() {
            ArrowText.text = TextValue;
        }

        public void Reset() {
            Background.color = Color.white;
            ArrowText.color = Color.black;
        }

        public void SetSelected() {
            Debug.Log("set " + gameObject.name + " selected");
            Background.color = Color.black;
            ArrowText.color = Color.white;
        }

        public void SetInactive() {
            Debug.Log("set " + gameObject.name + " inactive");
            Background.color = Color.black;
            ArrowText.color = Color.black;
        }
    }
}


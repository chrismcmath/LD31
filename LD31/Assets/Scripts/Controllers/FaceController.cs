using System.Collections;

using UnityEngine;
using UnityEngine.UI;

namespace LD31.Controllers {
    public class FaceController : MonoBehaviour {
        public readonly static string EYES_SPRITES_ROOT = "faces/eyes";
        public readonly static string MOUTH_SPRITES_ROOT = "faces/mouths";

        public Image Edge = null;
        public Image Background = null;
        public Image Eyes = null;
        public Image Mouth = null;

        public void Start() {
            Edge.color = Color.black;
        }

        public void SetSuccess() {
            string[] successParams = new string[] {Config.EYES_SUCCESS, Config.MOUTH_SUCCESS, "on"};
            Setup(successParams);
        }

        public void SetFail() {
            string[] failParams = new string[] {Config.EYES_FAIL, Config.EYES_FAIL, "on"};
            Setup(failParams);
        }

        public void SetOff() {
            string[] offParams = new string[] {Config.EYES_FAIL, Config.EYES_FAIL, "off"};
            Setup(offParams);
        }

        public void Setup(string[] faceParams) {
            //Debug.Log("setup " + faceParams[0] + ", " + faceParams[1] + ", " + faceParams[2]);
            Eyes.sprite = Resources.Load<Sprite>(string.Format("{0}/{1}", EYES_SPRITES_ROOT, faceParams[0]));
            Mouth.sprite = Resources.Load<Sprite>(string.Format("{0}/{1}", MOUTH_SPRITES_ROOT, faceParams[1]));

            if (faceParams[2] == "off") {
                Background.color = Color.black;
            } else {
                Background.color = Color.white;
            }
        }
    }
}


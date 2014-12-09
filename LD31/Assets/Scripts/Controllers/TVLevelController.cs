using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace LD31.Controllers {
    public class TVLevelController : MonoBehaviour {
        public List<Config.Direction> ValidAnswers = new List<Config.Direction>();
        public List<Config.Direction> InvalidOptions = new List<Config.Direction>();

        public string[] TopFaceParams = new string[] {Config.EYES_DOTS, Config.MOUTH_LINE_DOWN, "on"};
        public string[] LeftFaceParams = new string[] {Config.EYES_DOTS, Config.MOUTH_LINE_DOWN, "on"};
        public string[] RightFaceParams = new string[] {Config.EYES_DOTS, Config.MOUTH_LINE_DOWN, "on"};
        public string[] BottomFaceParams = new string[] {Config.EYES_DOTS, Config.MOUTH_LINE_DOWN, "on"};
        public string[] MiddleFaceParams = new string[] {Config.EYES_DOTS, Config.MOUTH_LINE_DOWN, "on"};

        private FacesController _FacesController;

        public void Awake() {
            GameObject facesGO = Instantiate(Resources.Load<GameObject>("faces"));
            _FacesController = facesGO.GetComponent<FacesController>();

            Transform facesTransform = facesGO.transform;
            facesTransform.SetParent(transform, false);

            Reset();

            _FacesController.gameObject.SetActive(false);
        }

        public void StartLevel() {
            _FacesController.gameObject.SetActive(true);
        }

        public void Reset() {
            _FacesController.Reset(
                    LeftFaceParams,
                    RightFaceParams,
                    TopFaceParams,
                    BottomFaceParams,
                    MiddleFaceParams);
        }

        //NOTE: currently unused (unity inspector issues)
        private List<string> GetDefaultFaceParams() {
            List<string> defaultFaceParams = new List<string>();
            defaultFaceParams.Add("dots");
            defaultFaceParams.Add("smile");
            return defaultFaceParams;
        }

        public bool IsValidOption(Config.Direction direction) {
            foreach (Config.Direction d in InvalidOptions) {
                if (direction == d) {
                    return false;
                }
            }
            return true;
        }

        public bool Submit(Config.Direction direction) {
            foreach (Config.Direction d in ValidAnswers) {
                if (direction == d) {
                    StartCoroutine(LevelSuccess(direction));
                    return true;
                }
            }
            StartCoroutine(LevelFail(direction));
            return false;
        }

        private IEnumerator LevelSuccess(Config.Direction direction) {
            yield return new WaitForSeconds(Config.RESULT_REVEAL_DELAY);
            SoundsController s = Model.Instance.SoundsController;
            s.TVSuccess.Play();
            _FacesController.SetSuccess(direction);
        }

        private IEnumerator LevelFail(Config.Direction direction) {
            yield return new WaitForSeconds(Config.RESULT_REVEAL_DELAY);
            SoundsController s = Model.Instance.SoundsController;
            s.TVFail.Play();
            _FacesController.SetFail(direction);
        }
    }
}


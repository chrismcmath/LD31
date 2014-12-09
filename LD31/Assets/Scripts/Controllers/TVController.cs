using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using LD31;

namespace LD31.Controllers {
    public class TVController : MonoBehaviour {
        public ArrowPromptController LeftArrow = null;
        public ArrowPromptController RightArrow = null;
        public ArrowPromptController UpArrow = null;
        public ArrowPromptController DownArrow = null;

        public Transform LevelParent = null;

        private bool _Listening = false;
        private ArrowPromptController _SelectedArrow;

        private int _CurrentLevelID = 0;
        private TVLevelController _CurrentLevel;

        public void Awake() {
            _CurrentLevel = GetLevelByID(_CurrentLevelID);
        }

        public void Start() {
            _CurrentLevel.StartLevel();
        }

        public void OnUserInput(Config.Direction direction) {
            if (!_Listening || !_CurrentLevel.IsValidOption(direction)) return;


            SoundsController s = Model.Instance.SoundsController;
            s.TVInput.Play();

            _SelectedArrow = GetArrowPromptFromDirection(direction);

            _SelectedArrow.SetSelected();
            if (_CurrentLevel.Submit(direction)) {
                StartCoroutine(NextLevel());
            } else {
                StartCoroutine(ChuckPlayerAway());
                StartCoroutine(ResetAfterWait());
            }

            _Listening = false;
        }

        public void StartListening() {
            _Listening = true;
        }

        private void UpdateArrows() {
            ResetArrows();

            foreach (Config.Direction d in _CurrentLevel.InvalidOptions) {
                ArrowPromptController arrow = GetArrowPromptFromDirection(d);
                arrow.SetInactive();
            }
        }

        private IEnumerator NextLevel() {
            yield return new WaitForSeconds(Config.RESULT_RAMIFICATION_DELAY);
            Debug.Log("next level!");
            SoundsController s = Model.Instance.SoundsController;

            if (_CurrentLevelID == Config.LEVEL_NUMBER) {
                s.Theme.Stop();
                s.TVStatic.Stop();

                StartCoroutine(PlayOutro());
                StartCoroutine(FadeInEnd());

                Model.Instance.FlashController.ToBlack();
                yield break;
            }


            _Listening = true;

            s.TVNextLevel.Play();

           TVLevelController oldLevel = _CurrentLevel;
           _CurrentLevel = GetLevelByID(++_CurrentLevelID);
           _CurrentLevel.StartLevel();
           GameObject.Destroy(oldLevel.gameObject);
           UpdateArrows();
        }

        private IEnumerator PlayOutro() {
            yield return new WaitForSeconds(2.0f);
            SoundsController s = Model.Instance.SoundsController;
            s.Outro.Play();
        }

        private IEnumerator FadeInEnd() {
            yield return new WaitForSeconds(20.0f);
            Model.Instance.FlashController.ToEnd();
        }

        private IEnumerator ChuckPlayerAway() {
            yield return new WaitForSeconds(Config.RESULT_RAMIFICATION_DELAY);
            Debug.Log("chuck player away!");
            Messenger.Broadcast(Config.EVENT_TV_GAME_CHUCK_PLAYER);
        }

        private IEnumerator ResetAfterWait() {
            yield return new WaitForSeconds(Config.RESET_WAIT_TIME);
            _CurrentLevel.Reset();
            UpdateArrows();

            if (Config.DEBUG_MODE) {
                _Listening = true;
            }
        }

        private void ResetArrows() {
            LeftArrow.Reset();
            UpArrow.Reset();
            RightArrow.Reset();
            DownArrow.Reset();
        }

        public TVLevelController GetLevelByID(int id) {
            foreach (Transform t in LevelParent) {
                if (t.gameObject.name == id.ToString()) {
                    return t.GetComponent<TVLevelController>();
                }
            }
            return null;
        }

        public ArrowPromptController GetArrowPromptFromDirection(Config.Direction direction) {
            switch (direction) {
                case Config.Direction.UP: 
                    return UpArrow;
                case Config.Direction.DOWN: 
                    return DownArrow;
                case Config.Direction.LEFT: 
                    return LeftArrow;
                case Config.Direction.RIGHT: 
                    return RightArrow;
                default:
                    return null;
            }
        }
    }
}


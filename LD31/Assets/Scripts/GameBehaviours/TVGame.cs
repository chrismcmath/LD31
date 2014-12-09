using System.Collections;

using UnityEngine;

using LD31;
using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class TVGame : TVBehaviour {
        protected TVController _TVController = null;
        private bool GameFailed = false;


        public TVGame() : base() {
            _TVController = Model.Instance.TVController;
            _TVController.StartListening();

            SoundsController s = Model.Instance.SoundsController;
            s.Wind.Stop();
            s.Theme.volume = Config.MIN_THEME_VOLUME;

            Messenger.AddListener(Config.EVENT_TV_GAME_CHUCK_PLAYER, OnFail);
        }

        ~TVGame() {
            Messenger.RemoveListener(Config.EVENT_TV_GAME_CHUCK_PLAYER, OnFail);
        }

        public void OnFail() {
            GameFailed = true;
        }

        public override GameBehaviour Update() {
            if (GameFailed) {
                return new ChuckPlayer();
            }

            if (Input.GetButtonDown("Right")) {
                SubmitTVInput(Config.Direction.RIGHT);
            } else if (Input.GetButtonDown("Left")) {
                SubmitTVInput(Config.Direction.LEFT);
            } else if (Input.GetButtonDown("Up")) {
                SubmitTVInput(Config.Direction.UP);
            } else if (Input.GetButtonDown("Down")) {
                SubmitTVInput(Config.Direction.DOWN);
            }
            
            return this;
        }

        public void SubmitTVInput(Config.Direction direction) {
            _TVController.OnUserInput(direction);
        }

    }
}

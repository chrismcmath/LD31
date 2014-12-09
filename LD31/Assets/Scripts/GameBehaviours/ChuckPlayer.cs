using System.Collections;

using UnityEngine;

using LD31;
using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class ChuckPlayer : PlayerBehaviour {
        public static readonly float MOVE_SPEED = 3f;
        public static readonly float CHANGE_BEHAVIOUR_THRESHOLD = -500f;
        public static readonly float CHANGE_BEHAVIOUR_TOLERANCE = 10f;

        public ChuckPlayer() : base() {
            Model.Instance.ObstacleGeneratorController.On = true;

            SoundsController s = Model.Instance.SoundsController;
            s.Wind.Play();
            s.ChuckAway.Play();
            Debug.Log("s is playing? " + s.Theme.isPlaying);
            if (!s.Theme.isPlaying) {
                Debug.Log("play theme");
                s.Theme.Play();
            }
            s.Theme.volume = 1f;
        }

        public override GameBehaviour Update() {
            _PlayerTransform.localPosition = new Vector3(
                    _PlayerTransform.localPosition.x,
                    _PlayerTransform.localPosition.y,
                    _PlayerTransform.localPosition.z + ((CHANGE_BEHAVIOUR_THRESHOLD - _PlayerTransform.localPosition.z) * (MOVE_SPEED * Time.deltaTime))
                    );

            _PlayerTransform.localRotation =
                Quaternion.Euler(_PlayerTransform.localRotation.eulerAngles + Vector3.forward * 10f);

            if (_PlayerTransform.localPosition.z < (CHANGE_BEHAVIOUR_THRESHOLD + CHANGE_BEHAVIOUR_TOLERANCE)) {
                return new FallingBehaviour();
            }

            return this;
        }
    }
}

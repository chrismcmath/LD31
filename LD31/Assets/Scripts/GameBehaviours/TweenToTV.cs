using System.Collections;

using UnityEngine;

using LD31;
using LD31.Controllers;

namespace LD31.GameBehaviours {
    public class TweenToTV : TVBehaviour {
        private float _TimeLeft;
        private Vector3 _InitialPosition;
        private Vector3 _TargetVector;
        private Vector3 _InitialRotation;

        public TweenToTV(float speed) : base() {
            Model.Instance.ObstacleGeneratorController.On = false;
            _TimeLeft = Config.TWEEN_TO_TV_PERIOD;
            _InitialPosition = _PlayerTransform.position;
            _InitialRotation = _PlayerTransform.rotation.eulerAngles;
            _TargetVector = Config.TV_LOCK_POSITION - _PlayerTransform.localPosition;
        }

        public override GameBehaviour Update() {
            _TimeLeft -= Time.deltaTime;
            float fractionLeft = 0f;
            if (_TimeLeft > 0f) {
                fractionLeft = (Config.TWEEN_TO_TV_PERIOD - _TimeLeft) / Config.TWEEN_TO_TV_PERIOD;
            }


            SoundsController s = Model.Instance.SoundsController;
            s.Theme.volume = Config.MIN_THEME_VOLUME + ((1f - Config.MIN_THEME_VOLUME) * (1f - fractionLeft));

            _PlayerTransform.localPosition = _InitialPosition + (fractionLeft * _TargetVector);
            _PlayerTransform.localRotation = Quaternion.Euler(_InitialRotation * (1f - fractionLeft));

            if (fractionLeft <= 0f) {
                _PlayerTransform.localPosition = Config.TV_LOCK_POSITION;
                _PlayerTransform.localRotation = Quaternion.identity;
                return new TVGame();
            }

            return this;
        }
    }
}

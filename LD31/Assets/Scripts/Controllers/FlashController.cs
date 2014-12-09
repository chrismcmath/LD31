using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using LD31;

namespace LD31.Controllers {
    public class FlashController : MonoBehaviour {
        public CanvasGroup White = null;
        public CanvasGroup Black = null;
        public CanvasGroup End = null;

        private bool _FlashWhite = false;
        private bool _FadeEnd = false;

        public void Update() {
            if (_FlashWhite) {
                White.alpha *= 0.9f;

                if (White.alpha < 0.01f) {
                    White.alpha = 0f;
                    _FlashWhite = false;
                }
            }

            if (_FadeEnd) {
                End.alpha += 0.01f;

                if (End.alpha >= 0.99f) {
                    End.alpha = 1f;
                    _FadeEnd = false;
                }
            }
        }
        public void FlashWhite() {
            _FlashWhite = true;
            White.alpha = 1.0f;
        }

        public void ToBlack() {
            Black.alpha = 1f;
        }

        public void ToEnd() {
            _FadeEnd = true;
        }
    }
}


using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class MakeupBook : MonoBehaviour
    {
        [SerializeField]
        private Button _nextButton;

        [SerializeField]
        private Button _previousButton;

        [SerializeField]
        private GameObject[] _menus;

        [SerializeField]
        private Transform _center;

        [SerializeField]
        private Transform _right;

        [SerializeField]
        private float _changeDuration;

        private float _centerPosX;

        private float _rightPosX;

        private float _leftPosX;

        private int _selectedIndex;

        private void Awake()
        {
            _centerPosX = _center.position.x;
            _rightPosX = _right.position.x;
            _leftPosX = _centerPosX -_rightPosX;
        }

        private void OnEnable()
        {
            _nextButton.onClick.AddListener(SetNext);

            _previousButton.onClick.AddListener(SetPrevious);
        }

        private void OnDisable()
        {
            _nextButton.onClick.RemoveAllListeners();

            _previousButton.onClick.RemoveAllListeners();
        }

        private void SetNext()
        {
            var current = _menus[_selectedIndex];

            _selectedIndex = (_selectedIndex + 1) % _menus.Length;

            var next = _menus[_selectedIndex];

            ChangeMenu(_leftPosX, _rightPosX, current, next);
        }

        private void SetPrevious()
        {
            var current = _menus[_selectedIndex];

            _selectedIndex--;

            if (_selectedIndex < 0)
            {
                _selectedIndex = _menus.Length - 1;
            }

            var previous = _menus[_selectedIndex];

            ChangeMenu(_rightPosX, _leftPosX, current, previous);
        }

        private void ChangeMenu(float currentTargetX, float changeStartX, GameObject current, GameObject change)
        {
            change.transform.position = new Vector3(
                changeStartX,
                change.transform.position.y,
                change.transform.position.z
                );

            //change.SetActive(true);

            current.transform.DOMoveX(currentTargetX, _changeDuration);
                //.OnComplete(() => current.SetActive(false));

            change.transform.DOMoveX(_centerPosX, _changeDuration);
        }
    }
}
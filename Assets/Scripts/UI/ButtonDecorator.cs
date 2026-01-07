using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace DivisionLike
{
    public class ButtonDecorator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Button m_Button;
        private TextMeshProUGUI m_Text;
        
        void Awake()
        {
            m_Button = GetComponent<Button>();
            m_Text = GetComponentInChildren<TextMeshProUGUI>();
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            m_Text.color = Color.black;
            this.transform.localPosition += new Vector3(0, 0f, -40f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_Text.color = Color.white;
            this.transform.localPosition += new Vector3(0, 0f, 40f);
        }
    }
}
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CheckClick : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameObject _actionButton;
    [SerializeField] private ShopUI _shopUI;
    [SerializeField] private OrderDeskUI _orderDeskUI;
    [SerializeField] private CreateHole _createHole;

    public bool shopTrigger;
    public bool orderDeskTrigger;
    public bool holeSelected;
    public Hole currentHole = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shopTrigger && !orderDeskTrigger)
        {
            if (collision.tag == "Shop")
            {
                shopTrigger = true;
                _actionButton.SetActive(true);
            }

            else if (collision.tag == "OrderDesk")
            {
                orderDeskTrigger = true;
                _actionButton.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Hole" && !holeSelected)
        {
            holeSelected = true;
            currentHole = collision.GetComponent<Hole>();
            if (currentHole.state != HoleStates.GROW || currentHole.isWeed)
            {
                currentHole.IsSelected();
                _actionButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hole" && holeSelected)
        {
            if (currentHole == collision.GetComponent<Hole>())
            {
                holeSelected = false;
                if (currentHole.state != HoleStates.GROW || !currentHole.isWeed)
                {
                    currentHole.IsNotSelected();
                    _actionButton.SetActive(false);
                }
                currentHole = null;
            }
        }

        if (collision.tag == "Shop" && shopTrigger && !orderDeskTrigger)
        {
            shopTrigger = false;
            _actionButton.SetActive(false);
        }
        else if (collision.tag == "OrderDesk" && orderDeskTrigger && !shopTrigger)
        {
            orderDeskTrigger = false;
            _actionButton.SetActive(false);
        }
    }

    public void Action()
    {
        if (shopTrigger && !orderDeskTrigger)
        {
            _buttons.SetActive(false);
            _shopUI.gameObject.SetActive(true);
            _shopUI.Setup();
            return;
        }

        if (!shopTrigger && orderDeskTrigger)
        {
            _buttons.SetActive(false);
            _orderDeskUI.gameObject.SetActive(true);
            return;
        }

        if (_createHole.canPlace && _createHole.currentHole != null)
        {
            _createHole.CreateHoleClick();
            return;
        }

        if (holeSelected && currentHole != null && !shopTrigger && !orderDeskTrigger)
        {
            currentHole.Action(_player);
            return;
        }
    }
}

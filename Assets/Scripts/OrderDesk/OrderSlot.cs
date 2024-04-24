using System.Collections.Generic;

/// <summary>
/// ����� �������� ���������� � ������
/// </summary>
[System.Serializable]
public class OrderSlot
{
    public Dictionary<Item, int> items;
    public int money;
    public int exp;

    /// <summary>
    /// ����������� ����� OrderSlot
    /// </summary>
    /// <param name="items">��������� ��������</param>
    /// <param name="money">�������� �������</param>
    /// <param name="exp">���������� �����</param>
    public OrderSlot(Dictionary<Item, int> items, int money, int exp)
    {
        this.items = items;
        this.money = money;
        this.exp = exp;
    }
}

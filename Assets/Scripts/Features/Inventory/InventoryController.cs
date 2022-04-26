using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

internal class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _model;
    private readonly IInventoryView _view;
    private readonly IItemsRepository _itemsRepository;
    private Action _hideAction;

    public InventoryController(
        [NotNull] IInventoryModel model,
        [NotNull] IInventoryView view,
        [NotNull] IItemsRepository itemsRepository)
    {
        _model = model;
        _view = view;
        _itemsRepository = itemsRepository;

        SetupView(_view);
    }

    protected override void OnDispose()
    {
        CleanupView();
        base.OnDispose();
    }

    public void HideInventory()
    {
        _view.Hide();
        _hideAction?.Invoke();
    }

    public void ShowInventory(Action callback)
    {
        _hideAction = callback;
        _view.Show();
        _view.Display(_itemsRepository.Items.Values.ToList());
    }

    public IReadOnlyList<IItem> GetEquippedItems()
    {
        return _model.GetEquippedItems();
    }

    private void SetupView(IInventoryView view)
    {
        view.Selected += OnItemSelected;
        view.Deselected += OnItemDeselected;
    }

    private void CleanupView()
    {
        _view.Selected -= OnItemSelected;
        _view.Deselected -= OnItemDeselected;
    }

    private void OnItemDeselected(object sender, IItem item)
    {
        _model.EquipItem(item);
    }

    private void OnItemSelected(object sender, IItem item)
    {
        _model.UnequipItem(item);
    }
}
using JetBrains.Annotations;
using System;

internal class InventoryController : BaseController, IInventoryController
{
    private readonly IInventoryModel _model;
    //private readonly IInventoryView _view;
    private readonly IItemsRepository _itemsRepository;

    public InventoryController(
        [NotNull] IInventoryModel model,
        //[NotNull] IInventoryView view,
        [NotNull] IItemsRepository itemsRepository)
    {
        _model = model;
        //_view = view;
        _itemsRepository = itemsRepository;
    }

    public void HideInventory()
    {
        throw new NotImplementedException();
    }

    public void ShowInventory(Action callback)
    {
        throw new NotImplementedException();
    }
}
using JetBrains.Annotations;
using Tools;
using UnityEngine;

public class GunAbility : IAbility
{
    private readonly GameObject _viewPrefab;
    private readonly float _projectileSpeed;
    public GunAbility([NotNull] string viewPath, float projectileSpeed)
    {
        _viewPrefab = ResourceLoader.LoadPrefab(new ResourcePath
        {
            PathResource = viewPath
        });
        _projectileSpeed = projectileSpeed;
    }

    public void Apply(IAbilityActivator activator)
    {
        var projectile = Object.Instantiate(_viewPrefab);
        projectile.GetComponent<Rigidbody2D>().
            AddForce(activator.GetViewObject().transform.right * _projectileSpeed, ForceMode2D.Force);
    }
}
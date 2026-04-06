using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.SCM.Domain.Model.Aggregates;

/// <summary>
/// Represents a supplier aggregate in the Supply Chain Management (SCM) domain.
/// A supplier is an entity that provides goods or services to the organization.
/// </summary>
/// <param name="identifier">The supplier's unique identifier. This is a required field and must not be null or whitespace.</param>
/// <param name="name">The name of the supplier. This is a required field and must not be null.</param>
/// <param name="address">The address of the supplier. This is a required field and must not be null.</param>
public class Supplier(string identifier, string name, Address address)
{
    public SupplierId Id { get; } = string.IsNullOrWhiteSpace(identifier) 
        ? throw new ArgumentException("Supplier identifier must be provided", nameof(identifier)) 
        : new SupplierId(identifier);
    public string Name { get; } = name ?? throw new ArgumentException("Supplier name must be provided", nameof(name));
    public Address Address { get; }  = address ?? throw new ArgumentNullException(nameof(address));
    
}
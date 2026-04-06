namespace ACME.OOP.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a Money value object containing amount and international currency code (ISO 4217).
/// </summary>
public record Money
{
    /// <summary>
    /// Creates a new instance of <see cref="Money"/> 
    /// </summary>
    /// <param name="amount">The amount for the money value object.</param>
    /// <param name="currency">The international currency code (ISO 4217) for the money value object. If given, it must be a valid 3-letter code.</param>
    /// <exception cref="ArgumentException">Thrown when the provided currency code is null, empty, whitespace, or not a valid 3-letter ISO code.</exception>
    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = string.IsNullOrWhiteSpace(currency) || currency.Length != 3 
            ? throw new ArgumentException("Currency must be a valid 3-letter ISO code.", nameof(currency))  
            : currency;
    }

    /// <summary>
    /// Provides a string representation for the <see cref="Money"/> value. 
    /// </summary>
    /// <returns>A string in the format of "Amount Currency", e.g., "100.00 USD".</returns>
    public override string ToString() => $"{Amount} {Currency}";

    /// <summary>
    /// Adds two <see cref="Money"/> objects together. 
    /// </summary>
    /// <param name="other">The other <see cref="Money"/> object to add. It can be null, in which case the original <see cref="Money"/> object is returned.</param>
    /// <returns>A new <see cref="Money"/> object representing the sum of the two amounts if they have the same currency, or the original <see cref="Money"/> object if the other is null.</returns>
    /// <exception cref="ArgumentException">Thrown when the other <see cref="Money"/> object is provided, and it has a different currency than the original.</exception>
    public Money Add(Money? other)
    {
        if (other is not null && other.Currency != Currency) 
            throw new ArgumentException("Cannot add money in another currency.");
        return other == null ? this : new Money(Amount + other.Amount, Currency);
    }
    
    /// <summary>
    /// Multiplies the amount of the <see cref="Money"/> object by a given multiplier. The currency remains unchanged.
    /// </summary>
    /// <param name="multiplier">The multiplier to apply to the amount. It can be any integer, including negative values and zero.</param>
    /// <returns>A new <see cref="Money"/> object with the amount multiplied by the given multiplier and the same currency.</returns>
    public Money Multiply(int multiplier) => new(Amount * multiplier, Currency);
    public decimal Amount { get; init; }
    public string Currency { get; init; }
    
    
}
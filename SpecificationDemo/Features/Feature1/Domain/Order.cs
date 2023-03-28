using SpecificationDemo.Features.Feature1.Rules;

namespace SpecificationDemo.Features.Feature1.Domain;

public class Order
{
    public Address? ShippingAddress { get; set; }
    public IList<Product> Items { get; set; }
    public int Total { get; set; }

    public Order()
    {
        Items = new List<Product>();
    }

    public bool IsRushOrderBadExample()
    {
        var isRush = false;

        if (ShippingAddress?.Country == "ESP")
        {
            if (Total > 100)
            {
                if (Items.Any(item => item.IsInStock))
                {
                    if (!Items.Any(item => item.ContainsHazardousMaterial))
                    {
                        isRush = true;
                    }
                }
            }
        }

        return isRush;
    }

    public bool IsOrderSensitiveBadExample()
    {
        var isSensitive = false;
        
        if (Total > 100)
        {
            if (Items.Any(item => item.IsInStock))
            {
                if (Items.Any(item => item.ContainsHazardousMaterial))
                {
                    isSensitive = true;
                }
            }
        }

        return isSensitive;
    }

    public bool IsRushOrderGoodExample() => new IsOrderRush().IsSatisfiedBy(this);

    public bool IsOrderSensitiveGoodExample() => new IsOrderSensitive().IsSatisfiedBy(this);
}
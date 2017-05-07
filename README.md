# Satisfied

Satisfied is a library providing an implementation of the specification pattern.

# Quickstart
## Installation
```
$> nuget install Satisfied
```

## Example Usage
```C#
public class Customer
{
	public string Name {get; set; }
}


public class CustomerNameSpecificaton : Specification<Customer>
{
	readonly string _partial;
	
	public CustomerNameSpecification(string partial)
	{
		_partial = partial;
	}

	public override Expression<Func<Customer, bool>> ToExpression()
    {
        return customer => customer.Name.Contains(_partial);
    }
}


public class Program
{
	static void Main()
	{
		var customer = new Customer { Name = "Jane Doe"; }
		var nameContainsJane = new CustomerNameSpecification("Jane");
		var isSatisfied = nameContainsJane.IsSatisfiedBy(customer); // true
	}
}

```

## Logical Operations

Satisfied supports composing multiple specifications using logical operations:

```C#
	var nameContainsJane = new CustomerNameSpecification("Jane");
	var ageIsOver18 = new CustomerAgeSpecification("18");
	var hasWaiver = new CustomerHasWaiverSpecification();
	var isResident = new CustomerIsResidentSpecification();

	var customerSpecification = nameContainsJane()
					.And(ageIsOver18.Or(hasWaiver))
					.And(isResident.Not());
```

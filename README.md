underscore-net
==============

Implementation of some Underscore.js feature in .NET, using C#

We will cover [Functions](http://underscorejs.org/#functions) Underscore.js first. Then will move on to other features.

#Current implementation
* _.Once(...)
* _.Debounce(...)

#Usage
First, add the using statement in your file as:
```csharp
using UnderscoreNet
```

Then, simply use the methods as you would in Underscore.js.

Example:
```csharp
using UnderscoreNet;
public class Test
{
	public static void DoSomething()
	{
		Console.WriteLine("Doing something...");
	}

	public static void Test()
	{
		var action = Underscore.Once(DoSomething);
		action(); // DoSomething gets called here.
		action(); // does nothing for this and all subsequent calls
		action();
		action();
	}
}
```

Sugarcoating:
```csharp
using _ = UnderscoreNet.Underscore; // if you know what i mean ;)
```



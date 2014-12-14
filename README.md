Underscore.Net
===============

Implementation of some Underscore.js feature in .NET, using C#. If you are a [Underscore.js](http://underscorejs.org) fan and a .NET developer, you will find this library quite interesting. 

We will cover [Functions](http://underscorejs.org/#functions) part of Underscore.js first. Then we'll move on to other features.

FYI, for Actions with generic type arguments, we have currently limited the number of argument to 4. If required, we will increment it later.

##Current support
* _.Once(...)
* _.Debounce(...)

##Usage
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

Please refer to the Underscore.Specs folder for tests with more usage.

###For hardcore Underscore.js fans
```csharp
using _ = UnderscoreNet.Underscore; // if you know what i mean ;)
```



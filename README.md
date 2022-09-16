# JsonDiffPatch.NET 6.0

## Thanks for Open Source

https://github.com/wbish/jsondiffpatch.net (Upgrade to .NET 6.0 at here)

https://github.com/benjamine/jsondiffpatch

https://github.com/google/diff-match-patch

https://github.com/JamesNK/Newtonsoft.Json

## Diff
Diff two json objects
```C#
  var jdp = new JsonDiffPatch();
  var left = JToken.Parse(@"{ ""key"": false }");
  var right = JToken.Parse(@"{ ""key"": true }");

  JToken patch = jdp.Diff(left, right);

  Console.WriteLine(patch.ToString());

  // Output:
  // {
  //     "key": [false, true]
  // }
```

## Patch
Patch a left object with a patch document
```C#
  var jdp = new JsonDiffPatch();
  var left = JToken.Parse(@"{ ""key"": false }");
  var right = JToken.Parse(@"{ ""key"": true }");
  JToken patch = jdp.Diff(left, right);

  var output = jdp.Patch(left, patch);

  Console.WriteLine(output.ToString());

  // Output:
  // {
  //     "key": true
  // }
```

## Unpatch
Unpatch a right object with a patch document
```C#
  var jdp = new JsonDiffPatch();
  var left = JToken.Parse(@"{ ""key"": false }");
  var right = JToken.Parse(@"{ ""key"": true }");
  JToken patch = jdp.Diff(left, right);

  var output = jdp.Unpatch(right, patch);

  Console.WriteLine(output.ToString());

  // Output:
  // {
  //     "key": false
  // }
```

## Sample
```c#
// See https://aka.ms/new-console-template for more information
using Microshaoft.Json;
using Newtonsoft.Json.Linq;

Console.WriteLine("Hello, World!");
var jdp = new JsonDiffPatch
                (
                    new Options
                        { 
                            ArrayDiff = ArrayDiffMode.Efficient
                        }
                );
var left = JToken.Parse (@"{""F1"": [1,2,{""p"":false},4]}");
left = JToken.Parse(@"{""F3"":1}");
var right = JToken.Parse(@"{""F2"": [1,2,{""p"":true},4]}");
var patch = jdp.Diff(left, right);
//patch = jdp.Diff(right, left);

if (patch != null)
{
    Console.WriteLine($"{nameof(left)} to {nameof(right)} {nameof(patch)}:\n{patch.ToString()}");
    var leftPatched = jdp.Patch(left, patch);
    if (leftPatched != null)
    {
        //Console.WriteLine($"{nameof(left)}:\n{left.ToString()}");
        Console.WriteLine($"{nameof(left)} {nameof(leftPatched)}:\n{leftPatched.ToString()}");
    }
    var rightPatched = jdp.Patch(right, patch);
    if (rightPatched != null)
    {
        //Console.WriteLine($"{nameof(left)}:\n{left.ToString()}");
        Console.WriteLine($"{nameof(right)} {nameof(rightPatched)}:\n{rightPatched.ToString()}");
    }
}
Console.ReadLine();
```
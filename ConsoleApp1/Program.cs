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

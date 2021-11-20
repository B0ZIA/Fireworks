using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeting : IGreeting
{
    private const string message = "Hello World";

    public string Message => message;
}

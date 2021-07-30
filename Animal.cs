using System;
class Animal{
    public int legs;
    public bool hasTail;
    public string call;

    public void MakeCall(){
        Console.WriteLine(call);
    }
}

class Dog : Animal{
    public Dog(){
        legs = 4;
        hasTail = true;
        call = "Woof Woof";
    }
}

class Bird : Animal{
    public Bird(){
        legs = 2;
        hasTail = false;
        call = "Kaw Kaw";
    }
}
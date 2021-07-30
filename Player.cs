using System;

namespace Chess{
public class Player{

    public Color color;
    public Move move;

    
    public enum Color{
        black,
        white, 
        neutral
    }

    public Player(Color color){
        this.color = color;
    }


    public Move ReadMove(){
        MoveEngine moveEngine;
        moveEngine = new MoveEngine(color);
        
        Move move = moveEngine.Move;
        

        
         return move;

    }

    public int GetColorCode(){
        if (color == Color.white){
            return 0;
        }
        else {
            return 1;
        }
    }

    

}
}
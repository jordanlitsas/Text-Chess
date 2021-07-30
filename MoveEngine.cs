using System;

namespace Chess{
public class MoveEngine{

    public Move Move {get; set;}
    private Player.Color color;

    public MoveEngine (Player.Color color){
        this.color = color;
        Move newMove = new Move();
        Move = newMove;

        ReadUserInput();

        

    }

    public void ReadUserInput(){
        Console.WriteLine(color + " - place a move: \n");


        string answer = Console.ReadLine();


        try {
            string fromCol = answer.Substring(0, 1);
            int fromRow = Int32.Parse(answer.Substring(1, 1));

            string toCol = answer.Substring(3,1);
            int toRow = Int32.Parse(answer.Substring(4, 1));
            TranslateMove(fromCol, fromRow, toCol, toRow);

        }
        catch {
            Console.WriteLine("Please enter your move with the required format outlined in the 'Instructions' menu option.");
        }




        


        

       

       
    }

    public void TranslateMove(string toConvertLetterFROM, int toConvertNumberFROM, string toConvertLetterTO, int toConvertNumberTO){

        switch (toConvertLetterFROM){
            case "a":
                Move.FromCol = 0;
                break;
            case "b":
                Move.FromCol = 1;
                break;
            case "c":
                Move.FromCol = 2;
                break;
            case "d":
                Move.FromCol = 3;
                break;
            case "e":
                Move.FromCol = 4;
                break;
            case "f":
                Move.FromCol = 5;
                break;
            case "g":
                Move.FromCol = 6;
                break;
            case "h":
                Move.FromCol = 7;
                break;
        }

        switch (toConvertLetterTO){
            case "a":
                Move.ToCol = 0;
                break;
            case "b":
                Move.ToCol = 1;
                break;
            case "c":
                Move.ToCol = 2;
                break;
            case "d":
                Move.ToCol = 3;
                break;
            case "e":
                Move.ToCol = 4;
                break;
            case "f":
                Move.ToCol = 5;
                break;
            case "g":
                Move.ToCol = 6;
                break;
            case "h":
                Move.ToCol = 7;
                break;
        }

        switch (toConvertNumberFROM){
            case 1: 
                Move.FromRow = 7;
                break;
            case 2: 
                Move.FromRow = 6;
                break;
            case 3: 
                Move.FromRow = 5;
                break;
            case 4: 
                Move.FromRow = 4;
                break;
            case 5: 
                Move.FromRow = 3;
                break;
            case 6: 
                Move.FromRow = 2;
                break;
            case 7: 
                Move.FromRow = 1;
                break;
            case 8: 
                Move.FromRow = 0;
                break;
            
        }
        switch (toConvertNumberTO){
            case 1: 
                Move.ToRow = 7;
                break;
            case 2: 
                Move.ToRow = 6;
                break;
            case 3: 
                Move.ToRow = 5;
                break;
            case 4: 
                Move.ToRow = 4;
                break;
            case 5: 
                Move.ToRow = 3;
                break;
            case 6: 
                Move.ToRow = 2;
                break;
            case 7: 
                Move.ToRow = 1;
                break;
            case 8: 
                Move.ToRow = 0;
                break;
            
        }


       
      

        }






    }
        
      
}

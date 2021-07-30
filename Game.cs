/*
    This class is responsible for maintaining the chess game. It supports user input and menu such as printing game rules, capturing which user is in check, and the general structure
    of the user menu where the player can interact with the game.
*/


using System;
using System.Collections.Generic;

namespace Chess{
    public class Game{

        //maintains the players
        public Player[] players = new Player[2];

        //maintains the board 
        public Board board;

        //Enumeration for menu options
        public MenuOption selection {get; set;}

        /*a collection of move objects. This supports counting points, undoing moves, presenting to the user how many moves have been played, quiting the game, 
        making a move, and printing instructions.*/
        public List<Move> moves = new List<Move>();
        
        //Determines who's move it is. If false, it is black's turn. 
        public bool whiteMove = true;

        //Used to receord which player is in check. If false - not in check.
        public bool whiteCheck {get; set;}
        public bool blackCheck {get; set;}



        //Initialises the board and players for a new game.
        public Game(){
            board = new Board();
            Player p1 = new Player(Player.Color.white);
            Player p2 = new Player(Player.Color.black);
            players[0] = p1;
            players[1] = p2;
        }
    



        //Holds the game loop: 
        public void Run(){

            //New game text.
            Console.WriteLine("\nWelcome to The World's Most Over-Complicated and Clunky Text-Based Chess Game!\n");

            //game loop
            do {

                //reprint board
                board.Refresh();

                //prompt/print user menu for player whose turn it is to select an option
                selection = ReadInput();

                //Do something depending on user's selection
                switch (selection){
                    
                    //If player decides to make a move. If statement within remains consistent between conditions, only changes per colour.
                    case MenuOption.MakeMove:

                    //When it's white's move 
                    if (whiteMove){
                        Move move = players[0].ReadMove();
                            
                        if (board.ExecuteMove(move, moves, "white", whiteCheck) ){
                            whiteMove = false;
                            moves.Add(move); 
                        }
                        try {
                            if (CheckMater.Run(board, Piece.Color.black).color == Piece.Color.white){
                                Console.WriteLine("Black is in check.");
                                blackCheck = true;
                            } 
                        }
                        catch{blackCheck = false;} 
                        
                    }

                        
                    

                   else if (!whiteMove){
                        Move move = players[1].ReadMove();
                            
                        if (board.ExecuteMove(move, moves, "black", blackCheck)){
                          whiteMove = true;
                          moves.Add(move);
                        }
                        try {
                            if (CheckMater.Run(board, Piece.Color.white).color == Piece.Color.black){
                                Console.WriteLine("White is in check.");
                                whiteCheck = true;
                            } 
                        }
                        catch{whiteCheck = false;} 
                      
                    }
                    

                   
                    break;




                    //need to reformat moves, best to send it somewhere else that returns printList.
                    case MenuOption.Instructions:
                        Console.WriteLine("\nMAKING A MOVE: \nIf it is your turn, enter 1. You can tell who's move it is by looking at menu option one '[1] Make Move --- color'\nNext, type in the coordinates of the piece you want to move, followed by a space, followed by the coordinates of the location that piece will move to.\nFor example, 'a2 a4' will move whatever is on a2 to a4, if it's a legal move.\n");
                        Console.WriteLine("CHECK AND CHECKMATE: \nThe game will tell you when you are in check, and will stop you from making a move that leaves you in check. \nHowever, you will need to determine when you or your opponent is in checkmate.");
                
                        break;

                    case MenuOption.Quit:
                        if (whiteMove){
                            Console.WriteLine("\nCongratulations Black\nThank you for playing");
                        }
                        else {
                            Console.WriteLine("\nCongratulations White\nThank you for playing");

                        }
                        break;
                }
            }

            while (selection != MenuOption.Quit);

        }

        public MenuOption ReadInput(){
            int option;
            if (whiteMove){
                Console.WriteLine("\n\n[1] Make Move --- White\n[2] Instructions\n[3] Quit\n\n");
            }
            else {
                Console.WriteLine("\n\n[1] Make Move --- Black\n[2] Instructions    \n[3] Quit\n\n");
            }
           

            do
                {
                    Console.WriteLine("\nChoose an option [1-3]: ");

                        try {
                            option = Convert.ToInt32(Console.ReadLine());
                        }

                        catch{
                            Console.WriteLine("Your answer must be a digit.");
                            option = -1;
                        }
                }
                while (option > 3 || option < 1 );

            return (MenuOption)(option-1);
            
        }
        

        public enum MenuOption{
            MakeMove,
            Instructions,
            Quit
        }
    }

}
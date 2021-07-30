using System;
using System.Collections.Generic;



namespace Chess
{

public class Board{

    public Location[,] locations = new Location[8, 8];
   

    public Board(){
        LoadResources();
        


    }

    public void Refresh(){
       
        int rowlength = locations.GetLength(0);
        int colLength = locations.GetLength(1);
        Console.WriteLine("\n");

        Console.WriteLine("    ___        ___        ___        ___        ___        ___        ___        ___");
        Console.WriteLine("    ___        ___        ___        ___        ___        ___        ___        ___");
        Console.WriteLine("\n");
            int label = 8;

        for (int i = 0; i < rowlength; i++){
            Console.Write(label);
            label--;

            for (int j = 0; j < colLength; j++){
                Console.Write(string.Format("{0} ", locations[i, j].piece.Symbol));
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
            Console.WriteLine("     ___        ___        ___        ___        ___        ___        ___        ___");
            Console.WriteLine("     ___        ___        ___        ___        ___        ___        ___        ___");
            Console.WriteLine("      A          B          C          D          E          F          G          H");

    }

    public void LoadLocations(){
        for(int row = 0; row < locations.GetLength(0); row++){
            for(int col = 0; col < locations.GetLength(1); col++){
                Location newLocation = new Location(row, col);
                locations[row, col] =  newLocation;
            }
        }



        
    }

    

    public void LoadPieces(){
        
     
        
        int i = 0;


    // BLACK - 0, 1
    // WHITE - 6, 7
        while (i <8){

            //white first

            
             //blank
            locations[2, i].piece = new Piece();
            locations[3, i].piece = new Piece();
            locations[4, i].piece = new Piece();
            locations[5, i].piece = new Piece();

            //pawns
            locations[1, i].piece = new Pawn(Piece.Color.black);
            locations[6, i].piece = new Pawn(Piece.Color.white);

            i++;
            
        } 
        




        

        //rook
        locations[0,0].piece = new Rook(Piece.Color.black);
        locations[0,7].piece = new Rook(Piece.Color.black);
        locations[7,0].piece = new Rook(Piece.Color.white);
        locations[7,7].piece = new Rook(Piece.Color.white);


        //knight
        locations[0,1].piece = new Knight(Piece.Color.black);
        locations[0,6].piece = new Knight(Piece.Color.black);
        locations[7, 1].piece = new Knight (Piece.Color.white);
        locations[7, 6].piece = new Knight (Piece.Color.white);

        //bishop
        locations[0, 2].piece = new Bishop(Piece.Color.black);
        locations[0, 5].piece = new Bishop(Piece.Color.black);
        locations[7, 2].piece = new Bishop(Piece.Color.white);
        locations[7, 5].piece = new Bishop(Piece.Color.white);

        //royals
       locations[7, 3].piece = new Queen (Piece.Color.white); 
        locations[7, 4].piece = new King (Piece.Color.white);
        locations[0, 3].piece = new Queen(Piece.Color.black);
       locations[0, 4].piece = new King(Piece.Color.black);



 

        }

    public void LoadResources(){
        LoadLocations();
         LoadPieces();
        
    }

    
   
    public bool ExecuteMove(Move move, List <Move> moves, String color, bool check){
        
        RuleBook rb = new RuleBook(move, locations, moves);
        if(locations[move.FromRow, move.FromCol].piece.color.ToString() != color){
            return false;
        }

        //see if move ie legal
        if (rb.ScanBook()){            
            Piece pieceToRemove = new Piece();
            int movesTaken = locations[move.FromRow, move.ToRow].piece.MoveCounter;
            Piece pieceToMove = locations[move.FromRow, move.FromCol].piece;
              
            
            pieceToRemove = locations[move.ToRow, move.ToCol].piece;
            locations[move.ToRow, move.ToCol].piece = pieceToMove;
            locations[move.FromRow, move.FromCol].piece = new Piece();
            
            //handle for castling
            if (rb.isCastle){
              if (rb.castleCondition){
                  switch (pieceToMove.color){
                  case Piece.Color.white:
                      if (rb.isLeftMove(move)){
                        locations[7, 3 ].piece = pieceToRemove;
                        locations[7, 2].piece = pieceToMove;
                      }
                      else if (rb.isRightMove(move)){
                         locations[7, 5 ].piece = pieceToRemove;
                         locations[7, 6].piece = pieceToMove;

                      }
                      break;

                    case Piece.Color.black:
                    if (rb.isLeftMove(move)){
                        locations[0, 3].piece = pieceToRemove;
                        locations[0, 2].piece = pieceToMove;
                    }

                    if (rb.isRightMove(move)){
                        locations[0, 5].piece = pieceToRemove;
                        locations[0, 6].piece = pieceToMove;
                    }
                    break;
                  }
                    
                }
                locations[move.ToRow, move.ToCol].piece = new Piece();

            }

            movesTaken++;
            pieceToMove.MoveCounter = movesTaken;

            //implements events like converting a pawn
            if (rb.ScanUniqueMove()){
                locations[move.ToRow, move.ToCol].piece = rb.GetUniquePiece();
                 
            }
            
            
            if (check){
                Piece threateningPiece = CheckMater.Run(this, pieceToMove.color);
                if (threateningPiece != null){
                    Console.WriteLine("You cannot make that move, your king is still threatened by a " + threateningPiece.color + " " + threateningPiece.type + ".");
                    locations[move.FromRow, move.FromCol].piece = pieceToMove;
                    locations[move.ToRow, move.ToCol].piece = pieceToRemove;
                    return false;
                 }
            }
            else if (!check){
                Piece threateningPiece = CheckMater.Run(this, pieceToMove.color);
                if (threateningPiece != null){
                    Console.WriteLine("You cannot make that move, your king would be in check.");
                    locations[move.FromRow, move.FromCol].piece = pieceToMove;
                    locations[move.ToRow, move.ToCol].piece = pieceToRemove;
                    return false;
                }
            }

            return true;
        }

        return false;
     
      
    }

}

}